<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CANCEL TRANSACTION.aspx.cs" Inherits="CANCEL_TRANSACTION" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            width: 4060px;
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
            height: 40px;
            width: 4060px;
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

            /* IMAGE CSS*/
            
            .zoom 
            {
             padding: 50px;
             background-image:url(image/1.jpg);
             transition: transform .2s; /* Animation */
             width: 200px;
             height: 200px;
             margin: 0 auto;
             }

             .zoom:hover
              {
              transform: scale(1.5); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
             }

             .style1
             {
                 width: 105%;
             }

             .style2
             {
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
       <asp:LinkButton ID="LNK_BTN_HOME" runat="server" class="active" 
               style=" margin-top:-2px;" onclick="LNK_BTN_HOME_Click" >
           <span class="icon-home">Home</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_My_Account" runat="server" style=" margin-top:-2px;" 
               class=" icon-user" onclick="LNK_BTN_My_Account_Click" >My Account</asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Free_Register" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Free_Register_Click" ><span class="icon-edit">Free Register</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Cart" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Cart_Click" ><span class="icon-shopping-cart">Cart</span></asp:LinkButton>
               
       </div>
       <asp:Label ID="WELCOME_LBL" runat="server" Text="Label" style=" margin-top:9px;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
      
       <!--CLOSING OF NAVIGATION BAR-->
       <!--NAVIGATION BAR TWO-->

       <div class="topnav1">
       <asp:LinkButton ID="LNK_BTN_Log_out" runat="server" ForeColor="#000099" 
         onclick="LNK_BTN_Log_out_Click">Log out</asp:LinkButton>
       </div>
    <div>

        <table class="style1">
            <tr>
                <td class="style2">

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="SELECT_DATE_FROM_LBL" runat="server" Text="SELECT DATE FROM:-" 
                        style="font-weight: 700"></asp:Label>

                 <asp:TextBox ID="DATE_FROM_TXTBOX" runat="server" Class="form-control" placeholder="SELECT DATE FROM" type="Date"></asp:TextBox>
                    <asp:Label ID="SELECT_DATE_TO_LBL" runat="server" Text="SELECT DATE TO:-" 
                        style="font-weight: 700"></asp:Label>
                 <asp:TextBox ID="DATE_TO_TXTBOX" runat="server" Class="form-control" placeholder="SELECT DATE TO"></asp:TextBox>
                    <asp:Button ID="VIEW_WAITING_ORDERS_BTN" runat="server" 
                        Text="VIEW WAITING ORDERS" Class="btn btn-light" 
                        onclick="VIEW_WAITING_ORDERS_BTN_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style2">

                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">

                    <asp:Label ID="SELECT_BILL_ID_TO_CANCEL_TRANSACTION_LBL" runat="server" 
                        Text="SELECT BILL ID TO CANCEL TRANSACTION:-" style="font-weight: 700"></asp:Label>

        <asp:DropDownList ID="DDL_BILL_ID" runat="server">
        </asp:DropDownList>
        <asp:Button ID="BTN_CLICK_HERE_TO_CANCEL_TRANSACTION" runat="server" 
                        Text="CLICK HERE TO CANCEL TRANSACTION" Class="btn btn-light" 
                        onclick="BTN_CLICK_HERE_TO_CANCEL_TRANSACTION_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="SELECT_CANCELLED_BILL_ID_LBL" runat="server" 
                        Text="SELECT CANCELLED BILL ID:-" style="font-weight: 700"></asp:Label>
                    <asp:DropDownList ID="DDL_CANCELLATION_ID" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="BTN_PRINT_CANCELLED_TRANSACTION" runat="server" 
                        Text="PRINT CANCELLED TRANSACTION" Class="btn btn-primary" 
                        onclick="BTN_PRINT_CANCELLED_TRANSACTION_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style2">

                    <asp:Button ID="VIEW_CANCELLED_TRANSACTION_HISTORY_BTN" runat="server" Text="VIEW CANCELLED TRANSACTION  HISTORY" 
                        Class="btn btn-success" 
                        onclick="VIEW_CANCELLED_TRANSACTION_HISTORY_BTN_Click" />
                </td>
            </tr>
            
        </table>
    </div>
    <div>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            onrowdatabound="OnRowDataBound">
        <RowStyle BackColor="White" ForeColor="#003399" />
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            </asp:GridView>
    </div>

     <h3><asp:Label ID="ERROR_MESSAGE_LBL" runat="server" 
             Text="NO WAITING ORDERS TO CANCEL" ForeColor="Red" 
             style="font-weight: 700"></asp:Label></h3>

    </form>
</body>
</html>
