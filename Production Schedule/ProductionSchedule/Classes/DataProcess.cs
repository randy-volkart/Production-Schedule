using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace ProductionSchedule.Classes
{
    using Globals;

    /// <summary>
    /// The DataProcess class manages ODBC data processing related to the ODBC tables created for
    /// the Production Schedule application. These tables are created in the same database as the
    /// BusinessVision Company. 
    /// </summary>
    /// <remarks>
    /// An ODBC connection is created as needed in function calls then destroyed once completed.
    /// </remarks>
    class DataProcess
    {
        /// <value>Stores the ODBC name of the company to connect to, read only.</value>
        private string Company { get; }

        /// <value>A boolean to store passing validation. Set to false in constructor.</value>
        private bool Validated { get; set; }

        #region parameters matching the work order database

        /// <value>A work order database field.</value>
        public int WorkOrderNo { get; set; }

        /// <value>A work order database field.</value>
        public string ProductionType { get; set; }

        /// <value>A work order database field.</value>
        public string ProductionLine { get; set; }

        /// <value>A work order database field.</value>
        public string ProductWarehouse { get; set; }

        /// <value>A work order database field.</value>
        public string ProductNumber { get; set; }

        /// <value>A work order database field.</value>
        public string ProductDescription { get; set; }

        /// <value>A work order database field.</value>
        public string PlannedUOM { get; set; }

        /// <value>A work order database field.</value>
        public decimal PlannedQuantity { get; set; }

        /// <value>A work order database field.</value>
        public DateTime PlannedDate { get; set; }

        /// <value>A work order database field.</value>
        public Nullable<int> PlannedShift { get; set; }

        /// <value>A work order database field.</value>
        public Nullable<int> ProdLineCapacity { get; set; }

        /// <value>A work order database field.</value>
        public Nullable<decimal> ReOrderPoint { get; set; }

        /// <value>A work order database field.</value>
        public Nullable<decimal> NoBatches { get; set; }

        /// <value>A work order database field.</value>
        public Nullable<decimal> BatchSize { get; set; }

        /// <value>A work order database field.</value>
        public string CustomerOrderNo { get; set; }

        /// <value>A work order database field.</value>
        public string FGWorkOrderNo { get; set; }

        /// <value>A work order database field.</value>
        public string Status { get; set; }

        /// <value>A work order database field.</value>
        public Nullable<decimal> ActualMftQty { get; set; }

        /// <value>A work order database field.</value>
        public Nullable<DateTime> ActualDate { get; set; }

        /// <value>A work order database field.</value>
        public Nullable<int> ActualShift { get; set; }

        /// <value>A work order database field.</value>
        public string Comments { get; set; }

        /// <value>A work order database field.</value>
        public string CreationDate { get; set; }

        /// <value>A work order database field.</value>
        public string CreationUser { get; set; }

        /// <value>A work order database field.</value>
        public string LastModifiedDate { get; set; }

        /// <value>A work order database field.</value>
        public string LastModifiedUser { get; set; }

        /// <value>A work order database field.</value>
        public char PrintIndicator { get; set; }

        #endregion

        /// <summary>
        /// Sets the ODBC company name and defaults Validated parameter to false.
        /// </summary>
        /// <param name="company">The ODBC name of the company to connect to.</param>
        /// <remarks>
        /// The property Validated is defaulted to false. Must pass the Validate method before
        /// inserting or updating to the database.
        /// </remarks>
        public DataProcess(string company)
        {
            Company = company;
            Validated = false;
        }

        /// <summary>
        /// A function to validate the work order data before inserting it into the database. 
        /// There is a parameter for each work order database column.
        /// </summary>
        /// <returns>
        /// Every validation failure gets added to the return string list. 
        /// If the list is empty, then validation passed so Validated property is set to true.
        /// </returns>
        public List<string> Validate
        (
            string workOrderNo, string productionType, string productionLine,
            string productWarehouse, string productNumber, string productDescription,
            string plannedUOM, string plannedQuantity, string plannedDate, string plannedShift,
            string prodLineCapacity, string reOrderPoint, string noBatches, string batchSize,
            string customerOrderNo, string fgWorkOrderNo, string status, string actualMftQty, string actualShift, string actualDate,
            string comments, string creationDate, string creationUser, string lastModifiedDate, string lastModifiedUser
        )
        {
            List<string> errors = new List<string>();

            // Testing each parameter here
            #region data validation

            int won;
            if (int.TryParse(workOrderNo, out won))
                this.WorkOrderNo = won;
            else
                errors.Add("Required: WorkOrderNo");

            if (productionType != null && productionType != "")
                this.ProductionType = productionType;
            else
                errors.Add("Required: ProductionType");

            if (productionLine != null && productionLine != "")
                this.ProductionLine = productionLine;
            else
                errors.Add("Required: ProductionLine");

            if (productWarehouse != null && productWarehouse != "")
                this.ProductWarehouse = productWarehouse;
            else
                errors.Add("Required: Warehouse");

            if (productNumber != null && productNumber != "")
                this.ProductNumber = productNumber;
            else
                errors.Add("Required: Item Code");

            if (productDescription != null && productDescription != "")
                this.ProductDescription = productDescription;
            else
                errors.Add("Required: Item Description");

            if (plannedUOM != null && plannedUOM != "")
                this.PlannedUOM = plannedUOM;
            else
                errors.Add("Required: Planned UOM");

            decimal plq;
            if (plannedQuantity == "")
                errors.Add("Required: Planned Quantity");
            else if (decimal.TryParse(plannedQuantity, out plq))
                this.PlannedQuantity = plq;
            else
                errors.Add("Format: Planned Quantity");

            DateTime pld;
            if (DateTime.TryParse(plannedDate, out pld))
                this.PlannedDate = pld;
            else
                errors.Add("Format: Required: Planned Date");

            int pls;
            if (plannedShift == "")
                this.PlannedShift = null;
            else if (int.TryParse(plannedShift, out pls))
                this.PlannedShift = pls;
            else
                errors.Add("Format: Planned Shift");

            int plc;
            if (prodLineCapacity == "")
                this.ProdLineCapacity = null;
            else if (int.TryParse(prodLineCapacity, out plc))
                this.ProdLineCapacity = plc;
            else
                errors.Add("Format: Production Line Capacity");

            decimal mil;
            if (reOrderPoint == "")
                this.ReOrderPoint = null;
            else if (decimal.TryParse(reOrderPoint, out mil))
                this.ReOrderPoint = mil;
            else
                errors.Add("Format: Re-Order Point");

            decimal bas;
            if (batchSize == "")
                this.BatchSize = null;
            else if (decimal.TryParse(batchSize, out bas))
                this.BatchSize = bas;
            else
                errors.Add("Format: Batch Size");

            // Must be between 0.000 and 99.999
            decimal nob;
            if (noBatches == "")
                this.NoBatches = null;
            else if (decimal.TryParse(noBatches, out nob))
                if (nob >= 0 && nob < 100 && CountDecimalPlaces(nob) <= 3)
                    this.NoBatches = nob;
                else
                    errors.Add("Format: Batch No must be between 0 and 0.999");
            else
                errors.Add("Format: Number of Batches");

            if (customerOrderNo != null)
                this.CustomerOrderNo = customerOrderNo;
            else
                errors.Add("Format: Customer Order Number");

            if (fgWorkOrderNo != null)
                this.FGWorkOrderNo = fgWorkOrderNo;
            else
                errors.Add("Format: Finished Goods Work Order Number");

            if (status != null && status != "")
                this.Status = status;
            else
                errors.Add("Status");

            decimal amq;
            if (actualMftQty == "")
                this.ActualMftQty = null;
            else if (decimal.TryParse(actualMftQty, out amq))
                this.ActualMftQty = amq;
            else
                errors.Add("Format: Actual Manufactured Quantity");

            int acs;
            if (actualShift == "")
                this.ActualShift = null;
            else if (int.TryParse(actualShift, out acs) )
                this.ActualShift = acs;
            else
                errors.Add("Format: Actual Shift");

            DateTime acd;
            if (DateTime.TryParse(actualDate, out acd))
                this.ActualDate = acd;
            else
                errors.Add("Format: Actual Date");

            if (comments != null)
                this.Comments = comments;
            else
                errors.Add("Comments");

            if (creationDate != null)
                this.CreationDate = creationDate;
            else
                errors.Add("Creation Date");

            if (creationUser != null && creationUser != "")
                this.CreationUser = creationUser;
            else
                errors.Add("Creation User");

            if (lastModifiedDate != null)
                this.LastModifiedDate = lastModifiedDate;
            else
                errors.Add("Last Modified Date");

            if (lastModifiedUser != null)
                this.LastModifiedUser = lastModifiedUser;
            else
                errors.Add("Last Modified User");

            #endregion

            if (errors.Count == 0)
            {
                Validated = true;
            }

            return errors;
        }

        // Function counts the number of decimal places in the parameter value. 
        // Used to verify No of Batches field.
        private static decimal CountDecimalPlaces(decimal dec)
        {
            decimal test;
            if (dec == 0)
                test = dec + 1;
            else
                test = dec;

            int[] bits = Decimal.GetBits(test);
            int exponent = bits[3] >> 16;
            int result = exponent;
            long lowDecimal = bits[0] | (bits[1] >> 8);
            while ((lowDecimal % 10) == 0)
            {
                result--;
                lowDecimal /= 10;
            }

            return result;
        }

        /// <summary>
        /// Selects a work order from the database 
        /// </summary>
        /// <param name="workOrderNo">The work order number to select</param>
        public void SelectOrder(string workOrderNo)
        {
            var selectQry = @"SELECT
                WorkOrderNo, ProductionType,ProductionLine,
                ProductWarehouse,ProductNumber,ProductDescription,
                PlannedUOM,PlannedQuantity,PlannedDate,PlannedShift,
                ProdLineCapacity,ReOrderPoint,NoBatches,BatchSize,
                CustomerOrderNo,FGWorkOrderNo,Status,ActualMftQty,ActualDate,ActualShift,
                Comments,CreationDate,CreationUser,LastModifiedDate,LastModifiedUser
                FROM PS_WORKORDERS WHERE WorkOrderNo = ?
            ";
            OdbcConnection odbc = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();

            int wo = 0;
            int.TryParse(workOrderNo, out wo);

            try
            {
                odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                odbc.Open();

                cmd = odbc.CreateCommand();
                cmd.CommandText = selectQry;
                cmd.Parameters.Add("WorkOrderNo", OdbcType.Int).Value = wo;

                OdbcDataReader reader = cmd.ExecuteReader();
                
                reader.Read();

                #region Assign parameters with reader

                WorkOrderNo = (int)reader.GetValue(0);// .GetString(0);
                ProductionType = reader.GetString(1);
                ProductionLine = reader.GetString(2);

                ProductWarehouse = reader.GetString(3);
                ProductNumber = reader.GetString(4);
                ProductDescription = reader.GetString(5);

                PlannedUOM = reader.GetString(6);
                PlannedQuantity = reader.GetDecimal(7);
                PlannedDate = reader.GetDate(8);
                PlannedShift = reader.GetInt32(9);

                ProdLineCapacity = reader.GetInt32(10);
                ReOrderPoint = reader.GetDecimal(11);
                NoBatches = reader.GetDecimal(12);
                BatchSize = reader.GetDecimal(13);

                CustomerOrderNo = reader.GetString(14);
                FGWorkOrderNo = reader.GetString(15);
                Status = reader.GetString(16);
                ActualMftQty = reader.GetDecimal(17);
                ActualDate = reader.GetDate(18);
                ActualShift = reader.GetInt32(19);

                Comments = reader.GetString(20);
                CreationDate = reader.GetString(21);
                CreationUser = reader.GetString(22);
                LastModifiedDate = reader.GetString(23);
                LastModifiedUser = reader.GetString(24);
                #endregion

                Validated = true;
            }
            catch (OdbcException odbce)
            {
                Utilities.ShowError(odbce.Message, odbce.ToString());
            }
            finally
            {
                cmd.Dispose();
                odbc.Close();
            }
        }

        /// <summary>
        /// Add a work order to the ODBC database.
        /// </summary>
        /// <remarks>
        /// To add the order function Validate must be run first and passed. 
        /// Values are passed to the object through the Validated function.
        /// </remarks>
        public void AddOrder()
        {
            if (this.Validated)
            {
                var insertQry = @"INSERT INTO PS_WORKORDERS(
                    WorkOrderNo,ProductionType,ProductionLine,
                    ProductWarehouse,ProductNumber,ProductDescription,
                    PlannedUOM,PlannedQuantity,PlannedDate,PlannedShift,
                    ProdLineCapacity,ReOrderPoint,NoBatches,BatchSize,
                    CustomerOrderNo,FGWorkOrderNo,Status,ActualMftQty,ActualDate,ActualShift,
                    Comments,CreationDate,CreationUser,LastModifiedDate,LastModifiedUser
                    ) VALUES (
                    ?,?,?,
                    ?,?,?,
                    ?,?,?,?,
                    ?,?,?,?,
                    ?,?,?,?,?,?,
                    ?,?,?,?,?
                );";

                OdbcConnection odbc = new OdbcConnection();
                OdbcCommand cmd = new OdbcCommand();

                try
                {
                    odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                    odbc.Open();

                    cmd = odbc.CreateCommand();
                    cmd.CommandText = insertQry;

                    #region Assign parameters

                    cmd.Parameters.Add("@WorkOrderNo", OdbcType.Int).Value = this.WorkOrderNo;
                    cmd.Parameters.Add("@ProductionType", OdbcType.Text).Value = this.ProductionType;
                    cmd.Parameters.Add("@ProductionLine", OdbcType.Text).Value = this.ProductionLine;

                    cmd.Parameters.Add("@ProductWarehouse", OdbcType.Text).Value = this.ProductWarehouse;
                    cmd.Parameters.Add("@ProductNumber", OdbcType.Text).Value = this.ProductNumber;
                    cmd.Parameters.Add("@ProductDescription", OdbcType.Text).Value = this.ProductDescription;

                    cmd.Parameters.Add("@PlannedUOM", OdbcType.Text).Value = this.PlannedUOM;
                    cmd.Parameters.Add("@PlannedQuantity", OdbcType.Decimal).Value = this.PlannedQuantity;
                    cmd.Parameters.Add("@PlannedDate", OdbcType.Date).Value = this.PlannedDate;
                    cmd.Parameters.Add("@PlannedShift", OdbcType.Int).Value = this.PlannedShift;

                    cmd.Parameters.Add("@ProdLineCapacity", OdbcType.Int).Value = this.ProdLineCapacity;
                    cmd.Parameters.Add("@ReOrderPoint", OdbcType.Decimal).Value = this.ReOrderPoint;
                    cmd.Parameters.Add("@NoBatches", OdbcType.Decimal).Value = this.NoBatches;
                    cmd.Parameters.Add("@BatchSize", OdbcType.Decimal).Value = this.BatchSize;

                    cmd.Parameters.Add("@CustomerOrderNo", OdbcType.Text).Value = this.CustomerOrderNo;
                    cmd.Parameters.Add("@FGWorkOrderNo", OdbcType.Text).Value = this.FGWorkOrderNo;
                    cmd.Parameters.Add("@Status", OdbcType.Text).Value = this.Status;
                    cmd.Parameters.Add("@ActualMftQty", OdbcType.Decimal).Value = this.ActualMftQty;
                    cmd.Parameters.Add("@ActualDate", OdbcType.Date).Value = this.ActualDate;
                    cmd.Parameters.Add("@ActualShift", OdbcType.Int).Value = this.ActualShift;

                    cmd.Parameters.Add("@Comments", OdbcType.Text).Value = this.Comments;
                    cmd.Parameters.Add("@CreationDate", OdbcType.Text).Value = this.CreationDate;
                    cmd.Parameters.Add("@CreationUser", OdbcType.Text).Value = this.CreationUser;
                    cmd.Parameters.Add("@LastModifiedDate", OdbcType.Text).Value = this.LastModifiedDate;
                    cmd.Parameters.Add("@LastModifiedUser", OdbcType.Text).Value = this.LastModifiedUser;

                    #endregion

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
        }

        /// <summary>
        /// Delete a work order form the work order table and add it to work order history. 
        /// </summary>
        /// <returns>Both transactions are tested before committed. If both passed true is return is true, if either fail then false.</returns>
        /// <remarks>Only a work order with status "Completed" or "Canceled" should be moved to history.</remarks>
        // *NOTE* - should not require Validated but rather check status value is "Completed". 
        public bool AddHistory()
        {
            bool success = true;
            //Removing a record from PS_WORKORDERS and adding it to PS_WORKORDERHISTORY
            if (this.Validated)
            {
                var historyQry = @"INSERT INTO PS_WORKORDERHISTORY(
                    WorkOrderNo,ProductionType,ProductionLine,
                    ProductWarehouse,ProductNumber,ProductDescription,
                    PlannedUOM,PlannedQuantity,PlannedDate,PlannedShift,
                    ProdLineCapacity,ReOrderPoint,NoBatches,BatchSize,
                    CustomerOrderNo,FGWorkOrderNo,Status,ActualMftQty,ActualDate,ActualShift,
                    Comments,CreationDate,CreationUser,LastModifiedDate,LastModifiedUser
                    ) VALUES (
                    ?,?,?,
                    ?,?,?,
                    ?,?,?,?,
                    ?,?,?,?,
                    ?,?,?,?,?,?,
                    ?,?,?,?,?
                );";

                var orderQry = @"DELETE FROM PS_WORKORDERS WHERE WorkOrderNo = ?";

                OdbcConnection odbc = new OdbcConnection();

                OdbcTransaction transaction = null;

                //h for history, which will be an insert
                //o for order, which will be delete
                OdbcCommand hcmd = new OdbcCommand();
                OdbcCommand ocmd = new OdbcCommand();

                try
                {
                    odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                    odbc.Open();

                    transaction = odbc.BeginTransaction();

                    hcmd = odbc.CreateCommand();
                    hcmd.Transaction = transaction;

                    hcmd.CommandText = historyQry;

                    #region Assign parameters

                    hcmd.Parameters.Add("@WorkOrderNo", OdbcType.Int).Value = this.WorkOrderNo;
                    hcmd.Parameters.Add("@ProductionType", OdbcType.Text).Value = this.ProductionType;
                    hcmd.Parameters.Add("@ProductionLine", OdbcType.Text).Value = this.ProductionLine;

                    hcmd.Parameters.Add("@ProductWarehouse", OdbcType.Text).Value = this.ProductWarehouse;
                    hcmd.Parameters.Add("@ProductNumber", OdbcType.Text).Value = this.ProductNumber;
                    hcmd.Parameters.Add("@ProductDescription", OdbcType.Text).Value = this.ProductDescription;

                    hcmd.Parameters.Add("@PlannedUOM", OdbcType.Text).Value = this.PlannedUOM;
                    hcmd.Parameters.Add("@PlannedQuantity", OdbcType.Decimal).Value = this.PlannedQuantity;
                    hcmd.Parameters.Add("@PlannedDate", OdbcType.Date).Value = this.PlannedDate;
                    hcmd.Parameters.Add("@PlannedShift", OdbcType.Int).Value = this.PlannedShift;

                    hcmd.Parameters.Add("@ProdLineCapacity", OdbcType.Int).Value = this.ProdLineCapacity;
                    hcmd.Parameters.Add("@ReOrderPoint", OdbcType.Decimal).Value = this.ReOrderPoint;
                    hcmd.Parameters.Add("@NoBatches", OdbcType.Decimal).Value = this.NoBatches;
                    hcmd.Parameters.Add("@BatchSize", OdbcType.Decimal).Value = this.BatchSize;

                    hcmd.Parameters.Add("@CustomerOrderNo", OdbcType.Text).Value = this.CustomerOrderNo;
                    hcmd.Parameters.Add("@FGWorkOrderNo", OdbcType.Text).Value = this.FGWorkOrderNo;
                    hcmd.Parameters.Add("@Status", OdbcType.Text).Value = this.Status;
                    hcmd.Parameters.Add("@ActualMftQty", OdbcType.Decimal).Value = this.ActualMftQty;
                    hcmd.Parameters.Add("@ActualDate", OdbcType.Date).Value = this.ActualDate;
                    hcmd.Parameters.Add("@ActualShift", OdbcType.Int).Value = this.ActualShift;

                    hcmd.Parameters.Add("@Comments", OdbcType.Text).Value = this.Comments;
                    hcmd.Parameters.Add("@CreationDate", OdbcType.Text).Value = this.CreationDate;
                    hcmd.Parameters.Add("@CreationUser", OdbcType.Text).Value = this.CreationUser;
                    hcmd.Parameters.Add("@LastModifiedDate", OdbcType.Text).Value = this.LastModifiedDate;
                    hcmd.Parameters.Add("@LastModifiedUser", OdbcType.Text).Value = this.LastModifiedUser;

                    #endregion

                    ocmd = odbc.CreateCommand();
                    ocmd.Transaction = transaction;
                    ocmd.CommandText = orderQry;

                    ocmd.Parameters.Add("@WorkOrderNo", OdbcType.Int).Value = this.WorkOrderNo;

                    hcmd.ExecuteNonQuery();
                    ocmd.ExecuteNonQuery();

                    transaction.Commit();
                    //otrans.Commit();
                }
                catch (OdbcException oe)
                {
                    Utilities.ShowError(oe.Message, "ODBC Error");
                    success = false;
                }
                finally
                {
                    hcmd.Dispose();
                    ocmd.Dispose();
                    odbc.Close();
                }
            }

            return success;
        }

        /// <summary>
        /// Adds a work order to the Loh History table.
        /// </summary>
        /// <param name="reasonForChange">Parameter should combine the process (Add/Delete/Completed/etc) and an optional user input.</param>
        /// <remarks>RecordLog should be run for all updates or status changes on the work order. Validation is also required.</remarks>
        public void RecordLog(string reasonForChange)
        {
            if (this.Validated)
            {
                var insertQry = @"INSERT INTO PS_WORKORDERLOG(
                    WorkOrderNo,ReasonForChange,ProductionType,ProductionLine,
                    ProductWarehouse,ProductNumber,ProductDescription,
                    PlannedUOM,PlannedQuantity,PlannedDate,PlannedShift,
                    ProdLineCapacity,ReOrderPoint,NoBatches,BatchSize,
                    CustomerOrderNo,FGWorkOrderNo,Status,ActualMftQty,ActualDate,ActualShift,
                    Comments,CreationDate,CreationUser,LastModifiedDate,LastModifiedUser
                    ) VALUES (
                    ?,?,?,?,
                    ?,?,?,
                    ?,?,?,?,
                    ?,?,?,?,
                    ?,?,?,?,?,?,
                    ?,?,?,?,?
                );";
                //ProdLineCapacity,MinInvLevel,NoBatches,BatchSize,
                OdbcConnection odbc = new OdbcConnection();
                OdbcCommand cmd = new OdbcCommand();
                try
                {
                    odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                    odbc.Open();

                    cmd = odbc.CreateCommand();
                    cmd.CommandText = insertQry;

                    #region Assign parameters

                    cmd.Parameters.Add("@WorkOrderNo", OdbcType.Int).Value = this.WorkOrderNo;
                    cmd.Parameters.Add("@ReasonForChange", OdbcType.Text).Value = reasonForChange;
                    cmd.Parameters.Add("@ProductionType", OdbcType.Text).Value = this.ProductionType;
                    cmd.Parameters.Add("@ProductionLine", OdbcType.Text).Value = this.ProductionLine;

                    cmd.Parameters.Add("@ProductWarehouse", OdbcType.Text).Value = this.ProductWarehouse;
                    cmd.Parameters.Add("@ProductNumber", OdbcType.Text).Value = this.ProductNumber;
                    cmd.Parameters.Add("@ProductDescription", OdbcType.Text).Value = this.ProductDescription;

                    cmd.Parameters.Add("@PlannedUOM", OdbcType.Text).Value = this.PlannedUOM;
                    cmd.Parameters.Add("@PlannedQuantity", OdbcType.Decimal).Value = this.PlannedQuantity;
                    cmd.Parameters.Add("@PlannedDate", OdbcType.Date).Value = this.PlannedDate;
                    cmd.Parameters.Add("@PlannedShift", OdbcType.Int).Value = this.PlannedShift;

                    cmd.Parameters.Add("@ProdLineCapacity", OdbcType.Int).Value = this.ProdLineCapacity;
                    cmd.Parameters.Add("@ReOrderPoint", OdbcType.Decimal).Value = this.ReOrderPoint;
                    cmd.Parameters.Add("@NoBatches", OdbcType.Decimal).Value = this.NoBatches;
                    cmd.Parameters.Add("@BatchSize", OdbcType.Decimal).Value = this.BatchSize;

                    cmd.Parameters.Add("@CustomerOrderNo", OdbcType.Text).Value = this.CustomerOrderNo;
                    cmd.Parameters.Add("@FGWorkOrderNo", OdbcType.Text).Value = this.FGWorkOrderNo;
                    cmd.Parameters.Add("@Status", OdbcType.Text).Value = this.Status;
                    cmd.Parameters.Add("@ActualMftQty", OdbcType.Decimal).Value = this.ActualMftQty;
                    cmd.Parameters.Add("@ActualDate", OdbcType.Date).Value = this.ActualDate;
                    cmd.Parameters.Add("@ActualShift", OdbcType.Int).Value = this.ActualShift;

                    cmd.Parameters.Add("@Comments", OdbcType.Text).Value = this.Comments;
                    cmd.Parameters.Add("@CreationDate", OdbcType.Text).Value = this.CreationDate;
                    cmd.Parameters.Add("@CreationUser", OdbcType.Text).Value = this.CreationUser;
                    cmd.Parameters.Add("@LastModifiedDate", OdbcType.Text).Value = this.LastModifiedDate;
                    cmd.Parameters.Add("@LastModifiedUser", OdbcType.Text).Value = this.LastModifiedUser;

                    #endregion
                    
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
        }

        /// <summary>
        /// Updates a work order in the ODBC database.
        /// </summary>
        /// <remarks>
        /// To update the order the Validate function must be run first and passed. 
        /// Values are passed to the object through the Validated function.
        /// </remarks>
        public void UpdateOrder()
        {
            if (this.Validated)
            {
                var updateQry = @"UPDATE PS_WORKORDERS SET 
                    ProductionType = ?,ProductionLine = ?,
                    ProductWarehouse = ?,ProductNumber = ?,ProductDescription = ?,
                    PlannedUOM = ?,PlannedQuantity = ?,PlannedDate = ?,PlannedShift = ?,
                    ProdLineCapacity = ?,ReOrderPoint = ?,NoBatches = ?,BatchSize = ?,
                    CustomerOrderNo = ?,FGWorkOrderNo = ?,Status = ?,ActualMftQty = ?,ActualDate = ?,ActualShift = ?,
                    Comments = ?,CreationDate = ?,CreationUser = ?,LastModifiedDate = ?,LastModifiedUser = ?
                    WHERE WorkOrderNo = ?;
                ";
                
                OdbcConnection odbc = new OdbcConnection();
                OdbcCommand cmd = new OdbcCommand();

                try
                {
                    odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                    odbc.Open();

                    cmd = odbc.CreateCommand();
                    cmd.CommandText = updateQry;

                    #region Assign parameters

                    cmd.Parameters.Add("@ProductionType", OdbcType.Text).Value = this.ProductionType;
                    cmd.Parameters.Add("@ProductionLine", OdbcType.Text).Value = this.ProductionLine;

                    cmd.Parameters.Add("@ProductWarehouse", OdbcType.Text).Value = this.ProductWarehouse;
                    cmd.Parameters.Add("@ProductNumber", OdbcType.Text).Value = this.ProductNumber;
                    cmd.Parameters.Add("@ProductDescription", OdbcType.Text).Value = this.ProductDescription;

                    cmd.Parameters.Add("@PlannedUOM", OdbcType.Text).Value = this.PlannedUOM;
                    cmd.Parameters.Add("@PlannedQuantity", OdbcType.Decimal).Value = this.PlannedQuantity;
                    cmd.Parameters.Add("@PlannedDate", OdbcType.Date).Value = this.PlannedDate;
                    cmd.Parameters.Add("@PlannedShift", OdbcType.Int).Value = this.PlannedShift;

                    cmd.Parameters.Add("@ProdLineCapacity", OdbcType.Int).Value = this.ProdLineCapacity;
                    cmd.Parameters.Add("@ReOrderPoint", OdbcType.Decimal).Value = this.ReOrderPoint;
                    cmd.Parameters.Add("@NoBatches", OdbcType.Decimal).Value = this.NoBatches;
                    cmd.Parameters.Add("@BatchSize", OdbcType.Decimal).Value = this.BatchSize;
                    

                    cmd.Parameters.Add("@CustomerOrderNo", OdbcType.Text).Value = this.CustomerOrderNo;
                    cmd.Parameters.Add("@FGWorkOrderNo", OdbcType.Text).Value = this.FGWorkOrderNo;
                    cmd.Parameters.Add("@Status", OdbcType.Text).Value = this.Status;
                    cmd.Parameters.Add("@ActualMftQty", OdbcType.Decimal).Value = this.ActualMftQty;
                    cmd.Parameters.Add("@ActualDate", OdbcType.Date).Value = this.ActualDate;
                    cmd.Parameters.Add("@ActualShift", OdbcType.Int).Value = this.ActualShift;

                    cmd.Parameters.Add("@Comments", OdbcType.Text).Value = this.Comments;
                    cmd.Parameters.Add("@CreationDate", OdbcType.Text).Value = this.CreationDate;
                    cmd.Parameters.Add("@CreationUser", OdbcType.Text).Value = this.CreationUser;
                    cmd.Parameters.Add("@LastModifiedDate", OdbcType.Text).Value = this.LastModifiedDate;
                    cmd.Parameters.Add("@LastModifiedUser", OdbcType.Text).Value = this.LastModifiedUser;

                    cmd.Parameters.Add("@WorkOrderNo", OdbcType.Int).Value = this.WorkOrderNo;

                    #endregion

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
        }

        /// <summary>
        /// Delete a work order from the database
        /// </summary>
        /// <param name="workOrderNo">The work order number to be deleted.</param>
        /// <param name="status">The work order status</param>
        /// <returns>True if delete is successful, false if not.</returns>
        /// <remarks>Only work orders with status "Okay" will be deleted. </remarks>
        public bool DeleteOrder(int workOrderNo, string status)
        {
            var success = false;

            if (status == nameof(Control.Status.Okay))
            {
                var deleteQry = @"DELETE FROM PS_WORKORDERS WHERE WorkOrderNo = ?;";

                OdbcConnection odbc = new OdbcConnection();
                OdbcCommand cmd = new OdbcCommand();
                try
                {
                    odbc.ConnectionString = Constants.GETODBCCONNECTIONSTRING(Company);
                    odbc.Open();

                    cmd = odbc.CreateCommand();
                    cmd.CommandText = deleteQry;
                    cmd.Parameters.Add("@WorkOrderNo", OdbcType.Int).Value = workOrderNo;
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (OdbcException oe)
                {
                    Utilities.ShowError(oe.Message, "ODBC Error");
                    success = false;
                }
                finally
                {
                    cmd.Dispose();
                    odbc.Close();
                }
            }

            return success;
        }
    }
}
