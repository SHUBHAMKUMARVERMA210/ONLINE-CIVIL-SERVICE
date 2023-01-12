<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRINT ADMIN LOG.aspx.cs" Inherits="PRINT_ADMIN_LOG" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

	.ad6eecaff9-9c70-40ae-85d1-81d28ec2f3ea-0 {border-color:#000000;border-left-width:0;border-right-width:0;border-top-width:0;border-bottom-width:0;}
	.fcb185aef4-2ac1-48fa-ab2a-65c3c89e4e02-0 {font-size:9pt;color:#000000;font-family:Arial;font-weight:bold;}
	.fcb185aef4-2ac1-48fa-ab2a-65c3c89e4e02-1 {font-size:9pt;color:#000000;font-family:Arial;font-weight:normal;}
	.fcb185aef4-2ac1-48fa-ab2a-65c3c89e4e02-2 {font-size:19pt;color:#000000;font-family:Algerian;font-weight:bold;}
	.fcb185aef4-2ac1-48fa-ab2a-65c3c89e4e02-3 {font-size:13pt;color:#000000;font-family:@Yu Gothic UI Semibold;font-weight:bold;}
	    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="a">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="True" Height="1106px" ReportSourceID="CrystalReportSource1" 
            Width="876px" />
    </div>
    </form>
</body>
</html>
