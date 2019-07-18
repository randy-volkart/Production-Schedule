create table PS_LOGHISTORY (
LogID IDENTITY PRIMARY KEY, 
WorkOrderNo VARCHAR(10) , //System assigned sequential number. Key field.
ProductType VARCHAR(20), //0 - FG, 3 - In process (Sub Assembly) - BV - System assigned sequential number. Key field
ProductWhse VARCHAR(10), //BV
ProductNo VARCHAR(34), //BV
ProductionLine VARCHAR(50), //Secondary Key to Production Line table
PlannedUOM VARCHAR(10), //BV - Force inventory (stocK) UOM
PlannedQuantity DECIMAL(7,5),
NoBatches DECIMAL(3,3), //0 - 99 with 3 decimals
PlannedDate DATE,
PlannedShift INTEGER,
PLCapacity INTEGER, //From production line table, at the timE of entry or change of WO
Allowance DECIMAL(3,2), //Allowance Percentage, 0.00-100.00%
BatchSize DECIMAL(8,3), //BV - Batch size is product minimum order quantity. Capture the number at time of entry or change of WO
MinInvLevel DECIMAL(15,5), //BV - Re order point of product.  Capture the number at time of entry or change of WO. 
CustomerOrderNo VARCHAR(20), //BV - Optional field. The order related to work order if any. Valid for FG WO.
FGWorkOrderNo VARCHAR(50), //Mandatory field. Valid for In process (sub assembly) WO. Includes the connected FG WO#.
ActualMftQty DECIMAL(9,5), //In same inventory UOM.
ActualDate DATE,
ActualShift VARCHAR(2),
Status VARCHAR(20), //Okay, Issued, Un-issued, Completed.
Comments LONGVARCHAR,
CreationDate DATE, //Output only
CreationUser VARCHAR(50), //Output only
LastModDate DATE, //Output only
LastModUser VARCHAR(50), //Output only
PrintIndicator CHAR(1), //0 - never printed, 1 - already printed, at least once
ReasonForChange LONGVARCHAR //Mandatory field, to be recorded in WO history log.
)
