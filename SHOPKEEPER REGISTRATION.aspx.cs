using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;

public partial class SHOPKEEPER_REGISTRATION : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }
    protected void SUBMIT_Click(object sender, EventArgs e)
    {
       
        if (SHOPKEEPER_NAME_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('PLEASE ENTER YOUR NAME')</script>");
        }
        else
        {
            if (PASSWORD_TXTBOX.Text == "")
            {
                Response.Write("<script>alert('PASSWORD FIELD CANNOT BE KEPT EMPTY')</script>");
            }
            else
            {
                if (CONFIRM_PASSWORD_TXTBOX.Text == "")
                {
                    Response.Write("<script>alert('PLEASE RE-ENTER YOUR PASSWORD IN CONFIRM PASSWORD AREA')</script>");
                }
                else
                {
                    if (PASSWORD_TXTBOX.Text != CONFIRM_PASSWORD_TXTBOX.Text)
                    {
                        Response.Write("<script>alert('YOUR PASSWORD DOSEN'T MATCHES WITH THE PASSWORD YOU ENTERED FIRST')</script>");
                        Response.Write("<script>alert('RE-ENTER YOUR CONFIRMATION PASSWORD AGAIN')</script>");
                    }
                    else
                    {
                        if (CONFIRM_PASSWORD_TXTBOX.Text == "")
                        {
                            Response.Write("<script>alert('PLEASE ENTER YOUR CONFIRM PASSWORD')</script>");
                        }
                        else
                        {
                            if (ADDRESS_LINE1_TXTBOX.Text == "")
                            {
                                Response.Write("<script>alert('ADDRESS LINE 1 BOX SHOULD NOT BE EMPTY')</script>");
                                Response.Write("<script>alert('CANNOT ENTER MORE THAN 26 CHARACTER')</script>");
                            }
                            else
                            {
                                if (ADDRESS_LINE2_TXTBOX.Text == "")
                                {
                                    Response.Write("<script>alert('ADDRESS LINE 2 BOX SHOULD NOT BE EMPTY')</script>");
                                    Response.Write("<script>alert('CANNOT ENTER MORE THAN 26 CHARACTER')</script>");
                                }
                                else
                                {
                                    if (TOWN_VILLAGE_TXTBOX.Text == "")
                                    {
                                        Response.Write("<script>alert('ENTER YOUR TOWN OR VILLAGE')</script>");
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
                                                if (PINCODE_TXTBOX.Text == "")
                                                {
                                                    Response.Write("<script>alert('ENTER YOUR PIN CODE')</script>");
                                                }
                                                else
                                                {
                                                    if (PHONE_NUMBER_TXTBOX.Text == "")
                                                    {
                                                        Response.Write("<script>alert('ENTER YOUR PHONE NUMBER')</script>");
                                                    }
                                                    else
                                                    {
                                                        if (ADHAAR_NUMBER_TXTBOX.Text == "")
                                                        {
                                                            Response.Write("<script>alert('ENTER YOUR ADHAAR NUMBER')</script>");
                                                        }
                                                        else
                                                        {
                                                            if (EMAIL_TXTBOX.Text == "")
                                                            {
                                                                Response.Write("<script>alert('ENTER YOUR EMAIL-ID')</script>");
                                                            }
                                                            else
                                                            {
                                                                if (SHOP_NAME_TXTBOX.Text == "")
                                                                {
                                                                    Response.Write("<script>alert('ENTER YOUR SHOP NAME')</script>");
                                                                }
                                                                else
                                                                {
                                                                    if (SHOP_LOCATION_TXTBOX.Text == "")
                                                                    {
                                                                        Response.Write("<script>alert('ENTER YOUR SHOP LOCATION')</script>");
                                                                        Response.Write("<script>alert('CANNOT ENTER MORE THAN 40 CHARACTERS')</script>");
                                                                    }
                                                                    else
                                                                    {
                                                                        con.Open();
                                                                        cmd = new SqlCommand("SELECT * FROM LOGIN_1 WHERE USER_NAME='" + EMAIL_TXTBOX.Text + "'", con);
                                                                        rd = cmd.ExecuteReader();
                                                                        if (rd.Read())
                                                                        {
                                                                            Response.Write("<script>alert('EMAIL ID ALREADY EXIST')</script>");
                                                                            Response.Write("<script>alert('USE OTHER EMAIL ID TO REGISTER')</script>");

                                                                        }
                                                                        else
                                                                        {
                                                                            string date = DateTime.Today.ToString("dd-MM-yyyy");
                                                                            string ADDRESS = ADDRESS_LINE1_TXTBOX.Text + "," + ADDRESS_LINE2_TXTBOX.Text;
                                                                            con.Close();
                                                                            rd.Close();
                                                                            con.Open();
                                                                            cmd = new SqlCommand("Insert into SHOPKEEPER values('" + SHOPKEEPER_NAME_TXTBOX.Text + "','" + CONFIRM_PASSWORD_TXTBOX.Text + "','" + ADDRESS + "','" + TOWN_VILLAGE_TXTBOX.Text + "','" + CITY_TXTBOX.Text + "','" + DISTRICT_TXTBOX.Text + "','" + PINCODE_TXTBOX.Text + "','" + PHONE_NUMBER_TXTBOX.Text + "','" + ADHAAR_NUMBER_TXTBOX.Text + "','" + EMAIL_TXTBOX.Text + "','" + SHOP_NAME_TXTBOX.Text + "','" +"SHOP NAME"+"("+SHOP_NAME_TXTBOX.Text+")"+"LOCATION="+SHOP_LOCATION_TXTBOX.Text + "','" + date + "')", con);
                                                                            cmd.ExecuteNonQuery();
                                                                            con.Close();
                                                                            con.Open();
                                                                            cmd = new SqlCommand("Insert into LOGIN_1 values('SHOPKEEPER','" + EMAIL_TXTBOX.Text + "','" + SHOPKEEPER_NAME_TXTBOX.Text + "','" + CONFIRM_PASSWORD_TXTBOX.Text + "','" + PHONE_NUMBER_TXTBOX.Text + "','" + EMAIL_TXTBOX.Text + "','NOT-VERIFIED','" + date + "')", con);
                                                                            cmd.ExecuteNonQuery();
                                                                            con.Close();
                                                                            Response.Redirect("LOGIN.aspx");
                                                                            Response.Write("<script>alert('DATA ADDED SUCCESSFULLY')</script>");
                                                                            Response.Write("<script>alert('LOGIN AFTER 24 HOURS')</script>");
                                                                            Response.Write("<script>alert('ID UNDER VERIFICATION')</script>");
                                                                            Response.Write("<script>alert('USE YOUR EMAIL ID TO LOGIN')</script>");
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
            }
        }
    }
    protected void RESET_PAGE_BTN_Click(object sender, EventArgs e)
    {
        SHOPKEEPER_NAME_TXTBOX.Text = string.Empty;
        PASSWORD_TXTBOX.Text = string.Empty;
        CONFIRM_PASSWORD_TXTBOX.Text = string.Empty;
        ADDRESS_LINE1_TXTBOX.Text = string.Empty;
        ADDRESS_LINE2_TXTBOX.Text = string.Empty;
        TOWN_VILLAGE_TXTBOX.Text = string.Empty;
        CITY_TXTBOX.Text = string.Empty;
        DISTRICT_TXTBOX.Text = string.Empty;
        PINCODE_TXTBOX.Text = string.Empty;
        PHONE_NUMBER_TXTBOX.Text = string.Empty;
        ADHAAR_NUMBER_TXTBOX.Text = string.Empty;
        EMAIL_TXTBOX.Text = string.Empty;
        SHOP_NAME_TXTBOX.Text = string.Empty;
        SHOP_LOCATION_TXTBOX.Text = string.Empty;
    }
    protected void BACK_TO_HOME_PAGE_BTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRODUCT.aspx");
    }
}