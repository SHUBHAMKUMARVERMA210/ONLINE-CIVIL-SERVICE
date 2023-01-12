<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CART.aspx.cs" Inherits="CART" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/css/bootstrap.css" rel="stylesheet"/>
    <link href="style.css" rel="stylesheet"/>
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="shortcut icon" href="assets/ico/favicon.ico" />
    
    <!--STYLESHEET-->

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
    margin-top:-18px;
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
            width: 30px;
        }
                  
        .style12
        {
            font-weight: 700;
        }
                  
        .style13
        {
            font-weight: 700;
        }
        .style14
        {
            font-weight: 700;
        }
        .style15
        {
            font-weight: 700;
        }
                  
        .style16
        {
            width: 166px;
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
     
                <!--NAVIGATION BAR-->
        
       <div class="topnav">
       <br />
       <asp:LinkButton ID="LNK_BTN_HOME" runat="server" class="active" 
               style=" margin-top:-2px;" onclick="LNK_BTN_HOME_Click">
           <span class="icon-home">Home</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_My_Account" runat="server" style=" margin-top:-2px;" 
               class=" icon-user" onclick="LNK_BTN_My_Account_Click">My Account</asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Free_Register" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Free_Register_Click"><span class="icon-edit">Free Register</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Cart" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Cart_Click"><span class="icon-shopping-cart">Cart</span></asp:LinkButton>
               
       </div>
       <asp:Label ID="WELCOME_LBL" runat="server" Text="Label"  ForeColor="Black"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;             
      
                
       <!--CLOSING OF NAVIGATION BAR-->

       <!--NAVIGATION BAR TWO-->

       <div class="topnav1" style=" margin-top:-20px;">
       <asp:LinkButton ID="LNK_BTN_Log_out" runat="server" ForeColor="#000099" 
                    onclick="LNK_BTN_Log_out_Click">Log out</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:LinkButton ID="LNK_BTN_Update_Your_Products" runat="server" ForeColor="#000099" 
                    onclick="LNK_BTN_Update_Your_Products_Click">Update Your Products</asp:LinkButton>
       
       </div>
       <asp:AdRotator ID="AdRotator1" runat="server"  AdvertisementFile="~/XMLFile.xml" style=" margin-left:890px;" Height="800" Width="459"/>

       <!--CLOSING OF NAVIGATION BAR TWO-->
      
       
                
                
                
			                   
                               <div  style=" margin-top:110px; margin-top:-800px">
                                   <asp:DataList ID="DataList1" runat="server" CellPadding="10" CellSpacing="10" 
                                       GridLines="Horizontal" Width="991px" DataSourceID="SqlDataSource1" 
                                       DataKeyField="PRODUCT_ID" onitemcommand="DataList1_ItemCommand">
                                       <ItemTemplate>
                                           <table class="style1" border="2px">
                                               <tr>
                                                   <td class="style3">
                                                       <asp:Label ID="PRODUCT_ID_LBL_2" runat="server" CssClass="style13" Text="PRODUCT ID"></asp:Label>
                                                   </td>
                                                   <td class="style16">
                                                       <asp:Label ID="PRODUCT_LBL" runat="server" CssClass="style6" Text="PRODUCT"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="PRODUCT_NAME_LBL_2" runat="server" Text="PRODUCT NAME" CssClass="style7"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="COST_LBL" runat="server" Text="COST" CssClass="style8"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="AVAILABLE_QUANTITY_LBL" runat="server" CssClass="style12" 
                                                           Text="AVAILABLE QUANTITY"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="ORDERED_QUANTITY_LBL_2" runat="server" CssClass="style14" 
                                                           Text="ORDERED QUANTITY"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="QUNTITY_LBL" runat="server" Text="QUNTITY" CssClass="style9"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="WEIGHT_LBL" runat="server" Text="WEIGHT" CssClass="style10"></asp:Label>
                                                   </td>
                                                   
                                                   <td>
                                                       <asp:Label ID="YOUR_COST_LBL_2" runat="server" CssClass="style15" Text="YOUR COST"></asp:Label>
                                                   </td>
                                                   
                                                   <td class="style11">
                                                       &nbsp;</td>
                                                   
                                               </tr>
                                               <tr>
                                                   <td class="style3">
                                                       <asp:Label ID="PRODUCT_ID_LBL" runat="server" Text='<%# Eval("PRODUCT_ID") %>'></asp:Label>
                                                   </td>
                                                   <td class="style16">
                                                       <asp:Image ID="PRODUCT_IMAGE_IMG_BTN" runat="server" Height="150" 
                                                           ImageUrl='<%# Eval("PRODUCT_IMAGE") %>' Width="150" />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="PRODUCT_NAME_LBL" runat="server" Text='<%# Eval("PRODUCT_NAME") %>'></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="PRODUCT_COST_LBL" runat="server" Text='<%# Eval("PRODUCT_COST") %>'></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="PRODUCT_QUANTITY_LBL" runat="server" Text='<%# Eval("PRODUCT_QUANTITY") %>'></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="ORDERED_QUANTITY_LBL" runat="server" Text='<%# Eval("ORDERED_QUANTITY") %>'></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:TextBox ID="ORDERED_QUANTITY_TXTBOX" runat="server" 
                                                           Text='<%# Eval("ORDERED_QUANTITY") %>' onkeypress="CheckNumeric(event);"></asp:TextBox>
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="PRODUCT_WEIGHT_LBL" runat="server" Text='<%# Eval("PRODUCT_WEIGHT") %>'></asp:Label>
                                                   </td>
                                                   
                                                   <td>
                                                       <asp:Label ID="YOUR_COST_LBL" runat="server" Text='<%# Eval("YOUR_COST") %>'></asp:Label>
                                                   </td>
                                                   
                                                   <td class="style11">
                                                       <asp:Button ID="BTN_REMOVE" runat="server" CommandName="remove" Text="REMOVE" 
                                                           CommandArgument='<%# Eval("PRODUCT_ID") %>' />
                                                   </td>
                                                   
                                               </tr>
                                           </table>
                                       </ItemTemplate>
                                   </asp:DataList>
                                   <asp:Label ID="TOTAL_COST_LBL" runat="server" Text="TOTAL COST:" style=" margin-left:68%; font-size:larger;"></asp:Label>
                                   <asp:Label ID="AMT_LBL" runat="server" Text="Label" style="font-size:larger;"></asp:Label>
                                   <br />
                                   <asp:Button ID="SAVE_QUANTITY_BTN" runat="server" Text="SAVE QUANTITY" CommandName="transaction" 
                                       CommandArgument='<%# Eval("PRODUCT_ID") %>' Class="btn btn-success" 
                                       onclick="SAVE_QUANTITY_BTN_Click"/>
                             
                                   &nbsp;<asp:Button ID="MAKE_PAYMENT_BTN" runat="server" Text="MAKE PAYMENT" 
                                       Class="btn btn-primary" onclick="MAKE_PAYMENT_BTN_Click"/>
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             
                                   <br />
                             
                                   <br />
                             
                                  <h1 style="margin-left:120px; width: 679px;"><asp:Label ID="ERROR_CART_MESSAGE_LBL" runat="server" 
                                       Text="NO PRODUCTS ADDED TO CART" ForeColor="Red" style="font-weight: 700"></asp:Label></h1> 
                                       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:MEGAPROJECTConnectionString %>" 
                                       SelectCommand="SELECT * FROM [CART] WHERE ([USERNAME] = @USERNAME)">
       <SelectParameters>
       <asp:ControlParameter ControlID="USERNAME_LBL" Name="USERNAME" PropertyName="Text" />
       </SelectParameters>
        </asp:SqlDataSource>
                                   <br />
                                   <br />
                                   <asp:Label ID="USERNAME_LBL" runat="server" Text="Label"></asp:Label>
                                   &nbsp;<asp:Label ID="DATE_LBL" runat="server" Text="Label"></asp:Label>
                                   <br />
                                   <br />
                                   <br />
                                   <br />
                                   <br />
                                   <br />
                                   <br />
    </div>
    </form>
</body>
</html>
