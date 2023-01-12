<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SHOPKEEPER REGISTRATION.aspx.cs" Inherits="SHOPKEEPER_REGISTRATION" %>

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
            width: 134px;
        }
        .style2
        {
            width: 141px;
            text-align: left;
            font-weight: bold;
        }
        .style3
        {
            width: 145px;
        }
        .style4
        {
            width: 175px;
            text-align: right;
            font-weight: bold;
        }
        .style5
        {
            text-align: left;
        }
        .style6
        {
            text-align: left;
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
<body class=" jumbotron alert alert-primary">
    <form id="form1" runat="server">
     <div class="topnav" style="margin-top:-20px; margin-left:-22px">
       <br />
       <h1>
           <asp:Label ID="SHOPKEEPER_REGISTRATION_LBL" runat="server" Text="SHOPKEEPER REGISTRATION"></asp:Label></h1>
       </div>
    <div>
        <table  class="table table-hover">
            <tr>
                <td class="style4" >
                    <asp:Label ID="SHOPKEEPER_NAME_LBL" runat="server" Text="SHOPKEEPER NAME"></asp:Label>
                </td>
               <td class="style3"     >
                    <asp:TextBox ID="SHOPKEEPER_NAME_TXTBOX" runat="server"  class=" form-control"></asp:TextBox>
                </td>
                <td class="style2"     >
                &nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;
                    </td>
                    </tr>
                    <tr>
                <td class="style4"   >
                    <asp:Label ID="PASSWORD_LBL" runat="server" Text="PASSWORD"></asp:Label>
                </td>
                <td class="style5"      >
                    <asp:TextBox ID="PASSWORD_TXTBOX" runat="server"  class=" form-control" 
                        Type="Password" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style6"     >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4"   >
                    <asp:Label ID="CONFIRM_PASSWORD_LBL" runat="server" Text="CONFIRM PASSWORD"></asp:Label>
                </td>
                <td class="style5"      >
                    <asp:TextBox ID="CONFIRM_PASSWORD_TXTBOX" runat="server" class=" form-control" Type="Password" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td class="style6"  >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4"   >
                    <asp:Label ID="ADDRESS_LINE_1_LBL" runat="server" Text="ADDRESS LINE 1"></asp:Label>
                </td>
                <td class="style5"     >
                    <asp:TextBox ID="ADDRESS_LINE1_TXTBOX" runat="server"  class=" form-control" 
                        MaxLength="26"></asp:TextBox>
                </td>
                <td class="style6"     >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4"  >
                    <asp:Label ID="ADDRESS_LINE_2_LBL" runat="server" Text="ADDRESS LINE 2"></asp:Label>
                </td>
                <td class="style5"     >
                    <asp:TextBox ID="ADDRESS_LINE2_TXTBOX" runat="server" class=" form-control" 
                        MaxLength="26"></asp:TextBox>
                </td>
                <td class="style6"     >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="TOWN_VILLAGE_LBL" runat="server" Text="TOWN/VILLAGE"></asp:Label></td>
                <td class="style5">
                    <asp:TextBox ID="TOWN_VILLAGE_TXTBOX" runat="server" class=" form-control" ></asp:TextBox>
                </td>
                <td class="style6"     >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4"  >
                    <asp:Label ID="CITY_LBL" runat="server" Text="CITY"></asp:Label>
                </td>
                <td class="style5"     >
                    <asp:TextBox ID="CITY_TXTBOX" runat="server" class=" form-control" ></asp:TextBox>
                </td>
                <td class="style6"     >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4"  >
                    <asp:Label ID="DISTRICT_LBL" runat="server" Text="DISTRICT"></asp:Label>
                </td>
                <td class="style5"     >
                    <asp:TextBox ID="DISTRICT_TXTBOX" runat="server"  class=" form-control"></asp:TextBox>
                </td>
                <td class="style6"     >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4"  >
                    <asp:Label ID="PINCODE_LBL" runat="server" Text="PINCODE"></asp:Label>
                </td>
                <td class="style5"     >
                    <asp:TextBox ID="PINCODE_TXTBOX" runat="server" class=" form-control" 
                        onkeypress="CheckNumeric(event);" MaxLength="6"></asp:TextBox>
                </td>
                <td class="style6"     >
                    <asp:RegularExpressionValidator ID="PIN_CODE_REGULAR_EXPRESSION" runat="server" 
                        ControlToValidate="PINCODE_TXTBOX" 
                        ErrorMessage="INVALID PIN CODE (PIN CODE SHOULD BE OF 6 DIGITS)" 
                        ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style4"  >
                    <asp:Label ID="PHONE_NUMBER_LBL" runat="server" Text="PHONE NUMBER"></asp:Label>
                </td>
                <td class="style5"     >
                    <asp:TextBox ID="PHONE_NUMBER_TXTBOX" runat="server" class=" form-control" 
                        onkeypress="CheckNumeric(event);" MaxLength="10"></asp:TextBox>
                </td>
                <td class="style6"     >
                    <asp:RegularExpressionValidator ID="PHONE_NUMBER_REGULAR_EXPRESSION" runat="server" 
                        ControlToValidate="PHONE_NUMBER_TXTBOX" 
                        ErrorMessage="INVALID PHONE NUMBER FORMAT (PHONE NUMBER SHOULD BE OF 10 DIGITS)" 
                        ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style4"   >
                    <asp:Label ID="ADHAAR_NUMBER_LBL" runat="server" Text="ADHAAR NUMBER"></asp:Label>
                </td>
                <td class="style5"      >
                    <asp:TextBox ID="ADHAAR_NUMBER_TXTBOX" runat="server" class=" form-control" 
                        onkeypress="CheckNumeric(event);" MaxLength="12"></asp:TextBox>
                </td>
                <td class="style6"     >
                    <asp:RegularExpressionValidator ID="ADHAAR_NUMBER_VALIDATION_EXPRESSION" runat="server" 
                        ErrorMessage="INVALID ADHAAR NUMBER(ADHAAR NUMBER SHOULD BE OF 12 DIGITS)" 
                        ControlToValidate="ADHAAR_NUMBER_TXTBOX" ValidationExpression="\d{12}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="EMAIL_LBL" runat="server" Text="EMAIL"></asp:Label>
                </td>
                <td class="style7"      >
                    <asp:TextBox ID="EMAIL_TXTBOX" runat="server"  class=" form-control" Type="Email"></asp:TextBox>
                </td>
                <td class="style6"      >
                    <asp:RegularExpressionValidator ID="EMAIL_ID_REGULAR_EXPRESSION" runat="server" ControlToValidate="EMAIL_TXTBOX"
                        
                        ErrorMessage="INCORRECT EMAIL - ID FORMAT (REFER :- EXAMPLE &quot;ashish12@gmail.com&quot;)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style4"  >
                    <asp:Label ID="SHOP_NAME_LBL" runat="server" Text="SHOP NAME"></asp:Label>
                </td>
                <td class="style5"      >
                    <asp:TextBox ID="SHOP_NAME_TXTBOX" runat="server" class=" form-control" ></asp:TextBox>
                </td>
                <td class="style6"     >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" >
                    <asp:Label ID="SHOP_LOCATION_LBL" runat="server" Text="SHOP LOCATION"></asp:Label>
                </td>
                <td class="style7"     >
                    <asp:TextBox ID="SHOP_LOCATION_TXTBOX" runat="server"  class=" form-control" 
                        MaxLength="40"></asp:TextBox>
                </td>
                <td class="style5"     >
                    </td>
            </tr>
            <tr>
                <td class="style4"  >
                    &nbsp;</td>
                <td class="style1"     >
                    <asp:Button ID="SUBMIT" runat="server" Text="SUBMIT" onclick="SUBMIT_Click"  class=" btn btn-success"/>
                    <asp:Button ID="BACK_TO_HOME_PAGE_BTN" runat="server" Text="BACK TO HOME PAGE" 
                        CausesValidation="False"  class=" btn btn-primary" 
                        onclick="BACK_TO_HOME_PAGE_BTN_Click"/>
                    <asp:Button ID="RESET_PAGE_BTN" runat="server" Text="RESET PAGE" 
                        class=" btn btn-light" onclick="RESET_PAGE_BTN_Click"/>
                </td>
                <td class="style6"     >
                    &nbsp;&nbsp;&nbsp; 
                    </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
