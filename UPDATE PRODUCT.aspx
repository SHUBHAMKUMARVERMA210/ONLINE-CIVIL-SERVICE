<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UPDATE PRODUCT.aspx.cs" Inherits="UPDATE_PRODUCT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
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
            width: 581px;
        }
        .style5
        {
            width: 398px;
        }
        .style6
        {
            width: 228px;
            height: 26px;
        }
        .style7
        {
            height: 26px;
        }
        .style8
        {
            width: 194px;
        }
        .style9
        {
            height: 26px;
            width: 194px;
            font-weight: bold;
            text-align: right;
        }
        .style10
        {
            width: 194px;
            font-weight: bold;
            text-align: right;
        }
        </style>
     <script language="javascript" type="text/javascript">
         function CheckNumeric(e) {

             if (window.event) {
                 if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8 & e.keyCode != 9) {
                     event.returnValue = false;
                     return false;

                 }
             }
             else {
                 if ((e.which < 48 || e.which > 57) & e.which != 8 & e.keyCode != 9) {
                     e.preventDefault();
                     return false;

                 }
             }
         }
     
    </script>
</head>
<body class=" jumbotron alert alert-primary">
    <form id="form1" runat="server">
    <div>
        
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <h1><asp:Label ID="Label1" runat="server" 
            style="font-family: Algerian; font-size: larger" Text="UPDATE PANEL"></asp:Label></h1> 
        <br />
        <br />
        <table class="style1" style="margin-left:250px">
            <tr>
                <td class="style10">
                    <asp:Label ID="CATEGORY_LBL" runat="server" Text="CATEGORY"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="DDL_CATEGORY" runat="server" 
                        onselectedindexchanged="DDL_CATEGORY_SelectedIndexChanged" 
                        Class="form-control" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="TYPE_LBL" runat="server" Text="TYPE"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="DDL_TYPE" runat="server" 
                        onselectedindexchanged="DDL_TYPE_SelectedIndexChanged" 
                        Class="form-control" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="SPECIFICATION_LBL" runat="server" Text="SPECIFICATION"></asp:Label>
                </td>
                <td class="style2" colspan="2">
                    <asp:DropDownList ID="DDL_SPECIFICATION" runat="server" 
                        onselectedindexchanged="DDL_SPECIFICATION_SelectedIndexChanged" 
                        Class="form-control" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="PRODUCT_NAME_LBL" runat="server" Text="PRODUCT NAME"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="PRODUCT_NAME_TXTBOX" runat="server" Class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="DDL_PRODUCT_NAME" runat="server" 
                        onselectedindexchanged="DDL_PRODUCT_NAME_SelectedIndexChanged" 
                        Class="form-control" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="PRODUCT_ID_LBL" runat="server" Text="PRODUCT ID"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="PRODUCT_ID_TXTBOX" runat="server" ReadOnly="True" Class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="PRODUCT_DESCRIPTION_LBL" runat="server" Text="PRODUCT DESCRIPTION"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="PRODUCT_DESCRIPTION_TXTBOX" runat="server" TextMode="MultiLine" Class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="SELECT_IMAGE_LBL" runat="server" Text="SELECT IMAGE"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:FileUpload ID="FileUpload1" runat="server" Class="form-control"/>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="COST_LBL" runat="server" Text="COST"></asp:Label>
                </td>
                <td class="style2" colspan="2">
                    <asp:TextBox ID="COST_TXTBOX" runat="server" Class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="QUANTITY_LBL" runat="server" Text="QUANTITY"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="QUANTITY_TXTBOX" runat="server" Class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Label ID="WEIGHT_LBL" runat="server" Text="WEIGHT"></asp:Label>
                </td>
                <td colspan="2" class="style7">
                    <asp:TextBox ID="WEIGHT_TXTBOX" runat="server" Class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style5" colspan="2">
                    <asp:Button ID="RESET_PAGE_BTN" runat="server" Text="RESET PAGE" 
                        onclick="RESET_PAGE_BTN_Click" Class="btn btn-light"/>
                    <asp:Button ID="UPDATE_BTN" runat="server" Text="UPDATE" 
                        onclick="UPDATE_BTN_Click" Class="btn btn-success"/>
                    <asp:Button ID="BACK_TO_SHOPKEEPER_LOG_BTN" runat="server" Text="BACK TO SHOPKEEPER LOG" 
                        Class="btn btn-primary" onclick="BACK_TO_SHOPKEEPER_LOG_BTN_Click"/>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="USERNAME_LBL" runat="server" Text="Label"></asp:Label>
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
    </form>
</body>
</html>
