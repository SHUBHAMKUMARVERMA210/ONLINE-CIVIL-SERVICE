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

public partial class REGISTER : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label11.Visible = false;
    }
    protected void PROCEED_BTN_Click(object sender, EventArgs e)
    {
        if (FIRST_NAME_TXTBOX.Text == "" & LAST_NAME_TXTBOX.Text == "" & ADDRESS_TXTBOX.Text == "" & CITY_TXTBOX.Text == "" & TOWN_STREET_LANE_TXTBOX.Text == "" & PIN_CODE_TXTBOX.Text == "" & STATE_TXTBOX.Text == "" & DISTRICT_TXTBOX.Text == "" & PHONE_NUMBER_TXTBOX.Text == "")
        {
            Response.Write("<script>alert('PLEASE FILL ALL THE CREDENTIALS')</script>");
        }
        else
        {
            if (FIRST_NAME_TXTBOX.Text == "")
            {
                Response.Write("<script>alert('PLEASE ENTER FIRST NAME')</script>");
            }
            else
            {
                if (LAST_NAME_TXTBOX.Text == "")
                {
                    Response.Write("<script>alert('PLEASE ENTER LAST NAME')</script>");
                }
                else
                {
                    if (ADDRESS_TXTBOX.Text == "")
                    {
                        Response.Write("<script>alert('PLEASE ENTER THE ADDRESS')</script>");
                    }
                    else
                    {
                        if (CITY_TXTBOX.Text == "")
                        {
                            Response.Write("<script>alert('PLEASE ENTER CITY NAME')</script>");
                        }
                        else
                        {
                            if (TOWN_STREET_LANE_TXTBOX.Text == "")
                            {
                                Response.Write("<script>alert('PLEASE ENTER TOWN/STREET/LANE NAME')</script>");
                            }
                            else
                            {
                                if (PIN_CODE_TXTBOX.Text == "")
                                {
                                    Response.Write("<script>alert('PLEASE ENTER PINCODE')</script>");
                                }
                                else
                                {
                                    if (STATE_TXTBOX.Text == "")
                                    {
                                        Response.Write("<script>alert('PLEASE ENTER STATE')</script>");
                                    }
                                    else
                                    {
                                        if (DISTRICT_TXTBOX.Text == "")
                                        {
                                            Response.Write("<script>alert('PLEASE ENTER DISTRICT NAME')</script>");
                                        }
                                        else
                                        {
                                            if (PHONE_NUMBER_TXTBOX.Text == "")
                                            {
                                                Response.Write("<script>alert('PLEASE ENTER PHONE NUMBER')</script>");
                                            }
                                            else
                                            {
                                                string unm = (string)(Session["a"]);
                                                int p4 = 0;
                                                string nm1 = FIRST_NAME_TXTBOX.Text + " " + LAST_NAME_TXTBOX.Text;
                                                cn.Open();
                                                cmd = new SqlCommand("SELECT MAX(BILL_ID) FROM TRANSACT_1", cn);
                                                rd = cmd.ExecuteReader();
                                                rd.Read();
                                                string p = rd[0].ToString();
                                                if (p == "")
                                                {
                                                    int p2 = 1;
                                                    cn.Close();
                                                    cn.Open();
                                                    cmd = new SqlCommand("INSERT INTO TRANSACT_1(USERNAME,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY) SELECT USERNAME,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,UPDATED_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY FROM TRANSACT UPDATE TRANSACT_1 SET BILL_ID='" + p2 + "',CUSTOMER_NAME='" + nm1 + "',CUSTOMER_ADDRESS='" + ADDRESS_TXTBOX.Text + "',CUSTOMER_CITY='" + CITY_TXTBOX.Text + "',CUSTOMER_TOWN='" + TOWN_STREET_LANE_TXTBOX.Text + "',CUSTOMER_PIN_CODE='" + PIN_CODE_TXTBOX.Text + "',CUSTOMER_STATE='" + STATE_TXTBOX.Text + "',CUSTOMER_DISTRICT='" + DISTRICT_TXTBOX.Text + "',CUSTOMER_PHONE='" + PHONE_NUMBER_TXTBOX.Text + "',CARD_NUMBER='" + p4 + "',CARD_PIN='" + p4 + "' WHERE BILL_ID IS NULL", cn);
                                                    cmd.ExecuteNonQuery();
                                                    cn.Close();
                                                    Response.Redirect("PAYMENT.aspx?p12=" + p2);
                                                }
                                                else
                                                {
                                                    int p3 = Convert.ToInt32(p);
                                                    p3 = p3 + 1;
                                                    cn.Close();
                                                    cn.Open();
                                                    cmd = new SqlCommand("INSERT INTO TRANSACT_1(USERNAME,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY) SELECT USERNAME,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,UPDATED_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY FROM TRANSACT UPDATE TRANSACT_1 SET BILL_ID='" + p3 + "',CUSTOMER_NAME='" + nm1 + "',CUSTOMER_ADDRESS='" + ADDRESS_TXTBOX.Text + "',CUSTOMER_CITY='" + CITY_TXTBOX.Text + "',CUSTOMER_TOWN='" + TOWN_STREET_LANE_TXTBOX.Text + "',CUSTOMER_PIN_CODE='" + PIN_CODE_TXTBOX.Text + "',CUSTOMER_STATE='" + STATE_TXTBOX.Text + "',CUSTOMER_DISTRICT='" + DISTRICT_TXTBOX.Text + "',CUSTOMER_PHONE='" + PHONE_NUMBER_TXTBOX.Text + "',CARD_NUMBER='" + p4 + "',CARD_PIN='" + p4 + "' WHERE BILL_ID='' AND USERNAME='" + unm + "'", cn);
                                                    cmd.ExecuteNonQuery();
                                                    cn.Close();
                                                    cn.Close();
                                                    cn.Close();
                                                    cn.Open();
                                                    cmd = new SqlCommand("UPDATE TRANSACT_1 SET BILL_ID='" + p3 + "',CUSTOMER_NAME='" + nm1 + "',CUSTOMER_ADDRESS='" + ADDRESS_TXTBOX.Text + "',CUSTOMER_CITY='" + CITY_TXTBOX.Text + "',CUSTOMER_TOWN='" + TOWN_STREET_LANE_TXTBOX.Text + "',CUSTOMER_PIN_CODE='" + PIN_CODE_TXTBOX.Text + "',CUSTOMER_STATE='" + STATE_TXTBOX.Text + "',CUSTOMER_DISTRICT='" + DISTRICT_TXTBOX.Text + "',CUSTOMER_PHONE='" + PHONE_NUMBER_TXTBOX.Text + "',CARD_NUMBER='" + p4 + "',CARD_PIN='" + p4 + "' WHERE BILL_ID IS NULL AND USERNAME='" + unm + "'", cn);
                                                    cmd.ExecuteNonQuery();
                                                    cn.Close();
                                                    Response.Redirect("PAYMENT.aspx?p13=" + p3);
                                                }
                                                rd.Close();
                                                cn.Close();
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
    protected void CANCEL_BTN_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        Response.Write("<script>alert('ARE YOU SURE')</script>");
        Response.Write("<script>alert('YOUR TRANSACTION WILL BE CANCELLED')</script>");
        cn.Open();
        cmd = new SqlCommand("DELETE FROM TRANSACT WHERE USERNAME='" + unm + "'", cn);
        cmd.ExecuteNonQuery();
        cn.Close();
        Response.Redirect("PRODUCT.aspx");
    }
}