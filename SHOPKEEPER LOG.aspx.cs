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

public partial class SHOPKEEPER_LOG : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    DataSet ds = new DataSet();
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        VIEW_PENDING_ORDERS_PANEL.Visible = false;
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
            DDL_STATUS.Items.Insert(0, "SATUS NOT AVAILABLE");
            DDL_STATUS.DataBind();
        }
        if (!IsPostBack)
        {
            SqlCommand cmd8 = new SqlCommand("select DISTINCT BILL_ID FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='WAITING'", con);
            SqlDataAdapter da8 = new SqlDataAdapter(cmd8);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            if (ds8.Tables[0].Rows.Count > 0)
            {
                DDL_BILL_ID.DataSource = ds8;
                DDL_BILL_ID.DataValueField = "BILL_ID";
                DDL_BILL_ID.DataBind();
                DDL_BILL_ID.Items.Insert(0, new ListItem("CHOOSE TRANSACTION ID", "0"));
                DDL_STATUS.Items.Insert(0, "SATUS NOT AVAILABLE");
            }
            else
            {
                DDL_BILL_ID.Items.Insert(0, "TRANSACTION ID NOT AVAILABLE");
                DDL_BILL_ID.DataBind();
            }
              
        }
        if (!IsPostBack)
        {
            SqlCommand cmd9 = new SqlCommand("select DISTINCT BILL_ID FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED'", con);
            SqlDataAdapter da9 = new SqlDataAdapter(cmd9);
            DataSet ds9 = new DataSet();
            da9.Fill(ds9);
            if (ds9.Tables[0].Rows.Count > 0)
            {
                DDL_UPDATED_BILL_ID.DataSource = ds9;
                DDL_UPDATED_BILL_ID.DataValueField = "BILL_ID";
                DDL_UPDATED_BILL_ID.DataBind();
                DDL_UPDATED_BILL_ID.Items.Insert(0, new ListItem("CHOOSE BILL ID TO PRINT", "0"));
            }
            else
            {
                DDL_UPDATED_BILL_ID.Items.Insert(0, "BILL ID NOT AVAILABLE TO PRINT");
                DDL_UPDATED_BILL_ID.DataBind();
            }
        }
        con.Close();
        con.Open();
        cmd = new SqlCommand("SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "'", con);
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
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
        con.Close();
    }
    protected void BTN_UPDATE_Click(object sender, EventArgs e)
    {
       
        }
    protected void DDL_BILL_ID_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (DDL_BILL_ID.SelectedItem.ToString() != "0" & DDL_BILL_ID.SelectedItem.ToString() != "TRANSACTION ID NOT AVAILABLE")
        {
            string[] status = { "--SELECT SATUS--", "DELEVERED" };
            DDL_STATUS.DataSource = status;
            DDL_STATUS.DataBind();
            VIEW_PENDING_ORDERS_PANEL.Visible = true;
        }
        else
        {
            DDL_STATUS.Items.Insert(0, "SATUS NOT AVAILABLE");
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
                if (q == "DELEVERED")
                {
                    Cell.BackColor = Color.LightGreen;
                }
            }

        }
    }
    protected void VIEW_BTN_Click(object sender, EventArgs e)
    {
       string unm = (string)(Session["a"]);
       if(DATE_FROM_TXTBOX.Text=="")
       {
           Response.Write("<script>alert('SELECT FROM DATE')</script>");
       }
       else
       {
           if (DATE_TO_TXTBOX.Text == "")
           {
               Response.Write("<script>alert('SELECT TO DATE')</script>");
           }
           else
           {
               GridView1.Visible = true;
               con.Close();
               con.Open();
               SqlCommand cmd6 = new SqlCommand("SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "'", con);
              SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
              DataSet ds6 = new DataSet();
               da6.Fill(ds6);
               GridView1.DataSource = ds6.Tables[0];
               GridView1.DataBind();
               con.Close();
              SqlCommand cmd5 = new SqlCommand("select DISTINCT BILL_ID FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='WAITING' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "'", con);
              SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
              DataSet ds5 = new DataSet();
              da5.Fill(ds5);
               if (ds5.Tables[0].Rows.Count > 0)
               {
                   DDL_BILL_ID.DataSource = ds5;
                   DDL_BILL_ID.DataValueField = "BILL_ID";
                   DDL_BILL_ID.DataBind();
                   DDL_BILL_ID.Items.Insert(0, new ListItem("CHOOSE TRANSACTION ID", "0"));
                   DDL_STATUS.Items.Insert(0, "SATUS NOT AVAILABLE");
               }
               else
               {
                   DDL_BILL_ID.Items.Insert(0, "TRANSACTION ID NOT AVAILABLE");
                   DDL_BILL_ID.DataBind();
               }
              SqlCommand cmd3 = new SqlCommand("select DISTINCT BILL_ID FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED' AND DATE_OF_TRANSACTION BETWEEN '"+DATE_FROM_TXTBOX.Text+"' AND '"+DATE_TO_TXTBOX.Text+"'", con);
              SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
              DataSet ds3 = new DataSet();
               da3.Fill(ds3);
               if (ds3.Tables[0].Rows.Count > 0)
               {
                   DDL_UPDATED_BILL_ID.DataSource = ds3;
                   DDL_UPDATED_BILL_ID.DataValueField = "BILL_ID";
                   DDL_UPDATED_BILL_ID.DataBind();
                   DDL_UPDATED_BILL_ID.Items.Insert(0, new ListItem("CHOOSE BILL ID TO PRINT", "0"));
               }
               else
               {
                   DDL_UPDATED_BILL_ID.Items.Insert(0, "BILL ID NOT AVAILABLE TO PRINT");
                   DDL_UPDATED_BILL_ID.DataBind();
               }

               con.Close();
               con.Open();
               SqlCommand cmd7 = new SqlCommand("SELECT * FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "'", con);
               rd = cmd7.ExecuteReader();
               if (rd.Read())
               {
               }
               else
               {
                   ERROR_MESSAGE_LBL.Visible = true;
                   GridView1.Visible = false;
                   rd.Close();
                   con.Close();
               }
           }
       }
    }
    protected void PRINT_BTN_Click(object sender, EventArgs e)
    {
        if (DDL_UPDATED_BILL_ID.SelectedItem.ToString() == "BILL ID NOT AVAILABLE TO PRINT")
        {
            Response.Write("<script>alert('NO BILL ID AVAILABLE TO PRINT')</script>");
        }
        else
        {
            if (DDL_UPDATED_BILL_ID.SelectedItem.ToString() == "CHOOSE BILL ID TO PRINT")
            {
                Response.Write("<script>alert('CHOOSE BILL ID TO PRINT')</script>");
            }
            else
            {
                string status = "PRINT";
                int bill_id = Convert.ToInt32(DDL_UPDATED_BILL_ID.SelectedItem.ToString());
                con.Close();
                con.Open();
                cmd = new SqlCommand("DELETE FROM PRINT_TRANSACT", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("INSERT INTO PRINT_TRANSACT(USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_CITY,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_PIN,CARD_TYPE,CARD_HOLDERS_NAME,DATE_OF_EXPIRY,TOTAL_AMOUNT) SELECT USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_PIN,CARD_TYPE,CARD_HOLDERS_NAME,DATE_OF_EXPIRY,TOTAL_AMOUNT FROM TRANSACT_1 WHERE BILL_ID='" + bill_id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("PRINT TRANSACTION.aspx?STATUS=" + status);
            }
        }
    }
    protected void BTN_UPDATE_Click1(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        if (DDL_BILL_ID.SelectedItem.ToString() == "CHOOSE TRANSACTION ID")
        {
            Response.Write("<script>alert('PLEASE CHOOSE A TRANSACTION ID')</script>");
        }
        else
        {
            if (DDL_BILL_ID.SelectedItem.ToString() == "TRANSACTION ID NOT AVAILABLE")
            {
                Response.Write("<script>alert('TRANSACTION ID NOT AVAILABLE')</script>");
            }
            else
            {
                if (DDL_STATUS.SelectedItem.ToString() == "--SELECT SATUS--")
                {
                    Response.Write("<script>alert('PLEASE SELECT STATUS')</script>");
                }
                else
                {
                    if (DDL_STATUS.SelectedItem.ToString() == "SATUS NOT AVAILABLE")
                    {
                        Response.Write("<script>alert('STATUS NOT AVAILABLE')</script>");
                    }
                    else
                    {
                        if (DDL_STATUS.SelectedItem.ToString() == "SATUS NOT AVAILABLE" & DDL_BILL_ID.SelectedItem.ToString() == "TRANSACTION ID NOT AVAILABLE")
                        {
                            Response.Write("<script>alert('STATUS AND TRANSACTION_ID NOT AVAILABLE')</script>");
                            Response.Write("<script>alert('DATA CANNOT BE UPDATED')</script>");
                        }

                        else
                        {
                            VIEW_PENDING_ORDERS_PANEL.Visible = true;
                            int bill_id = Convert.ToInt32(DDL_BILL_ID.SelectedItem.ToString());
                            con.Close();
                            con.Open();
                            cmd = new SqlCommand("UPDATE TRANSACT_1 SET STATUS='" + DDL_STATUS.SelectedItem.ToString() + "' WHERE BILL_ID='" + bill_id + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Close();
                            con.Open();
                            SqlCommand cmd5 = new SqlCommand("SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "'", con);
                            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                            DataSet ds5 = new DataSet();
                            da5.Fill(ds5);
                            GridView1.DataSource = ds5.Tables[0];
                            GridView1.DataBind();
                            con.Close();
                            SqlCommand cmd10 = new SqlCommand("select DISTINCT BILL_ID FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "'", con);
                            SqlDataAdapter da10 = new SqlDataAdapter(cmd10);
                            DataSet ds10 = new DataSet();
                            da10.Fill(ds10);
                            if (ds10.Tables[0].Rows.Count > 0)
                            {
                                DDL_UPDATED_BILL_ID.DataSource = ds10;
                                DDL_UPDATED_BILL_ID.DataValueField = "BILL_ID";
                                DDL_UPDATED_BILL_ID.DataBind();
                                DDL_UPDATED_BILL_ID.Items.Insert(0, new ListItem("CHOOSE BILL ID TO PRINT", "0"));
                            }
                            else
                            {
                                DDL_UPDATED_BILL_ID.Items.Insert(0, "BILL ID NOT AVAILABLE TO PRINT");
                                DDL_UPDATED_BILL_ID.DataBind();
                            }
                        }
                    }
                }
            }
        }
        SqlCommand cmd11 = new SqlCommand("select DISTINCT BILL_ID FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED'", con);
        SqlDataAdapter da11 = new SqlDataAdapter(cmd11);
        DataSet ds11 = new DataSet();
        da11.Fill(ds11);
        if (ds11.Tables[0].Rows.Count > 0)
        {
            DDL_UPDATED_BILL_ID.DataSource = ds11;
            DDL_UPDATED_BILL_ID.DataValueField = "BILL_ID";
            DDL_UPDATED_BILL_ID.DataBind();
            DDL_UPDATED_BILL_ID.Items.Insert(0, new ListItem("CHOOSE BILL ID TO PRINT", "0"));
        }
        else
        {
            DDL_UPDATED_BILL_ID.Items.Insert(0, "BILL ID NOT AVAILABLE TO PRINT");
            DDL_UPDATED_BILL_ID.DataBind();
        }
        con.Close();
        con.Open();
        SqlCommand cmd12 = new SqlCommand("SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "'", con);
        SqlDataAdapter da12 = new SqlDataAdapter(cmd12);
        DataSet ds12 = new DataSet();
        da12.Fill(ds12);
        GridView1.DataSource = ds12.Tables[0];
        GridView1.DataBind();
        con.Close();
    }
    protected void VIEW_PENDING_ORDERS_BTN_Click(object sender, EventArgs e)
    {
        VIEW_PENDING_ORDERS_PANEL.Visible = true;
    }
    protected void VIEW_DELEVERED_ORDERS_BTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("DELEVERED PRODUCT.aspx");
    }
    protected void UPDATE_YOUR_PRODUCTS_BTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("UPDATE PRODUCT.aspx");
    }
}
