using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Web.SessionState;

public partial class CART : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        ERROR_CART_MESSAGE_LBL.Visible = false;
        DATE_LBL.Visible = false;
        string a = Request.QueryString["EMAIL_ID"];
        string b = Request.QueryString["PRODUCT_ID"];
        string nm = (string)(Session["nm"]);
        string unm = (string)(Session["a"]);
        USERNAME_LBL.Text = (string)(Session["a"]);
        LNK_BTN_My_Account.Text = nm;
        WELCOME_LBL.Visible = true;
        WELCOME_LBL.Text = "WELCOME!" + " " + nm;
        if(nm==null)
        {
            LNK_BTN_My_Account.Text = "My Account";
            WELCOME_LBL.Visible = false;
        }
        USERNAME_LBL.Visible = false;
        con.Open();
        cmd = new SqlCommand("select USERNAME,PRODUCT_ID from CART where USERNAME='" + a + "' AND PRODUCT_ID='" + b + "'", con);
        rd=cmd.ExecuteReader();
        if(rd.Read())
        {
            Response.Write("<script>alert('data inserted already')</script>");
        }
        else
       {
            con.Close();
            con.Open();
            cmd = new SqlCommand("insert into CART(PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY) Select PRODUCT_ID,COST,WEIGHT,QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY from PRODUCT where PRODUCT_ID='" + b + "'", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("update CART set USERNAME='" + unm + "',CUSTOMER_NAME='" + nm + "' where PRODUCT_ID='" + b + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        string utyp = (string)(Session["c"]);
        if (utyp == "CUSTOMER" || utyp == null)
        {
            LNK_BTN_Update_Your_Products.Visible = false;
        }
        DATE_LBL.Text = DateTime.Today.ToString("dd-MM-yyyy");
        con.Close();
        con.Open();
        cmd = new SqlCommand("SELECT SUM(YOUR_COST) FROM CART WHERE USERNAME='" + unm + "'", con);
        rd = cmd.ExecuteReader();
        rd.Read();
        string amt = rd[0].ToString();
        AMT_LBL.Text = amt;
        con.Close();
        rd.Close();
        con.Close();
        con.Close();
        con.Close();
        con.Open();
        cmd = new SqlCommand("SELECT * FROM CART WHERE USERNAME='" + unm + "' AND PRODUCT_NAME IS NOT  NULL", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

        }
        else
        {
            ERROR_CART_MESSAGE_LBL.Visible = true;
            SAVE_QUANTITY_BTN.Visible = false;
            MAKE_PAYMENT_BTN.Visible = false;
            AMT_LBL.Visible = false;
            TOTAL_COST_LBL.Visible = false;
        }
        rd.Close();
        con.Close();
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRODUCT.aspx");
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "remove")
        {
            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM CART WHERE PRODUCT_ID='" + e.CommandArgument.ToString() + "'", con);
            
            cmd1.ExecuteNonQuery();
            
            Response.Redirect("CART.aspx");
            con.Close();
        }
        
    }
    protected void LNK_BTN_HOME_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + unm + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

            Response.Redirect("PRODUCT.aspx");
        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();

    }
    protected void LNK_BTN_My_Account_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        string utyp = (string)(Session["c"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + unm + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

            if (utyp == "SHOPKEEPER")
            {
                Response.Redirect("MY ACCOUNT.aspx?USERTYPE=" + utyp);
            }
            else
            {
                Response.Redirect("MY ACCOUNT.aspx?USERTYPE=" + utyp);
            }
        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
    protected void LNK_BTN_Free_Register_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + unm + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            Response.Redirect("CUSTOMER REGISTRATION.aspx");
        }
        else
        {
            Response.Redirect("CUSTOMER REGISTRATION.aspx");
        }
        con.Close();
    }
    protected void LNK_BTN_Cart_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + unm + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

            Response.Redirect("CART.aspx");
        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
    protected void LNK_BTN_Log_out_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + unm + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

            Session.Abandon();
            WELCOME_LBL.Text = "";
            LNK_BTN_My_Account.Text = "My Account";
            Response.Redirect("CART.aspx");
        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
    protected void LNK_BTN_Update_Your_Products_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + unm + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

            Response.Redirect("PRODUCT ADDITION.aspx");
        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
    protected void SAVE_QUANTITY_BTN_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        foreach (DataListItem item in DataList1.Items)
        {
            double oq1;
            string aq = ((Label)(item.FindControl("PRODUCT_QUANTITY_LBL"))).Text;
            double aq1 = Convert.ToDouble(aq);
            string oq = ((TextBox)(item.FindControl("ORDERED_QUANTITY_TXTBOX"))).Text;
            if (oq == "")
            {
                oq1 = 0;
            }
            else
            {
                oq1 = Convert.ToDouble(oq);
                if (oq1 > aq1)
                {
                    Response.Write("<script>alert('PLEASE ENTER LOW QUANTITY')</script>");
                }
                else
                {
                    if (oq1 <= aq1 & oq1 != 0)
                    {
                        string id2 = ((Label)(item.FindControl("PRODUCT_ID_LBL"))).Text;
                        string co = ((Label)(item.FindControl("PRODUCT_COST_LBL"))).Text;
                        double co1 = Convert.ToDouble(co);
                        double mul = co1 * oq1;
                        con.Close();
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("UPDATE CART SET ORDERED_QUANTITY='" + oq1 + "',YOUR_COST='" + mul + "' WHERE PRODUCT_ID='" + id2 + "'", con);
                        cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        Response.Redirect("CART.aspx");
    }
    protected void MAKE_PAYMENT_BTN_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        string unm1 = (string)(Session["a"]);
        string date = DateTime.Today.ToString("dd-MM-yyyy");
        int n = 0;
        con.Close();
        con.Close();
        con.Open();
        cmd = new SqlCommand("DELETE FROM TRANSACT WHERE USERNAME='" + unm1 + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        con.Open();
        SqlCommand cmd1 = new SqlCommand("INSERT INTO TRANSACT(USERNAME,CUSTOMER_NAME,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,UPDATED_COST) SELECT USERNAME,CUSTOMER_NAME,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,YOUR_COST FROM CART WHERE USERNAME='" + unm + "' AND ORDERED_QUANTITY>'" + n + "' UPDATE TRANSACT SET DATE_OF_TRANSACTION='" + date + "' UPDATE TRANSACT SET UPDATED_QUANTITY=PRODUCT_QUANTITY-(ORDERED_QUANTITY),STATUS='CART'", con);
        cmd1.ExecuteNonQuery();
        con.Close();
        con.Close();
        Response.Redirect("TRANSACTION.aspx?TOTALCOST="+AMT_LBL.Text);
    }
}