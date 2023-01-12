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

public partial class MY_ACCOUNT : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        TRANSACTION_ERROR_LBL.Visible = false;
        RECORD_PANEL.Visible = false;
        PASSWORD_PANEL.Visible = false;
        CUSTOMER_TYPE_LBL.Visible = false;
        VIEW_TRANSACTION_PANEL.Visible = false;
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
    protected void UPDATE_RECORDS_BTN_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string CUSTOMERTYPE = Convert.ToString(Request.QueryString["USERTYPE"]);
        if (CUSTOMERTYPE != "SHOPKEEPER")
        {
            if (NAME_TXTBOX.Text == "")
            {
                Response.Write("<script>alert('ENTER YOUR NAME')</script>");
            }
            else
            {
                if (PHONE_NUMBER_TXTBOX.Text == "")
                {
                    Response.Write("<script>alert('ENTER YOUR PHONE NUMBER')</script>");
                }
                else
                {
                    if (ADDRESS_TXTBOX.Text == "")
                    {
                        Response.Write("<script>alert('ENTER YOUR ADDRESS')</script>");
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("UPDATE CUSTOMER SET CUSTOMER_NAME='" + NAME_TXTBOX.Text + "',ADDRESS='" + ADDRESS_TXTBOX.Text + "',PHONE_NUMBER='" + PHONE_NUMBER_TXTBOX.Text + "' WHERE EMAIL_ID='" + un + "'", con);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        con.Close();
                        con.Open();
                        SqlCommand cmd3 = new SqlCommand("UPDATE LOGIN_1 SET CUSTOMER_NAME='" + NAME_TXTBOX.Text + "',PHONE_NUMBER='" + PHONE_NUMBER_TXTBOX.Text + "' WHERE USER_NAME='" + un + "'", con);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('DATA UPDATED SUCCESSFULLY')</script>");
                    }
                }
            }
        }
        else
        {
            if (NAME_TXTBOX.Text == "")
            {
                Response.Write("<script>alert('ENTER YOUR NAME')</script>");
            }
            else
            {
                if (PHONE_NUMBER_TXTBOX.Text == "")
                {
                    Response.Write("<script>alert('ENTER YOUR PHONE NUMBER')</script>");
                }
                else
                {
                    if (TOWN_VILLAGE_TXTBOX.Text == "")
                    {
                        Response.Write("<script>alert('ENTER YOUR TOWN OR VILLAGE NAME')</script>");
                    }
                    else
                    {
                        if (CITY_TXTBOX.Text == "")
                        {
                            Response.Write("<script>alert('ENTER YOUR CITY NAME')</script>");
                        }
                        else
                        {
                            if (DISTRICT_TXTBOX.Text == "")
                            {
                                Response.Write("<script>alert('ENTER YOUR DISTRICT NAME')</script>");
                            }
                            else
                            {
                                if (PIN_CODE_TXTBOX.Text == "")
                                {
                                    Response.Write("<script>alert('ENTER YOUR PIN CODE')</script>");
                                }
                                else
                                {
                                    if (ADHAAR_NUMBER_TXTBOX.Text == "")
                                    {
                                        Response.Write("<script>alert('ENTER YOUR ADHAAR NUMBER')</script>");
                                    }
                                    else
                                    {
                                        if (SHOP_NAME_TXTBOX.Text == "")
                                        {
                                            Response.Write("<script>alert('ENTER YOUR SHOP NAME')</script>");
                                        }
                                        else
                                        {
                                            if (ADDRESS_TXTBOX.Text == "")
                                            {
                                                Response.Write("<script>alert('ENTER YOUR ADDRESS')</script>");
                                            }
                                            else
                                            {
                                                if (SHOP_LOCATION_TXTBOX.Text == "")
                                                {
                                                    Response.Write("<script>alert('ENTER YOUR SHOP LOCATION')</script>");
                                                }
                                                else
                                                {
                                                    con.Open();
                                                    SqlCommand cmd4 = new SqlCommand("UPDATE SHOPKEEPER SET SHOPKEEPER_NAME='" + NAME_TXTBOX.Text + "',ADDRESS='" + ADDRESS_TXTBOX.Text + "',TOWN_VILLAGE='" + TOWN_VILLAGE_TXTBOX.Text + "',CITY='" + CITY_TXTBOX.Text + "',DISTRICT='" + DISTRICT_TXTBOX.Text + "',PIN_CODE='" + PIN_CODE_TXTBOX.Text + "',PHONE_NUMBER='" + PHONE_NUMBER_TXTBOX.Text + "',ADHAAR_NUMBER='" + ADHAAR_NUMBER_TXTBOX.Text + "',SHOP_NAME='" + SHOP_NAME_TXTBOX.Text + "',SHOP_LOCATION='" + SHOP_LOCATION_TXTBOX.Text + "' WHERE EMAIL='" + un + "'", con);
                                                    cmd4.ExecuteNonQuery();
                                                    con.Close();
                                                    con.Close();
                                                    con.Open();
                                                    SqlCommand cmd5 = new SqlCommand("UPDATE LOGIN_1 SET CUSTOMER_NAME='" + NAME_TXTBOX.Text + "',PHONE_NUMBER='" + PHONE_NUMBER_TXTBOX.Text + "' WHERE USER_NAME='" + un + "'", con);
                                                    cmd5.ExecuteNonQuery();
                                                    con.Close();
                                                    Response.Write("<script>alert('DATA UPDATED SUCCESSFULLY')</script>");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    protected void GO_TO_HOME_PAGE_BTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRODUCT.ASPX");
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
            Response.Redirect("LOGIN.aspx");
        }
        con.Close();
    }
    protected void BTN_UPDATE_RECORDS_Click(object sender, EventArgs e)
    {
        VIEW_TRANSACTION_PANEL.Visible = false;
        RECORD_PANEL.Visible = true;
        PASSWORD_PANEL.Visible = false;
        string un = (string)(Session["a"]);
        string pwd = (string)(Session["b"]);
        string utyp = (string)(Session["c"]);
        string CUSTOMERTYPE = Convert.ToString(Request.QueryString["USERTYPE"]);
        CUSTOMER_TYPE_LBL.Text = CUSTOMERTYPE;
        if (CUSTOMERTYPE != "SHOPKEEPER")
        {
            DataTable dt = new DataTable();
            TOWN_VILLAGE_LBL.Visible = false;
            TOWN_VILLAGE_TXTBOX.Visible = false;
            CITY_LBL.Visible = false;
            CITY_TXTBOX.Visible = false;
            DISTRICT_LBL.Visible = false;
            DISTRICT_TXTBOX.Visible = false;
            PIN_CODE_LBL.Visible = false;
            PIN_CODE_TXTBOX.Visible = false;
            ADHAAR_NUMBER_LBL.Visible = false;
            ADHAAR_NUMBER_TXTBOX.Visible = false;
            SHOP_NAME_LBL.Visible = false;
            SHOP_NAME_TXTBOX.Visible = false;
            SHOP_LOCATION_LBL.Visible = false;
            SHOP_LOCATION_TXTBOX.Visible = false;
            cmd = new SqlCommand("SELECT C.CUSTOMER_NAME,C.ADDRESS,C.PHONE_NUMBER,C.EMAIL_ID FROM CUSTOMER C INNER JOIN LOGIN L ON C.EMAIL_ID=L.EMAIL_ID WHERE L.USER_NAME='" + un + "'", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            USER_ID_TXTBOX.Text = dt.Rows[0].ItemArray[3].ToString();
            NAME_TXTBOX.Text = dt.Rows[0].ItemArray[0].ToString();
            ADDRESS_TXTBOX.Text = dt.Rows[0].ItemArray[1].ToString();
            PHONE_NUMBER_TXTBOX.Text = dt.Rows[0].ItemArray[2].ToString();
        }
        else
        {

            DataTable dt1 = new DataTable();
            TOWN_VILLAGE_LBL.Visible = true;
            TOWN_VILLAGE_TXTBOX.Visible = true;
            CITY_LBL.Visible = true;
            CITY_TXTBOX.Visible = true;
            DISTRICT_LBL.Visible = true;
            DISTRICT_TXTBOX.Visible = true;
            PIN_CODE_LBL.Visible = true;
            PIN_CODE_TXTBOX.Visible = true;
            ADHAAR_NUMBER_LBL.Visible = true;
            ADHAAR_NUMBER_TXTBOX.Visible = true;
            SHOP_NAME_LBL.Visible = true;
            SHOP_NAME_TXTBOX.Visible = true;
            SHOP_LOCATION_LBL.Visible = true;
            SHOP_LOCATION_TXTBOX.Visible = true;
            SqlCommand cmd1 = new SqlCommand("SELECT SHOPKEEPER_NAME,ADDRESS,TOWN_VILLAGE,CITY,DISTRICT,PIN_CODE,PHONE_NUMBER,ADHAAR_NUMBER,EMAIL,SHOP_NAME,SHOP_LOCATION FROM SHOPKEEPER", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            USER_ID_TXTBOX.Text = dt1.Rows[0].ItemArray[8].ToString();
            NAME_TXTBOX.Text = dt1.Rows[0].ItemArray[0].ToString();
            ADDRESS_TXTBOX.Text = dt1.Rows[0].ItemArray[1].ToString();
            TOWN_VILLAGE_TXTBOX.Text = dt1.Rows[0].ItemArray[2].ToString();
            CITY_TXTBOX.Text = dt1.Rows[0].ItemArray[3].ToString();
            DISTRICT_TXTBOX.Text = dt1.Rows[0].ItemArray[4].ToString();
            PIN_CODE_TXTBOX.Text = dt1.Rows[0].ItemArray[5].ToString();
            PHONE_NUMBER_TXTBOX.Text = dt1.Rows[0].ItemArray[6].ToString();
            ADHAAR_NUMBER_TXTBOX.Text = dt1.Rows[0].ItemArray[7].ToString();
            SHOP_NAME_TXTBOX.Text = dt1.Rows[0].ItemArray[9].ToString();
            SHOP_LOCATION_TXTBOX.Text = dt1.Rows[0].ItemArray[10].ToString();

        }
    }
    protected void BTN_UPDATE_PASSWORD_Click(object sender, EventArgs e)
    {
        VIEW_TRANSACTION_PANEL.Visible = false;
        RECORD_PANEL.Visible = false;
        PASSWORD_PANEL.Visible = true;
    }
    protected void SAVE_PASSWORD_BTN_Click(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string utyp = (string)(Session["c"]);
        if (OLD_PASSWORD_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('ENTER YOUR OLD PASSWORD')</script>");
        }
        else
        {
            if (NEW_PASSWORD_TXTBOX.Text == "")
            {
                Response.Write("<script>alert('ENTER YOUR NEW PASSWORD')</script>");
            }
            else
            {

                if (NEW_PASSWORD_TXTBOX.Text != CONFIRM_PASSWORD_TXTBOX.Text)
                {
                    Response.Write("<script>alert('ENTER YOUR CONFIRMATION PASSWORD AGAIN')</script>");
                }
                else
                {
                    if (CONFIRM_PASSWORD_TXTBOX.Text == "")
                    {
                        Response.Write("<script>alert('ENTER YOUR NEW PASSWORD')</script>");
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM LOGIN_1 WHERE PASSWORD!='" + OLD_PASSWORD_TXTBOX.Text + "' AND USER_NAME='" + un + "'", con);
                        rd = cmd2.ExecuteReader();
                        if (rd.Read())
                        {
                            Response.Write("<script>alert('ENTER CORRECT OLD PASSWORD')</script>");
                        }
                        else
                        {
                            rd.Close();
                            con.Close();
                            if (utyp == "SHOPKEEPER")
                            {
                                con.Close();
                                con.Open();
                                cmd = new SqlCommand("UPDATE LOGIN_1 SET PASSWORD='" + CONFIRM_PASSWORD_TXTBOX.Text + "' WHERE USER_NAME='" + un + "'", con);
                                cmd.ExecuteNonQuery();
                                cmd = new SqlCommand("UPDATE SHOPKEEPER SET PASSWORD='" + CONFIRM_PASSWORD_TXTBOX.Text + "' WHERE EMAIL='" + un + "'", con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            else
                            {
                                rd.Close();
                                con.Close();
                                con.Open();
                                cmd = new SqlCommand("UPDATE LOGIN_1 SET PASSWORD='" + CONFIRM_PASSWORD_TXTBOX.Text + "' WHERE USER_NAME='" + un + "'", con);
                                cmd.ExecuteNonQuery();
                                cmd = new SqlCommand("UPDATE CUSTOMER SET PASSWORD='" + CONFIRM_PASSWORD_TXTBOX.Text + "' WHERE EMAIL_ID='" + un + "'", con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
            }
        }
    }
    protected void RESET_FROM_BTN_Click(object sender, EventArgs e)
    {
        string utyp = (string)(Session["c"]);
        if (utyp == "SHOPKEEPER")
        {
            NAME_TXTBOX.Text = string.Empty;
            PHONE_NUMBER_TXTBOX.Text = string.Empty;
            TOWN_VILLAGE_TXTBOX.Text = string.Empty;
            CITY_LBL.Text = string.Empty;
            DISTRICT_TXTBOX.Text = string.Empty;
            PIN_CODE_TXTBOX.Text = string.Empty;
            ADHAAR_NUMBER_TXTBOX.Text = string.Empty;
            SHOP_NAME_TXTBOX.Text = string.Empty;
            SHOP_LOCATION_TXTBOX.Text = string.Empty;
            ADDRESS_TXTBOX.Text = string.Empty;
        }
        else
        {
            NAME_TXTBOX.Text = string.Empty;
            PHONE_NUMBER_TXTBOX.Text = string.Empty;
            TOWN_VILLAGE_TXTBOX.Text = string.Empty;
            ADDRESS_TXTBOX.Text = string.Empty;
        }
    }
    protected void RESET_BTN_Click(object sender, EventArgs e)
    {
        OLD_PASSWORD_TXTBOX.Text = string.Empty;
        NEW_PASSWORD_TXTBOX.Text = string.Empty;
        CONFIRM_PASSWORD_TXTBOX.Text = string.Empty;
    }
    protected void VIEW_TRANSACTIONS_BTN_Click(object sender, EventArgs e)
    {
        VIEW_TRANSACTION_PANEL.Visible = true;
        RECORD_PANEL.Visible = false;
        PASSWORD_PANEL.Visible = false;
        string un = (string)(Session["a"]);
        con.Close();
        con.Open();
        SqlCommand cmd4 = new SqlCommand("select  USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_TYPE,CARD_HOLDERS_NAME,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE USERNAME='" + un + "'", con);
        SqlDataAdapter da4;
        da4 = new SqlDataAdapter(cmd4);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        GridView1.DataSource = ds4.Tables[0];
        GridView1.DataBind();
        con.Close();
        con.Close();
        con.Close();
        con.Open();
        cmd = new SqlCommand("SELECT * FROM TRANSACT_1 WHERE USERNAME='" + un + "' AND PRODUCT_NAME IS NOT  NULL", con);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {

        }
        else
        {
            TRANSACTION_ERROR_LBL.Visible = true;
        }
        con.Close();
        con.Close();
        SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT BILL_ID FROM TRANSACT_1 WHERE USERNAME='" + un + "' AND STATUS='DELEVERED'", con);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            DDL_PRODUCT_ID.DataSource = ds1;
            DDL_PRODUCT_ID.DataValueField = "BILL_ID";
            DDL_PRODUCT_ID.DataBind();
            DDL_PRODUCT_ID.Items.Insert(0, new ListItem("CHOOSE BILL ID TO PRINT", "0"));
        }
        else
        {
            DDL_PRODUCT_ID.Items.Insert(0, "BILL ID NOT AVAILABLE TO PRINT");
            DDL_PRODUCT_ID.DataBind();
        }
        con.Close();
        con.Close();
    }
    protected void CLICK_TO_CANCEL_TRANSACTION_LOG_Click(object sender, EventArgs e)
    {
        Response.Redirect("CANCEL TRANSACTION.aspx");
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string q = (string)DataBinder.Eval(e.Row.DataItem, "STATUS");
            foreach (TableCell Cell in e.Row.Cells)
            {
                if (q == "DELEVERED")
                {
                    Cell.BackColor = Color.LightGreen;
                }
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
    protected void PRINT_SAVED_TRANSACTION_BTN_Click(object sender, EventArgs e)
    {
        if (DDL_PRODUCT_ID.SelectedItem.ToString() == "BILL ID NOT AVAILABLE TO PRINT")
        {
            Response.Write("<script>alert('BILL ID NOT AVAILABLE TO PRINT')</script>");
            VIEW_TRANSACTION_PANEL.Visible = true;
        }
        else
        {
            if (DDL_PRODUCT_ID.SelectedItem.ToString() == "CHOOSE BILL ID TO PRINT")
            {
                Response.Write("<script>alert('CHOOSE BILL ID TO PRINT')</script>");
                VIEW_TRANSACTION_PANEL.Visible = true;
            }
            else
            {
                VIEW_TRANSACTION_PANEL.Visible = true;
                string un = (string)(Session["a"]);
                Response.Redirect("PRINT SAVED TRANSACTION.aspx?billid23=" + DDL_PRODUCT_ID.SelectedItem.ToString());
            }
        }
    }
}
