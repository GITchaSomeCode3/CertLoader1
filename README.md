# CertLoader1

An application for uploading calibration certs to a DB, by either manual input or JSON file



Backup of DB is in GIT.  Used default instance of sql.  (/.)
Json files containing tool cert data are uploaded to git.  These can be imported via the UI


FUNCTIONS

Import Json - JSON file is uploaded to DB with a stored procedure.  PDF created on the fly and uploaded with Stored Procedure

Add Record (Manual) - Data from Text box is put into JSON format, uploaded with SP. Order and Cert numbers generated automatically

Double Click (datagrid) -  this brings up a menu.  Options are View PDF or Delete Record


