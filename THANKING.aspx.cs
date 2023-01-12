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

public partial class THANKING : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        TRANSACT_ID_LBL.Visible = false;
         string unm = (string)(Session["a"]);
            string TRANSACTION_ID = Convert.ToString(Request.QueryString["TRANSACTION_ID1"]);
            string TRANSACTION_ID3 = Convert.ToString(Request.QueryString["TRANSACTION_ID2"]);
            if (TRANSACTION_ID == "1")
            {
                TRANSACT_ID_LBL.Text = TRANSACTION_ID;
            }
            else
            {
                TRANSACT_ID_LBL.Text = TRANSACTION_ID3;
            }
    }
    protected void Continue_to_homepage_Click(object sender, EventArgs e)
    {
        string transact = Convert.ToString(TRANSACT_ID_LBL.Text);
        if (transact != "Label")
        {
            string unm = (string)(Session["a"]);
            int TRANSACTION_ID = Convert.ToInt32(TRANSACT_ID_LBL.Text);
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM PRINT_TRANSACT WHERE USERNAME='" + unm + "' AND BILL_ID='" + TRANSACTION_ID + "'");
            con.Close();
            Response.Redirect("PRODUCT.aspx");
        }
        else
        {
            Response.Redirect("PRODUCT.aspx");
        }
  }
    protected void PRINT_TRANSACTION_Click(object sender, EventArgs e)
    {
        string transact = Convert.ToString(TRANSACT_ID_LBL.Text);
        if (transact != "Label")
        {
            string unm = (string)(Session["a"]);
            string TRANSACTION_ID = Convert.ToString(Request.QueryString["TRANSACTION_ID1"]);
            string TRANSACTION_ID3 = Convert.ToString(Request.QueryString["TRANSACTION_ID2"]);
            if (TRANSACTION_ID == "1")
            {
                TRANSACT_ID_LBL.Text = TRANSACTION_ID;
                int TRANSACTION_ID2 = Convert.ToInt32(TRANSACT_ID_LBL.Text);
                con.Open();
                cmd = new SqlCommand("DELETE FROM PRINT_TRANSACT", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("INSERT INTO PRINT_TRANSACT(USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_PIN,CARD_TYPE,CARD_HOLDERS_NAME,DATE_OF_EXPIRY,TOTAL_AMOUNT) SELECT USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_PIN,CARD_TYPE,CARD_HOLDERS_NAME,DATE_OF_EXPIRY,TOTAL_AMOUNT FROM TRANSACT_1 WHERE USERNAME='" + unm + "' AND BILL_ID='" + TRANSACTION_ID2 + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("PRINT TRANSACTION.aspx");
            }
            else
            {
                TRANSACT_ID_LBL.Text = TRANSACTION_ID3;
                int TRANSACTION_ID4 = Convert.ToInt32(TRANSACT_ID_LBL.Text);
                con.Close();
                con.Open();
                cmd = new SqlCommand("DELETE FROM PRINT_TRANSACT", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("INSERT INTO PRINT_TRANSACT(USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_PIN,CARD_TYPE,CARD_HOLDERS_NAME,DATE_OF_EXPIRY,TOTAL_AMOUNT) SELECT USERNAME,BILL_ID,PRODUCT_ID,PRODUCT_COST,PRODUCT_WEIGHT,PRODUCT_QUANTITY,PRODUCT_NAME,PRODUCT_IMAGE,ORDERED_QUANTITY,DATE_OF_TRANSACTION,UPDATED_QUANTITY,YOUR_COST,SHOPKEEPER_USERNAME,SHOPKEEPER_NAME,SHOPKEEPER_TOWN_VILLAGE,SHOPKEEPER_DISTRICT,SHOPKEEPER_PHONE_NUMBER,SHOPKEEPER_SHOP_LOCATION,SHOPKEEPER_CITY,CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_CITY,CUSTOMER_TOWN,CUSTOMER_PIN_CODE,CUSTOMER_STATE,CUSTOMER_DISTRICT,CUSTOMER_PHONE,CARD_NUMBER,CARD_PIN,CARD_TYPE,CARD_HOLDERS_NAME,DATE_OF_EXPIRY,TOTAL_AMOUNT FROM TRANSACT_1 WHERE USERNAME='" + unm + "' AND BILL_ID='" + TRANSACTION_ID4 + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("PRINT TRANSACTION.aspx");
            }
        }
        else
        {
            Response.Redirect("PRODUCT.aspx");
        }
    }
}