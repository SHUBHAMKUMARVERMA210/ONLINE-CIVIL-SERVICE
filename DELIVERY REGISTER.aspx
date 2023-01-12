<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DELIVERY REGISTER.aspx.cs" Inherits="REGISTER" %>

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
        .style1
       {
           width: 115%;
       }
       .style2
       {
           width: 298px;
       }
       .style3
       {
           width: 298px;
           height: 22px;
           text-align: right;
           font-weight: bold;
       }
       .style4
       {
           height: 22px;
           text-align: left;
       }
        .style5
       {
           width: 298px;
           height: 38px;
           text-align: right;
           font-weight: bold;
       }
       .style6
       {
           height: 38px;
           text-align: left;
       }
        .style7
       {
           width: 298px;
           text-align: right;
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
<body>
    <form id="form1" runat="server">
     <div class="topnav"><br/><br />
     <asp:Label ID="Label1" runat="server" Text="REGISTER YOUR PRODUCT DELIVERY ADDRESS" class="active" style="font-size:36px; margin-left:280px; font-family:Algerian; color:Blue"></asp:Label>
     </div>
<div>
     <table class="style1" style="margin-left:80px">
         <tr>
             <td class="style7">
                 <asp:Label ID="FIRST_NAME_LBL" runat="server" Text="FIRST NAME"></asp:Label>
             </td>
             <td class="text-left">
                 <asp:TextBox ID="FIRST_NAME_TXTBOX" runat="server" Class="form-control" Width="488px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style3">
                 <asp:Label ID="LAST_NAME_LBL" runat="server" Text="LAST NAME"></asp:Label>
             </td>
             <td class="style4">
                 <asp:TextBox ID="LAST_NAME_TXTBOX" runat="server" Class="form-control" Width="488px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style3">
                 <asp:Label ID="ADDRESS_LBL" runat="server" Text="ADDRESS"></asp:Label>
             </td>
             <td class="style4">
                 <asp:TextBox ID="ADDRESS_TXTBOX" runat="server" Class="form-control" Height="90px" 
                     TextMode="MultiLine" Width="488px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style7">
                 <asp:Label ID="CITY_LBL" runat="server" Text="CITY"></asp:Label>
             </td>
             <td class="text-left">
                 <asp:TextBox ID="CITY_TXTBOX" runat="server" Class="form-control" Width="488px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style7">
                 <asp:Label ID="TOWN_STREET_LANE_LBL" runat="server" Text="TOWN/STREET/LANE"></asp:Label>
             </td>
             <td class="text-left">
                 <asp:TextBox ID="TOWN_STREET_LANE_TXTBOX" runat="server" Class="form-control" Width="488px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style3">
                 <asp:Label ID="PIN_CODE_LBL" runat="server" Text="PIN CODE"></asp:Label>
             </td>
             <td class="style4">
                 <asp:TextBox ID="PIN_CODE_TXTBOX" runat="server" Class="form-control" Width="488px" 
                     MaxLength="6"  onkeypress="CheckNumeric(event);"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td class="style4">
                    <asp:RegularExpressionValidator ID="PIN_CODE_REGULAR_EXPRESSION" runat="server" 
                        ControlToValidate="PIN_CODE_TXTBOX" 
                        ErrorMessage="INVALID PIN CODE (PIN CODE SHOULD BE OF 6 DIGITS)" 
                        ValidationExpression="\d{6}" style="font-weight: 700"></asp:RegularExpressionValidator>
             </td>
         </tr>
         <tr>
             <td class="style7">
                 <asp:Label ID="STATE_LBL" runat="server" Text="STATE"></asp:Label>
             </td>
             <td class="text-left">
                 <asp:TextBox ID="STATE_TXTBOX" runat="server" Class="form-control" Width="488px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style3">
                 <asp:Label ID="DISTRICT_LBL" runat="server" Text="DISTRICT"></asp:Label>
             </td>
             <td class="style4">
                 <asp:TextBox ID="DISTRICT_TXTBOX" runat="server" Class="form-control" Width="488px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style5">
                 <asp:Label ID="PHONE_NUMBER_LBL" runat="server" Text="PHONE NUMBER"></asp:Label>
             </td>
             <td class="style6">
                 <asp:TextBox ID="PHONE_NUMBER_TXTBOX" runat="server" Class="form-control" Width="488px" 
                     onkeypress="CheckNumeric(event);" MaxLength="10"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style5">
                 &nbsp;</td>
             <td class="style6">
                    <asp:RegularExpressionValidator ID="PHONE_NUMBER_REGULAR_EXPRESSION" runat="server" 
                        ControlToValidate="PHONE_NUMBER_TXTBOX" 
                        ErrorMessage="INVALID PHONE NUMBER FORMAT (PHONE NUMBER SHOULD BE OF 10 DIGITS)" 
                        ValidationExpression="\d{10}" style="font-weight: 700"></asp:RegularExpressionValidator>
             </td>
         </tr>
         <tr>
             <td class="style2">
                 &nbsp;</td>
             <td>
                 <asp:Button ID="PROCEED_BTN" runat="server" Text="PROCEED" 
                     Class="btn btn-success" onclick="PROCEED_BTN_Click"/>
                 <asp:Button ID="CANCEL_BTN" runat="server" Text="CANCEL" Class="btn btn-danger" 
                     onclick="CANCEL_BTN_Click"/>
             </td>
         </tr>
         <tr>
             <td class="style2">
                 <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>
     </div>
     </form>
</body>
</html>
