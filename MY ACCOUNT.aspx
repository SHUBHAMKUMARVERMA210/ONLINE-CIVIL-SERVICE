<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MY ACCOUNT.aspx.cs" Inherits="MY_ACCOUNT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="assets/css/bootstrap.css" rel="stylesheet"/>
    <link href="style.css" rel="stylesheet"/>
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="shortcut icon" href="assets/ico/favicon.ico" />

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
            height: 45px;
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
             .style7
             {
                 width: 826px;
                 text-align: right;
                 font-weight: bold;
             }
             .style10
             {
                 width: 431px;
                 text-align: right;
             }
             .style11
             {
                 width: 256px;
             }
             .style12
             {
                 width: 54%;
             }
             .style13
             {
                 width: 291px;
             }
             .style14
             {
                 width: 291px;
                 height: 22px;
                 text-align: right;
             }
             .style15
             {
                 height: 22px;
                 text-align: left;
             }
             .style16
             {
                 width: 431px;
                 text-align: right;
                 font-weight: bold;
             }
             .style17
             {
                 width: 291px;
                 height: 24px;
                 text-align: right;
             }
             .style18
             {
                 height: 24px;
                 text-align: left;
             }
             .style19
             {
                 text-align: left;
             }
             .style20
             {
                 width: 291px;
                 text-align: right;
             }
             .style21
             {
                 width: 100%;
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
<body>
    <form id="form1" runat="server">
    <div class="topnav" style="margin-top:-20px;">
       <br />
       <asp:LinkButton ID="LNK_BTN_HOME" runat="server" class="active" 
            style=" margin-top:-2px;" onclick="LNK_BTN_HOME_Click"><span class="icon-home">Home</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_My_Account" runat="server" style=" margin-top:-2px;" 
            class=" icon-user" onclick="LNK_BTN_My_Account_Click" >My Account</asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Free_Register" runat="server" 
            style=" margin-top:-2px;" onclick="LNK_BTN_Free_Register_Click"><span class="icon-edit">Free Register</span></asp:LinkButton>
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
       <!--CLOSING OF NAVIGATION BAR TWO-->
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="68px" BackColor="#66FF33" 
        Width="4060px" Style="margin-top:-20px">
        <br />
        <asp:Button ID="BTN_UPDATE_PASSWORD" runat="server" Text="UPDATE PASSWORD" 
        Class="btn btn-light" onclick="BTN_UPDATE_PASSWORD_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BTN_UPDATE_RECORDS" runat="server" Class="btn btn-light" 
            onclick="BTN_UPDATE_RECORDS_Click" Text="UPDATE RECORDS" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="VIEW_TRANSACTIONS_BTN" runat="server" Text="VIEW TRANSACTIONS" 
            Class="btn btn-light" onclick="VIEW_TRANSACTIONS_BTN_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="CLICK_TO_CANCEL_TRANSACTION_LOG" runat="server" 
            Text="CLICK TO CANCEL TRANSACTION LOG" Class="btn btn-light" 
            onclick="CLICK_TO_CANCEL_TRANSACTION_LOG_Click"/>
    </asp:Panel>
    <br />
    <div>
    <asp:Panel ID="RECORD_PANEL" runat="server" Height="296px" Width="852px">
        <table class="style1">
            <tr>
                <td class="style16">
                    <asp:Label ID="USER_ID_LBL" runat="server" Text="USER ID"></asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="USER_ID_TXTBOX" runat="server" ReadOnly="True" 
                        class="form-control" Width="220px"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:Label ID="CITY_LBL" runat="server" Text="CITY"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="CITY_TXTBOX" runat="server" class="form-control" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    <asp:Label ID="NAME_LBL" runat="server" Text="NAME"></asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="NAME_TXTBOX" runat="server" class="form-control" Width="220px"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:Label ID="DISTRICT_LBL" runat="server" Text="DISTRICT"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="DISTRICT_TXTBOX" runat="server" class="form-control" 
                        Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    <asp:Label ID="PHONE_NUMBER_LBL" runat="server" Text="PHONE NUMBER"></asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="PHONE_NUMBER_TXTBOX" runat="server" class="form-control" 
                        onkeypress="CheckNumeric(event);" Width="220px"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:Label ID="PIN_CODE_LBL" runat="server" Text="PIN CODE"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="PIN_CODE_TXTBOX" runat="server" class="form-control" 
                        onkeypress="CheckNumeric(event);" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    <asp:Label ID="TOWN_VILLAGE_LBL" runat="server" Text="TOWN/VILLAGE"></asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="TOWN_VILLAGE_TXTBOX" runat="server" class="form-control" 
                        Width="220px"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:Label ID="ADHAAR_NUMBER_LBL" runat="server" Text="ADHAAR NUMBER"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ADHAAR_NUMBER_TXTBOX" runat="server" class="form-control" 
                        onkeypress="CheckNumeric(event);" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td class="style7">
                    <asp:Label ID="SHOP_NAME_LBL" runat="server" Text="SHOP NAME"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="SHOP_NAME_TXTBOX" runat="server" class="form-control" 
                        Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    <asp:Label ID="ADDRESS_LBL" runat="server" Text="ADDRESS" 
                        style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="4">
                    <asp:TextBox ID="ADDRESS_TXTBOX" runat="server" MaxLength="50" 
                        TextMode="MultiLine" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="4">
                    <asp:Label ID="SHOP_LOCATION_LBL" runat="server" Text="SHOP LOCATION" 
                        style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="4">
                    <asp:TextBox ID="SHOP_LOCATION_TXTBOX" runat="server" MaxLength="50" 
                        TextMode="MultiLine" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="4">
                    <asp:Button ID="UPDATE_RECORDS_BTN" runat="server" Text="UPDATE RECORDS" 
                        class="btn btn-success" onclick="UPDATE_RECORDS_BTN_Click"/>
                    <asp:Button ID="RESET_FROM_BTN" runat="server" Text="RESET FROM" 
                        class="btn btn-light" onclick="RESET_FROM_BTN_Click"/>
                    <asp:Button ID="GO_TO_HOME_PAGE_BTN" runat="server" Text="GO TO HOME PAGE" 
                        class="btn btn-primary" onclick="GO_TO_HOME_PAGE_BTN_Click"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
        <br />
        <br />
    </div>
    <div style="width: 901px">
    
        <br />
        <br />
    
        <asp:Panel ID="PASSWORD_PANEL" runat="server" Height="155px" Width="894px">
            <table class="style12">
                <tr>
                    <td class="style17">
                        <asp:Label ID="OLD_PASSWORD_LBL" runat="server" Text="OLD PASSWORD" 
                            style="font-weight: 700"></asp:Label>
                    </td>
                    <td class="style18">
                        <asp:TextBox ID="OLD_PASSWORD_TXTBOX" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style20">
                        <asp:Label ID="NEW_PASSWORD_LBL" runat="server" Text="NEW PASSWORD" 
                            style="font-weight: 700"></asp:Label>
                    </td>
                    <td class="style19">
                        <asp:TextBox ID="NEW_PASSWORD_TXTBOX" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        <asp:Label ID="CONFIRM_PASSWORD_LBL" runat="server" Text="CONFIRM PASSWORD" 
                            style="font-weight: 700"></asp:Label>
                    </td>
                    <td class="style15">
                        <asp:TextBox ID="CONFIRM_PASSWORD_TXTBOX" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        <asp:Button ID="SAVE_PASSWORD_BTN" runat="server"  
                            Text="SAVE PASSWORD" onclick="SAVE_PASSWORD_BTN_Click" class="btn btn-success"/>
                    </td>
                    <td>
                        <asp:Button ID="RESET_BTN" runat="server" Text="RESET" class="btn btn-light" 
                            onclick="RESET_BTN_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="VIEW_TRANSACTION_PANEL" runat="server">
            <table class="style21">
                <tr>
                    <td class="style19">
                        <asp:DropDownList ID="DDL_PRODUCT_ID" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style19">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="PRINT_SAVED_TRANSACTION_BTN" runat="server" Text="PRINT" 
                            onclick="PRINT_SAVED_TRANSACTION_BTN_Click" Class="btn btn-primary"/>
                    </td>
                </tr>
                <tr>
                    <td class="style19">
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
        <br />
        </asp:Panel>
    </div>
    <p>
    <asp:Label ID="CUSTOMER_TYPE_LBL" runat="server" Text="Label"></asp:Label>
    </p>
    <h2><asp:Label ID="TRANSACTION_ERROR_LBL" runat="server" 
        Text="NO TRANSACTION HISTORY AVAILABLE" ForeColor="Red" 
        style="font-weight: 700"></asp:Label></h2>
    </form>
</body>
</html>
