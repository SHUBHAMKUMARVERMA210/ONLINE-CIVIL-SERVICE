<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADMIN LOG.aspx.cs" Inherits="ADMIN_LOG" %>

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
    <script src="assets/js/jquery-1.12.4.js"></script>
    <script src="assets/js/jquery-ui.js"></script>

         <style type="text/css">

           /*NAVIGATION CSS*/
            
             /* Add a light blue background color to the top navigation */
.topnav {
    background-color: lightBlue;
    overflow:hidden;
    margin-top:-18px;
            height: 79px;
            width: 2630px;
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
            width: 2630px;
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

/*NAVIGATION CSS 3*/
            
             /* Add a light blue background color to the top navigation */
.topnav2 {
    background-color: Blue;
    overflow:hidden;
    margin-top:-18px;
            height: 30px;
            width: 1349px;
            margin-right: 0px;
            position : -webkit-sticky;
        }

/* Style the links inside the navigation bar */
.topnav2 a {
    float: left;
    color: Black;
    text-align: center;
    padding: 20px 20px;
    text-decoration: none;
    font-size: 17px;
    position : -webkit-sticky;
}

/* Change the color of links on hover */
.topnav2 :hover {
    background-color: LightGray;
}

/* Add a color to the active/current link */
.topnav2 a.active {
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
             .style10
             {
                 width: 100%;
             }
             .style13
             {
                 text-align: left;
             }
             .style1
       {
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
<body>
    <form id="form1" runat="server">
    <!--NAVIGATION BAR-->
        
       <div class="topnav">
       <br />
       <asp:LinkButton ID="LNK_BTN_HOME" runat="server" class="active" 
               onclick="LNK_BTN_HOME_Click"><span class="icon-home">Home</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_My_Account" runat="server" style=" margin-top:-2px;" 
               class=" icon-user" onclick="LNK_BTN_My_Account_Click" >My Account</asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Free_Register" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Free_Register_Click"><span class="icon-edit">Free Register</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Cart" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Cart_Click"><span class="icon-shopping-cart">Cart</span></asp:LinkButton>
       
       </div>
       <asp:Label ID="WELCOME_LBL" runat="server" Text="Label" style=" margin-top:9px;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                          
       <!--CLOSING OF NAVIGATION BAR-->
       <!--NAVIGATION BAR TWO-->

       <div class="topnav1">
       <asp:LinkButton ID="LNK_BTN_Log_out" runat="server" ForeColor="#000099" 
        onclick="LNK_BTN_Log_out_Click">Log out</asp:LinkButton>
       </div>
    <div>
    <br />
    
        <asp:Panel ID="ACTIVITY_PANEL" runat="server" BackColor="Lime" Height="67px" Style="margin-top:-20px" Width="2630">
        <br />
            <asp:Button ID="CALCULATE_SHOPKEEPER_TRANSACTION_BTN" runat="server" 
                Text="CALCULATE SHOPKEEPER TRANSACTION" Class="btn btn-light" 
                onclick="CALCULATE_SHOPKEEPER_TRANSACTION_BTN_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="UPDATE_CATEGORY_BTN" runat="server" Text="UPDATE CATEGORY" 
                Class="btn btn-light" onclick="UPDATE_CATEGORY_BTN_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="VERIFY_SHOPKEEPER_BTN" runat="server" 
                Text="VERIFY SHOPKEEPER"  Class="btn btn-light" 
                onclick="VERIFY_SHOPKEEPER_BTN_Click"/>
        </asp:Panel>
    <br />
        <asp:Panel ID="CALCULATE_SHOPKEEPER_TRANSACTION_PANEL" runat="server" Height="402px" Style="margin-top:-20px">
            <table class="style10">
                <tr>
                    <td class="style13">
                        <asp:Label ID="SELECT_DISTRICT_LBL" runat="server" style="font-weight: 700" 
                        Text="SELECT DISTRICT:-"></asp:Label>
                        <asp:DropDownList ID="DDL_DISTRICT" runat="server" Class="form-control" AutoPostBack="True" 
                        onselectedindexchanged="DDL_DISTRICT_SelectedIndexChanged"  Width="289px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        <asp:Label ID="SELECT_SHOPKEEPER_ID_LBL" runat="server" style="font-weight: 700" 
                        Text="SELECT SHOPKEEPER ID:-"></asp:Label>
                        <asp:DropDownList ID="DDL_SHOPKEEPER_ID" runat="server" Width="289px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        <asp:Label ID="SELECT_DATE_FROM_LBL" runat="server" style="font-weight: 700" 
                        Text="SELECT DATE FROM:-"></asp:Label>
                        <asp:TextBox ID="DATE_FROM_TXTBOX" runat="server" 
                        placeholder="SELECT DATE FROM"></asp:TextBox>
                        <asp:Label ID="SELECT_DATE_TO_LBL" runat="server" style="font-weight: 700" 
                        Text="SELECT DATE TO:-"></asp:Label>
                        <asp:TextBox ID="DATE_TO_TXTBOX" runat="server" placeholder="SELECT DATE TO"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="VIEW_BTN" runat="server" Text="VIEW " Class="btn btn-primary" 
                        onclick="VIEW_BTN_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="PRINT_BTN" runat="server" Text="PRINT" Class="btn btn-success" 
                        onclick="PRINT_BTN_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="TOTAL_COST" runat="server" Text="TOTAL COST:-" 
                        style="font-weight: 700"></asp:Label>
                        <asp:Label ID="AMOUNT" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" 
                        Text="CALCULATED AMOUNT TO BE PAID BY SHOPKEEPER:-" 
                        style="font-weight: 700"></asp:Label>
                        <asp:Label ID="CALCULATED_AMOUNT" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
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
        <br />
        <asp:Panel ID="CATEGORY_PANEL" runat="server" Height="141px">
            <table class="style1">
                <tr>
                    <td class="style1">
                        <asp:Label ID="CATEGORY_LBL" runat="server" Text="CATEGORY"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="CATEGORY_TEXTBOX" runat="server" Class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="TYPE_LBL" runat="server" Text="TYPE"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="TYPE_TXTBOX" runat="server" Class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="SPECIFICATION_LBL" runat="server" Text="SPECIFICATION"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="SPECIFICATION_TXTBOX" runat="server" Class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Button ID="SAVE_BTN" runat="server" Text="SAVE" Class=" btn btn-success" 
                        onclick="SAVE_BTN_Click"/>
                    </td>
                    <td class="style4">
                        <asp:Button ID="RESET_PAGE_BTN" runat="server" Text="RESET PAGE" 
                        Class=" btn btn-light" onclick="RESET_PAGE_BTN_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
    </div>
    </form>
</body>
</html>
