<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PAYMENT.aspx.cs" Inherits="PAYMENT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            height: 180px;
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


 /*NAVIGATION CSS 2*/
            
             /* Add a light blue background color to the top navigation */
.topnav1 {
    background-color: Yellow;
    overflow:hidden;
    margin-top:-20px;
            height: 30px;
            width: 1349px;
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
    background-color: Aqua;
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
        .style8
       {
           width: 100%;
       }
       .style9
       {
           width: 408px;
       }
       .style10
       {
           width: 408px;
           text-align: right;
       }
       .style11
       {
           width: 408px;
           text-align: right;
           height: 42px;
       }
       .style12
       {
           text-align: left;
           height: 42px;
       }
        .style13
       {
           width: 408px;
           height: 30px;
       }
       .style14
       {
           height: 30px;
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
    <div class="topnav"><br/><br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/image/creditcards.jpg" 
            Height="140px" Width="1348px" />
     </div>
    <div><br />
        <table class="style8" style="margin-left:80px" >
            <tr>
                <td class="style10">
                    <asp:Label ID="CARD_NUMBER_LBL" runat="server" Text="CARD NUMBER" 
                        style="font-weight: 700" ></asp:Label>
                </td>
                <td class="text-left">
                    <asp:TextBox ID="CARD_NUMBER_TXTBOX" runat="server" MaxLength="16" Width="440px" onkeypress="CheckNumeric(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="PIN_LBL" runat="server" Text="PIN" style="font-weight: 700"></asp:Label>
                </td>
                <td class="text-left">
                    <asp:TextBox ID="PIN_TXTBOX" runat="server" MaxLength="4" Width="440px" 
                        TextMode="Password" onkeypress="CheckNumeric(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="CARD_HOLDERS_NAME_LBL" runat="server" Text="CARD HOLDERS NAME" 
                        style="font-weight: 700"></asp:Label>
                </td>
                <td class="text-left">
                    <asp:TextBox ID="CARD_HOLDERS_NAME_TXTBOX" runat="server" Width="440px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="EXPIRY_DATE_LBL" runat="server" Text="EXPIRY DATE" 
                        style="font-weight: 700"></asp:Label>
                </td>
                <td class="text-left">
                    <asp:DropDownList ID="DDL_EXP_DATE" runat="server" Width="220px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DDL_EXP_YEAR" runat="server" Width="220px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="CARD_TYPE_LBL" runat="server" Text="CARD TYPE" 
                        style="font-weight: 700"></asp:Label>
                </td>
                <td class="style12">
                    <asp:DropDownList ID="DDL_CARD_TYPE" runat="server" Width="440px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style14">
                    <asp:Button ID="PAY_BTN" runat="server" Text="PAY" Class="btn btn-success" 
                        onclick="PAY_BTN_Click"/>
                    <asp:Button ID="CANCEL_BTN" runat="server" Text="CANCEL" 
                        Class="btn btn-primary" onclick="CANCEL_BTN_Click" />
                   <asp:Button ID="RESET_PAGE_BTN" runat="server" Text="RESET PAGE" 
                        Class="btn btn-light" onclick="RESET_PAGE_BTN_Click"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
     <asp:Label ID="BILL_ID_LBL" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="AMOUNT_LBL" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
