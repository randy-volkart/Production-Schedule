using System;
using System.Security.Cryptography;
using System.Data.Odbc;

namespace ProductionSchedule.Classes
{
    using Globals;

    /*
     * Facilitates loging into the program.      
     */
    /// <summary>
    /// An object that creates an active connection to an ODBC database 
    /// and manages a user login table using PBKDF2 encryption.
    /// </summary>
    sealed class Login
    {
        private OdbcConnection Odbc { get; }

        /// <value>The ODBC database name.</value>
        private string Company { get; }
        /// <value>A username.</value>
        private string Username { get; }
        /// <value>A password.</value>
        private string Password { get; }

        // Static values for the ODBC database.
        private static string UserTable = "PS_USER";
        private static string UserColumn = "username";
        private static string PasswordColumn = "userpassword";
        private static string PermissionColumn = "permissions";

        private static int HashIterations = 10000;
        
        /// <summary>
        /// Connects to an ODBC database and stores the username and pasword to be processed.
        /// </summary>
        /// <param name="company">The ODBC DB name to connect to.</param>
        /// <param name="username">Provide a username.</param>
        /// <param name="password">Provide a password.</param>
        public Login(string company, string username, string password)
        {
            Company = company;
            Username = username;
            Password = password;

            try
            {
                Odbc = new OdbcConnection(Constants.GETODBCCONNECTIONSTRING(Company));
                Odbc.Open();
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
        }

        /// <summary>
        /// Call this function to test if the <see cref="Login.Username"/> and 
        /// <see cref="Login.Password"/> provided to the object matches the username and 
        /// password in the ODBC database specified by <see cref="Login.Company"/>. 
        /// </summary>
        /// <returns>Returns -1 if login validation fails, or the permission level of the user
        /// (should be 1-9) if it passes.</returns>
        public int Validate()
        {
            int permission = -1;

            OdbcCommand cmdSelectLogin = new OdbcCommand();
            string query = $"SELECT {UserColumn},{PasswordColumn},{PermissionColumn} from {UserTable} WHERE {UserColumn} = ?" ;

            try
            {
                cmdSelectLogin = this.Odbc.CreateCommand();
                cmdSelectLogin.CommandText = query;
                cmdSelectLogin.Parameters.Add(UserColumn, OdbcType.Text).Value = this.Username;

                OdbcDataReader reader = cmdSelectLogin.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    //get the saved password salt/hash
                    string savedPasswordHash = reader.GetString(1);

                    //turn it into bytes
                    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

                    //take the salt out of the string
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);

                    //hash the user inputted password with the salt
                    var pbkdf2 = new Rfc2898DeriveBytes(this.Password, salt, HashIterations);

                    //put hashed input into an array for comparison
                    byte[] hash = pbkdf2.GetBytes(20);


                    //compare result byte by byte
                    Boolean result = true;
                    for (int i = 0; i < 20; i++)
                    {
                        if (hashBytes[i + 16] != hash[i])
                            result = false;
                    }

                    if(result)
                    {
                        permission = reader.GetInt16(2);
                    }
                }
            }
            catch (OdbcException odbce)
            {
                Utilities.ShowError(odbce.Message, odbce.ToString());
            }
            catch (Exception e)
            {
                Utilities.ShowError(e.Message, e.ToString());
            }

            return permission;
        }

        /// <summary>
        /// Creates a new user in the <see cref="Login.Company"/> database using 
        /// <see cref="Login.Username"/> and <see cref="Login.Password"/>.
        /// </summary>
        /// <returns>Returns true if user creation succeeds, false if not.</returns>
        public Boolean CreateUser()
        {
            string savedPasswordHash = GetPasswordHash();

            Boolean result = false;

            OdbcCommand cmdAddUser = new OdbcCommand();
            string query =  $@"INSERT INTO PS_USER 
                                ({UserColumn},{PasswordColumn},{PermissionColumn})
                            VALUES 
                                (?, ?, ?)";

            try
            {
                cmdAddUser = this.Odbc.CreateCommand();
                cmdAddUser.CommandText = query;
                cmdAddUser.Parameters.Add(UserColumn, OdbcType.Text).Value = this.Username;
                cmdAddUser.Parameters.Add(PasswordColumn, OdbcType.Text).Value = savedPasswordHash;
                cmdAddUser.Parameters.Add(PermissionColumn, OdbcType.Int).Value = 1;

                int insert = cmdAddUser.ExecuteNonQuery();

                if (insert > 0)
                    result = true;
            }
            catch (OdbcException odbce)
            {
                Utilities.ShowError(odbce.Message, odbce.ToString());
            }
            catch (Exception e)
            {
                Utilities.ShowError(e.Message, e.ToString());
            }

            return result;
        }

        // Creates a hash with Password using PBKDF2 encryption. 
        private string GetPasswordHash()
        {
            string savedPasswordHash = "";
            byte[] salt;

            //generate salt
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //hash and salt it using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, HashIterations);

            //hash is 20 bytes, salt 16 bytes

            //place the string in the byte array
            byte[] hash = pbkdf2.GetBytes(20);

            //New byte array to store the hashed password+saLT, 20 for has and 16 for salt
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //convert byte array to string
            savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }
    }
    
}
