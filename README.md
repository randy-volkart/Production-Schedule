# Production-Schedule
A snapsot of a current project I am working on intended as a portfolio coding demo. See the README for more details.

# Stack: Visual Studios, C#, SQL/ODBC, Crystal Reports
# Author: Randy Volkart (randy.volkart@outlook.com)
# Date: 2019-07-18

# Purpose: 

This project has been added to Github as a C# coding demonstration. It is a snapshot of a currently in progress project I am working on, and as it's only intended as a code demo updates will not be posted on Github. 

# Running the code?: 

Project is not setup to compile and run immediately from download. It relies on an ODBC connection to of a Sage BusinessVision company(ies) data, so will not work without a BV install and some additional Crystal Reports and ODBC setup. 

# Project outline:

Sage BusinessVision (BV) is an ERP system that manages accounting, sales, and inventory. Within the inventory is a sub process called Bill of Material (BoM), which allows you to create an BoM or Manufactured inventory item by combing stock from already existing items - including other BoM's. It is limited to single use BoM/Manufactured items intended for direct sales. 

The Production Schedule program increases the capacity of the BV BoM to allow for larger scale production, such as an assembly line. It ties into the BV Company data providing addition info, assembly tracking, more complex BoM's, and detailed reporting for things such as daily material requirement. 

The GUI is setup to mimic the look and function of BV. Like in BV reporting is done through Crystal Reports, with a Crystal plugin added to Visual Studios. 

# Project Status:

About 60% complete. Login, main form, and data entry form are in late beta phase, and 2/5+ crystal reports and associated forms are built. 
