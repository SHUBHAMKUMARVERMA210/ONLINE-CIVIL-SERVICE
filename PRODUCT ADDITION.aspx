<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRODUCT ADDITION.aspx.cs" Inherits="PRODUCT_ADDITION" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
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
            width: 267px;
            text-align: left;
        }
        .style2
        {
            height: 29px;
            width: 220px;
            font-weight: bold;
            text-align: right;
        }
        .style3
        {
            width: 267px;
            height: 29px;
            text-align: center;
        }
        .style4
        {
            width: 354px;
        }
        .style5
        {
            width: 354px;
            height: 29px;
        }
        .style6
        {
            width: 220px;
        }
        .style7
        {
            width: 220px;
            height: 27px;
        }
        .style8
        {
            width: 354px;
            height: 27px;
        }
        .style9
        {
            width: 267px;
            height: 27px;
        }
        .style10
        {
            width: 220px;
            height: 26px;
            text-align: right;
        }
        .style11
        {
            width: 354px;
            height: 26px;
        }
        .style12
        {
            width: 267px;
            height: 26px;
        }
        .style13
        {
            width: 282px;
            text-align: left;
        }
        .style14
        {
            width: 282px;
            height: 29px;
            text-align: center;
        }
        .style15
        {
            width: 282px;
            height: 26px;
        }
        .style16
        {
            width: 282px;
            height: 27px;
        }
        .style17
        {
            width: 282px;
            text-align: left;
            height: 26px;
        }
        .style18
        {
            width: 267px;
            text-align: left;
            height: 26px;
        }
        .style19
        {
            width: 220px;
            height: 27px;
            font-weight: bold;
            text-align: right;
        }
        .style20
        {
            width: 220px;
            font-weight: bold;
            text-align: right;
        }
        .style21
        {
            width: 220px;
            height: 26px;
            font-weight: bold;
            text-align: right;
        }
    </style>
     <script language="javascript" type="text/javascript">
         function CheckNumeric(e) {

             if (window.event)
             {
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
     <script type="text/javascript">
  $( function() {
    $( "#DATE_TXTBOX" ).datepicker(
    {
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true,
     }
    );
  } );
  </script>
   </head>
<body class=" jumbotron alert alert-primary">
    <form id="form1" runat="server">
   <div class="topnav" style="margin-top:-20px; margin-left:-22px">
       <br />
       <h1>
           <asp:Label ID="PRODUCT_ADDITION_LBL" runat="server" Text="PRODUCT ADDITION"></asp:Label></h1>
       </div>
   
    <div>
    
        <table class="table table-hover">
            <tr>
                <td class="style20">
                    <asp:Label ID="CATEGORY_LBL" runat="server" Text="CATEGORY"></asp:Label>
                </td>
                <td class="style4">
                    <asp:DropDownList ID="DDL_CATEGORY" runat="server" AutoPostBack="True" 
                        class=" form-control" 
                        onselectedindexchanged="DDL_CATEGORY_SelectedIndexChanged" TabIndex="1">
                    </asp:DropDownList>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style21">
                    <asp:Label ID="TYPE_LBL" runat="server" Text="TYPE"></asp:Label>
                </td>
                <td class="style11">
                    <asp:DropDownList ID="DDL_TYPE" runat="server" class=" form-control" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DDL_TYPE_SelectedIndexChanged" TabIndex="2" >
                    </asp:DropDownList>
                </td>
                <td class="style17">
                    &nbsp;</td>
                <td class="style18">
                    </td>
            </tr>
            <tr>
                <td class="style20">
                    <asp:Label ID="SPECIFICATION_LBL" runat="server" Text="SPECIFICATION"></asp:Label>
                </td>
                <td class="style4">
                    <asp:DropDownList ID="DDL_SPECIFICATION" runat="server" class=" form-control" 
                        AutoPostBack="True" TabIndex="3">
                    </asp:DropDownList>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="PRODUCT_ID_LBL" runat="server" Text="PRODUCT ID"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="PRODUCT_ID_TXTBOX" runat="server" ReadOnly="True" 
                        class="form-control" TabIndex="4"></asp:TextBox>
                </td>
                <td class="style14">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="PRODUCT_NAME_LBL" runat="server" Text="PRODUCT NAME"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="PRODUCT_NAME_TXTBOX" runat="server" class="form-control" 
                        TabIndex="5"></asp:TextBox>
                </td>
                <td class="style14">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="PRODUCT_DESCRIPTION_LBL" runat="server" Text="PRODUCT DESCRIPTION"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="PRODUCT_DESCRIPTION_TXTBOX" runat="server" 
                        class="form-control" TabIndex="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style14">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style20">
                    <asp:Label ID="SELECT_IMAGE_LBL" runat="server" Text="SELECT IMAGE"></asp:Label>
                </td>
                <td class="style4">
                    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" 
                        TabIndex="7" />
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style20">
                    <asp:Label ID="COST_LBL" runat="server" Text="COST"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="COST_TXTBOX" runat="server" class="form-control" 
                        onkeypress="CheckNumeric(event);" TabIndex="8"></asp:TextBox>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style20">
                    <asp:Label ID="QUANTITY_LBL" runat="server" Text="QUANTITY"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="QUANTITY_TXTBOX" runat="server" class="form-control" 
                        onkeypress="CheckNumeric(event);" TabIndex="9"></asp:TextBox>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19">
                    <asp:Label ID="WEIGHT_LBL" runat="server" Text="WEIGHT"></asp:Label>
                </td>
                <td class="style8">
                    <asp:TextBox ID="WEIGHT_TXTBOX" runat="server" class="form-control" 
                        onkeypress="CheckNumeric(event);" TabIndex="10"></asp:TextBox>
                </td>
                <td class="style16">
                    <asp:DropDownList ID="DLL_WEIGHT_TYPE" runat="server" class="form-control" 
                        TabIndex="11">
                    </asp:DropDownList>
                    </td>
                <td class="style9">
                    </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Button ID="SAVE_BTN" runat="server" Text="SAVE "  class=" btn btn-success" 
                        onclick="SAVE_BTN_Click" TabIndex="13"/>
                    <asp:Button ID="NEXT_PAGE_BTN" runat="server" Text="NEXT PAGE" class=" btn btn-primary" 
                        CausesValidation="False" onclick="NEXT_PAGE_BTN_Click" TabIndex="14"/>
                    <asp:Button ID="RESET_PAGE_BTN" runat="server" Text="RESET PAGE" 
                        class=" btn btn-light" onclick="RESET_PAGE_BTN_Click" TabIndex="15"/>
                </td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            </table>
    </div>
    <asp:Label ID="USERNAME_LBL" runat="server" Text="Label"></asp:Label>
    &nbsp;</form>
</body>
</html>
