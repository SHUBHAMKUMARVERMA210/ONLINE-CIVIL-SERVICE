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

public partial class CHANGE_PASSWORD : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    DataSet ds = new DataSet();
    SqlDataAdapter da;
    static Random Random=new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        CONFIRM_OTP_PANEL.Visible = false;
        NEW_PASSWORD_PANEL.Visible = false;
        
    }
    protected void SEND_OTP_BTN_Click(object sender, EventArgs e)
    {
        if(USERNAME_TXTBOX.Text=="")
        {
            Response.Write("<script>alert('PLEASE ENTER YOUR USERNAME')</script>");
        }
            else
            {
                
                con.Close();
                con.Open();
                cmd = new SqlCommand("SELECT * FROM LOGIN_1 WHERE USER_NAME='" + USERNAME_TXTBOX.Text + "'", con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    for (int i = 0; i < 2; i++)
                    {
                        OTP_LBL.Text = Convert.ToString(Random.Next(10, 2000));
                    }
                    CONFIRM_OTP_PANEL.Visible = true;
                }
                else
                {
                    rd.Close();
                    con.Close();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("SELECT * FROM LOGIN_1 WHERE USER_NAME!='" + USERNAME_TXTBOX.Text + "'", con);
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        Response.Write("<script>alert('INVALID USERNAME')</script>");
                        Response.Write("<script>alert('PLEASE ENTER CORRECT USERNAME')</script>");
                    }
            }
        }
    }
    protected void CONFIRM_OTP_BTN_Click(object sender, EventArgs e)
    {
        if (ENTER_OTP_TXTBOX.Text != OTP_LBL.Text)
        {
            Response.Write("<script>alert('OTP DOSENT MATCHED')</script>");
        }
        else
        {
            ENTER_USERNAME_PANEL.Visible = false;
            CONFIRM_OTP_PANEL.Visible = false;
            NEW_PASSWORD_PANEL.Visible = true;
            Session["username"] = USERNAME_TXTBOX.Text;
            string username = (string)(Session["username"]);
            YOUR_USERNAME_TXTBOX.Text = username;
        }
    }
    protected void UPDATE_PASSWORD_BTN_Click(object sender, EventArgs e)
    {
        if (NEW_PASSWORD_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('ENTER NEW PASSWORD')</script>");
        }
        else
        {
            if (CONFIRM_PASSWORD_TXTBOX.Text == "")
            {
                Response.Write("<script>alert('ENTER CONFIRMATION PASSWORD')</script>");
            }
            else
            {
                if (NEW_PASSWORD_TXTBOX.Text != CONFIRM_PASSWORD_TXTBOX.Text)
                {
                    Response.Write("<script>alert('YOUR CONFIRMATION PASSWORD DOSEN'T MATCHED')</script>");
                    Response.Write("<script>alert('PLEASE RE-ENTER YOUR PASSWORD AGAIN')</script>");
                }
                else
                {
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("UPDATE LOGIN_1 SET PASSWORD='" + CONFIRM_PASSWORD_TXTBOX.Text + "' WHERE USER_NAME='" + YOUR_USERNAME_TXTBOX.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("UPDATE SHOPKEEPER SET PASSWORD='" + CONFIRM_PASSWORD_TXTBOX.Text + "' WHERE EMAIL='" + YOUR_USERNAME_TXTBOX.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("UPDATE CUSTOMER SET PASSWORD='" + CONFIRM_PASSWORD_TXTBOX.Text + "' WHERE EMAIL_ID='" + YOUR_USERNAME_TXTBOX.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Abandon();
                    Response.Redirect("LOGIN.aspx");
                }
            }
        }
    }
}