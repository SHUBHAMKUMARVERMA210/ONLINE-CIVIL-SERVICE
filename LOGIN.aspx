<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LOGIN.aspx.cs" Inherits="LOGIN" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="bootstrap/js/jquery-3.3.1.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/bootstrap.js" type="text/javascript"></script>

<!--LOGIN BOX STYLE-->

<style type="text/css">
  
  body
{
	margin: 0;
	padding: 0;
	background: url(1.jpg);
	background-size: cover;
	background-position: initial;
	font-family: sans-serif;
}
.loginbox{
	width: 320px;
	height: 550px;
	background: Gray;
	color: #fff;
	margin-top:340px;
	top: 50%;
	left:50%;
	position: absolute;
	transform:translate(-50%,-50%); 
	box-sizing: border-box;
	padding: 70px 30px;
}
.avtar
{
	width: 100px;
	height: 100px;
	border-radius: 50%;
	position: absolute;
	top: -50px;
	left: calc(50% - 50px);
}

h1
{
	margin: 0;
	padding: 0 0 20px;
	text-align: center;
	font-size: 22px;
}
.loginbox p
{
	margin: 0;
	padding: 0;
	font-weight: bold;
}
.loginbox input
{
	width: 100%;
	margin-bottom: 20px;
} 
.loginbox input[type="text"], input[type="password"]
{
	border-bottom: 1px solid #fff;
	background: transparent;
	outline: none;
	height: 40px;
	color: #fff;
	font-size: 16px;
        text-align: left;
        border-left-style: none;
        border-left-color: inherit;
        border-left-width: medium;
        border-right-style: none;
        border-right-color: inherit;
        border-right-width: medium;
        border-top-style: none;
        border-top-color: inherit;
        border-top-width: medium;
    }
.loginbox input[type="select"]
{
	border: none;
	border-bottom: 1px solid #fff;
	background: transparent;
	outline: none;
	height: 40px;
	color: #fff;
	font-size: 16px;
}
.loginbox input[type="submit"]
{
	border: none;
	outline: none;
	height: 40px;
	background: #fb2525;
	color: #fff;
	font-size: 18px;
	text-align:center;
}
.loginbox input[type="submit"]:hover
{
	cursor: pointer;
	background: #ffc107;
	color:#000;
}
.loginbox a
{
	text-decoration: none;
	font-size: 12px;
	line-height: 20px;
	color: Aqua;
        text-align: center;
    }
.loginbox a:hover
{
	color:#ffc107;
	
}
     
</style>
</head>


<body class=" jumbotron alert alert-light">
    
    <div class="loginbox">
        <asp:Image ID="Image1" ImageUrl="~/image/images.jpg" runat="server" class="avtar" />
		<h1>LOGIN HERE</h1>
		<form id="form1" runat="server">
			<p>USERNAME</p>
        <asp:TextBox ID="TextBox1" runat="server" placeholder="ENTER USERNAME"></asp:TextBox>
		    <p>PASSWORD</p>
        <asp:TextBox ID="TextBox2" runat="server" type="password" 
                placeholder="ENTER PASSWORD" TextMode="Password"></asp:TextBox>
            <p>SELECT USER TYPE</p>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList><br /><br />
        <asp:Button ID="LOGIN_BTN" runat="server" Text="LOG IN" value="log" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="SIGN IN" onclick="Button2_Click" />
            <br />
       <a href="#">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:LinkButton ID="LinkButton1" runat="server" 
                onclick="LinkButton1_Click">FORGOT YOUR PASSWORD</asp:LinkButton></a>
		</form>
    </div>
</body>
</html>
