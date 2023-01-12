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

public partial class PRODUCT : System.Web.UI.Page
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
        if (utyp=="SHOPKEEPER")
        {
        con.Open();
        cmd = new SqlCommand("select * from SHOPKEEPER where EMAIL='"+un+"'",con);
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
                LNK_BTN_Shopkeeper_Log.Visible = false;
        }
        else
            WELCOME_LBL.Text = " ";
        if(utyp=="CUSTOMER"|| utyp==null)
        {
            LNK_BTN_Shopkeeper_Log.Visible = false;
            LNK_BTN_Admin_Log.Visible = false;
        }
        if (utyp == "SHOPKEEPER" || utyp == null)
        {
            LNK_BTN_Admin_Log.Visible = false;
        }
        if (!IsPostBack)
        {
            cmd = new SqlCommand("select DISTINCT CATEGORY from PRODUCT ", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_CATEGORY.DataSource = ds;
                DDL_CATEGORY.DataValueField = "CATEGORY";
                DDL_CATEGORY.DataBind();
                DDL_CATEGORY.Items.Insert(0, new ListItem("CHOOSE CATEGORY NAME", "0"));
                DDL_TYPE.Items.Insert(0, new ListItem("TYPE NOT AVAILABLE", "0"));
                DDL_SPECIFICATION.Items.Insert(0, new ListItem("SPECIFICATION NOT AVAILABLE", "0"));
                DDL_CATEGORY.SelectedIndex = 0;
            }
            else
            {
                DDL_CATEGORY.Items.Insert(0, "CATEGORY NOT AVAILABLE");
                DDL_CATEGORY.DataBind();
            }

        }
    }
   
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "buynow")
        {
            Response.Redirect("DESCRIPTION.aspx?nm=" + e.CommandArgument.ToString());
        }
        if (e.CommandName == "cart")
        {
            string un = (string)(Session["a"]);
            string pwd = (string)(Session["b"]);
            con.Open();
            cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {

                Response.Redirect("CART.aspx?PRODUCT_ID=" + e.CommandArgument.ToString() + "&EMAIL_ID=" + un);
            }
            else
                Response.Redirect("LOGIN.aspx");
            con.Close();

            
        }
        if (e.CommandName == "buy_now")
        {
            string un = (string)(Session["a"]);
            string pwd = (string)(Session["b"]);
            con.Open();
            cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {

                Response.Redirect("BUY NOW.aspx?PRODUCT_ID=" + e.CommandArgument.ToString() + "&EMAIL_ID=" + un);
            }
            else
                Response.Redirect("LOGIN.aspx");
            con.Close();


        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        con.Open();
        cmd = new SqlCommand("select * from LOGIN_1 where EMAIL_ID='" + un + "'", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            

        }
        else
        {
            Response.Redirect("LOGIN.aspx");
        }
        con.Close();
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
            Response.Redirect("LOGIN.aspx");
        }
        con.Close();
        
    }
    protected void LNK_BTN_Shopkeeper_Log_Click(object sender, EventArgs e)
    {
        Response.Redirect("SHOPKEEPER LOG.aspx");
    }
    protected void LNK_BTN_Admin_Log_Click(object sender, EventArgs e)
    {
        Response.Redirect("ADMIN LOG.aspx");
    }
    protected void DDL_CATEGORY_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_CATEGORY.SelectedItem.ToString() != "0")
        {
            Response.Redirect("PRODUCT2.aspx?a1=" + DDL_CATEGORY.SelectedItem.ToString());
        }
        else
        {
            DDL_TYPE.Items.Insert(0, "TYPE NOT AVAILABLE");
        }
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
    protected void LNK_BTN_ADD_YOUR_PRODUCTS_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        string utyp = (string)(Session["c"]);
        con.Close();
        con.Open();
            cmd = new SqlCommand("SELECT * FROM LOGIN_1 WHERE EMAIL_ID='" + un + "' AND PASSWORD='" + pwd + "' AND USER_TYPE='" + utyp + "' AND STATUS='VERIFIED'", con);
            rd = cmd.ExecuteReader();
            if (rd.Read() & utyp == "SHOPKEEPER")
            {
                Response.Redirect("PRODUCT ADDITION.aspx");
            }
        else
        {
            Response.Redirect("SHOPKEEPER REGISTRATION.aspx");
        }
        rd.Close();
        con.Close();
    }
}