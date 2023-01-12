<%@ Page Language="C#" AutoEventWireup="true" CodeFile="THANKING.aspx.cs" Inherits="THANKING" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="assets/css/bootstrap.css" rel="stylesheet"/>
    <link href="style.css" rel="stylesheet"/>
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="shortcut icon" href="assets/ico/favicon.ico" />
    <script language="javascript">
     <link rel="shortcut icon" href="assets/ico/favicon.ico" />
    </script>
    <style type="text/css">
        .text-xs-center
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="jumbotron text-xs-center" style="margin-left:280px; width: 704px;">
  <h1 class="display-3" style="color:Green">Thank You!</h1>
  <p class="lead"><strong>Please check your Transaction</strong> for the awaiting product delivery status</p>
  <hr>
  <p>
    Having trouble? <a href="">Contact us</a>
  <p class="lead">
      <asp:Button ID="Continue_to_homepage" runat="server" Text="Continue to homepage" 
          class="btn btn-primary btn-sm" onclick="Continue_to_homepage_Click" />
  </p>
  <p>
      <asp:Button ID="PRINT_TRANSACTION" runat="server" Text="PRINT YOUR CURRENT TRANSACTION" 
          class="btn btn-light btn-sm" onclick="PRINT_TRANSACTION_Click"/>
  </p>
</div>
    <div>
    <br /><br />
        &nbsp;</div>
    <asp:Label ID="TRANSACT_ID_LBL" runat="server" Text="Label" ></asp:Label>
    </form>
</body>
</html>
