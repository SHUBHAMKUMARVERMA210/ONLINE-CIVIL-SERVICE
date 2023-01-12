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

public partial class TRANSACTION : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        USERNAME_LBL.Text = un;
        USERNAME_LBL.Visible = false;
        string pwd = (string)(Session["b"]);
        string utyp = (string)(Session["c"]);
        if(utyp=="SHOPKEEPER")
        {
        con.Open();
        cmd = new SqlCommand("select * from SHOPKEEPER where EMAIL='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            WELCOME_LBL.Text = "WELCOME!" + " " + rd[1].ToString();
            LNK_BTN_My_Account.Text = rd[1].ToString();
            Session["nm"] = rd[1].ToString();

        }
             else
            WELCOME_LBL.Text = " ";
        con.Close();
        }
        else if (utyp == "CUSTOMER")
        {
            con.Open();
            cmd = new SqlCommand("select * from CUSTOMER where EMAIL_ID='" + un + "'", con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                WELCOME_LBL.Text = "WELCOME!" + " " + rd[1].ToString();
                LNK_BTN_My_Account.Text = rd[1].ToString();
                Session["nm"] = rd[1].ToString();

            }
            else
                WELCOME_LBL.Text = " ";
            con.Close();
        }
        else if (utyp == "ADMIN")
        {
            WELCOME_LBL.Text = "WELCOME!" + " " + "ADMIN";
            LNK_BTN_My_Account.Text = "ADMIN";
            Session["nm"] = "ADMIN";
        }
        else
            WELCOME_LBL.Text = " ";
        con.Close();
        con.Open();
        cmd = new SqlCommand("SELECT SUM(UPDATED_COST) FROM TRANSACT WHERE USERNAME='"+un+"'",con);
        rd = cmd.ExecuteReader();
        rd.Read();
        string amount = rd[0].ToString();
        COST_LBL.Text = amount;
        rd.Close();
        con.Close();
    }
    protected void LNK_BTN_My_Account_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string utyp = (string)(Session["c"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

            cmd = new SqlCommand("DELETE FROM TRANSACT WHERE USERNAME='" + un + "'", con);
            rd.Close();
            cmd.ExecuteNonQuery();
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
        string un = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            cmd = new SqlCommand("DELETE FROM TRANSACT WHERE USERNAME='" + un + "'", con);
            rd.Close();
            cmd.ExecuteNonQuery();
            Response.Redirect("CUSTOMER REGISTRATION.aspx");

        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
    protected void LNK_BTN_Cart_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            cmd = new SqlCommand("DELETE FROM TRANSACT WHERE USERNAME='" + un + "'", con);
            rd.Close();
            cmd.ExecuteNonQuery();
            Response.Redirect("CART.aspx");

        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
    protected void LNK_BTN_Log_out_Click_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        Response.Write("<script>alert('ARE YOU SURE YOU WANT TO LOG OUT')</script>");
        Response.Write("<script>alert('THE CURRENT TRANSACTION WILL BE CLOSED AND REMOVED')</script>");
        if (rd.Read())
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM TRANSACT WHERE USERNAME='" + un + "'", con);
            rd.Close();
            cmd.ExecuteNonQuery();
            con.Close();
            Session.Abandon();
            WELCOME_LBL.Text = "";
            LNK_BTN_My_Account.Text = "My Account";

        }
        else
            Response.Redirect("LOGIN.aspx");
       
    }
    protected void BTN_MAKE_PAYMENT_Click(object sender, EventArgs e)
    {
        Response.Redirect("DELIVERY REGISTER.aspx");
    }
    protected void BTN_CANCEL_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        con.Open();
        cmd = new SqlCommand("DELETE FROM TRANSACT WHERE USERNAME='" + unm + "'", con);
        cmd.ExecuteNonQuery();
        Response.Redirect("PRODUCT.aspx");
        con.Close();
    }
    protected void LNK_BTN_HOME_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        con.Close();
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

            cmd = new SqlCommand("DELETE FROM TRANSACT WHERE USERNAME='" + un + "'", con);
            rd.Close();
            cmd.ExecuteNonQuery();
            Response.Redirect("PRODUCT.aspx");
        }
        else
            Response.Redirect("LOGIN.aspx");
        con.Close();
    }
}
 