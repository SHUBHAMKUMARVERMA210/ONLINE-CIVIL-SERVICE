<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TRANSACTION.aspx.cs" Inherits="TRANSACTION" %>

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
              width: 100%;
          }
          .style2
          {
              width: 115px;
          }
          .style6
          {
              font-weight: 700;
          }
          .style7
          {
              font-weight: 700;
          }
          .style8
          {
              font-weight: 700;
          }
          .style9
          {
              font-weight: 700;
          }
          .style10
          {
              font-weight: 700;
          }
          .style11
          {
              font-weight: 700;
          }
          .style12
          {
              font-weight: 700;
          }
          .style13
          {
              font-weight: 700;
          }
        </style>
</head>
<body>
    <form id="form1" runat="server">
      <!--NAVIGATION BAR-->
        
       <div class="topnav">
       <br />
       <asp:LinkButton ID="LNK_BTN_HOME" runat="server" class="active" 
               style=" margin-top:-2px;" onclick="LNK_BTN_HOME_Click" >
           <span class="icon-home">Home</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_My_Account" runat="server" style=" margin-top:-2px;" 
               class=" icon-user" onclick="LNK_BTN_My_Account_Click">My Account</asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Free_Register" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Free_Register_Click"><span class="icon-edit">Free Register</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Cart" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Cart_Click"><span class="icon-shopping-cart">Cart</span></asp:LinkButton>
               
       </div>
       <asp:Label ID="WELCOME_LBL" runat="server" Text="Label"  ForeColor="Black"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:LinkButton ID="LNK_BTN_Log_out_Click" runat="server" ForeColor="#000099" 
          onclick="LNK_BTN_Log_out_Click_Click">Log out</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
       &nbsp;&nbsp;&nbsp;&nbsp;
                           
      
                
       <!--CLOSING OF NAVIGATION BAR-->

       <!--NAVIGATION BAR TWO-->

       <div class="topnav1">
       
       </div>
       <asp:AdRotator ID="AdRotator1" runat="server"  AdvertisementFile="~/XMLFile.xml" style=" margin-left:760px;" Height="800" Width="600"/>

       <!--CLOSING OF NAVIGATION BAR TWO-->
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Width="2000px" style="margin-top:-800px">
            <ItemTemplate>
                <table class="style1" border="2px">
                    <tr>
                        <td class="style2">
                            <asp:Label ID="PRODUCT_IMAGE_LBL" runat="server" Text="PRODUCT IMAGE" CssClass="style13"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TRANSACTION_ID_LBL" runat="server" Text="TRANSACTION ID" CssClass="style12"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PRODUCT_ID_LBL" runat="server" Text="PRODUCT ID" CssClass="style11"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PRODUCT_NAME_LBL" runat="server" Text="PRODUCT NAME" CssClass="style10"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PRODUCT_COST_LBL" runat="server" Text="PRODUCT COST" CssClass="style9"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PRODUCT_WEIGHT_LBL" runat="server" Text="PRODUCT WEIGHT" CssClass="style8"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="ORDERED_QUANTITY_LBL" runat="server" Text="ORDERED QUANTITY" 
                                CssClass="style7"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TRANSACTION_DATE_LBL" runat="server" Text="TRANSACTION DATE" 
                                CssClass="style6"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PRODUCT_IMAGE") %>' Height="100" Width="100" />
                        </td>
                        <td>
                            <asp:Label ID="TRANSACTION2_ID_LBL" runat="server" Text='<%# Eval("TRANSACTION_ID") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PRODUCT2_ID_LBL" runat="server" Text='<%# Eval("PRODUCT_ID") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PRODUCT2_NAME_LBL" runat="server" Text='<%# Eval("PRODUCT_NAME") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PRODUCT2_COST_LBL" runat="server" Text='<%# Eval("PRODUCT_COST") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PRODUCT2_WEIGHT_LBL" runat="server" Text='<%# Eval("PRODUCT_WEIGHT") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="ORDERED2_QUANTITY2_LBL" runat="server" Text='<%# Eval("ORDERED_QUANTITY") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="DATE_OF_TRANSACTION_LBL" runat="server" 
                                Text='<%# Eval("DATE_OF_TRANSACTION") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <asp:Label ID="TOTAL_COST_LBL" runat="server" Text="TOTAL COST:"></asp:Label>
        <asp:Label ID="COST_LBL" runat="server" Text="Label"></asp:Label>
        <br /><br /><br />
        <asp:Button ID="BTN_MAKE_PAYMENT" runat="server" Text="MAKE PAYMENT" 
            Class="btn btn-success" onclick="BTN_MAKE_PAYMENT_Click"/>
        <asp:Button ID="BTN_CANCEL" runat="server" Text="CANCEL" 
            Class="btn btn-primary" onclick="BTN_CANCEL_Click"/>
        <asp:Label ID="USERNAME_LBL" runat="server" Text="Label"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MEGAPROJECTConnectionString %>" 
            SelectCommand="SELECT * FROM [TRANSACT] WHERE ([USERNAME] = @USERNAME)">
            <SelectParameters>
            <asp:ControlParameter ControlID="USERNAME_LBL" Name="USERNAME" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    </form>
</body>
</html>
