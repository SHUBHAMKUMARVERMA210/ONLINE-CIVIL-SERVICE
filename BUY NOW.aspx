<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BUY NOW.aspx.cs" Inherits="BUY_NOW" %>

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
                 width: 100%;
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
                 height: 22px;
             }

             .style11
             {
                 height: 23px;
             }

        </style>
   
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
       <asp:Label ID="WELCOME_LBL" runat="server" Text="Label" style=" margin-top:9px;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                             
      
       <!--CLOSING OF NAVIGATION BAR-->
       <!--NAVIGATION BAR TWO-->

       <div class="topnav1">
        <asp:LinkButton ID="LNK_BTN_Log_out" runat="server" ForeColor="#000099" 
               onclick="LNK_BTN_Log_out_Click">Log out</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:LinkButton ID="LNK_BTN_View_Transaction_Details" runat="server" 
           ForeColor="#000099" onclick="LNK_BTN_View_Transaction_Details_Click">View Transaction Details</asp:LinkButton>
      
       </div>
       <div>
       
           <asp:Label ID="USERNAME_LBL" runat="server" Text="Label"></asp:Label>
           <asp:Label ID="DATE_LBL" runat="server" Text="Label"></asp:Label>
       
       </div>
       <asp:AdRotator ID="AdRotator1" runat="server"  AdvertisementFile="~/XMLFile.xml" style=" margin-left:947px; margin-top:-100px" Height="800" Width="400"/>

       <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
           RepeatDirection="Horizontal" Style=" margin-top:-800px; margin-left:60px" RepeatColumns="1">
           <ItemTemplate>
               <table class="style1" border="2px">
                   <tr>
                       <td>
                           <asp:Label ID="PRODUCT_NAME_LBL" runat="server" Text='<%# Eval("PRODUCT_NAME") %>' 
                               CssClass="style8"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Image ID="PRODUCT_IMAGE_IMG" runat="server" ImageUrl='<%# Eval("PRODUCT_IMAGE") %>' Height="400" Width="900" />
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="RS_LBL" runat="server" CssClass="style6" Text="RS:"></asp:Label>
                           <asp:Label ID="PRODUCT_COST_LBL" runat="server" Text='<%# Eval("PRODUCT_COST") %>'></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="AVAILABLE_QUANTITY_LBL" runat="server" CssClass="style7" 
                               Text="AVAILABLE QUANTITY = "></asp:Label>
                           <asp:Label ID="PRODUCT_QUANTITY_LBL" runat="server" Text='<%# Eval("PRODUCT_QUANTITY") %>'></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="QUANTITY_TXTBOX" runat="server" placeholder="ENTER YOUR QUANTITY" Width="187px" BorderColor=Black></asp:TextBox>
                       </td>
                   </tr>
               </table>
           </ItemTemplate>
       </asp:DataList>
       <asp:Button ID="Place_Order_BTN" runat="server" Text="Place Order" 
           Class="btn btn-success" Style=" margin-top:10px;margin-left:350px" 
           onclick="Place_Order_BTN_Click"/>
       <asp:Button ID="Cancel_BTN" runat="server" Text="Cancel" Class="btn btn-danger" 
           Style=" margin-top:10px;margin-right:-480px" onclick="Cancel_BTN_Click"/>
       <br />
       <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" Style="  margin-top:50px;margin-left:320px" RepeatColumns="1">
           <ItemTemplate>
               <table class="style1" border="2px">
                   <tr>
                       <td class="style10">
                           <asp:Label ID="DESCRIPTION_LBL" runat="server" CssClass="style9" Text="DESCRIPTION"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="PRODUCT_DESCRIPTION_LBL" runat="server" 
                               Text='<%# Eval("PRODUCT_DESCRIPTION") %>'></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td class="style11">
                           </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="SPECIFICATION_LBL" runat="server" Text="SPECIFICATION" 
                               style="font-weight: 700"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="SPECIFICATION_LBL2" runat="server" Text='<%# Eval("SPECIFICATION") %>'></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="TYPE_LBL" runat="server" Text="TYPE" style="font-weight: 700"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="TYPE_LBL1" runat="server" Text='<%# Eval("TYPE") %>'></asp:Label>
                       </td>
                   </tr>
                    <tr>
                  <td >
                      <asp:Label ID="DEALER_NAME_LBL" runat="server" Text="DEALER NAME:-" 
                          style="font-weight: 700"></asp:Label>
                      <asp:Label ID="DEALER_NAME_LBL2" runat="server" Text='<%# Eval("SHOPKEEPER_NAME") %>'></asp:Label>
                  </td>
              </tr>
              <tr>
                 <td >
                      <asp:Label ID="LOCATION_LBL" runat="server"
                          Text="LOCATION" style="font-weight: 700"></asp:Label>
                      <br />
                      <asp:Label ID="SHOPKEEPER_DISTRICT_LBL" runat="server" 
                          Text='<%# Eval("SHOPKEEPER_DISTRICT") %>'></asp:Label>
                      ,<asp:Label ID="SHOPKEEPER_CITY_LBL" runat="server" 
                          Text='<%# Eval("SHOPKEEPER_CITY") %>'></asp:Label>
                      ,<asp:Label ID="SHOPKEEPER_TOWN_LBL" runat="server" 
                          Text='<%# Eval("SHOPKEEPER_TOWN_VILLAGE") %>'></asp:Label>
                  </td>
              </tr>
              
                   <tr>
                       <td>
                           <asp:Label ID="SHOPKEEPER_PHONE_LBL2" runat="server" style="font-weight: 700" 
                               Text="PHONE NUMBER"></asp:Label>
                           <br />
                           <asp:Label ID="SHOPKEEPER_PHONE_NUMBER_LBL" runat="server" 
                               Text='<%# Eval("SHOPKEEPER_PHONE_NUMBER") %>'></asp:Label>
                       </td>
                   </tr>
              
               </table>
           </ItemTemplate>
       </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
           ConnectionString="<%$ ConnectionStrings:MEGAPROJECTConnectionString %>" 
           SelectCommand="SELECT * FROM BUY_NOW WHERE USERNAME=@USERNAME">
    <SelectParameters>
    <asp:ControlParameter ControlID="USERNAME_LBL" Name="USERNAME" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>

       <!--CLOSING OF NAVIGATION BAR TWO-->
       
    </form>
</body>
</html>
