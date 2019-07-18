create table PS_WORKORDERLOG (

LogNo	IDENTITY PRIMARY KEY, //System assigned sequential number. Key field.
WorkOrderNo INTEGER, 
ProductionType VARCHAR(20), //0 - FG, 3 - In process (Sub Assembly) - BV - System assigned sequential number. Key field
ProductionLine VARCHAR(50), //Secondary Key to Production Line table

ProductWarehouse VARCHAR(10), //BV
ProductNumber VARCHAR(34), //BV
ProductDescription VARCHAR(80), //BV

PlannedUOM VARCHAR(10), //BV - Force inventory (stocK) UOM
PlannedQuantity DECIMAL(7,5),
PlannedDate DATE,
PlannedShift INTEGER,

ProdLineCapacity INTEGER, //From production line table, at the timE of entry or change of WO
ReOrderPoint DECIMAL(15,5), //BV - Re order point of product.  Capture the number at time of entry or change of WO. 
NoBatches DECIMAL(3,3), //0 - 99 with 3 decimals
BatchSize DECIMAL(11,3), //BV - Batch size is product minimum order quantity. Capture the number at time of entry or change of WO
//Allowance DECIMAL(3,2), //Allowance Percentage, 0.00-100.00% - this field is in original design doc but dont see it in access program

CustomerOrderNo VARCHAR(20), //BV - Optional field. The order related to work order if any. Valid for FG WO.
FGWorkOrderNo VARCHAR(50), //Mandatory field. Valid for In process (sub assembly) WO. Includes the connected FG WO#.
Status VARCHAR(20), //Okay, Issued, Un-issued, Completed.
ActualMftQty DECIMAL(9,5), //In same inventory UOM.
ActualDate DATE,
ActualShift INTEGER,

Comments LONGVARCHAR,
CreationDate VARCHAR(8), //Output only
CreationUser VARCHAR(50), //Output only
LastModifiedDate VARCHAR(8), //Output only
LastModifiedUser VARCHAR(50), //Output only

PrintIndicator CHAR(1), //0 - never printed, 1 - already printed, at least once
ReasonForChange LONGVARCHAR //Mandatory field, to be recorded in WO history log.
)
