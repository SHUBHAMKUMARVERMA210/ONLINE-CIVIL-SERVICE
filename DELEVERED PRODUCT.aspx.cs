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

public partial class DELEVERD_PRODUCT : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    DataSet ds = new DataSet();
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        VIEW_DELEVERED_PRODUCT_BY_ID_PANEL.Visible = false;
        VIEW_DELEVERED_PRODUCT_BY_DATE_PANEL.Visible = false;
        BTN_CALCULATE_BY_PRODUCT_ID_AND_DATE.Visible = false;
        BTN_PRINT_BY_ID_AND_DATE.Visible = false;
        BTN_PRINT_BY_DATE.Visible = false;
        BTN_PRINT_BY_ID.Visible = false;
        AMT_LBL.Visible = false;
        string a = Request.QueryString["EMAIL_ID"];
        string b = Request.QueryString["PRODUCT_ID"];
        string nm = (string)(Session["nm"]);
        string unm = (string)(Session["a"]);
        WELCOME_LBL.Visible = true;
        WELCOME_LBL.Text = "WELCOME!" + " " + nm;
        if (nm == null)
        {
        
            WELCOME_LBL.Visible = false;
        }
        if (!IsPostBack)
        {
            cmd = new SqlCommand("SELECT DISTINCT PRODUCT_ID FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "'", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_PRODUCT_ID.DataSource = ds;
                DDL_PRODUCT_ID.DataValueField = "PRODUCT_ID";
                DDL_PRODUCT_ID.DataBind();
                DDL_PRODUCT_ID.Items.Insert(0, new ListItem("CHOOSE PRODUCT ID", "0"));
            }
            else
            {
                DDL_PRODUCT_ID.Items.Insert(0, "PRODUCT ID NOT AVAILABLE");
                DDL_PRODUCT_ID.DataBind();
            }
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
        }
        else
        {
            Response.Redirect("LOGIN.aspx");
        }
        con.Close();

    }
    protected void BTN_CALCULATE_BY_PRODUCT_ID_AND_DATE_Click(object sender, EventArgs e)
    {
        BTN_PRINT_BY_ID.Visible = false;
        BTN_PRINT_BY_ID_AND_DATE.Visible = true;
        BTN_PRINT_BY_DATE.Visible = false;
        con.Open();
        cmd = new SqlCommand("DELETE FROM PRINT_DELEVERED_PRODUCT", con);
        cmd.ExecuteNonQuery();
        con.Close();
        if (DDL_PRODUCT_ID.SelectedItem.ToString() == "CHOOSE PRODUCT ID")
        {
            Response.Write("<script>alert('PLEASE CHOOSE A PRODUCT ID')</script>");
        }
        else
        {
            if (DDL_PRODUCT_ID.SelectedItem.ToString() == "PRODUCT ID NOT AVAILABLE")
            {
                Response.Write("<script>alert('PRODUCT ID NOT AVAILABLE')</script>");
            }
            else
            {
                if (DATE_FROM_TXTBOX.Text == "")
                {
                    Response.Write("<script>alert('PLEASE SELECT DATE FROM')</script>");
                }
                else
                {
                    if (DATE_TO_TXTBOX.Text == "")
                    {
                        Response.Write("<script>alert('PLEASE SELECT DATE TO')</script>");
                    }
                    else
                    {
                        int product_id = Convert.ToInt32(DDL_PRODUCT_ID.SelectedIndex.ToString());
                        string unm = (string)(Session["a"]);
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' AND SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED' AND PRODUCT_ID='" + product_id + "'", con);
                        rd = cmd.ExecuteReader();
                        if(rd.Read())
                        {
                        rd.Close();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        con.Close();
                        BTN_CALCULATE_BY_PRODUCT_ID_AND_DATE.Visible = true;
                        BTN_PRINT_BY_ID_AND_DATE.Visible = true;
                        }
                        else
                        {
                            Response.Write("<script>alert('NO RECORDS PRESENT')</script>");
                        }
                    }
                }
            }
        }

    }
    protected void BTN_CALCULATE_BY_DATE_Click(object sender, EventArgs e)
    {
        con.Open();
        cmd = new SqlCommand("DELETE FROM PRINT_DELEVERED_PRODUCT", con);
        cmd.ExecuteNonQuery();
        con.Close();
        if (DATE_FROM_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('PLEASE SELECT DATE FROM')</script>");
        }
        else
        {
            if (DATE_TO_TXTBOX.Text == "")
            {
                Response.Write("<script>alert('PLEASE SELECT DATE TO')</script>");
            }
            else
            {
                string unm = (string)(Session["a"]);
                con.Close();
                con.Open();
                cmd = new SqlCommand("SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,YOUR_COST,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' AND SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED'", con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    rd.Close();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    con.Close();
                    VIEW_DELEVERED_PRODUCT_BY_DATE_PANEL.Visible = true;
                    BTN_PRINT_BY_DATE.Visible = true;
                }
                else
                {
                    Response.Write("<script>alert('NO RECORDS PRESENT BETWEEN THESE DATES')</script>");
                }
            }
        }
    }
    protected void BTN_CALCULATE_BY_PRODUCT_ID_Click(object sender, EventArgs e)
    {
        con.Open();
        cmd = new SqlCommand("DELETE FROM PRINT_DELEVERED_PRODUCT", con);
        cmd.ExecuteNonQuery();
        con.Close();
        if (DDL_PRODUCT_ID.SelectedItem.ToString() == "CHOOSE PRODUCT ID")
        {
            Response.Write("<script>alert('PLEASE CHOOSE A PRODUCT ID')</script>");
        }
        else
        {
            if (DDL_PRODUCT_ID.SelectedItem.ToString() == "PRODUCT ID NOT AVAILABLE")
            {
                Response.Write("<script>alert('PRODUCT ID NOT AVAILABLE')</script>");
            }
            else
            {
                int product_id=Convert.ToInt32(DDL_PRODUCT_ID.SelectedItem.ToString());
                string unm = (string)(Session["a"]);
                con.Close();
                con.Open();
                cmd = new SqlCommand("SELECT BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,TOTAL_AMOUNT,STATUS FROM TRANSACT_1 WHERE PRODUCT_ID='" + product_id + "' AND SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED'", con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    rd.Close();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    con.Close();
                    VIEW_DELEVERED_PRODUCT_BY_ID_PANEL.Visible = true;
                    BTN_PRINT_BY_ID.Visible = true;
                }
                else
                {
                    Response.Write("<script>alert('NO RECORDS PRESENT IN THIS ID')</script>");
                }
            }
        }
    }
    protected void BTN_PRINT_BY_ID_AND_DATE_Click(object sender, EventArgs e)
    {
        BTN_PRINT_BY_ID.Visible = false;
        BTN_PRINT_BY_ID_AND_DATE.Visible = true;
        BTN_PRINT_BY_DATE.Visible = false;
        string unm = (string)(Session["a"]);
        if (DDL_PRODUCT_ID.SelectedItem.ToString() == "CHOOSE PRODUCT ID")
        {
            Response.Write("<script>alert('PLEASE CHOOSE A PRODUCT ID')</script>");
        }
        else
        {
            if (DDL_PRODUCT_ID.SelectedItem.ToString() == "PRODUCT ID NOT AVAILABLE")
            {
                Response.Write("<script>alert('PRODUCT ID NOT AVAILABLE')</script>");
                Response.Write("<script>alert('UNABLE TO PRINT')</script>");
            }
            else
            {
                if (DATE_FROM_TXTBOX.Text == "")
                {
                    Response.Write("<script>alert('PLEASE SELECT DATE FROM')</script>");
                }
                else
                {
                    if (DATE_TO_TXTBOX.Text == "")
                    {
                        Response.Write("<script>alert('PLEASE SELECT DATE TO')</script>");
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM PRINT_DELEVERED_PRODUCT", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        int product_id = Convert.ToInt32(DDL_PRODUCT_ID.SelectedIndex.ToString());
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO PRINT_DELEVERED_PRODUCT(USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,ORDERED_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME) SELECT USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME FROM TRANSACT_1 WHERE PRODUCT_ID='" + product_id + "' AND DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' AND SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("SELECT SUM(ORDERED_COST) FROM PRINT_DELEVERED_PRODUCT WHERE SHOPKEEPER_USERNAME='" + unm + "'", con);
                        rd = cmd.ExecuteReader();
                        rd.Read();
                        string amt = rd[0].ToString();
                        AMT_LBL.Text = amt;
                        con.Close();
                        rd.Close();
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("UPDATE PRINT_DELEVERED_PRODUCT SET TOTAL_AMOUNT='" + amt + "',DATE_FROM='" + DATE_FROM_TXTBOX.Text + "',DATE_TO='" + DATE_TO_TXTBOX.Text + "',BY_PRODUCT_ID='"+DDL_PRODUCT_ID.SelectedItem.ToString()+"'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("PRINT DELEVERED PRODUCT.aspx");
                    }
                }
            }
        }
    }
    protected void BTN_PRINT_BY_DATE_Click(object sender, EventArgs e)
    {
        BTN_PRINT_BY_ID.Visible = false;
        BTN_PRINT_BY_ID_AND_DATE.Visible = false;
        BTN_PRINT_BY_DATE.Visible = true;
        string unm = (string)(Session["a"]);
        if (DATE_FROM_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('PLEASE SELECT DATE FROM')</script>");
        }
        else
        {
            if (DATE_TO_TXTBOX.Text == "")
            {
                Response.Write("<script>alert('PLEASE SELECT DATE TO')</script>");
            }
            else
            {
                if (DATE_FROM_TXTBOX.Text == "" & DATE_TO_TXTBOX.Text == "")
                {
                    Response.Write("<script>alert('PLEASE SELECT DATE FROM AND DATE TO')</script>");
                }
                else
                {
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM PRINT_DELEVERED_PRODUCT", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO PRINT_DELEVERED_PRODUCT(USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,ORDERED_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME) SELECT USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME FROM TRANSACT_1 WHERE DATE_OF_TRANSACTION BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' AND SHOPKEEPER_USERNAME='" + unm + "' AND STATUS='DELEVERED'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("SELECT SUM(ORDERED_COST) FROM PRINT_DELEVERED_PRODUCT WHERE SHOPKEEPER_USERNAME='" + unm + "'", con);
                    rd = cmd.ExecuteReader();
                    rd.Read();
                    string amt = rd[0].ToString();
                    AMT_LBL.Text = amt;
                    con.Close();
                    rd.Close();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("UPDATE PRINT_DELEVERED_PRODUCT SET TOTAL_AMOUNT='"+amt+"',DATE_FROM='"+DATE_FROM_TXTBOX.Text+"',DATE_TO='"+DATE_TO_TXTBOX.Text+"',BY_PRODUCT_ID='NULL'",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("PRINT DELEVERED PRODUCT.aspx");
                }
            }
        }
         
    }
    protected void BTN_PRINT_BY_ID_Click(object sender, EventArgs e)
    {
        BTN_PRINT_BY_ID.Visible = true;
        BTN_PRINT_BY_ID_AND_DATE.Visible = false;
        BTN_PRINT_BY_DATE.Visible = false;
        string unm = (string)(Session["a"]);
        if (DDL_PRODUCT_ID.SelectedItem.ToString() == "CHOOSE PRODUCT ID")
        {
            Response.Write("<script>alert('PLEASE CHOOSE A PRODUCT ID')</script>");
        }
        else
        {
            if (DDL_PRODUCT_ID.SelectedItem.ToString() == "PRODUCT ID NOT AVAILABLE")
            {
                Response.Write("<script>alert('PRODUCT ID NOT AVAILABLE')</script>");
            }
            else
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("DELETE FROM PRINT_DELEVERED_PRODUCT", con);
                cmd.ExecuteNonQuery();
                con.Close();
                int product_id = Convert.ToInt32(DDL_PRODUCT_ID.SelectedIndex.ToString());
                con.Open();
                cmd = new SqlCommand("INSERT INTO PRINT_DELEVERED_PRODUCT(USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,ORDERED_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME) SELECT USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_NAME,ORDERED_QUANTITY,DATE_OF_TRANSACTION,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME FROM TRANSACT_1 WHERE SHOPKEEPER_USERNAME='" + unm + "' AND PRODUCT_ID='" + product_id + "' AND STATUS='DELEVERED'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Close();
                con.Open();
                cmd = new SqlCommand("SELECT SUM(ORDERED_COST) FROM PRINT_DELEVERED_PRODUCT WHERE SHOPKEEPER_USERNAME='" + unm + "'", con);
                rd = cmd.ExecuteReader();
                rd.Read();
                string amt = rd[0].ToString();
                AMT_LBL.Text = amt;
                con.Close();
                rd.Close();
                con.Close();
                con.Open();
                cmd = new SqlCommand("UPDATE PRINT_DELEVERED_PRODUCT SET TOTAL_AMOUNT='" + amt + "',DATE_FROM='NULL',DATE_TO='NULL',BY_PRODUCT_ID='"+DDL_PRODUCT_ID.SelectedItem.ToString()+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("PRINT DELEVERED PRODUCT.aspx");
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

                if (q == "DELEVERED")
                {
                    Cell.BackColor = Color.LightGreen;
                }
            }

        }
    }
    protected void VIEW_DELEVERED_PRODUCT_BY_ID_BTN_Click(object sender, EventArgs e)
    {
        VIEW_DELEVERED_PRODUCT_BY_ID_PANEL.Visible = true;
        BTN_CALCULATE_BY_PRODUCT_ID_AND_DATE.Visible = false;
        BTN_CALCULATE_BY_PRODUCT_ID.Visible = true;
        BTN_PRINT_BY_ID.Visible = true;
    }
    protected void VIEW_DELEVERED_PRODUCT_BY_DATE_BTN_Click(object sender, EventArgs e)
    {
        VIEW_DELEVERED_PRODUCT_BY_DATE_PANEL.Visible = true;
        BTN_CALCULATE_BY_PRODUCT_ID_AND_DATE.Visible = false;
        BTN_PRINT_BY_DATE.Visible = true;
        BTN_CALCULATE_BY_DATE.Visible = true;
    }
    protected void VIEW_DELEVERED_PRODUCT_BY_ID_AND_DATE_BTN_Click(object sender, EventArgs e)
    {
        VIEW_DELEVERED_PRODUCT_BY_ID_PANEL.Visible = true;
        VIEW_DELEVERED_PRODUCT_BY_DATE_PANEL.Visible = true;
        BTN_CALCULATE_BY_DATE.Visible = false;
        BTN_CALCULATE_BY_PRODUCT_ID.Visible = false;
        BTN_CALCULATE_BY_PRODUCT_ID_AND_DATE.Visible = true;
        BTN_PRINT_BY_ID_AND_DATE.Visible = true;
        BTN_PRINT_BY_ID.Visible = false;
        BTN_PRINT_BY_DATE.Visible = false;
    }
    protected void LNK_BTN_Back_to_shopkeeper_log_Click(object sender, EventArgs e)
    {
        Response.Redirect("SHOPKEEPER LOg.aspx");
    }
}
