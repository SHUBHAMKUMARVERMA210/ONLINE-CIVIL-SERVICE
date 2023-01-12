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
using System.Globalization;

public partial class ADMIN_LOG : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    DataSet ds = new DataSet();
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        CATEGORY_PANEL.Visible = false;
        CALCULATE_SHOPKEEPER_TRANSACTION_PANEL.Visible = false;
        string a = Request.QueryString["EMAIL_ID"];
        string b = Request.QueryString["PRODUCT_ID"];
        string nm = (string)(Session["nm"]);
        string unm = (string)(Session["a"]);
        WELCOME_LBL.Text = "WELCOME!" + " " + "ADMIN";
        LNK_BTN_My_Account.Text = "ADMIN";
        if (nm == null)
        {
            LNK_BTN_My_Account.Text = "My Account";
            WELCOME_LBL.Visible = false;
        }
        if (!IsPostBack)
        {
            cmd = new SqlCommand("select DISTINCT DISTRICT FROM SHOPKEEPER", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_DISTRICT.DataSource = ds;
                DDL_DISTRICT.DataValueField = "DISTRICT";
                DDL_DISTRICT.DataBind();
                DDL_DISTRICT.Items.Insert(0, new ListItem("CHOOSE DISTRICT", "0"));
                DDL_SHOPKEEPER_ID.Items.Insert(0, "SHOPKEEPER ID NOT AVAILABLE");
            }
            else
            {
                DDL_DISTRICT.Items.Insert(0, "DISTRICT NOT AVAILABLE");
                DDL_DISTRICT.DataBind();
            }
        }
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
        con.Close();

    }
    protected void DDL_DISTRICT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_DISTRICT.SelectedItem.ToString() != "0" & DDL_DISTRICT.SelectedItem.ToString() != "DISTRICT NOT AVAILABLE")
        {
            cmd = new SqlCommand("select DISTINCT EMAIL FROM SHOPKEEPER WHERE DISTRICT='"+DDL_DISTRICT.SelectedItem.ToString()+"'", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_SHOPKEEPER_ID.DataSource = ds;
                DDL_SHOPKEEPER_ID.DataValueField = "EMAIL";
                DDL_SHOPKEEPER_ID.DataBind();
                DDL_SHOPKEEPER_ID.Items.Insert(0, new ListItem("CHOOSE SHOPKEEPER ID", "0"));
                CALCULATE_SHOPKEEPER_TRANSACTION_PANEL.Visible = true;
            }
        }
        else
        {
            DDL_SHOPKEEPER_ID.Items.Insert(0, "SHOPKEEPER ID AVAILABLE");
        }
    }
    protected void VIEW_BTN_Click(object sender, EventArgs e)
    {
        if (DDL_DISTRICT.SelectedItem.ToString() == "DISTRICT NOT AVAILABLE" & DDL_SHOPKEEPER_ID.SelectedItem.ToString() == "SHOPKEEPER ID AVAILABLE" & DATE_FROM_TXTBOX.Text == "" & DATE_TO_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('UNABLE TO VIEW')</script>");
        }
        else
        {
            if (DDL_DISTRICT.SelectedItem.ToString() == "CHOOSE DISTRICT")
            {
                Response.Write("<script>alert('CHOOSE DISTRICT')</script>");
            }
            else
            {
                if (DDL_SHOPKEEPER_ID.SelectedItem.ToString() == "CHOOSE SHOPKEEPER ID")
                {
                    Response.Write("<script>alert('CHOOSE SHOPKEEPER ID')</script>");
                }
                else
                {
                    if (DATE_FROM_TXTBOX.Text=="")
                    {
                        Response.Write("<script>alert('CHOOSE FROM DATE')</script>");
                    }
                    else
                    {
                        if (DATE_TO_TXTBOX.Text == "")
                        {
                            Response.Write("<script>alert('CHOOSE DATE TO')</script>");
                        }
                        else
                        {
                            CALCULATE_SHOPKEEPER_TRANSACTION_PANEL.Visible = true;
                            con.Close();
                            con.Open();
                            string sta = "DELEVERED";
                            cmd = new SqlCommand("SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + DDL_SHOPKEEPER_ID.SelectedItem.ToString() + "' AND STATUS='" + sta + "' AND DATE_OF_TRANSACTION BETWEEN '"+DATE_FROM_TXTBOX.Text+"' AND '"+DATE_TO_TXTBOX.Text+"'", con);
                            da = new SqlDataAdapter(cmd);
                            da.Fill(ds);
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                            con.Close();
                            con.Close();
                            con.Open();
                            cmd = new SqlCommand("SELECT SUM(YOUR_COST) FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + DDL_SHOPKEEPER_ID.SelectedItem.ToString() + "' AND STATUS='" + sta + "' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "'", con);
                            rd = cmd.ExecuteReader();
                            rd.Read();
                            string amtt = rd[0].ToString();
                            if (amtt != "")
                            {
                                double amt = Convert.ToDouble(amtt);
                                AMOUNT.Text = Convert.ToString(amt);
                                double calculated_amount = amt * 12 / 100;
                                CALCULATED_AMOUNT.Text = Convert.ToString(calculated_amount);
                                con.Close();
                            }
                            else
                            {
                                Response.Write("<script>alert('UNABLE TO VIEW')</script>");
                                Response.Write("<script>alert('DELEVERED RECORDS NOT PRESENT')</script>");
                            }
                        }
                    }

                }
            }
        }
    }
    protected void PRINT_BTN_Click(object sender, EventArgs e)
    {
        if (DDL_DISTRICT.SelectedItem.ToString() == "DISTRICT NOT AVAILABLE" & DDL_SHOPKEEPER_ID.SelectedItem.ToString() == "SHOPKEEPER ID AVAILABLE" & DATE_FROM_TXTBOX.Text == "" & DATE_TO_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('UNABLE TO VIEW')</script>");
        }
        else
        {
            if (DDL_DISTRICT.SelectedItem.ToString() == "CHOOSE DISTRICT")
            {
                Response.Write("<script>alert('CHOOSE DISTRICT')</script>");
            }
            else
            {
                if (DDL_SHOPKEEPER_ID.SelectedItem.ToString() == "CHOOSE SHOPKEEPER ID")
                {
                    Response.Write("<script>alert('CHOOSE SHOPKEEPER ID')</script>");
                }
                else
                {
                    if (DATE_FROM_TXTBOX.Text == "")
                    {
                        Response.Write("<script>alert('CHOOSE FROM DATE')</script>");
                    }
                    else
                    {
                        if (DATE_TO_TXTBOX.Text == "")
                        {
                            Response.Write("<script>alert('CHOOSE DATE TO')</script>");
                        }
                        else
                        {
                            string sta = "DELEVERED";

                            con.Close();
                            con.Close();
                            con.Open();
                            cmd = new SqlCommand("DELETE FROM PRINT_ADMIN_LOG",con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Close();
                            con.Open();
                            cmd = new SqlCommand("SELECT SUM(YOUR_COST) FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + DDL_SHOPKEEPER_ID.SelectedItem.ToString() + "' AND STATUS='" + sta + "' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "'", con);
                            rd = cmd.ExecuteReader();
                            rd.Read();
                            double amt = Convert.ToDouble(rd[0].ToString());
                            double calculated_amount = amt * 12 / 100;
                            con.Close();
                            con.Close();
                            con.Open();
                            cmd = new SqlCommand("INSERT INTO PRINT_ADMIN_LOG(BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_USERNAME,CUSTOMER_NAME) SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_USERNAME,CUSTOMER_NAME FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + DDL_SHOPKEEPER_ID.SelectedItem.ToString() + "' AND STATUS='" + sta + "' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' UPDATE P SET P.SHOPKEEPER_ID=T.SHOPKEEPER_ID,P.SHOPKEEPER_NAME=T.SHOPKEEPER_NAME,P.ADDRESS=T.ADDRESS,P.TOWN_VILLAGE=T.TOWN_VILLAGE,P.CITY=T.CITY,P.DISTRICT=T.DISTRICT,P.PIN_CODE=T.PIN_CODE,P.PHONE_NUMBER=T.PHONE_NUMBER,P.ADHAAR_NUMBER=T.ADHAAR_NUMBER,P.EMAIL=T.EMAIL,P.SHOP_NAME=T.SHOP_NAME,P.SHOP_LOCATION=T.SHOP_LOCATION FROM PRINT_ADMIN_LOG P INNER JOIN SHOPKEEPER T ON T.EMAIL=P.SHOPKEEPER_USERNAME WHERE T.EMAIL='" + DDL_SHOPKEEPER_ID.SelectedItem.ToString() + "' UPDATE PRINT_ADMIN_LOG SET TOTAL_COST='" + amt + "',CALCULATED_COST='" +calculated_amount+ "',DATE_FROM='"+DATE_FROM_TXTBOX.Text+"',DATE_TO='"+DATE_TO_TXTBOX.Text+"' WHERE SHOPKEEPER_USERNAME='" + DDL_SHOPKEEPER_ID.SelectedItem.ToString() + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("PRINT ADMIN LOG.aspx");
                            
                        }
                    }

                }
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
                if (q == "DELEVERED")
                {
                    Cell.BackColor = Color.LightGreen;
                }
            }

        }
    }
    protected void CALCULATE_SHOPKEEPER_TRANSACTION_BTN_Click(object sender, EventArgs e)
    {
        CALCULATE_SHOPKEEPER_TRANSACTION_PANEL.Visible = true;
        CATEGORY_PANEL.Visible = false;
    }
    protected void UPDATE_CATEGORY_BTN_Click(object sender, EventArgs e)
    {
        CALCULATE_SHOPKEEPER_TRANSACTION_PANEL.Visible = false;
        CATEGORY_PANEL.Visible = true;
    }
    protected void SAVE_BTN_Click(object sender, EventArgs e)
    {
        con.Open();
        cmd = new SqlCommand("INSERT INTO CATEGORY VALUES('" + CATEGORY_TEXTBOX.Text + "','" + TYPE_TXTBOX.Text + "','" + SPECIFICATION_TXTBOX.Text + "')", con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('YOUR CATEGORY IS ADDED')</script>");
        con.Close();
    }
    protected void RESET_PAGE_BTN_Click(object sender, EventArgs e)
    {
        CATEGORY_TEXTBOX.Text = string.Empty;
        TYPE_TXTBOX.Text = string.Empty;
        SPECIFICATION_TXTBOX.Text = string.Empty;
    }
    protected void VERIFY_SHOPKEEPER_BTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("VERIFY.aspx");
    }
}
