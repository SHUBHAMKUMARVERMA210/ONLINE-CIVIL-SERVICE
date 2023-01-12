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

public partial class VERIFY : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DDL_STATUS.Items.Insert(0, "STATUS NOT AVAILABLE TO UPDATE");
            DDL_STATUS.DataBind();
        }
        if(!IsPostBack)
        {
            DDL_USER_ID.Items.Insert(0, "USERNAME NOT AVAILABLE TO UPDATE");
            DDL_USER_ID.DataBind();
        }
    }

    protected void VIEW_BTN_Click(object sender, EventArgs e)
    {
        if (DATE_FROM_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('PLEASE ENTER DATE FROM')</script>");
        }
        else
        {
            if (DATE_TO_TXTBOX.Text=="")
            {
                Response.Write("<script>alert('PLEASE ENTER DATE TO')</script>");
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("SELECT USER_NAME FROM LOGIN_1 WHERE DATE BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' AND USER_TYPE='SHOPKEEPER'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DDL_USER_ID.DataSource = ds1;
                    DDL_USER_ID.DataValueField = "USER_NAME";
                    DDL_USER_ID.DataBind();
                    DDL_USER_ID.Items.Insert(0, new ListItem("CHOOSE USERNAME TO UPDATE", "0"));
                }
                else
                {
                    DDL_USER_ID.Items.Insert(0, "USERNAME NOT AVAILABLE TO UPDATE");
                    DDL_USER_ID.DataBind();
                }
                con.Close();
                con.Close();
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM LOGIN_1 WHERE DATE BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' AND USER_TYPE='SHOPKEEPER'", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                GridView1.DataSource = ds2.Tables[0];
                GridView1.DataBind();
                con.Close();
                con.Close();
                con.Open();
                cmd = new SqlCommand("SELECT * FROM LOGIN_1 WHERE DATE BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' AND USER_TYPE='SHOPKEEPER' AND USER_NAME IS NOT NULL",con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                }
                else
                {
                    Response.Write("<script>alert('NO USER RECORDS PRESENT BETWEEN THESE DATES')</script>");
                }
                con.Close();
            }
        }
    }
    protected void DDL_USER_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_USER_ID.SelectedItem.ToString() != "0" & DDL_USER_ID.SelectedItem.ToString() != "SHOPKEEPER ID NOT AVAILABLE TO UPDATE")
        {
            string[] status = { "--SELECT SATUS--", "VERIFIED", "NOT-VERIFIED" };
            DDL_STATUS.DataSource = status;
            DDL_STATUS.DataBind();
        }
        else
        {
            DDL_STATUS.Items.Insert(0, "STATUS NOT AVAILABLE TO UPDATE");
            DDL_STATUS.DataBind();
        }
    }
    protected void UPDATE_BTN_Click(object sender, EventArgs e)
    {
          if (DDL_USER_ID.SelectedItem.ToString() == "CHOOSE USERNAME TO UPDATE")
            {
                Response.Write("<script>alert('CHOOSE SHOPKEEPER ID TO UPDATE')</script>");
            }
            else
            {
                if (DDL_USER_ID.SelectedItem.ToString() == "USERNAME NOT AVAILABLE TO UPDATE")
                {
                    Response.Write("<script>alert('SHOPKEEPER ID NOT AVAILABLE TO UPDATE')</script>");
                }
                else
                {
                    if (DDL_STATUS.SelectedItem.ToString() == "--SELECT SATUS--")
                    {
                        Response.Write("<script>alert('SELECT STATUS TO UPDATE')</script>");
                    }
                    else
                    {
                        if (DDL_STATUS.SelectedItem.ToString() == "STATUS NOT AVAILABLE TO UPDATE")
                        {
                            Response.Write("<script>alert('STATUS NOT AVAILABLE ')</script>");
                        }
                        else
                        {
                            con.Close();
                            con.Open();
                            SqlCommand cmd3 = new SqlCommand("UPDATE LOGIN_1 SET STATUS='"+DDL_STATUS.SelectedItem.ToString()+"' WHERE USER_NAME='"+DDL_USER_ID.SelectedItem.ToString()+"'",con);
                            cmd3.ExecuteNonQuery();
                            con.Close();
                            con.Close();
                            con.Close();
                            con.Close();
                            con.Open();
                            SqlCommand cmd4 = new SqlCommand("SELECT * FROM LOGIN_1 WHERE DATE BETWEEN '" + DATE_FROM_TXTBOX.Text + "' AND '" + DATE_TO_TXTBOX.Text + "' AND USER_TYPE='SHOPKEEPER'", con);
                            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                            DataSet ds4 = new DataSet();
                            da4.Fill(ds4);
                            GridView1.DataSource = ds4.Tables[0];
                            GridView1.DataBind();
                            con.Close();
                            con.Close();
                        }
                    }
                }
            }
        }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string m = (string)DataBinder.Eval(e.Row.DataItem, "STATUS");
            string n = (string)DataBinder.Eval(e.Row.DataItem, "USER_TYPE");
            foreach (TableCell Cell in e.Row.Cells)
            {
                if (m == "VERIFIED" && n == "SHOPKEEPER")
                {
                    Cell.BackColor = Color.LightGreen;
                }
                if (m == "NOT-VERIFIED" && n == "SHOPKEEPER")
                {
                    Cell.BackColor = Color.LightPink;
                }
            }
        }
    }
    protected void BACK_TO_ADMIN_LOG_BTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("ADMIN LOG.aspx");
    }
    protected void PRINT_BTN_Click(object sender, EventArgs e)
    {
        if (DDL_USER_ID.SelectedItem.ToString() == "USERNAME NOT AVAILABLE TO UPDATE")
        {
            Response.Write("<script>alert('NO USERNAME AVAILABLE')</script>");
        }
        else
        {
            if (DDL_USER_ID.SelectedItem.ToString() == "CHOOSE USERNAME TO UPDATE")
            {
                Response.Write("<script>alert('CHOOSE USERNAME TO PRINT')</script>");
            }
            else
            {
                Response.Redirect("PRINT USER.aspx?username=" + DDL_USER_ID.SelectedItem.ToString());
            }
        }
    }
}