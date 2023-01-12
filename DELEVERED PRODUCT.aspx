<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DELEVERED PRODUCT.aspx.cs" Inherits="DELEVERD_PRODUCT" %>

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
            width: 2530px;
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
            width: 2530px;
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
             .style11
             {
             }
             .style15
             {
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
           <h1>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Label ID="HEADING_LBL" runat="server" Text="DELEVERED PRODUCTS DETAILS" 
                   Style="font-family:Algerian;" ForeColor="#0033CC"></asp:Label></h1>
       </div>
       <asp:Label ID="WELCOME_LBL" runat="server" Text="Label" style=" margin-top:9px;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                  
      
       <!--CLOSING OF NAVIGATION BAR-->
       <!--NAVIGATION BAR TWO-->

       <div class="topnav1">
        <asp:LinkButton ID="LNK_BTN_Log_out" runat="server" ForeColor="#000099" 
         onclick="LNK_BTN_Log_out_Click">Log out</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:LinkButton ID="LNK_BTN_Back_to_shopkeeper_log" runat="server" ForeColor="#000099"
               onclick="LNK_BTN_Back_to_shopkeeper_log_Click">Back to shopkeeper log</asp:LinkButton>
       </div>
       <br />
     <asp:Panel ID="ACTIVITY_PANEL" runat="server" Height="55px" Width="2530px" 
         BackColor="Lime" Style="margin-top:-20px">
         <br />
         &nbsp;<asp:Button ID="VIEW_DELEVERED_PRODUCT_BY_ID_BTN" runat="server" 
             Class="btn btn-light" onclick="VIEW_DELEVERED_PRODUCT_BY_ID_BTN_Click" 
             Text="VIEW DELEVERED PRODUCT BY ID" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="VIEW_DELEVERED_PRODUCT_BY_DATE_BTN" runat="server" 
             Class="btn btn-light" onclick="VIEW_DELEVERED_PRODUCT_BY_DATE_BTN_Click" 
             Text="VIEW DELEVERED PRODUCT BY DATE" />
         &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="VIEW_DELEVERED_PRODUCT_BY_ID_AND_DATE_BTN" runat="server" 
             Text="VIEW DELEVERED PRODUCT BY ID AND DATE" 
             onclick="VIEW_DELEVERED_PRODUCT_BY_ID_AND_DATE_BTN_Click" Class="btn btn-light"/>
     </asp:Panel>
     <br />
     <asp:Panel ID="VIEW_DELEVERED_PRODUCT_BY_ID_PANEL" runat="server" Height="75px">
         <table class="style10">
             <tr>
                 <td>
                     <asp:Label ID="SELECT_PRODUCT_ID_LBL" runat="server" style="font-weight: 700" 
                         Text="SELECT PRODUCT ID:-"></asp:Label>
                     <asp:DropDownList ID="DDL_PRODUCT_ID" runat="server" Class="form-control">
                     </asp:DropDownList>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="BTN_CALCULATE_BY_PRODUCT_ID" runat="server" 
                         Class="btn btn-secondary" onclick="BTN_CALCULATE_BY_PRODUCT_ID_Click" 
                         Text="CALCULATE BY PRODUCT ID" />
                     <asp:Button ID="BTN_PRINT_BY_ID" runat="server" Class="btn btn-primary" 
                         onclick="BTN_PRINT_BY_ID_Click" Text="PRINT BY ID" />
                 </td>
             </tr>
         </table>
     </asp:Panel>
     <br />
     <asp:Panel ID="VIEW_DELEVERED_PRODUCT_BY_DATE_PANEL" runat="server" Height="88px">
         <table class="style10">
             <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
                         Text="SELECT DATE FROM:-"></asp:Label>
                     <asp:TextBox ID="DATE_FROM_TXTBOX" runat="server" Class="form-control" 
                         placeholder="SELECT DATE FROM" type="Date"></asp:TextBox>
                     <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                         Text="DATE TILL:-"></asp:Label>
                     <asp:TextBox ID="DATE_TO_TXTBOX" runat="server" Class="form-control" 
                         placeholder="SELECT DATE TO"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="BTN_CALCULATE_BY_DATE" runat="server" Class="btn btn-success" 
                         onclick="BTN_CALCULATE_BY_DATE_Click" Text="CALCULATE BY DATE" />
                     <asp:Button ID="BTN_PRINT_BY_DATE" runat="server" Class="btn btn-primary" 
                         onclick="BTN_PRINT_BY_DATE_Click" Text="PRINT BY DATE" />
                 </td>
             </tr>
         </table>
     </asp:Panel>
     <table class="style10">
         <tr>
             <td class="style15">
                 <asp:Button ID="BTN_CALCULATE_BY_PRODUCT_ID_AND_DATE" runat="server" 
                     Text="CALCULATE BY PRODUCT ID AND DATE" Class="btn btn-light" 
                     onclick="BTN_CALCULATE_BY_PRODUCT_ID_AND_DATE_Click"/>
             </td>
         </tr>
         <tr>
             <td class="style11">
                 <asp:Button ID="BTN_PRINT_BY_ID_AND_DATE" runat="server" Text="PRINT BY ID AND DATE" 
                     Class="btn btn-primary" onclick="BTN_PRINT_BY_ID_AND_DATE_Click"/>
             </td>
         </tr>
         <tr>
             <td class="style11">
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style11">
                 &nbsp;</td>
         </tr>
         </table>
       
                 <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                     BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
         CellPadding="4" onrowdatabound="OnRowDataBound">
                     <RowStyle BackColor="White" ForeColor="#003399" />
                     <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                     <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                     <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                     <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 </asp:GridView>
       
     <asp:Label ID="AMT_LBL" runat="server" Text="Label"></asp:Label>
       
    </form>
</body>
</html>
