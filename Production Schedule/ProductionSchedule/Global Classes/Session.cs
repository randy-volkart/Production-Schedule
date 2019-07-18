using System;

namespace ProductionSchedule.Globals
{
    /*
     * Class holds information set at login time to be used through the program.
     */
    /// <summary>
    /// Holds values set at login to be used during a users session.
    /// </summary>
    public sealed class Session
    {

        // The login User Name.
        /// <value>Set to the login username.</value>
        public string User { get; }

        // The datetime stamp at login.
        /// <value>Set to the current date at login.</value>
        public DateTime SessionDate { get; }

        // The login users permission level.
        /// <value>Set to the login users permission level.</value>
        public int Level { get; }

        // The company name for display.
        /// <value>Set to the company display name.</value>
        public string CompanyName { get; }

        // The company ODBC name. Combined with Constants.GETODBCCONNECTIONSTRING(string OdbcName) to connect 
        // to the SQL database.
        /// <value>Set to the Company ODBC name</value> 
        public string CompanyODBC { get; } //ODBC connection name

        public Session(string user, DateTime sessiondate, int level, string companyName, string companyODBC)
        {
            User = user;
            SessionDate = sessiondate;
            Level = level;
            CompanyName = companyName;
            CompanyODBC = companyODBC;
        }
    }
}
