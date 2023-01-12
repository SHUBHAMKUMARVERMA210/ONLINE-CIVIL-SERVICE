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


public partial class LOGIN : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string[] s = { "--SELECT USER TYPE--", "ADMIN", "SHOPKEEPER", "CUSTOMER" };
            DropDownList1.DataSource = s;
            DropDownList1.DataBind();
        }
       
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("CUSTOMER REGISTRATION.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CHANGE PASSWORD.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("CUSTOMER REGISTRATION.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string st = "VERIFIED";
        if (TextBox1.Text == "" & TextBox2.Text != "" & DropDownList1.SelectedItem.ToString() != "--SELECT USER TYPE--")
        {

            Response.Write("<script>alert('ENTER A USERNAME')</script>");
        }
        else
        {
            if (TextBox2.Text == "" & TextBox1.Text != "" & DropDownList1.SelectedItem.ToString() != "--SELECT USER TYPE--")
            {
                Response.Write("<script>alert('ENTER A PASSWORD')</script>");
            }
            else
            {
                if (TextBox2.Text == "" & TextBox1.Text == "" & DropDownList1.SelectedItem.ToString() == "--SELECT USER TYPE--")
                {
                    Response.Write("<script>alert('ENTER A USERNAME')</script>");
                    Response.Write("<script>alert('ENTER A PASSWORD')</script>");
                    Response.Write("<script>alert('SELECT A USER TYPE')</script>");
                }
                else
                {
                    if (TextBox1.Text == "" & TextBox2.Text != "" & DropDownList1.SelectedItem.ToString() == "--SELECT USER TYPE--")
                    {
                        Response.Write("<script>alert('ENTER A USERNAME')</script>");
                        Response.Write("<script>alert('SELECT A USER TYPE')</script>");
                    }
                    else
                    {
                        if (TextBox1.Text != "" & TextBox2.Text == "" & DropDownList1.SelectedItem.ToString() == "--SELECT USER TYPE--")
                        {
                            Response.Write("<script>alert('ENTER A PASSWORD')</script>");
                            Response.Write("<script>alert('SELECT A USER TYPE')</script>");
                        }
                        else
                        {
                            if (TextBox1.Text != "" & TextBox2.Text != "" & DropDownList1.SelectedItem.ToString() == "--SELECT USER TYPE--")
                            {
                                Response.Write("<script>alert('SELECT A USER TYPE')</script>");
                            }
                            else
                            {
                                con.Open();
                                cmd = new SqlCommand("SELECT USER_TYPE,USER_NAME,PASSWORD,STATUS FROM LOGIN_1 WHERE USER_NAME!='" + TextBox1.Text + "'AND PASSWORD='" + TextBox2.Text + "' AND USER_TYPE='" + DropDownList1.SelectedItem.ToString() + "' AND STATUS='" + st + "'", con);
                                rd = cmd.ExecuteReader();
                                if (rd.Read())
                                {
                                    Response.Write("<script>alert('INVALID USERNAME')</script>");
                                    Response.Write("<script>alert('LOGIN UNSUCCESSFULL')</script>");
                                }
                                else
                                {
                                    rd.Close();
                                    con.Close();
                                    con.Close();
                                    con.Open();
                                    cmd = new SqlCommand("SELECT USER_TYPE,USER_NAME,PASSWORD,STATUS FROM LOGIN_1 WHERE USER_NAME='" + TextBox1.Text + "'AND PASSWORD!='" +TextBox2.Text + "' AND USER_TYPE='" + DropDownList1.SelectedItem.ToString() + "' AND STATUS='" + st + "'", con);
                                    rd = cmd.ExecuteReader();
                                    if (rd.Read())
                                    {
                                        Response.Write("<script>alert('INVALID PASSWORD')</script>");
                                        Response.Write("<script>alert('LOGIN UNSUCCESSFULL')</script>");
                                    }
                                    else
                                    {
                                        rd.Close();
                                        con.Close();
                                        con.Close();
                                        con.Close();
                                        con.Open();
                                        cmd = new SqlCommand("SELECT USER_TYPE,USER_NAME,PASSWORD,STATUS FROM LOGIN_1 WHERE USER_NAME='" + TextBox1.Text + "'AND PASSWORD='" + TextBox2.Text + "' AND USER_TYPE!='" + DropDownList1.SelectedItem.ToString() + "' AND STATUS='" + st + "'", con);
                                        rd = cmd.ExecuteReader();
                                        if (rd.Read())
                                        {
                                            Response.Write("<script>alert('INVALID USER TYPE')</script>");
                                            Response.Write("<script>alert('LOGIN UNSUCCESSFULL')</script>");
                                        }
                                        else
                                        {
                                            rd.Close();
                                            con.Close();
                                            con.Close();
                                            con.Open();
                                            cmd = new SqlCommand("SELECT USER_TYPE,USER_NAME,PASSWORD,STATUS FROM LOGIN_1 WHERE USER_NAME='" + TextBox1.Text + "'AND PASSWORD='" + TextBox2.Text + "' AND USER_TYPE='" + DropDownList1.SelectedItem.ToString() + "' AND STATUS!='" + st + "'", con);
                                            rd = cmd.ExecuteReader();
                                            if (rd.Read())
                                            {
                                                Response.Write("<script>alert('YOUR USER ID IS NOT VERIFIED BY THE ADMIN')</script>");
                                                Response.Write("<script>alert('WAIT TILL YOUR ID VERIFIES')</script>");
                                                Response.Write("<script>alert('THANKYOU')</script>");
                                            }
                                            else
                                            {
                                                rd.Close();
                                                con.Close();
                                                con.Close();
                                                con.Open();
                                                cmd = new SqlCommand("SELECT USER_TYPE,USER_NAME,PASSWORD,STATUS FROM LOGIN_1 WHERE USER_NAME='" + TextBox1.Text + "'AND PASSWORD!='" +TextBox2.Text + "' AND USER_TYPE!='" + DropDownList1.SelectedItem.ToString() + "' AND STATUS!='" + st + "'", con);
                                                rd = cmd.ExecuteReader();
                                                if (rd.Read())
                                                {
                                                    Response.Write("<script>alert('INVALID CREDENTIALS')</script>");
                                                    Response.Write("<script>alert('LOGIN UNSUCCESSFULL')</script>");

                                                }
                                                else
                                                {
                                                    rd.Close();
                                                    con.Close();
                                                    con.Open();
                                                    cmd = new SqlCommand(" SELECT * FROM LOGIN_1 WHERE USER_NAME='" + TextBox1.Text + "' AND PASSWORD='" + TextBox2.Text + "' AND USER_TYPE='" + DropDownList1.SelectedItem.ToString() + "' AND STATUS='" + st + "'", con);
                                                    rd = cmd.ExecuteReader();
                                                    if (rd.Read())
                                                    {
                                                        Session["a"] = TextBox1.Text;
                                                        Session["b"] = TextBox2.Text;
                                                        Session["c"] = DropDownList1.SelectedValue.ToString();
                                                        Response.Write("<script>alert('LOGIN SUCCESSFUL')</script>");
                                                        Response.Redirect("PRODUCT.aspx");
                                                    }

                                                    else
                                                    {
                                                        rd.Close();
                                                        con.Close();
                                                        Response.Write("<script>alert('INVALID CREDENTIALS')</script>");
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