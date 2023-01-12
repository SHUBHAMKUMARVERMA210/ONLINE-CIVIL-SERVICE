<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRODUCT.aspx.cs" Inherits="PRODUCT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
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
            height: 45px;
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

/*NAVIGATION CSS 3*/
            
             /* Add a blue background color to the top navigation */
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
             background-image:url('image/1.jpg');
             transition: transform .2s; /* Animation */
             width: 200px;
             height: 200px;
             margin: 0 auto;
                 font-weight: 700;
             }

             .zoom:hover
              {
              transform: scale(1.5); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
             }
             .style7
             {
                 width: 826px;
             }
             .style8
             {
                 height: 23px;
                 width: 276px;
             }
             .style9
             {
                 width: 276px;
             }
        </style>
        </head>
       <body style=" margin-left:0px;">
       <form id="form1" runat="server">

       <!--NAVIGATION BAR-->
        
       <div class="topnav" style="margin-top:-20px;">
       <br />
           <asp:DropDownList ID="DDL_CATEGORY" runat="server" Style="margin-top:10px" 
               AutoPostBack="True" 
               onselectedindexchanged="DDL_CATEGORY_SelectedIndexChanged">
           </asp:DropDownList>
       <asp:LinkButton ID="LNK_BTN_HOME" runat="server" class="active" 
               style=" margin-top:-2px;" onclick="LNK_BTN_HOME_Click" >
           <span class="icon-home">Home</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_My_Account" runat="server" style=" margin-top:-2px;" 
               class=" icon-user" onclick="LNK_BTN_My_Account_Click">My Account</asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Free_Register" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Free_Register_Click" ><span class="icon-edit">Free Register</span></asp:LinkButton>
       <asp:LinkButton ID="LNK_BTN_Cart" runat="server" style=" margin-top:-2px;" 
               onclick="LNK_BTN_Cart_Click" ><span class="icon-shopping-cart">Cart</span></asp:LinkButton>
               
       </div>
      <asp:Label ID="WELCOME_LBL" runat="server" Text="Label" style=" margin-top:9px;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 
       <!--CLOSING OF NAVIGATION BAR-->
       <!--NAVIGATION BAR TWO-->
       <div class="topnav1">
       <asp:LinkButton ID="LNK_BTN_Log_out" runat="server" ForeColor="#000099" 
           onclick="LNK_BTN_Log_out_Click">Log out</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:LinkButton ID="LNK_BTN_ADD_YOUR_PRODUCTS" runat="server"  
               ForeColor="#000099" onclick="LNK_BTN_ADD_YOUR_PRODUCTS_Click">Add Your Products</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:LinkButton ID="LNK_BTN_Shopkeeper_Log" runat="server" ForeColor="#000099" 
           onclick="LNK_BTN_Shopkeeper_Log_Click">Shopkeeper Log</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:LinkButton ID="LNK_BTN_Admin_Log" runat="server" ForeColor="#000099" 
           onclick="LNK_BTN_Admin_Log_Click">Admin Log</asp:LinkButton>
       </div>
       <!--CLOSING OF NAVIGATION BAR TWO-->
       <!--CATEGORY-->
       <div class="style7">
        <!--NAVIGATION BAR THREE-->
       <div class="topnav2" style=" margin-top:0px;">
             <asp:DropDownList ID="DDL_TYPE" runat="server" AutoPostBack="True">
           </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:DropDownList ID="DDL_SPECIFICATION" runat="server" AutoPostBack="True">
           </asp:DropDownList>
       </div>
       <!--CLOSING OF NAVIGATION BAR THREE-->
       
        <asp:AdRotator ID="AdRotator1" runat="server"  AdvertisementFile="~/XMLFile.xml" style=" margin-left:1063px; margin-top:-100px" Height="800" Width="286"/>
    
       
  <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
        RepeatColumns="4" onitemcommand="DataList1_ItemCommand" BorderColor="Black" 
                RepeatDirection="Horizontal"  Style=" margin-top:-800px;" 
               CellSpacing="-1">
      <ItemTemplate>
          <table class="table-hover table-success" border="2" bgcolor="#666666">
              <tr>
                  <td class="style8">
                      <asp:Label ID="PRODUCT_NAME_LBL" runat="server" Text='<%# Eval("PRODUCT_NAME") %>'></asp:Label>
                      &nbsp;<asp:Label ID="PRODUCT_ID_LBL" runat="server" Text='<%# Eval("PRODUCT_ID") %>' 
                          Visible="False" class="zoom"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="style9">
                  <div class=" thumbnail">
                      <a class="zoomTool" title="decription"><span class="icon-search"></span> QUICK VIEW </a>
                      <asp:ImageButton ID="ImageButton1"  runat="server" Height="222px" Width="181px" 
                          CommandName="buynow" ImageUrl='<%# Eval("PRODUCT_IMAGE") %>' 
                          CssClass=" icon-search"  CommandArgument='<%# Eval("PRODUCT_NAME") %>' 
                          onclick="ImageButton1_Click" />
                 </div>
                  </td>
              </tr>
              <tr>
                  <td class="style9"> 
                      <asp:Label ID="Rs_LBL" runat="server" Text="Rs." style="font-weight: 700"></asp:Label>
                      <asp:Label ID="COST_LBL" runat="server" Text='<%# Eval("COST") %>'></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="style9">
                      <asp:Label ID="WEIGHT_LBL" runat="server" Text='<%# Eval("WEIGHT") %>'></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="style9">
                      <asp:Label ID="DEALER_NAME_LBL" runat="server" Text="DEALER NAME:-" 
                          style="font-weight: 700"></asp:Label>
                      <asp:Label ID="DEALER_NAME_LBL2" runat="server" Text='<%# Eval("SHOPKEEPER_NAME") %>'></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="style9">
                      <asp:Label ID="LOCATION_LBL" runat="server" style="font-weight: 700" 
                          Text="LOCATION"></asp:Label>
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
                  <td class="style9">
                      <asp:Button ID="BTN_Buy_now" runat="server" Text="Buy now" class="btn btn-success" 
                           CommandName="buy_now" CommandArgument='<%# Eval("PRODUCT_ID") %>' />
                      <asp:Button ID="BTN_Add_to_cart" runat="server" Text="Add to cart" 
                          class="btn btn-primary" CommandName="cart" 
                          CommandArgument='<%# Eval("PRODUCT_ID") %>' />
                  </td>
              </tr>
          </table>
      </ItemTemplate>
        </asp:DataList>
        </div>
       <!--CLOSING OF DATALIST-->
       <div>
        <!--ADVERTISEMENT ROATATOR-->
       <!--CLOSING OF ADVERTISEMENT ROTATOR-->
       </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:MEGAPROJECTConnectionString %>" 
        SelectCommand="SELECT * FROM [PRODUCT] WHERE QUANTITY!=''">
        </asp:SqlDataSource>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
<!-- well-->
<!--row -->
<!-- Clients -->

<!--Footer-->

<!-- GO TO TOP BUTTON -->
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><button runat="server" onclick="topFunction()"  id="myBtn" title="Go to top" class="btn btn-primary"><i class=" icon-double-angle-up">&nbsp;&nbsp;&nbsp;&nbsp;<br />click to go to top</i></button>
       
<script type="text/javascript">
    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            document.getElementById("myBtn").style.display = "block";
        } else {
            document.getElementById("myBtn").style.display = "none";
        }
    }
    function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }
</script>
    <script src="assets/js/jquery.js" type="text/jscript"></script>
	<script src="assets/js/bootstrap.min.js" type="text/jscript"></script>
	<script src="assets/js/jquery.easing-1.3.min.js" type="text/jscript"></script>
    <script src="assets/js/jquery.scrollTo-1.4.3.1-min.js" type="text/jscript"></script>
    <script src="assets/js/shop.js" type="text/jscript"></script>
    </form>
    </body>
</html>
