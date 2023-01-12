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
public partial class CANCEL_TRANSACTION : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlCommand cmd1;
    SqlDataReader rd;
    SqlDataReader rd1;
    SqlDataAdapter da;
    SqlDataAdapter da1;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        ERROR_MESSAGE_LBL.Visible = false;
        string a = Request.QueryString["EMAIL_ID"];
        string b = Request.QueryString["PRODUCT_ID"];
        string nm = (string)(Session["nm"]);
        string unm = (string)(Session["a"]);
        LNK_BTN_My_Account.Text = nm;
        WELCOME_LBL.Visible = true;
        WELCOME_LBL.Text = "WELCOME!" + " " + nm;
        if (nm == null)
        {
            LNK_BTN_My_Account.Text = "My Account";
            WELCOME_LBL.Visible = false;
        }
        string un = (string)(Session["a"]);
        if (!IsPostBack)
        {
            cmd = new SqlCommand("select DISTINCT BILL_ID FROM TRANSACT_1 WHERE USERNAME='" + un + "' AND STATUS='WAITING'", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_BILL_ID.DataSource = ds;
                DDL_BILL_ID.DataValueField = "BILL_ID";
                DDL_BILL_ID.DataBind();
                DDL_BILL_ID.Items.Insert(0, new ListItem("CHOOSE BILL ID", "0"));
            }
            else
            {
                DDL_BILL_ID.Items.Insert(0, "TRANSACTION ID NOT AVAILABLE");
                DDL_BILL_ID.DataBind();
            }
        }
        if (!IsPostBack)
        {
            cmd1 = new SqlCommand("select DISTINCT BILL_ID FROM TRANSACT_1 WHERE USERNAME='" + un + "' AND STATUS='CANCELLED'", con);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                DDL_CANCELLATION_ID.DataSource = ds1;
                DDL_CANCELLATION_ID.DataValueField = "BILL_ID";
                DDL_CANCELLATION_ID.DataBind();
                DDL_CANCELLATION_ID.Items.Insert(0, new ListItem("CHOOSE CANCELLATION ID", "0"));
            }
            else
            {
                DDL_CANCELLATION_ID.Items.Insert(0, "CANCELLATION ID NOT AVAILABLE");
                DDL_CANCELLATION_ID.DataBind();
            }
        }
        con.Close();
        con.Open();
        SqlCommand cmd4 = new SqlCommand("select  USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_TYPE,CARD_HOLDERS_NAME,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE USERNAME='" + un + "'AND STATUS='WAITING'", con);
        SqlDataAdapter da4;
        da4 = new SqlDataAdapter(cmd4);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        GridView1.DataSource = ds4.Tables[0];
        GridView1.DataBind();
        con.Close();
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
        {
            Response.Redirect("LOGIN.aspx");
        }
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
        {
            Response.Redirect("LOGIN.aspx");
        }
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
    }
    protected void BTN_CLICK_HERE_TO_CANCEL_TRANSACTION_Click(object sender, EventArgs e)
    {
        if (DDL_BILL_ID.SelectedItem.ToString() == "TRANSACTION ID NOT AVAILABLE")
        {
            Response.Write("<script>alert('TRANSACTION NOT AVAILABLE')</script>");
            Response.Write("<script>alert('PLEASE LOGIN WITH RESPECTIVE ID')</script>");
        }
        else
        {
            if (DDL_BILL_ID.SelectedItem.ToString() == "CHOOSE BILL ID")
            {
                Response.Write("<script>alert('PLEASE SELECT A TRANSACTION ID')</script>");
            }
            else
            {
                int a = Convert.ToInt32(DDL_BILL_ID.SelectedItem.ToString());
                con.Open();
                cmd = new SqlCommand("UPDATE P SET P.QUANTITY=P.QUANTITY+(T.ORDERED_QUANTITY) FROM PRODUCT P INNER JOIN TRANSACT_1 T ON T.PRODUCT_ID=P.PRODUCT_ID WHERE T.BILL_ID='" + a + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("SELECT DISTINCT TOTAL_AMOUNT FROM TRANSACT_1 WHERE BILL_ID='" + a + "'", con);
                rd = cmd.ExecuteReader();
                rd.Read();
                string amt = rd[0].ToString();
                double amt1 = Convert.ToDouble(amt);
                rd.Close();
                con.Close();
                con.Open();
                cmd = new SqlCommand("UPDATE B SET B.AMOUNT=B.AMOUNT+'" + amt1 + "' FROM BANK B INNER JOIN TRANSACT_1 T ON B.CARD_NUMBER=T.CARD_NUMBER WHERE T.BILL_ID='" + a + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("UPDATE TRANSACT_1 SET STATUS='CANCELLED' WHERE BILL_ID='" + a + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("CANCEL TRANSACTION.aspx");

            }
        }
    }
    protected void BTN_PRINT_CANCELLED_TRANSACTION_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        if (DDL_CANCELLATION_ID.SelectedItem.ToString() == "CANCELLATION ID NOT AVAILABLE")
        {
            Response.Write("<script>alert('CANCELLATION NOT ID AVAILABLE')</script>");
            Response.Write("<script>alert('PLEASE LOGIN WITH RESPECTIVE ID')</script>");
        }
        else
        {
            if (DDL_CANCELLATION_ID.SelectedItem.ToString() == "CHOOSE CANCELLATION ID")
            {
                Response.Write("<script>alert('PLEASE SELECT A CANCELLATION ID TO PRINT IT')</script>");
            }
            else
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("DELETE FROM PRINT_CANCELLED_TRANSACT", con);
                cmd.ExecuteNonQuery();
                con.Close();
                int a = Convert.ToInt32(DDL_CANCELLATION_ID.SelectedItem.ToString());
                con.Close();
                con.Open();
                cmd = new SqlCommand("INSERT INTO PRINT_CANCELLED_TRANSACT(USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_PIN,CARD_TYPE,CARD_HOLDERS_NAME,DATE_OF_EXPIRY,TOTAL_AMOUNT) SELECT USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_PIN,CARD_TYPE,CARD_HOLDERS_NAME,DATE_OF_EXPIRY,TOTAL_AMOUNT FROM TRANSACT_1 WHERE USERNAME='" + un + "' AND BILL_ID='" + a + "' AND STATUS='CANCELLED'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("PRINT CANCELLED TRANSACTION.aspx");
            }
        }
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string q = (string)DataBinder.Eval(e.Row.DataItem, "STATUS");
            foreach (TableCell Cell in e.Row.Cells)
            {

                if (q == "WAITING")
                {
                    Cell.BackColor = Color.Yellow;
                }
                if (q == "CANCELLED")
                {
                    Cell.BackColor = Color.LightPink;
                }
            }

        }
    }
    protected void VIEW_CANCELLED_TRANSACTION_HISTORY_BTN_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);

        con.Close();
        con.Open();
        SqlCommand cmd3 = new SqlCommand("select  USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_TYPE,CARD_HOLDERS_NAME,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE USERNAME='" + un + "' AND STATUS='CANCELLED'", con);
        SqlDataAdapter da3;
        da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        GridView1.DataSource = ds3.Tables[0];
        GridView1.DataBind();
        con.Close();
    }
    protected void VIEW_WAITING_ORDERS_BTN_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);

        con.Close();
        con.Open();
        SqlCommand cmd5 = new SqlCommand("select  USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_TYPE,CARD_HOLDERS_NAME,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE USERNAME='" + un + "' AND STATUS='WAITING' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "'", con);
        SqlDataAdapter da5;
        da5 = new SqlDataAdapter(cmd5);
        DataSet ds5 = new DataSet();
        da5.Fill(ds5);
        GridView1.DataSource = ds5.Tables[0];
        GridView1.DataBind();
        con.Close();
        con.Close();
        con.Open();
        SqlCommand cmd8 = new SqlCommand("SELECT * FROM TRANSACT_1 WHERE USERNAME='" + un + "' AND STATUS='WAITING' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "'",con);
        rd = cmd8.ExecuteReader();
        if (rd.Read())
        {
        }
        else
        {
            ERROR_MESSAGE_LBL.Visible = true;
            rd.Close();
            con.Close();
        }
        con.Close();
    }
}