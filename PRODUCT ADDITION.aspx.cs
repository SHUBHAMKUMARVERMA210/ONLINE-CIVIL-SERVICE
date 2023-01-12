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

public partial class PRODUCT_ADDITION : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        string un = (string)(Session["a"]);
        USERNAME_LBL.Text = un;
        USERNAME_LBL.Visible = false;
        if (!IsPostBack)
        {
            cmd = new SqlCommand("select DISTINCT CATEGORY from CATEGORY ", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDL_CATEGORY.DataSource = ds;
                DDL_CATEGORY.DataValueField = "CATEGORY";
                DDL_CATEGORY.DataBind();
                DDL_CATEGORY.Items.Insert(0, new ListItem("CHOOSE CATEGORY NAME", "0"));
                DDL_SPECIFICATION.Items.Insert(0, new ListItem("TYPE NOT AVAILABLE", "0"));
                DDL_TYPE.Items.Insert(0, new ListItem("SPECIFICATION NOT AVAILABLE", "0"));
                DDL_CATEGORY.SelectedIndex = 0;
                string[] s = { "MG", "GM", "KG", "MM","ML", "LTR" };
                DLL_WEIGHT_TYPE.DataSource = s;
                DLL_WEIGHT_TYPE.DataBind();
            }
            else
            {
                DDL_CATEGORY.Items.Insert(0, "CATEGORY NOT AVAILABLE");
                DDL_CATEGORY.DataBind();
            }

         }
        con.Open();
        
        con.Close();
        
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
            DDL_TYPE.Items.Insert(0, "TYPE NOT AVAILABLE");
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
            DDL_SPECIFICATION.Items.Insert(0, "SPECIFICATION NOT AVAILABLE");
        }

    }
    protected void SAVE_BTN_Click(object sender, EventArgs e)
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

                                                        try
                                                        {
                                                            string s = FileUpload1.FileName;
                                                            if (s == "")
                                                            {
                                                                Response.Write("<script>alert('PLEASE SELECT THE REQUIRED IMAGE')</script>");
                                                            }
                                                            else
                                                            {
                                                                string date = DateTime.Today.ToString("dd-MM-yyyy");
                                                                FileUpload1.PostedFile.SaveAs(Server.MapPath("~//image//" + s.Trim()));
                                                                string path = "~//image//" + s.Trim();
                                                                con.Open();
                                                                string sq = WEIGHT_TXTBOX.Text + DLL_WEIGHT_TYPE.SelectedItem.ToString();
                                                                cmd = new SqlCommand("Insert into PRODUCT values('" + PRODUCT_NAME_TXTBOX.Text + "','" + PRODUCT_DESCRIPTION_TXTBOX.Text + "','" + DDL_CATEGORY.SelectedItem.ToString() + "','" + path + "','" + COST_TXTBOX.Text + "','" + QUANTITY_TXTBOX.Text + "','" + sq + "','" + date + "','" + USERNAME_LBL.Text + "','" + DDL_TYPE.SelectedItem.ToString() + "','" + DDL_SPECIFICATION.SelectedItem.ToString() + "','o','o','o','o','o','o') UPDATE P SET P.SHOPKEEPER_NAME=S.SHOPKEEPER_NAME,P.SHOPKEEPER_TOWN_VILLAGE=S.TOWN_VILLAGE,P.SHOPKEEPER_DISTRICT=S.DISTRICT,P.SHOPKEEPER_PHONE_NUMBER=S.PHONE_NUMBER,P.SHOPKEEPER_SHOP_LOCATION=S.SHOP_LOCATION,P.SHOPKEEPER_CITY=S.CITY FROM PRODUCT P INNER JOIN SHOPKEEPER S ON S.EMAIL=P.SHOPKEEPER_USERNAME", con);
                                                                Response.Write("<script>alert('DATA INSERTED SUCCESSFULLY BY YOU')</script>");
                                                                cmd.ExecuteNonQuery();
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
    protected void NEXT_PAGE_BTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRODUCT.aspx");
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
}