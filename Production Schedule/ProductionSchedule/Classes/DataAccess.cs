using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ProductionSchedule.Classes
{
    using Globals;

    /// <summary>
    /// The DataAccess class creates an active ODBC connection to the company database and fetches
    /// various data from the BusinessVision and Production Schedule tables, which are maintained in the
    /// same DB.
    /// </summary>
    /// <remarks>An active connection to an ODBC database is kept while the object exists. </remarks>
    class DataAccess
    {

        private OdbcConnection Odbc { get; }

        /// <summary>
        /// Constructor creates an open connection to an ODBC database.
        /// </summary>
        /// <param name="company">The ODBC Name of the company to connect to</param>
        public DataAccess(string company)
        {
            try
            {
                Odbc = new OdbcConnection(Constants.GETODBCCONNECTIONSTRING(company));
                Odbc.Open();
            }
            catch (OdbcException oe)
            {
                Utilities.ShowError(oe.Message, "ODBC Error");
            }
        }


        /// <returns>A string list of BusinessVision warehouse codes</returns>
        public List<string> GetBVWarehouses()
        {
            List<string> warehouses = new List<string>();
            warehouses = GetComboBoxData("WHSE_KEY", "WAREHOUSE", "");
            return warehouses;
        }

        /// <returns>A string list of Production Line codes</returns>
        public List<string> GetProductionLines()
        {
            List<string> productionlines = new List<string>();
            productionlines = GetComboBoxData("Code", "PS_PRODUCTIONLINE", "");
            return productionlines;
        }

        /// <returns>A string list of BusinessVision item codes</returns>
        public List<string> GetItemLines(string whse)
        {
            List<string> items = new List<string>();
            string filter = String.Format("WHERE WHSE = '{0}' AND TYPE_KEY = 'M'", whse);
            items = GetComboBoxData("CODE", "INVENTORY", filter);
            return items;
        }

        /// <returns>A string list of BusinessVision item descriptions.</returns>
        public string GetItemDescription(string whse, string itemcode)
        {
            string desc = "";
            string filter = string.Format("WHERE WHSE = '{0}' AND CODE='{1}'", whse, itemcode);

            desc = (string)GetTextBoxData("INV_DESCRIPTION", "INVENTORY", filter);
            desc.TrimEnd();

            return desc;
        }

        /// <returns>A string list of BusinessVision unit of measurement codes.</returns>
        public string GetUOMs(string whse, string itemcode)
        {
            string uom = "";
            string filter = string.Format("WHERE WHSE = '{0}' AND CODE = '{1}'", whse, itemcode);
            uom = (string)GetTextBoxData("BVSTKUOM", "INVENTORY", filter);
            uom.TrimEnd();
            return uom;
        }

        /// <returns>A string list of BusinessVision items default stock unit of measurement codes.</returns>
        public string GetStockUOM(string whse, string itemcode)
        {
            string stock = "";
            string filter = string.Format("WHERE WHSE = '{0}' AND CODE = '{1}'", whse, itemcode);
            stock = (string)GetTextBoxData("BVSTKUOM", "INVENTORY", filter);
            stock.TrimEnd();
            return stock;
        }

        /// <param name="whse">A BusinessVision warehouse code.</param>
        /// <param name="itemcode">A BusinessVision item code.</param>
        /// <returns>A single decimal value which is the reorder point of the item.</returns>
        public decimal GetReOrderPoint(string whse, string itemcode)
        {
            decimal rop = 0;
            string filter = string.Format("WHERE WHSE = '{0}' AND CODE = '{1}'", whse, itemcode);
            rop = (decimal)GetTextBoxData("ROP", "INVENTORY", filter);

            return rop;
        }

        /// <param name="whse">A BusinessVision warehouse code.</param>
        /// <param name="itemcode">A BusinessVision item code.</param>
        /// <returns>A single decimal value with that is the minimum inventory level of the item.</returns>
        public decimal GetMinInvLevel(string whse, string itemcode)
        {
            decimal mil = 0;
            string filter = string.Format("WHERE WHSE = '{0}' AND CODE = '{1}'", whse, itemcode);
            mil = (decimal)GetTextBoxData("MIN_BUY_QTY", "INVENTORY", filter);

            return mil;
        }


        // A function to reduce redundant code while getting combobox data from BV. 
        // *WARNING*: Parameters are not bound in these functions so need to evaluate if an SQL injection
        // attack can occur. Data should only be getting pulled from BV so about the only possible way
        // I could see it is if someone messed with the BV item descriptions. 
        private List<string> GetComboBoxData(string column, string table, string filter)
        {
            List<string> strlist= new List<string>();

            OdbcCommand cmd = new OdbcCommand();

            try
            {
                cmd = this.Odbc.CreateCommand();
                cmd.CommandText = String.Format("SELECT {0} FROM {1} {2}", column, table, filter);

                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string line = (reader.GetString(0));
                    line = line.TrimEnd();
                    strlist.Add(line);
                }
            }
            catch (Exception e)
            {
                Utilities.ShowError(e.Message, e.Source);
            }
            finally
            {
                cmd.Dispose();
            }

            return strlist;
        }

        // A function to reduce redundant code while getting a singlevalue for a text box from BV. 
        // *WARNING*: Parameters are not bound in these functions so need to evaluate if an SQL injection
        // attack can occur. Data should only be getting pulled from BV so about the only possible way
        // I could see it is if someone messed with the BV item descriptions. 
        private object GetTextBoxData(string column, string table, string filter)
        {
            object obj = "";

            OdbcCommand cmd = new OdbcCommand();

            try
            {
                cmd = Odbc.CreateCommand();
                cmd.CommandText = String.Format("SELECT {0} FROM {1} {2}", column, table, filter);

                OdbcDataReader reader = cmd.ExecuteReader();

                reader.Read();
                obj = reader.GetValue(0);
                
            }
            catch (Exception e)
            {
                Utilities.ShowError(e.Message, e.Source);
            }
            finally
            {
                cmd.Dispose();
            }

            return obj;
        }

        /// <summary>
        /// Get the next work order number/ID to be used on a new work order.
        /// </summary>
        /// <returns>A 10 digit integer value starting from 1000000000.</returns>
        /// <remarks>Since adding the work order history table and updating the program to takes 
        /// completed work orders from table PS_WORKORDERS and moves them to table PS_WORKORDERHISTORY, 
        /// this function requires updating. The sequence will break if the last work order is
        /// "completed".</remarks>
        public int GetNewWorkOrderNo()
        {
            int lastWorkOrder;
            int newWO = 0;

            string qry = @"select top 1 WorkOrderNo from PS_WORKORDERS order by WorkOrderNo desc";

            OdbcCommand cmd = new OdbcCommand();
            
            try
            {
                cmd = Odbc.CreateCommand();
                cmd.CommandText = qry;

                OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    lastWorkOrder = reader.GetInt32(0);
                    newWO = lastWorkOrder + 1;
                }
                // Should mean table is empty.
                else
                {
                    newWO = 1000000000;
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

            return newWO;
        }

        /// <summary>
        /// Gets the work order number from the PS_WORKORDERS table immediately prior to 
        /// the provided work order number.
        /// </summary>
        /// <param name="currentWorkOrder">An active work order number.</param>
        /// <returns>A 10 digit integer value representing a work order number.</returns>
        /// <remarks>Completed work orders get moved to history, so the previous work order number
        /// is not simply the currentWorkOrder - 1.</remarks>
        public string GetPreviousWorkOrderNo(string currentWorkOrder)
        {
            int prevWO = 0;
            int cwo = 0;

            string qry = @"
                SELECT TOP 1 WorkOrderNo 
                FROM PS_WORKORDERS 
                WHERE WorkOrderNo < ? 
                ORDER BY WorkOrderNo DESC";

            OdbcCommand cmd = new OdbcCommand();

            int.TryParse(currentWorkOrder, out cwo);

            try
            {
                cmd = Odbc.CreateCommand();
                cmd.CommandText = qry;
                cmd.Parameters.Add("@WorkOrderNo", OdbcType.Int).Value = cwo;

                OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    prevWO = reader.GetInt32(0);
                }
                else //should mean table is empty
                {
                    prevWO = 0;
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

            return prevWO.ToString();
        }

        /// <summary>
        /// Gets the work order number from the PS_WORKORDERS table immediately after 
        /// the provided work order number.
        /// </summary>
        /// <param name="currentWorkOrder">An active work order number.</param>
        /// <returns>A 10 digit integer value representing a work order number.</returns>
        /// <remarks>Completed work orders get moved to history, so the previous work order number
        /// is not simply the currentWorkOrder + 1.</remarks>
        public string GetNextWorkOrderNo(string currentWorkOrder)
        {
            int nextWO = 0;

            OdbcCommand cmd = new OdbcCommand();

            string qry = @"
                SELECT TOP 1 WorkOrderNo 
                FROM PS_WORKORDERS 
                WHERE WorkOrderNo > ? 
                ORDER BY WorkOrderNo ASC";

            int cwo = 0;
            int.TryParse(currentWorkOrder, out cwo);

            try
            {
                cmd = Odbc.CreateCommand();
                cmd.CommandText = qry;
                cmd.Parameters.Add("@WorkOrderNo", OdbcType.Int).Value = cwo;

                OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    nextWO = reader.GetInt32(0);
                }
                // Should mean table is empty.
                else
                {
                    nextWO = 0;
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

            return nextWO.ToString();
        }

        /// <summary>
        /// Retrieves the first work order number by numerical sequence form the 
        /// PS_WORKORDERS table.
        /// </summary>
        /// <returns>A 10 digit integer value representing a work order number.</returns>
        public string GetFirstWorkOrderNo()
        {
            int firstWO = 0;

            OdbcCommand cmd = new OdbcCommand();

            string qry = @"
                SELECT TOP 1 WorkOrderNo 
                FROM PS_WORKORDERS 
                ORDER BY WorkOrderNo ASC";

            try
            {
                cmd = Odbc.CreateCommand();
                cmd.CommandText = qry;

                OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    firstWO = reader.GetInt32(0);
                }
                // Should mean table is empty.
                else
                {
                    firstWO = 0;
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

            return firstWO.ToString();
        }

        /// <summary>
        /// Retrieves the last work order number by numerical sequence form the 
        /// PS_WORKORDERS table.
        /// </summary>
        /// <returns>A 10 digit integer value representing a work order number.</returns>
        public string GetLastWorkOrderNo()
        {
            int lastWO = 0;

            OdbcCommand cmd = new OdbcCommand();

            string qry = @"
                SELECT TOP 1 WorkOrderNo 
                FROM PS_WORKORDERS 
                ORDER BY WorkOrderNo DESC";

            try
            {
                cmd = Odbc.CreateCommand();
                cmd.CommandText = qry;

                OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    lastWO = reader.GetInt32(0);
                }
                // Should mean table is empty.
                else
                {
                    lastWO = 0;
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

            return lastWO.ToString();
        }

        /// <summary>
        /// Gets a set of work order data based on the parameters to be set to a ListView object. 
        /// </summary>
        /// <param name="StatusFilter"></param>
        /// <param name="ProductionTypeFilter"></param>
        /// <returns>A list of work order data sorted into ListViewItem's.</returns>
        public List<ListViewItem> GetWorkOrdersForSelectListView(string StatusFilter, string ProductionTypeFilter)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            OdbcCommand cmdSelectWorkOrders = new OdbcCommand();
            string qry = @" SELECT WorkOrderNo, ProductionType, ProductWarehouse, 
                            ProductNumber, ProductionLine, Status, 
                            NoBatches, PlannedDate, PlannedShift 
                            FROM PS_WORKORDERS
                            WHERE STATUS like ? AND ProductionType like ?
                            ORDER BY WorkOrderNo";

            try
            {
                cmdSelectWorkOrders = Odbc.CreateCommand();
                cmdSelectWorkOrders.CommandText = qry;
                cmdSelectWorkOrders.Parameters.Add("@Status", OdbcType.Text).Value = StatusFilter;
                cmdSelectWorkOrders.Parameters.Add("@ProductionType", OdbcType.Text).Value = ProductionTypeFilter;

                OdbcDataReader reader = cmdSelectWorkOrders.ExecuteReader();

                while (reader.Read())
                {
                    string won = reader.GetString(0);
                    string prt = reader.GetString(1);
                    string prw = reader.GetString(2);
                    string prn = reader.GetString(3);
                    string prl = reader.GetString(4);
                    string sta = reader.GetString(5);
                    var nob = reader.GetValue(6);
                    string pld = reader.GetDate(7).ToString("yy-MM-dd");
                    string pls = reader.GetString(8);

                    ListViewItem item = new ListViewItem(new[] { won, prt, prw, prn, prl, sta, nob.ToString(), pld, pls });
                    items.Add(item);
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

            return items;
        }
    }
}
