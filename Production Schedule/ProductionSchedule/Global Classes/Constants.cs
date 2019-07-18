using System;
using System.Collections.Generic;

namespace ProductionSchedule.Globals
{
    /*
     * A collection of constant values to be used throughout the project.
     */
    /// <summary>
    /// Constant values to be used in the Production Schedule project.
    /// </summary>
    public static class Constants
    {
        /// <value>The User Initials to be entered into the BusinessVision database.</value>
        public static String BVUSER = "PSD";

        /// <value>The version number to be entered into BusinessVision database.</value>
        public static Double BVVERSION = 7.92;

        /// <value>The date format used in BusinessVision database records.</value>
        public static String BVDATEFORMAT = "yyyyMMdd";

        /// <value>The time format used in BusinessVision database records.</value>
        public static string BVTIMESTAMPFORMAT = "hmsfff";

        // Connection string to PSQL database.
        ///<summary>
        ///Takes the ODBC Name of the database and returns a connection string to
        ///connect to that database.
        ///</summary>
        /// <param name="OdbcName">The name of an ODBC database.</param>
        public static String GETODBCCONNECTIONSTRING(string OdbcName)
        {
            var connection = $"Dsn={OdbcName};arrayfetchon=1;arraybuffersize=8;dbq={OdbcName};openmode=0;clientversion=10.30.017.000;codepageconvert=1252;pvclientencoding=CP1252;pvserverencoding=CP1252";
            return connection;
        }

        // A structure to build a Company selection list - for login.
        /// <summary>
        /// Holds information for a company selection list.
        /// </summary>
        /// <param name="OdbcName">The name of an ODBC database.</param>
        /// <param name="CompanyName">The business vision company name, meant for display.</param>
        public struct CompanyList
        {
            public string OdbcName { get; }
            public string CompanyName { get; }

            public CompanyList(string odbcName, string companyName)
            {
                OdbcName = odbcName;
                CompanyName = companyName;
            }
        }

        // Add BV companies for the login company selection screen here.
        /// <summary>
        /// The Company Selection list at login.
        /// </summary>
        public static List<CompanyList> COMPANIES = new List<CompanyList>()
        {
            //Adds companies to the login screen
            new CompanyList("ABCDEMO", "ABC Electronic Components Inc."),
            new CompanyList("BPI2017", "BPI Business Programs (2017) Inc.")
        };

        /// <summary>
        /// The product type list, meant for a combo box
        /// </summary>
        public static List<string> PRODUCT_TYPE_LIST = new List<string>() { "In Process", "Finished Goods" };

        /// <summary>
        /// The status list, meant for a combo box.
        /// </summary>
        public static List<String> STATUS_LIST = new List<string>() { "Okay", "Issued", "UnIssued", "Cancelled", "Completed" };
    }

}
