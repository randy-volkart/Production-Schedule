using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace ProductionSchedule.Classes
{
    using Globals;

    /// <summary>
    /// A Struct to hold fields necessary for Finished Goods reports.
    /// </summary>
    public struct FinishedGoodsData
    {
        /// <value>The BusinessVision warehouse.</value>
        public string Whse { get; }

        /// <value>The BusinessVision warehouse description.</value>
        public string WhseDesc { get; }

        /// <value>The BusinessVision Product Code, a grouping code 
        /// not to be confused with Item Code.</value>
        public string ProductCode { get; }

        /// <value>The BusinessVision Item Code.</value>
        public string ItemCode { get; }

        /// <value>The BusinessVision Item Description.</value>
        public string ItemDesc { get; }

        ///// <value>The BusinessVision Item Re-order point.</value>
        public decimal ReOrderPoint { get; }

        public FinishedGoodsData(string whse, string whseDesc, string productCode, string itemCode, string itemDesc, decimal reOrderPoint)
        {
            Whse = whse;
            WhseDesc = whseDesc;
            ProductCode = productCode;
            ItemCode = itemCode;
            ItemDesc = itemDesc;
            ReOrderPoint = reOrderPoint;
        }
    }

    /// <summary>
    /// The Report class manages ODBC data processing related to reports. Pulls data from both 
    /// BusinessVision and Production Schedule, which exist in the same database marked by the
    /// BV Company name. 
    /// </summary>
    class Report
    {

        /// <value>The ODBC database name.</value>
        private string Company;

        // For future implementation...
        //private static string QryWorkOrderSum;
        //private static string QryRequiredQuantitySum;
        //private static string QryOnhandCount;

        /// <param name="company">The ODBC database name for the BusinessVision company.</param>
        public Report(string company)
        {
            Company = company;
        }

        #region Functions to get parameter values for the form

        /// <summary>
        /// Get the BusinessVision warehouse list for use in report parameter selection
        /// </summary>
        /// <returns>A list of BusinessVision warehouses</returns>
        public List<string> GetWarehousesList()
        {
            List<string> warehouses = new List<string>();
            OdbcConnection odbc = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();

            var qryWhse = "SELECT rtrim(WHSE_KEY) as WHSE_KEY FROM WAREHOUSE;";

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                cmd = odbc.CreateCommand();
                cmd.CommandText = qryWhse;

                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    warehouses.Add(reader.GetString(0));
                }                
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
                odbc.Close();
            }

            //Some companies may not have multi-warehousing turned on in BV, so will not have a warehouse field
            if (warehouses.Count == 0)
                warehouses.Add("");

            return warehouses;
        }

        /// <summary>
        /// Get the BusinessVision product code list for use in report parameter selection.
        /// </summary>
        /// <returns>A list of BusinessVision warehouses</returns>
        /// <remarks>Do not confuse the BusinessVision Product Code with Item Code. Item codeis the 
        /// individual inventory item, product code is an optional higher level grouping for item codes.</remarks>
        public List<string> GetProductsList()
        {
            List<string> productCodes = new List<string>();
            //start with a blank to represent all
            productCodes.Add("");

            OdbcConnection odbc = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();

            string qryWhse = "SELECT rtrim(CODE) as CODE FROM PRODUCT_CODE;";

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                cmd = odbc.CreateCommand();
                cmd.CommandText = qryWhse;

                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productCodes.Add(reader.GetString(0));
                }
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
                odbc.Close();
            }

            return productCodes;
        }

        /// <summary>
        /// Get the BusinessVision item list for use in report parameter selection.
        /// </summary>
        /// <param name="warehouse">Parameter for BusinessVision warehouse. Blank value selects all.</param>
        /// <param name="productCode">Parameter for BusinessVision Product Code.</param>
        /// <returns>A list of BusinessVision warehouses</returns>
        /// <remarks>Do not confuse the BusinessVision Product Code with Item Code. Item codeis the 
        /// individual inventory item, product code is an optional higher level grouping for item codes.</remarks>
        public List<string> GetItemsList(string warehouse, string productCode)
        {
            List<string> items = new List<string>();

            items.Add("");

            OdbcConnection odbc = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();

            string qryWhse = "SELECT rtrim(CODE) as CODE FROM INVENTORY WHERE TYPE_KEY = 'M' AND HOLD=0 ";

            if (warehouse != "")
                qryWhse += " AND WHSE = ? ";
            if (productCode != "")
                qryWhse += " AND PROD = ?";

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                cmd = odbc.CreateCommand();
                cmd.CommandText = qryWhse;

                if(warehouse != "")
                    cmd.Parameters.Add("WHSE", OdbcType.Text).Value = warehouse;
                if (productCode != "")
                    cmd.Parameters.Add("PROD", OdbcType.Text).Value = productCode;

                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(reader.GetString(0));
                }
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
                odbc.Close();
            }

            return items;
        }

        #endregion

        #region Finished Goods Daily Stock Status report section

        /// <summary>
        /// Selects and returns the data for the Finished Goods Daily Stock Status report.
        /// </summary>
        /// <param name="startDate">Parameter to set a starting point for the report</param>
        /// <param name="days">Parameter for number od days to run the report. To match the associated
        /// Crystal report should be hardcoded to 14 or 28. </param>
        /// <returns>DataTable containing results of the finished goods daily stock status selection query</returns>
        /// <remarks>The associated Crystal Report is configured to either 14 or 28 days.</remarks>
        public DataTable RunFinishedGoodsDailyStockStatusReport(DateTime startDate, int days)
        {
            OdbcConnection odbc = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();
            DataTable table = new DataTable();

            var qryFG = @"SELECT * FROM PS_TEMPFGREPORTDATA;";

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                cmd = odbc.CreateCommand();
                cmd.CommandText = qryFG;

                OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
                odbc.Close();
            }

            return table;
        }

        /// <summary>
        /// Prepares the Finished Goods Daily Stock Status report which looks at every work order provided in 
        /// parameterfgData and compiles a count of the inventory, work order, and re-order numbers on each calendar
        /// day according to the days parameter."/> 
        /// </summary>
        /// <param name="fgData">A list of <see cref="FinishedGoodsData" /> to be processed for the report</param>
        /// <param name="days">The number of days to print on the report.</param>
        /// <remarks>Regarding the days input, the current crystal report is hardcoded for either 14 or 28 days.</remarks>
        public void PrepareFGReport(List<FinishedGoodsData> fgData, int days)
        {
            var hCount = fgData.Count;
            var woPrior = 0M;
            var coPrior = 0M;

            ClearTempFGReportData();

            OdbcConnection odbc = new OdbcConnection();

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                for (int h = 0; h < hCount; h++)
                {
                    //InsertTempFGData(fgData[h].Whse, fgData[h].WhseDesc, fgData[h].ProductCode,
                    //  fgData[h].ItemCode, fgData[h].ItemDesc, fgData[h].ReOrderPoint);
                    DateTime plannedDate = new DateTime(2019, 5, 30);//DateTime.Now;
                    decimal[,] counts = new decimal[days, 3];
                    var inv = 0M;

                    for (int d = 0; d < days; d++)
                    {
                        var wo = 0M;
                        var co = 0M;

                        //The required work order (from Production Schedule) count on the given day
                        wo = GetWorkOrderCount(ref odbc, fgData[h].Whse, fgData[h].ItemCode, plannedDate, d);
                        //The required sales order (from BusinessVision)count on the given day
                        co = GetSalesOrderCount(ref odbc, fgData[h].Whse, fgData[h].ItemCode, plannedDate, d);
                        //invert sign for report
                        co *= (-1);

                        if (d == 0)
                            //The items onhand count from BV
                            inv = GetInvCount(ref odbc, fgData[h].Whse, fgData[h].ItemCode);
                        else
                            //add the prior wo and co counts into inv
                            inv += woPrior + coPrior;

                        plannedDate = plannedDate.AddDays(1);

                        counts[d, 0] = inv;
                        counts[d, 1] = co;
                        counts[d, 2] = wo;

                        woPrior = wo;
                        coPrior = co;
                    }

                    InsertTempFGDataLine(ref odbc, fgData[h].Whse, fgData[h].WhseDesc, fgData[h].ProductCode,
                      fgData[h].ItemCode, fgData[h].ItemDesc, fgData[h].ReOrderPoint, days, counts);
                }

            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                odbc.Close();
            }
        }

        // The Finished Goods report uses a temporary table, this function should be run first
        // to clear it.
        private void ClearTempFGReportData()
        {
            OdbcConnection odbc = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();

            var qryDeleteTempData = "DELETE FROM PS_TEMPFGREPORTDATA;";

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                cmd = odbc.CreateCommand();
                cmd.CommandText = qryDeleteTempData;

                //cmd.Parameters.Add("WorkOrderNo", OdbcType.Int).Value = workOrderNo;
                cmd.ExecuteNonQuery();
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
                odbc.Close();
            }
        }

        // Fills one line of the temporary table to be used with the Finished Goods report. 
        // For every day 1-14 or 1-28 three values need to be calculated:
        // I - Inventory count
        // C - Sales order count 
        // W - Work order count
        // (note: need to double check these definitions)
        private void InsertTempFGDataLine(ref OdbcConnection odbc, string whse, string whseDesc, string prod, 
            string item, string itemDesc, decimal rop, int days, decimal[,] counts)
        {
            OdbcCommand cmd = new OdbcCommand();

            var qryInsertTempData = "";
            var qryHdr = "INSERT INTO PS_TEMPFGREPORTDATA ";
            var qryCol = "(Whse, WhseName, ProductCode, ItemCode, ItemDescription, ReOrderPoint, ";
            var qryVal = ") VALUES ( ?, ?, ?, ? ,?, ?, ";

            // The right end of qryCol and qryVal is iterative and depends on the int value of days.
            for(int i = 1; i <= days; i++)
            {
                if (i != days)
                {
                    qryCol += " I" + i.ToString("D2") + ", C" + i.ToString("D2") + ", W" + i.ToString("D2") + ", ";
                    qryVal += "?, ?, ?, ";
                }
                // Last iteration needs to remove the last comma from the string. 
                else
                {
                    qryCol += " I" + i.ToString("D2") + ", C" + i.ToString("D2") + ", W" + i.ToString("D2");
                    qryVal += " ?, ?, ? ";
                }
            }

            // Combine the pieces of the insert query to finalize it.
            qryInsertTempData = $"{qryHdr}{qryCol}{qryVal});";

            try
            {
                cmd = odbc.CreateCommand();
                cmd.CommandText = qryInsertTempData;

                cmd.Parameters.Add("Whse", OdbcType.Text).Value = whse;
                cmd.Parameters.Add("WhseName", OdbcType.Text).Value = whseDesc;
                cmd.Parameters.Add("ProductCode", OdbcType.Text).Value = prod;
                cmd.Parameters.Add("ItemCode", OdbcType.Text).Value = item;
                cmd.Parameters.Add("ItemDescription", OdbcType.Text).Value = itemDesc;
                cmd.Parameters.Add("ReOrderPoint", OdbcType.Decimal).Value = rop;

                // Bind parameters based on the number of days.
                for (int i = 1; i <= days; i++)
                {
                    string iParam = "I" + i.ToString("D2");
                    string cParam = "C" + i.ToString("D2");
                    string wParam = "W" + i.ToString("D2");

                    cmd.Parameters.Add(iParam, OdbcType.Decimal).Value = counts[i - 1, 0];
                    cmd.Parameters.Add(cParam, OdbcType.Decimal).Value = counts[i - 1, 1];
                    cmd.Parameters.Add(wParam, OdbcType.Decimal).Value = counts[i - 1, 2];
                }

                cmd.ExecuteNonQuery();
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        // Get the sum total of the work order Planned Quantity amount for a specific inventory item
        // on a specific day. For the first day of the iteration take all amounts on and before that day.
        private decimal GetWorkOrderCount(ref OdbcConnection odbc, string whse, string itemCode, 
            DateTime plannedDate, int iterator)
        {
            OdbcCommand cmd = new OdbcCommand();

            var sqlFormattedDate = plannedDate.ToString("yyyy-MM-dd");
            var wo = 0M;

            var qrySelectWorkOrderCount = @"
                SELECT 
                    Sum(PlannedQuantity) as SumPQ 
                FROM 
                    PS_WORKORDERS
                WHERE 
                    ProductionType = 'Finished Goods' AND
                    Status = 'Completed' AND
                    ProductWarehouse = ? AND
                    ProductNumber = ? AND 
            ";
            
            // If the planned date is the first date in an iterator include all dates before it.
            if (iterator == 0)
                qrySelectWorkOrderCount += " PlannedDate <= ?";
            else
                qrySelectWorkOrderCount += " PlannedDate = ?";

            try
            {
                cmd = odbc.CreateCommand();
                cmd.CommandText = qrySelectWorkOrderCount;

                cmd.Parameters.Add("ProductWarehouse", OdbcType.Text).Value = whse;
                cmd.Parameters.Add("ProductNumber", OdbcType.Text).Value = itemCode;
                cmd.Parameters.AddWithValue("PlannedDate", sqlFormattedDate);

                OdbcDataReader reader = cmd.ExecuteReader();
                reader.Read();

                var value = reader.GetValue(0);
                if (value is IConvertible && value.ToString() != "")
                    wo = ((IConvertible)value).ToDecimal(null);

            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
            }

            return wo;
        }

        // Get the sum total of the business vision sales order amount for a specific inventory item
        // on a specific day. For the first day of the iteration take all amounts on and before that day.
        private decimal GetSalesOrderCount(ref OdbcConnection odbc, string whse, string itemCode, 
            DateTime plannedDate, int iterator)
        {
            OdbcCommand cmd = new OdbcCommand();

            var co = 0M;
            var qrySelectOrderCount = @"
                    SELECT 
                        sum(d.BVORDQTY) as SumBVOrdQty 
                    FROM 
                        SALES_ORDER_DETAIL d LEFT JOIN 
                        SALES_ORDER_HEADER h ON
                            h.NUMBER = d.NUMBER
                    WHERE
                        d.WHSE = ? AND
                        d.CODE = ? AND
            ";

            // If the order/required date is the first date in an iterator include all dates before it.
            if (iterator == 0)
                qrySelectOrderCount += "  h.ORD_DATE <= ? ";
            else
                qrySelectOrderCount += "  h.ORD_DATE = ? ";

            try { 
                cmd = odbc.CreateCommand();

                /* !!! Check if we want to use Order Date or Required Date. In BV Order date is always filled out but
                 * Required date is optional and usually blank. */
                cmd.CommandText = qrySelectOrderCount;

                cmd.Parameters.Add("WHSE", OdbcType.Text).Value = whse;
                cmd.Parameters.Add("CODE", OdbcType.Text).Value = itemCode;
                cmd.Parameters.Add("ORD_DATE", OdbcType.Date).Value = plannedDate;

                OdbcDataReader reader = cmd.ExecuteReader();
                reader.Read();

                var value = reader.GetValue(0);
                if (value is IConvertible && value.ToString() != "")
                    co = ((IConvertible)value).ToDecimal(null);

            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
            }

            return co;
        }

        // Get the sum total of the business vision inventory onhand amount for a specific inventory item.
        // No specific date required here as the original number will be used once then added to or subtracted
        // from depending on work order and sales order amounts. 
        private decimal GetInvCount(ref OdbcConnection odbc, string whse, string itemCode)
        {
            OdbcCommand cmd = new OdbcCommand();

            var inv = 0M;
            var qrySelectOnHandAmount = @"
                    SELECT 
                        ONHAND 
                    FROM 
                        INVENTORY 
                    WHERE
                        WHSE = ? AND
                        CODE = ?
                ";

            try { 
                cmd = odbc.CreateCommand();
                cmd.CommandText = qrySelectOnHandAmount;

                cmd.Parameters.Add("WHSE", OdbcType.Text).Value = whse;
                cmd.Parameters.Add("CODE", OdbcType.Text).Value = itemCode;

                OdbcDataReader reader = cmd.ExecuteReader();
                reader.Read();

                inv = reader.GetDecimal(0);
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
            }

            return inv;
        }
        #endregion

        #region Production Schedule Report

        /// <summary>
        /// Selects and returns the data for the Production Schedule report.
        /// </summary>
        /// <param name="workOrderType">Selection parameter for the type of work order: In Process, Finished Goods.</param>
        /// <param name="workOrderStatus">Selection parameter for the work order status: Okay, In Process, Completed, etc.</param>
        /// <param name="fromDate">range selection parameter for the beginning date of the ActualDate field</param>
        /// <param name="toDate">range selection parameter for the end date of the ActualDate field</param>
        /// <returns>DataTable containing results of the work order selection query</returns>
        public DataTable RunProductionScheduleReport(string workOrderType, string workOrderStatus,
            DateTime fromDate, DateTime toDate)
        {
            var useType = false;
            var useStatus = false;

            if (workOrderType == Constants.PRODUCT_TYPE_LIST[0]) //"All"
                useType = false;
            else
                useType = true;

            if (workOrderStatus == Constants.PRODUCT_TYPE_LIST[0]) //"All"
                useStatus = false;
            else
                useStatus = true;

            string qryPS = @"SELECT * 
                FROM PS_WORKORDERS WHERE 
                ActualDate BETWEEN ? AND ? ";

            // Skip if workOrderType = "All".
            if (useType)
                qryPS += "AND ProductionType = ? ";

            // Skip if workOrderStatus = "All".
            if (useStatus)
                qryPS += "AND Status = ? ";

            OdbcConnection odbc = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();
            DataTable table = new DataTable();

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                cmd = odbc.CreateCommand();
                cmd.CommandText = qryPS;

                cmd.Parameters.Add("@ActualDate", OdbcType.Date).Value = fromDate;
                cmd.Parameters.Add("@ActualDate", OdbcType.Date).Value = toDate;

                // Skip if workOrderType = "All".
                if (useType)
                    cmd.Parameters.Add("@ProductionType", OdbcType.Text).Value = workOrderType;

                // Skip if workOrderStatus = "All".
                if (useStatus)
                    cmd.Parameters.Add("@Status", OdbcType.Text).Value = workOrderStatus;

                OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
                odbc.Close();
            }

            return table;
        }

        #endregion

        #region Daily Product List Report

        /// <summary>
        /// Selects and returns the data for the Daily Product List report.
        /// </summary>
        /// <param name="warehouse">Parameter for BusinessVision warehouse. Blank value selects all.</param>
        /// <param name="productCode">Parameter for BusinessVision Product Code.</param>
        /// <param name="itemCode">Parameter for BusinessVision Item Code. Blank value selects all.</param>
        /// <returns>DataTable containing results of the daily product list selection query</returns>
        /// <remarks>Do not confuse the BusinessVision Product Code with Item Code. Item codeis the 
        /// individual inventory item, product code is an optional higher level grouping for item codes.</remarks>
        public DataTable GetDailyProductListReport(string warehouse, string productCode, string itemCode)
        {
            DataTable bomsTable = new DataTable();
            OdbcConnection odbc = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();

            // TYPE_KEY 'M' = Manufactured and Kitted items, both of which count as bill of material items.
            var qryBOMs = @"
                SELECT DISTINCT 
                    RTrim(INVENTORY.CODE) as CODE, RTrim(INVENTORY.INV_DESCRIPTION) as INV_DESCRIPTION, 
                    RTrim(INVENTORY.PROD) as PROD, RTrim(INVENTORY.WHSE) as WHSE, 
                    RTrim(WAREHOUSE.WHSE_DESCRIPTION) as WHSE_DESCRIPTION, 
                    RTrim(PRODUCT_CODE.PRD_DESC) as PRD_DESC, INVENTORY.ROP
                FROM 
                    (INVENTORY INNER JOIN WAREHOUSE ON INVENTORY.WHSE = WAREHOUSE.WHSE_KEY) 
                    INNER JOIN PRODUCT_CODE ON INVENTORY.PROD = PRODUCT_CODE.CODE
                WHERE 
                    INVENTORY.TYPE_KEY = 'M' AND INVENTORY.HOLD=0 
            ";

            // Add parameters as necessary
            if (warehouse != "")
                qryBOMs += " AND INVENTORY.WHSE = ? ";
            if (productCode != "")
                qryBOMs += " AND INVENTORY.PROD = ? ";
            if (itemCode != "")
                qryBOMs += " AND INVENTORY.CODE = ?";
            qryBOMs += "ORDER BY INVENTORY.CODE; ";

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                cmd = odbc.CreateCommand();
                cmd.CommandText = qryBOMs;
                if (warehouse != "")
                    cmd.Parameters.Add("WHSE", OdbcType.Text).Value = warehouse;
                if (productCode != "")
                    cmd.Parameters.Add("PROD", OdbcType.Text).Value = productCode;
                if (itemCode != "")
                    cmd.Parameters.Add("CODE", OdbcType.Text).Value = itemCode;

                OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                adapter.Fill(bomsTable);
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
            finally
            {
                cmd.Dispose();
                odbc.Close();
            }

            return bomsTable;
        }

        #endregion
    }
}
