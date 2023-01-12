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

public partial class UPDATE_PRODUCT : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    DataSet ds = new DataSet();
    SqlDataAdapter da;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        USERNAME_LBL.Visible = false;
        string un = (string)(Session["a"]);
        USERNAME_LBL.Text = un;
        if (!IsPostBack)
        {
            cmd = new SqlCommand("select CATEGORY from CATEGORY ", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_CATEGORY.DataSource = ds;
                DDL_CATEGORY.DataValueField = "CATEGORY";
                DDL_CATEGORY.DataBind();
                DDL_CATEGORY.Items.Insert(0, new ListItem("CHOOSE CATEGORY NAME", "0"));
                DDL_PRODUCT_NAME.Items.Insert(0, new ListItem("PRODUCT NOT AVAILABLE", "0"));
                DDL_SPECIFICATION.Items.Insert(0, new ListItem("TYPE NOT AVAILABLE", "0"));
                DDL_TYPE.Items.Insert(0, new ListItem("SPECIFICATION NOT AVAILABLE", "0"));
                DDL_CATEGORY.SelectedIndex = 0;
            }
            else
            {
                DDL_CATEGORY.Items.Insert(0, "CATEGORY NOT AVAILABLE");
                DDL_CATEGORY.DataBind();
            }

        }
        con.Open();
        con.Close();
        string unm = (string)(Session["a"]);
        con.Close();
        con.Open();
       SqlCommand cmd2 = new SqlCommand("SELECT * FROM PRODUCT WHERE SHOPKEEPER_USERNAME='"+unm+"'", con);
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        GridView1.DataSource = ds2.Tables[0];
        GridView1.DataBind();
        con.Close();
        con.Close();
       
    }
    protected void UPDATE_BTN_Click(object sender, EventArgs e)
    {
        if (DDL_CATEGORY.SelectedItem.ToString() == "CHOOSE CATEGORY NAME")
        {
            Response.Write("<script>alert('PLEASE SELECT THE RSEPECTIVE CATEGORY')</script>");
        }
        else
        {
            if (DDL_CATEGORY.SelectedItem.ToString() == "CATEGORY NOT AVAILABLE")
            {
                Response.Write("<script>alert('CATEGORY NAME NOT AVAILABLE')</script>");
            }
            else
            {
                if (DDL_TYPE.SelectedItem.ToString() == "CHOOSE TYPE")
                {
                    Response.Write("<script>alert('PLEASE SELECT SPECIFIC TYPE NAME')</script>");
                }
                else
                {
                    if (DDL_TYPE.SelectedItem.ToString() == "TYPE NOT AVAILABLE")
                    {
                        Response.Write("<script>alert('TYPE NOT AVAILABLE')</script>");
                    }
                    else
                    {
                        if (DDL_SPECIFICATION.SelectedItem.ToString() == "CHOOSE SPECIFICATION")
                        {
                            Response.Write("<script>alert('PLEASE SELECT RESPECTIVE SPECIFICATION')</script>");
                        }
                        else
                        {
                            if (DDL_SPECIFICATION.SelectedItem.ToString() == "SPECIFICATION NOT AVAILABLE")
                            {
                                Response.Write("<script>alert('SPECIFICATION NOT AVAILABLE')</script>");
                            }
                            else
                            {
                                if (DDL_PRODUCT_NAME.SelectedItem.ToString() == "CHOOSE PRODUCT")
                                {
                                    Response.Write("<script>alert('PLEASE CHOOSE YOUR PRODUCT')</script>");
                                }
                                else
                                {
                                    if (DDL_PRODUCT_NAME.SelectedItem.ToString() == "PRODUCT NOT AVAILABLE")
                                    {
                                        Response.Write("<script>alert('PRODUCT NOT AVAILABLE')</script>");
                                    }
                                    else
                                    {
                                        if (PRODUCT_NAME_TXTBOX.Text == "")
                                        {
                                            Response.Write("<script>alert('PRODUCT NAME CANNOT BE EMPTY')</script>");
                                        }
                                        else
                                        {
                                            if (PRODUCT_DESCRIPTION_TXTBOX.Text == "")
                                            {
                                                Response.Write("<script>alert('PRODUCT DESCRIPTION CANNOT BE EMPTY')</script>");
                                            }
                                            else
                                            {
                                                if (COST_TXTBOX.Text == "")
                                                {
                                                    Response.Write("<script>alert('PRODUCT COST CANNOT BE EMPTY')</script>");
                                                }
                                                else
                                                {
                                                    if (QUANTITY_TXTBOX.Text == "")
                                                    {
                                                        Response.Write("<script>alert('PRODUCT QUANTITY CANNOT BE EMPTY')</script>");
                                                    }
                                                    else
                                                    {
                                                        if (WEIGHT_TXTBOX.Text == "")
                                                        {
                                                            Response.Write("<script>alert('PRODUCT WEIGHT CANNOT BE EMPTY')</script>");
                                                        }
                                                        else
                                                        {

                                                            try
                                                            {
                                                                string s = FileUpload1.FileName;
                                                                if (s == "")
                                                                {
                                                                    Response.Write("<script>alert('PLEASE SELECT THE REQUIRED IMAGE')</script>");
                                                                }
                                                                else
                                                                {
                                                                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~//image//" + s.Trim()));
                                                                    string path = "~//image//" + s.Trim();
                                                                    con.Open();
                                                                    cmd = new SqlCommand("UPDATE PRODUCT SET PRODUCT_NAME='" + PRODUCT_NAME_TXTBOX.Text + "',PRODUCT_DESCRIPTION='" + PRODUCT_DESCRIPTION_TXTBOX.Text + "',PRODUCT_IMAGE='" + path + "',COST='" + COST_TXTBOX.Text + "',QUANTITY='" + QUANTITY_TXTBOX.Text + "',WEIGHT='" + WEIGHT_TXTBOX.Text + "' where PRODUCT_ID='" + PRODUCT_ID_TXTBOX.Text + "'", con);
                                                                    Response.Write("<script>alert('DATA UPDATED SUCCESSFULLY BY YOU')</script>");
                                                                    cmd.ExecuteNonQuery();
                                                                    con.Close();
                                                                    con.Close();
                                                                    string unm = (string)(Session["a"]);
                                                                    con.Close();
                                                                    con.Open();
                                                                   SqlCommand cmd1 = new SqlCommand("SELECT * FROM PRODUCT WHERE SHOPKEEPER_USERNAME='" + unm + "'", con);
                                                                   SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                                                                   DataSet ds1=new DataSet();
                                                                    da1.Fill(ds1);
                                                                    GridView1.DataSource = ds1.Tables[0];
                                                                    GridView1.DataBind();
                                                                    con.Close();
                                                                    con.Close();
                                                                }
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Response.Write(ex.ToString());
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
            }
        }
    }
    protected void DDL_CATEGORY_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_CATEGORY.SelectedItem.ToString() != "0")
        {
            cmd = new SqlCommand("SELECT TYPE FROM CATEGORY where CATEGORY='" + DDL_CATEGORY.SelectedItem.ToString() + "'", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_TYPE.DataSource = ds;
                DDL_TYPE.DataValueField = "TYPE";
                DDL_TYPE.DataBind();
                DDL_TYPE.Items.Insert(0, new ListItem("CHOOSE TYPE", "0"));
                DDL_TYPE.SelectedIndex = 0;

            }
        }
        else
        {
            DDL_PRODUCT_NAME.Items.Insert(0, "TYPE NOT AVAILABLE");
        }
    }
    protected void DDL_TYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_TYPE.SelectedItem.ToString() != "0")
        {
            cmd = new SqlCommand("SELECT SPECIFICATION FROM CATEGORY where TYPE='" + DDL_TYPE.SelectedItem.ToString() + "'", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_SPECIFICATION.DataSource = ds;
                DDL_SPECIFICATION.DataValueField = "SPECIFICATION";
                DDL_SPECIFICATION.DataBind();
                DDL_SPECIFICATION.Items.Insert(0, new ListItem("CHOOSE SPECIFICATION", "0"));
                DDL_SPECIFICATION.SelectedIndex = 0;

            }
        }
        else
        {
            DDL_PRODUCT_NAME.Items.Insert(0, "SPECIFICATION NOT AVAILABLE");
        }

    }
    protected void DDL_SPECIFICATION_SelectedIndexChanged(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        if (DDL_SPECIFICATION.SelectedItem.ToString() != "0")
        {
            cmd = new SqlCommand("SELECT PRODUCT_NAME FROM PRODUCT where SPECIFICATION='" + DDL_SPECIFICATION.SelectedItem.ToString() + "' AND SHOPKEEPER_USERNAME='" + un + "' AND TYPE='" + DDL_TYPE.SelectedItem.ToString() + "'", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_PRODUCT_NAME.DataSource = ds;
                DDL_PRODUCT_NAME.DataValueField = "PRODUCT_NAME";
                DDL_PRODUCT_NAME.DataBind();
                DDL_PRODUCT_NAME.Items.Insert(0, new ListItem("CHOOSE PRODUCT", "0"));
                DDL_PRODUCT_NAME.SelectedIndex = 0;

            }
        }
        else
        {
            DDL_PRODUCT_NAME.Items.Insert(0, "PRODUCT NOT AVAILABLE");
        }
    }
    protected void RESET_PAGE_BTN_Click(object sender, EventArgs e)
    {
        PRODUCT_ID_TXTBOX.Text = string.Empty;
        PRODUCT_NAME_TXTBOX.Text = string.Empty;
        PRODUCT_DESCRIPTION_TXTBOX.Text = string.Empty;
        COST_TXTBOX.Text = string.Empty;
        QUANTITY_TXTBOX.Text = string.Empty;
        WEIGHT_TXTBOX.Text = string.Empty;
    }
    protected void DDL_PRODUCT_NAME_SelectedIndexChanged(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        string product = Convert.ToString(DDL_PRODUCT_NAME.SelectedValue);
        cmd = new SqlCommand("SELECT DISTINCT PRODUCT_ID,PRODUCT_NAME,PRODUCT_DESCRIPTION,CATEGORY,PRODUCT_IMAGE,COST,QUANTITY,WEIGHT,DATE_OF_ENTRY,SHOPKEEPER_USERNAME from PRODUCT where PRODUCT_NAME='" + product + "' AND SHOPKEEPER_USERNAME='" + un + "'", con);
        da = new SqlDataAdapter(cmd);
        DataTable dt3 = new DataTable();
        da.Fill(dt3);
        PRODUCT_ID_TXTBOX.Text = dt3.Rows[0].ItemArray[0].ToString();
        PRODUCT_NAME_TXTBOX.Text = dt3.Rows[0].ItemArray[1].ToString();
        PRODUCT_DESCRIPTION_TXTBOX.Text = dt3.Rows[0].ItemArray[2].ToString();
        COST_TXTBOX.Text = dt3.Rows[0].ItemArray[5].ToString();
        QUANTITY_TXTBOX.Text = dt3.Rows[0].ItemArray[6].ToString();
        WEIGHT_TXTBOX.Text = dt3.Rows[0].ItemArray[7].ToString();

    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int q = (int)DataBinder.Eval(e.Row.DataItem, "QUANTITY");
            foreach (TableCell Cell in e.Row.Cells)
            {

                if (q <= 0)
                {
                    Cell.BackColor = Color.LightPink;
                }
                if (q > 0)
                {
                    Cell.BackColor = Color.LightGreen;
                }
            }
        }
    }
    protected void BACK_TO_SHOPKEEPER_LOG_BTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("SHOPKEEPER LOG.aspx");
    }
}
