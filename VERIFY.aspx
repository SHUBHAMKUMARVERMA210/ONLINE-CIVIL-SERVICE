<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VERIFY.aspx.cs" Inherits="VERIFY" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="bootstrap/js/jquery-3.3.1.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="assets/ico/favicon.ico" />
     <link rel="stylesheet" href="assets/css/jquery-ui.css"/>
    <script src="style.css"></script>
    <script src="assets/js/jquery-1.12.4.js"/></script>
    <script src="assets/js/jquery-ui.js"/></script>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            width: 96%;
        }
        .style3
        {
            text-align: center;
            width: 437px;
        }
        .style4
        {
            text-align: right;
            width: 123px;
        }
        .style5
        {
            width: 306px;
        }
        .style6
        {
            width: 437px;
            font-weight: bold;
        }
        .style7
        {
            text-align: right;
            width: 123px;
            height: 26px;
            font-weight: bold;
        }
        .style8
        {
            width: 306px;
            height: 26px;
        }
        .style9
        {
            text-align: center;
            width: 437px;
            height: 26px;
        }
        .style10
        {
            height: 26px;
        }
        .style11
        {
            text-align: right;
            width: 123px;
            font-weight: bold;
        }
        </style>
         <script type="text/javascript">
  $( function() {
    $( "#DATE_FROM_TXTBOX" ).datepicker(
    {
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true,
     }
    );
  } );
  </script>
           <script type="text/javascript">
  $( function() {
    $( "#DATE_TO_TXTBOX" ).datepicker(
    {
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true,
     }
    );
  } );
  </script>
</head>
<body class=" jumbotron alert alert-primary">
    <form id="form1" runat="server">
    <div>
    
        <h1>&nbsp;<asp:Label ID="Label1" runat="server" Text="VERIFY USER"></asp:Label></h1>
        <br />
        <div>
        
            <table class="style2" align="center">
                <tr>
                    <td class="style11">
                        <asp:Label ID="DATE_FROM_LBL" runat="server" Text="DATE FROM"></asp:Label>
                    </td>
                    <td class="style5">
                 <asp:TextBox ID="DATE_FROM_TXTBOX" runat="server" Class="form-control" placeholder="SELECT DATE FROM" type="Date"></asp:TextBox>
                    </td>
                    <td class="style6" >
                        <asp:Label ID="DATE_TO_LBL" runat="server" Text="DATE TO"></asp:Label>
                    </td>
                    <td>
                 <asp:TextBox ID="DATE_TO_TXTBOX" runat="server" Class="form-control" placeholder="SELECT DATE TO"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style11">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style3">
                        <b>
                        <asp:Button ID="VIEW_BTN" runat="server" Text="VIEW" class="btn btn-primary" 
                            onclick="VIEW_BTN_Click"/>
                        </b>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        <asp:Label ID="SELECT_ID_LBL" runat="server" Text="SELECT ID"></asp:Label>
                    </td>
                    <td class="style8">
                        <asp:DropDownList ID="DDL_USER_ID" runat="server" Class="form-control" 
                            AutoPostBack="True" onselectedindexchanged="DDL_USER_ID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="style9">
                        <b>
                        <asp:Label ID="STATUS_LBL" runat="server" Text="STATUS"></asp:Label>
                    </td>
                    <td class="style10">
                        <asp:DropDownList ID="DDL_STATUS" runat="server" Class="form-control">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        </b></td>
                    <td class="style5">
                        <b>
                        <asp:Button ID="PRINT_BTN" runat="server" Text="PRINT" Class="btn btn-light" 
                            onclick="PRINT_BTN_Click"/>
                        </b>
                    </td>
                    <td class="style3">
                        <b>
                        <asp:Button ID="BACK_TO_ADMIN_LOG_BTN" runat="server" Text=" BACK TO ADMIN LOG" 
                            Class="btn btn-light" onclick="BACK_TO_ADMIN_LOG_BTN_Click" />
                        <asp:Button ID="UPDATE_BTN" runat="server" Text="UPDATE" 
                            class="btn btn-success" onclick="UPDATE_BTN_Click"/>
                        </b>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        
        </div>
        <div class="style1">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                onrowdatabound="OnRowDataBound">
                <RowStyle BackColor="White" ForeColor="#003399" />
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
