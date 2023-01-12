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

public partial class DESCRIPTION : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        string utyp = (string)(Session["c"]);
        if (utyp == "SHOPKEEPER")
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

        }
        else
        {
            Response.Redirect("PRODUCT.aspx");
        }
        con.Close();
    }
}