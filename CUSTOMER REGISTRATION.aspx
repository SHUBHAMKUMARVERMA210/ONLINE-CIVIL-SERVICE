<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CUSTOMER REGISTRATION.aspx.cs" Inherits="CUSTOMER_REGISTRATION" %>

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
      
           /*NAVIGATION CSS*/
            
             /* Add a light blue background color to the top navigation */
.topnav {
    background-color: lightBlue;
    overflow:hidden;
    margin-top:-18px;
            height: 79px;
            width: 1349px;
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
        .style1
        {
            text-align: right;
        }
        .style2
        {
            text-align: right;
            font-weight: bold;
        }
        .style3
        {
            font-weight: bold;
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
<body  class=" jumbotron alert alert-primary">
    <form id="form1" runat="server">
    <div class="topnav" style="margin-top:-20px; margin-left:-22px">
       <br />
       <h1>
           <asp:Label ID="SHOPKEEPER_REGISTRATION_LBL" runat="server" Text="CUSTOMER REGISTRATION"></asp:Label></h1>
       </div>
    
    <div>
    
        <table class="table table-hover" style="margin-left:200px">
            <tr>
                <td class="style2">
                    <asp:Label ID="CUSTOMER_NAME_LBL" runat="server" Text="CUSTOMER NAME"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="CUSTOMER_NAME_TXTBOX" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="PASSWORD_LBL" runat="server" Text="PASSWORD"></asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="PASSWORD_TXTBOX" runat="server" class="form-control" type="Password" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="CONFIRM_PASSWORD_LBL" runat="server" Text="CONFIRM PASSWORD"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="CONFIRM_PASSWORD_TXTBOX" runat="server" class="form-control" type="Password" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="ADDRESS_LBL" runat="server" Text="ADDRESS"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="ADDRESS_TXTBOX" runat="server" class="form-control" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="PHONE_NUMBER_LBL" runat="server" Text="PHONE NUMBER"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="PHONE_NUMBER_TXTBOX" runat="server" class="form-control" 
                        onkeypress="CheckNumeric(event);" MaxLength="10"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:RegularExpressionValidator ID="PHONE_NUMBER_REGULAR_EXPRESSION" runat="server" 
                        ControlToValidate="PHONE_NUMBER_TXTBOX" 
                        ErrorMessage="INVALID PHONE NUMBER FORMAT (PHONE NUMBER SHOULD BE OF 10 DIGITS)" 
                        ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="EMAIL_LBL" runat="server" Text="EMAIL"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="EMAIL_TXTBOX" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="EMAIL_TXTBOX" ErrorMessage="INCORRECT EMAIL - ID FORMAT (REFER :- EXAMPLE &quot;ashish12@gmail.com&quot;)" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="SAVE_BTN" runat="server" Text="SAVE" class=" btn btn-success" 
                        onclick="SAVE_BTN_Click"/>
                    <asp:Button ID="RESET_PAGE_BTN" runat="server" Text="RESET PAGE" 
                        class=" btn btn-light" onclick="RESET_PAGE_BTN_Click" />
                    <asp:Button ID="BACK_TO_HOME_PAGE_BTN" runat="server" Text="BACK TO HOME PAGE" 
                        onclick="BACK_TO_HOME_PAGE_BTN_Click"  class=" btn btn-primary"/>
                </td>
                <td class="style9">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
