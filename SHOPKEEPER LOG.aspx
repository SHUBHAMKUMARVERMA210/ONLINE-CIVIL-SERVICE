<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SHOPKEEPER LOG.aspx.cs" Inherits="SHOPKEEPER_LOG" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="assets/css/bootstrap.css" rel="stylesheet"/>
    <link href="style.css" rel="stylesheet"/>
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="shortcut icon" href="assets/ico/favicon.ico" />
    <link rel="stylesheet" href="assets/css/jquery-ui.css"/>
    <script src="style.css"></script>
    <script src="assets/js/jquery-1.12.4.js"/></script>
    <script src="assets/js/jquery-ui.js"/></script>

         <style type="text/css">
/*NAVIGATION CSS*/
            
             /* Add a light blue background color to the top navigation */
.topnav {
    background-color: lightBlue;
    overflow:hidden;
    margin-top:-18px;
            height: 79px;
            width: 3780px;
            margin-right: 0px;
            position : -webkit-sticky;
        }

/* Style the links inside the navigation bar */
.topnav a {
    float: left;
    color: Black;
    text-align: center;
    padding: 20px 20px;
    text-decoration: none;
    font-size: 17px;
    position : -webkit-sticky;
}

/* Change the color of links on hover */
.topnav a:hover {
    background-color: Aqua;
    color: black;
    font-size:24px;
}

/* Add a color to the active/current link */
.topnav a.active {
    background-color: #4CAF50;
    color: Black;
}


 /*NAVIGATION CSS 2*/
            
             /* Add a light blue background color to the top navigation */
.topnav1 {
    background-color: Yellow;
    overflow:hidden;
    margin-top:-20px;
            height: 45px;
            width: 3780px;
            margin-right: 0px;
            position : -webkit-sticky;
        }

/* Style the links inside the navigation bar */
.topnav1 a {
    float: left;
    color: Black;
    text-align: center;
    padding: 20px 20px;
    text-decoration: none;
    font-size: 17px;
    position : -webkit-sticky;
}

/* Change the color of links on hover */
.topnav1 a:hover {
    color: black;
    font-size:24px;
}

/* Add a color to the active/current link */
.topnav1 a.active {
    background-color: #4CAF50;
    color: Black;
}        
             .style1
             {
                 text-align: left;
                 width: 477px;
             }
             .style2
             {
                 text-align: left;
                 height: 32px;
                 width: 477px;
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
<body>
    <form id="form1" runat="server">
     <!--NAVIGATION BAR-->
        
       <div class="topnav">
       <br />
       <asp:LinkButton ID="LNK_BTN_HOME" runat="server" class="active" onclick="LNK_BTN_HOME_Click"><span class="icon-home">Home</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_My_Account" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_My_Account_Click" class=" icon-user" >My Account</asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Free_Register" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Free_Register_Click"><span class="icon-edit">Free Register</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Cart" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Cart_Click"><span class="icon-shopping-cart">Cart</span></asp:LinkButton>
               
       </div>                                
      
       <!--CLOSING OF NAVIGATION BAR-->
       <!--NAVIGATION BAR TWO-->
       <asp:Label ID="WELCOME_LBL" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
       <div class="topnav1">
       <asp:LinkButton ID="LNK_BTN_Log_out" runat="server" ForeColor="#000099" 
         onclick="LNK_BTN_Log_out_Click">Log out</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       </div>
       <br />
       
     <asp:Panel ID="ACTIVITY_PANEL" runat="server" Height="76px" Style="margin-top:-20px" 
         BackColor="Lime" Width="3780px">
         <br />
         <asp:Button ID="VIEW_PENDING_ORDERS_BTN" runat="server" 
             Text="VIEW PENDING ORDERS" Class="btn btn-light" 
             onclick="VIEW_PENDING_ORDERS_BTN_Click"/>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="UPDATE_YOUR_PRODUCTS_BTN" runat="server" 
             Text="UPDATE YOUR PRODUCTS" Class="btn btn-light" 
             onclick="UPDATE_YOUR_PRODUCTS_BTN_Click"/>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="VIEW_DELEVERED_ORDERS_BTN" runat="server" 
             Text="VIEW DELEVERED ORDERS" Class="btn btn-light" 
             onclick="VIEW_DELEVERED_ORDERS_BTN_Click"/>
     </asp:Panel>
       <br />
    <asp:Panel ID="VIEW_PENDING_ORDERS_PANEL" runat="server" Height="481px" Style="margin-top:-20px">
        <table>
            <tr>
                <td class="style1">
                    <asp:Label ID="SELECT_DATE_FROM_LBL" runat="server" Text="SELECT DATE FROM:-" 
                        style="font-weight: 700"></asp:Label>
                    <asp:TextBox ID="DATE_FROM_TXTBOX" runat="server" 
                        placeholder="SELECT DATE FROM"></asp:TextBox>
                    <asp:Label ID="SELECT_DATE_TO_LBL" runat="server" Text="SELECT DATE TO:-" 
                        style="font-weight: 700"></asp:Label>
                    <asp:TextBox ID="DATE_TO_TXTBOX" runat="server" placeholder="SELECT DATE TO"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="VIEW_BTN" runat="server" Text="VIEW" onclick="VIEW_BTN_Click" 
                     Class="btn btn-light"/>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="SELECT_BILL_ID_TO_UPDATE_LBL" runat="server" 
                     Text="SELECT BILL ID TO UPDATE:-" style="font-weight: 700"></asp:Label>
                    <asp:DropDownList ID="DDL_BILL_ID" runat="server" Class="form-control" 
                     AutoPostBack="True" 
                     onselectedindexchanged="DDL_BILL_ID_SelectedIndexChanged1">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="SELECT_STATUS_TO_UPDATE_LBL" runat="server" 
                     Text="SELECT STATUS TO UPDATE:-" style="font-weight: 700"></asp:Label>
                    <asp:DropDownList ID="DDL_STATUS" runat="server" Class="form-control">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BTN_UPDATE" runat="server" Text="UPDATE" 
                     Class="btn btn-success" onclick="BTN_UPDATE_Click1" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="SELECT_UPDATED_BILL_ID_LBL" runat="server" 
                     Text="SELECT UPDATED BILL ID TO PRINT:-" style="font-weight: 700"></asp:Label>
                    <asp:DropDownList ID="DDL_UPDATED_BILL_ID" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="PRINT_BTN" runat="server" Text="PRINT" 
                     onclick="PRINT_BTN_Click" Class="btn btn-primary"/>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" 
                     BorderStyle="None" BorderWidth="1px" CellPadding="4" 
         onrowdatabound="OnRowDataBound">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
       
     <h3><asp:Label ID="ERROR_MESSAGE_LBL" runat="server" ForeColor="Red" style="font-weight: 700" 
         Text="NO PRODUCT RECORDS BETWEEN THESE DATES"></asp:Label></h3>
       
    </form>
</body>
</html>
