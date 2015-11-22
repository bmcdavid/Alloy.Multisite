#Setup
Create a new website in IIS with the following bindings:

`
local.alloy.com
local2.alloy.com
local3.alloy.com
`

Add host entry files for above bindings in for 127.0.0.1

`
C:\Windows\System32\drivers\etc\hosts
`

## SQL

Setup SQL Express 2014 with the database, EPiServerDB_bf213514.mdf, located in the App_Data folder, and update the connection string.

or

Follow instructions [here](http://blogs.msdn.com/b/sqlexpress/archive/2011/12/09/using-localdb-with-full-iis-part-1-user-profile.aspx) to use LocalDb for IIS.

## Code Components

* Business/SelectionFactories/LayoutSelector.cs - creates dropdown of folders in ~/Views/Shared/Layouts
* Views/_viewstart.cshtml - gets values of SiteLayout from start page type and adds to path.
* Models/Pages/StartPage.cs - has property using LayoutSelector to allow single layout selection.
