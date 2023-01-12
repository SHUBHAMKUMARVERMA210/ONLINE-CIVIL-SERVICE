using System.Data.OleDb;
using System.Configuration;
using System.Data;
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

public partial class BUY_NOW : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        string a = Request.QueryString["EMAIL_ID"];
        string b = Request.QueryString["PRODUCT_ID"];
        string nm = (string)(Session["nm"]);
        string unm = (string)(Session["a"]);
        USERNAME_LBL.Text = (string)(Session["a"]);
        LNK_BTN_My_Account.Text = nm;
        WELCOME_LBL.Visible = true;
        WELCOME_LBL.Text = "WELCOME!" + " " + nm;
        if (nm == null)
        {
            LNK_BTN_My_Account.Text = "My Account";
            WELCOME_LBL.Visible = false;
        }
        USERNAME_LBL.Visible = false;
        DATE_LBL.Visible = false;
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM BUY_NOW where USERNAME='" + a + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("insert into BUY_NOW(PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,PRODUCT_DESCRIPTION,SPECIFICATION,TYPE,CATEGORY) SELECT PRODUCT_ID,COST,WEIGHT,QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,PRODUCT_DESCRIPTION,SPECIFICATION,TYPE,CATEGORY FROM PRODUCT WHERE PRODUCT_ID='" + b + "'", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("UPDATE BUY_NOW SET USERNAME='" + unm + "',CUSTOMER_NAME='" + nm + "' WHERE PRODUCT_ID='" + b + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DATE_LBL.Text = DateTime.Today.ToString("yyyy-MM-dd");
        b = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void LNK_BTN_HOME_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        if (un == null && pwd == null)
        {
            Response.Redirect("LOGIN.aspx");
        }
        else
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM BUY_NOW WHERE USERNAME='" + un + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("PRODUCT.aspx");
        }
    }
    protected void LNK_BTN_My_Account_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        string utyp = (string)(Session["c"]);
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM BUY_NOW WHERE USERNAME='" + un + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
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
        {
            Response.Redirect("LOGIN.aspx");
        }
        con.Close();
    }
    protected void LNK_BTN_Free_Register_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM BUY_NOW WHERE USERNAME='" + un + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("CUSTOMER REGISTRATION.aspx");

        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
    protected void LNK_BTN_Cart_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM BUY_NOW WHERE USERNAME='" + un + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("CART.aspx");

        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
    protected void LNK_BTN_Log_out_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            Session.Abandon();
            WELCOME_LBL.Text = "";
            LNK_BTN_My_Account.Text = "My Account";
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM BUY_NOW WHERE USERNAME='" + un + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        else
        {
            Response.Redirect("LOGIN.aspx");
        }
        con.Close();
    }
    protected void LNK_BTN_View_Transaction_Details_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM BUY_NOW WHERE USERNAME='" + un + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("VIEW TRANSACTION.aspx");

        }
        else
        {
            Response.Redirect("LOGIN.aspx");
        }
        con.Close();
    }
    protected void Place_Order_BTN_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        string date = DateTime.Today.ToString("dd-MM-yyyy");
        if (un == null && pwd == null)
        {
            Response.Redirect("LOGIN.aspx");
        }
        else
        {
            foreach (DataListItem item in DataList1.Items)
            {
                int n = 0;
                string qty = ((TextBox)(item.FindControl("QUANTITY_TXTBOX"))).Text;
                if (qty == "")
                {
                    Response.Write("<script>alert('PLEASE ENTER QUANTITY')</script>");
                    Response.Write("<script>alert('CANNOT PROCEED')</script>");
                }
                else
                {
                    int qty1 = Convert.ToInt32(qty);
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM TRANSACT", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("UPDATE BUY_NOW SET ORDERED_QUANTITY='" + qty1 + "' WHERE USERNAME='" + un + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("UPDATE BUY_NOW SET YOUR_COST=PRODUCT_COST*(ORDERED_QUANTITY) WHERE USERNAME='" + un + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TRANSACT(USERNAME,CUSTOMER_NAME,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,UPDATED_COST) SELECT USERNAME,CUSTOMER_NAME,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,YOUR_COST FROM BUY_NOW WHERE USERNAME='" + un + "' AND ORDERED_QUANTITY>'" + n + "' UPDATE TRANSACT SET DATE_OF_TRANSACTION='" + date + "' UPDATE TRANSACT SET UPDATED_QUANTITY=PRODUCT_QUANTITY-(ORDERED_QUANTITY)", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("DELETE BUY_NOW WHERE USERNAME='" + un + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("TRANSACTION.aspx");
                }
            }
        }
    }
    protected void Cancel_BTN_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        if (un == null && pwd == null)
        {
            Response.Redirect("LOGIN.aspx");
        }
        else
        {
            con.Open();
            cmd = new SqlCommand("DELETE FROM BUY_NOW WHERE USERNAME='" + un + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("BUY NOW.aspx");
        }
    }
}