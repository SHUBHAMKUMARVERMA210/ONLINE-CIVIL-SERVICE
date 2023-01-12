<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CHANGE PASSWORD.aspx.cs" Inherits="CHANGE_PASSWORD" %>

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
            height: 90px;
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
            height: 40px;
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
           width: 157px;
           text-align: left;
       }
       .style2
       {
           width: 386px;
           text-align: right;
       }
       .style4
       {
           width: 224px;
       }
        .style5
       {
           width: 157px;
           text-align: center;
       }
       .style6
       {
       }
        .style7
       {
           width: 213%;
       }
        .style8
       {
           text-align: right;
       }
       .style9
       {
           text-align: left;
       }
       .style10
       {
           width: 386px;
           text-align: center;
       }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <!--NAVIGATION BAR-->
        
       <div class="topnav">
       <br />
       <h1>
           <asp:Label ID="UPDATE_YOUR_PASSWORD_LBL" runat="server" 
               Text="UPDATE YOUR PASSWORD" ForeColor="#3333FF" Style="margin-left:400px"></asp:Label></h1>
       </div>
       
       <!--CLOSING OF NAVIGATION BAR-->

       <!--NAVIGATION BAR TWO-->

       <div class="topnav1">
       
       </div>
   <br />
    <asp:Panel ID="ENTER_USERNAME_PANEL" runat="server" Style="margin-left:400px" 
        Width="567px">
        <table class="w-100">
            <tr>
                <td class="style2">
                    <asp:Label ID="ENTER_USERNAME_LBL" runat="server" Text="ENTER USERNAME :-" 
                    style="font-weight: 700"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="USERNAME_TXTBOX" runat="server" class="form-control"  
                    Width="221px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="SEND_OTP_BTN" runat="server" Text="SEND OTP" 
                    Class=" btn btn-warning" onclick="SEND_OTP_BTN_Click"/>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="YOUR_OTP_IS_HERE_LBL" runat="server" Text="YOUR OTP IS HERE :-" 
                    style="font-weight: 700"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="OTP_LBL" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br /><br />
    <asp:Panel ID="CONFIRM_OTP_PANEL" runat="server" Height="53px" 
        Style="margin-left:400px" Width="452px">
        <table class="style7">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="ENTER_OTP_LBL" runat="server" Text="ENTER YOUR OTP HERE:-" 
                        style="font-weight: 700"></asp:Label>
                    <asp:TextBox ID="ENTER_OTP_TXTBOX" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="CONFIRM_OTP_BTN" runat="server" Text="CONFIRM OTP" 
                        onclick="CONFIRM_OTP_BTN_Click" Class="btn btn-primary"/>
                </td>
            </tr>
        </table>
        &nbsp;<br />
        <br />
        <br />
        <br />
    </asp:Panel>
    <br /><br />
   
    <asp:Panel ID="NEW_PASSWORD_PANEL" runat="server" Height="103px" 
        Style="margin-left:400px" Width="726px">
        <table class="style7">
            <tr>
                <td class="style8">
                    <asp:Label ID="YOUR_USERAME_LBL" runat="server" Text="YOUR USERNAME:-" 
                        style="font-weight: 700"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="YOUR_USERNAME_TXTBOX" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Label ID="NEW_PASSWORD_LBL" runat="server" style="font-weight: 700" 
                        Text="NEW PASSWORD :-"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="NEW_PASSWORD_TXTBOX" runat="server" class="form-control" 
                        Width="221px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Label ID="CONFIRM_PASSWORD_LBL" runat="server" style="font-weight: 700" 
                        Text="CONFIRM PASSWORD :-"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="CONFIRM_PASSWORD_TXTBOX" runat="server" class="form-control" 
                        Width="221px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="UPDATE_PASSWORD_BTN" runat="server" Text="UPDATE PASSWORD" 
                        onclick="UPDATE_PASSWORD_BTN_Click" Class="btn btn-success"/>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    
   
    </form>
</body>
</html>
