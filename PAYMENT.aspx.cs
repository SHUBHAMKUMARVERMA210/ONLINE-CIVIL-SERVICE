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


public partial class PAYMENT : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        AMOUNT_LBL.Visible = false;
        string unm = (string)(Session["a"]);
        string a = Convert.ToString(Request.QueryString["p12"]);
        string b = Convert.ToString(Request.QueryString["p13"]);
        string id2 = (string)(Session["id2"]);
        if (a=="1")
        {
            BILL_ID_LBL.Text = a;
            int a1 = Convert.ToInt32(a);
        }
        else
        {
            BILL_ID_LBL.Text = b;
            int b1 = Convert.ToInt32(b);
        }
        if (!IsPostBack)
        {
            string[] s = {"--SELECT--", "03","04"};
            DDL_EXP_DATE.DataSource = s;
            DDL_EXP_DATE.DataBind();
            string[] s1 = { "--SELECT--", "2030","2040" };
            DDL_EXP_YEAR.DataSource = s1;
            DDL_EXP_YEAR.DataBind();
            string[] s2 = { "--SELECT--", "SBI DEBIT","SBI CREDIT" };
            DDL_CARD_TYPE.DataSource = s2;
            DDL_CARD_TYPE.DataBind();
        }
    }
    protected void PAY_BTN_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        string a = Convert.ToString(Request.QueryString["p12"]);
        string b = Convert.ToString(Request.QueryString["p13"]);
        string id2 = (string)(Session["id2"]);
        string st = "--SELECT--";
        if (a == "1")
        {
            string pn = PIN_TXTBOX.Text;
            string dt = DDL_EXP_DATE.SelectedItem.ToString() + "/" + DDL_EXP_YEAR.SelectedItem.ToString();
            BILL_ID_LBL.Text = a;
            int a1 = Convert.ToInt32(a);
            cn.Open();
            cmd = new SqlCommand("SELECT SUM(YOUR_COST) FROM TRANSACT_1 WHERE BILL_ID='" + a1 + "'", cn);
            rd = cmd.ExecuteReader();
            rd.Read();
            string amt = rd[0].ToString();
            if (amt == "")
            {
                Response.Write("<script>alert('CANNOT MAKE PAYMENT')</script>");
            }
            else
            {
                if (CARD_NUMBER_TXTBOX.Text == "" & CARD_HOLDERS_NAME_TXTBOX.Text == "" & pn == "" & DDL_EXP_DATE.SelectedItem.ToString() == st & DDL_EXP_YEAR.SelectedItem.ToString() == st & DDL_CARD_TYPE.SelectedItem.ToString() == st)
                {
                    Response.Write("<script>alert('ENTER ALL CREDENTIALS')</script>");
                }
                else
                {
                    if (pn == "")
                    {
                        Response.Write("<script>alert('ENTER PIN')</script>");
                    }
                    else
                    {
                        rd.Close();
                        cn.Close();
                        cn.Open();
                        AMOUNT_LBL.Text = amt;
                        double amt1 = Convert.ToDouble(amt);
                        cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + PIN_TXTBOX.Text + "' AND EXP_DT='" + dt + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                        rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            rd.Close();
                            cn.Close();
                            cn.Open();
                            cmd = new SqlCommand("UPDATE BANK SET AMOUNT=AMOUNT-'" + amt1 + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Open();
                            string exd = DDL_EXP_DATE.SelectedItem.ToString() + "/" + DDL_EXP_YEAR.SelectedItem.ToString();
                            cmd = new SqlCommand("UPDATE TRANSACT_1 SET CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "',CARD_PIN='" + pn + "',CARD_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "',CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "',DATE_OF_EXPIRY='" + exd + "',TOTAL_AMOUNT='" + amt1 + "',STATUS='WAITING' WHERE USERNAME='" + unm + "' AND BILL_ID='" + a1 + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Close();
                            cn.Open();
                            cmd = new SqlCommand("UPDATE P SET P.QUANTITY=P.QUANTITY-(T.ORDERED_QUANTITY) FROM PRODUCT P INNER JOIN TRANSACT_1 T ON T.PRODUCT_ID=P.PRODUCT_ID WHERE T.USERNAME='" + unm + "' AND T.BILL_ID='" + a1 + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Open();
                            cmd = new SqlCommand("DELETE C FROM CART C INNER JOIN TRANSACT T ON T.PRODUCT_ID=C.PRODUCT_ID WHERE C.PRODUCT_ID=T.PRODUCT_ID AND T.USERNAME='" + unm + "' AND T.STATUS='CART'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Close();
                            cn.Open();
                            cmd = new SqlCommand("DELETE  FROM TRANSACT WHERE USERNAME='" + unm + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            Response.Redirect("THANKING.aspx?TRANSACTION_ID1=" + a);
                        }
                        cn.Close();
                        cn.Close();
                        if (CARD_NUMBER_TXTBOX.Text == "" & CARD_HOLDERS_NAME_TXTBOX.Text != "" & pn != "" & DDL_EXP_DATE.SelectedItem.ToString() != "" & DDL_EXP_YEAR.SelectedItem.ToString() != "" & DDL_CARD_TYPE.SelectedItem.ToString() != "")
                        {
                            Response.Write("<script>alert('ENTER CARD NUMBER')</script>");
                        }
                        else
                        {
                            if (CARD_NUMBER_TXTBOX.Text != "" & CARD_HOLDERS_NAME_TXTBOX.Text == "" & pn != "" & DDL_EXP_DATE.SelectedItem.ToString() != "" & DDL_EXP_YEAR.SelectedItem.ToString() != "" & DDL_CARD_TYPE.SelectedItem.ToString() != "")
                            {
                                Response.Write("<script>alert('ENTER CARD HOLDERS NAME')</script>");
                            }
                            else
                            {
                                if (CARD_NUMBER_TXTBOX.Text != "" & CARD_HOLDERS_NAME_TXTBOX.Text != "" & pn == "" & DDL_EXP_DATE.SelectedItem.ToString() != "" & DDL_EXP_YEAR.SelectedItem.ToString() != "" & DDL_CARD_TYPE.SelectedItem.ToString() != "")
                                {
                                    Response.Write("<script>alert('ENTER PIN')</script>");
                                }
                                else
                                {
                                    if (CARD_NUMBER_TXTBOX.Text != "" & CARD_HOLDERS_NAME_TXTBOX.Text != "" & pn != "" & DDL_EXP_DATE.SelectedItem.ToString() == st & DDL_EXP_YEAR.SelectedItem.ToString() == st & DDL_CARD_TYPE.SelectedItem.ToString() != "")
                                    {
                                        Response.Write("<script>alert('SELECT EXPIRY DATE')</script>");
                                    }
                                    else
                                    {
                                        if (CARD_NUMBER_TXTBOX.Text != "" & CARD_HOLDERS_NAME_TXTBOX.Text != "" & pn != "" & DDL_EXP_DATE.SelectedItem.ToString() != "" & DDL_EXP_YEAR.SelectedItem.ToString() != "" & DDL_CARD_TYPE.SelectedItem.ToString() == st)
                                        {
                                            Response.Write("<script>alert('SELECT CARD TYPE')</script>");
                                        }
                                        else
                                        {
                                            cn.Close();
                                            cn.Open();
                                            string exd = DDL_EXP_DATE.SelectedItem.ToString() + "/" + DDL_EXP_YEAR.SelectedItem.ToString();
                                            cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER!='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT='" + exd + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                            rd = cmd.ExecuteReader();
                                            if (rd.Read())
                                            {
                                                rd.Close();
                                                cn.Close();
                                                Response.Write("<script>alert('INVALID CARD NUMBER')</script>");
                                            }
                                                else
                                                {
                                                    cn.Close();
                                                    cn.Open();
                                                    cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER!='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT='" + exd + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                    rd = cmd.ExecuteReader();
                                                    if (rd.Read())
                                                    {
                                                        rd.Close();
                                                        cn.Close();
                                                        Response.Write("<script>alert('INVALID USERNAME')</script>");
                                                    }
                                                    else
                                                    {
                                                        cn.Close();
                                                        cn.Open();
                                                        cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME!='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT='" + exd + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                        rd = cmd.ExecuteReader();
                                                        if (rd.Read())
                                                        {
                                                            rd.Close();
                                                            cn.Close();
                                                            Response.Write("<script>alert('INVALID CARD HOLDER NAME')</script>");
                                                        }
                                                        else
                                                        {
                                                            cn.Close();
                                                            cn.Open();
                                                            cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN!='" + pn + "' AND EXP_DT='" + exd + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                            rd = cmd.ExecuteReader();
                                                            if (rd.Read())
                                                            {
                                                                rd.Close();
                                                                cn.Close();
                                                                Response.Write("<script>alert('INVALID PIN')</script>");
                                                            }
                                                            else
                                                            {
                                                                cn.Close();
                                                                cn.Open();
                                                                cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT!='" + exd + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                                rd = cmd.ExecuteReader();
                                                                if (rd.Read())
                                                                {
                                                                    rd.Close();
                                                                    cn.Close();
                                                                    Response.Write("<script>alert('INVALID EXPIRY DATE')</script>");
                                                                }
                                                                else
                                                                {
                                                                    cn.Close();
                                                                    cn.Open();
                                                                    cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT='" + exd + "' AND PAYMENT_TYPE!='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                                    rd = cmd.ExecuteReader();
                                                                    if (rd.Read())
                                                                    {
                                                                        rd.Close();
                                                                        cn.Close();
                                                                        Response.Write("<script>alert('INVALID CARD TYPE')</script>");
                                                                    }
                                                                    else
                                                                    {
                                                                        Response.Write("<script>alert('INVALID CREDENTIALS')</script>");
                                                                        Response.Write("<script>alert('RE-ENTER ALL CREDENTIALS AGAIN')</script>");
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
        else
        {
            string pn = PIN_TXTBOX.Text;
            string dt = DDL_EXP_DATE.SelectedItem.ToString() + "/" + DDL_EXP_YEAR.SelectedItem.ToString();
            BILL_ID_LBL.Text = b;
            int b1 = Convert.ToInt32(b);
            cn.Open();
            cmd = new SqlCommand("SELECT SUM(YOUR_COST) FROM TRANSACT_1 WHERE BILL_ID='" + b1 + "'", cn);
            rd = cmd.ExecuteReader();
            rd.Read();
            string amt = rd[0].ToString();
            if (amt == "")
            {
                Response.Write("<script>alert('CANNOT MAKE PAYMENT')</script>");
            }
            else
            {
                if (CARD_NUMBER_TXTBOX.Text == "" & CARD_HOLDERS_NAME_TXTBOX.Text == "" & pn == "" & DDL_EXP_DATE.SelectedItem.ToString() == st & DDL_EXP_YEAR.SelectedItem.ToString() == st & DDL_CARD_TYPE.SelectedItem.ToString() == st)
                {
                    Response.Write("<script>alert('ENTER ALL CREDENTIALS')</script>");
                }
                else
                {
                    if (pn == "")
                    {
                        Response.Write("<script>alert('ENTER PIN')</script>");
                    }
                    else
                    {
                        rd.Close();
                        cn.Close();
                        cn.Open();
                        AMOUNT_LBL.Text = amt;
                        double amt1 = Convert.ToDouble(amt);
                        cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT='" + dt + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                        rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            rd.Close();
                            cn.Close();
                            cn.Open();
                            cmd = new SqlCommand("UPDATE BANK SET AMOUNT=AMOUNT-'" + amt1 + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Open();
                            string exd = DDL_EXP_DATE.SelectedItem.ToString() + "/" + DDL_EXP_YEAR.SelectedItem.ToString();
                            cmd = new SqlCommand("UPDATE TRANSACT_1 SET CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "',CARD_PIN='" + PIN_TXTBOX.Text + "',CARD_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "',CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "',DATE_OF_EXPIRY='" + dt + "',TOTAL_AMOUNT='" + amt1 + "',STATUS='WAITING' WHERE USERNAME='" + unm + "' AND BILL_ID='" + b1 + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Close();
                            cn.Open();
                            cmd = new SqlCommand("UPDATE P SET P.QUANTITY=P.QUANTITY-T.ORDERED_QUANTITY FROM PRODUCT P INNER JOIN TRANSACT_1 T ON T.PRODUCT_ID=P.PRODUCT_ID WHERE T.USERNAME='" + unm + "' AND T.BILL_ID='" + b1 + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Close();
                            cn.Close();
                            cn.Open();
                            cmd = new SqlCommand("DELETE C FROM CART C INNER JOIN TRANSACT T ON T.PRODUCT_ID=C.PRODUCT_ID WHERE C.PRODUCT_ID=T.PRODUCT_ID AND T.USERNAME='" + unm + "' AND T.STATUS='CART'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Close();
                            cn.Open();
                            cmd = new SqlCommand("DELETE  FROM TRANSACT WHERE USERNAME='" + unm + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cn.Close();
                            Response.Redirect("THANKING.aspx?TRANSACTION_ID2=" + b);
                        }
                        cn.Close();
                        cn.Close();
                        if (CARD_NUMBER_TXTBOX.Text == "" & CARD_HOLDERS_NAME_TXTBOX.Text != "" & pn != "" & DDL_EXP_DATE.SelectedItem.ToString() != "" & DDL_EXP_YEAR.SelectedItem.ToString() != "" & DDL_CARD_TYPE.SelectedItem.ToString() != "")
                        {
                            Response.Write("<script>alert('ENTER CARD NUMBER')</script>");
                        }
                        else
                        {
                            if (CARD_NUMBER_TXTBOX.Text != "" & CARD_HOLDERS_NAME_TXTBOX.Text == "" & pn != "" & DDL_EXP_DATE.SelectedItem.ToString() != "" & DDL_EXP_YEAR.SelectedItem.ToString() != "" & DDL_CARD_TYPE.SelectedItem.ToString() != "")
                            {
                                Response.Write("<script>alert('ENTER CARD HOLDERS NAME')</script>");
                            }
                            else
                            {
                                if (CARD_NUMBER_TXTBOX.Text != "" & CARD_HOLDERS_NAME_TXTBOX.Text != "" & pn == "" & DDL_EXP_DATE.SelectedItem.ToString() != "" & DDL_EXP_YEAR.SelectedItem.ToString() != "" & DDL_CARD_TYPE.SelectedItem.ToString() != "")
                                {
                                    Response.Write("<script>alert('ENTER PIN')</script>");
                                }
                                else
                                {
                                    if (CARD_NUMBER_TXTBOX.Text != "" & CARD_HOLDERS_NAME_TXTBOX.Text != "" & pn != "" & DDL_EXP_DATE.SelectedItem.ToString() == st & DDL_EXP_YEAR.SelectedItem.ToString() == st & DDL_CARD_TYPE.SelectedItem.ToString() != "")
                                    {
                                        Response.Write("<script>alert('SELECT EXPIRY DATE')</script>");
                                    }
                                    else
                                    {
                                        if (CARD_NUMBER_TXTBOX.Text != "" & CARD_HOLDERS_NAME_TXTBOX.Text != "" & pn != "" & DDL_EXP_DATE.SelectedItem.ToString() != "" & DDL_EXP_YEAR.SelectedItem.ToString() != "" & DDL_CARD_TYPE.SelectedItem.ToString() == st)
                                        {
                                            Response.Write("<script>alert('SELECT CARD TYPE')</script>");
                                        }
                                        else
                                        {
                                            cn.Close();
                                            cn.Open();
                                            cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER!='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT='" + dt + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                            rd = cmd.ExecuteReader();
                                            if (rd.Read())
                                            {
                                                rd.Close();
                                                cn.Close();
                                                Response.Write("<script>alert('INVALID CARD NUMBER')</script>");
                                            }

                                                else
                                                {
                                                    cn.Close();
                                                    cn.Open();
                                                    cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME!='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT='" + dt + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                    rd = cmd.ExecuteReader();
                                                    if (rd.Read())
                                                    {
                                                        rd.Close();
                                                        cn.Close();
                                                        Response.Write("<script>alert('INVALID CARD HOLDER NAME')</script>");
                                                    }
                                                    else
                                                    {
                                                        cn.Close();
                                                        cn.Open();
                                                        cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN!='" + pn + "' AND EXP_DT='" + dt + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                        rd = cmd.ExecuteReader();
                                                        if (rd.Read())
                                                        {
                                                            rd.Close();
                                                            cn.Close();
                                                            Response.Write("<script>alert('INVALID PIN')</script>");
                                                        }
                                                        else
                                                        {
                                                            cn.Close();
                                                            cn.Open();
                                                            cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT!='" + dt + "' AND PAYMENT_TYPE='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                            rd = cmd.ExecuteReader();
                                                            if (rd.Read())
                                                            {
                                                                rd.Close();
                                                                cn.Close();
                                                                Response.Write("<script>alert('INVALID EXPIRY DATE')</script>");
                                                            }
                                                            else
                                                            {
                                                                cn.Close();
                                                                cn.Open();
                                                                cmd = new SqlCommand("SELECT * FROM BANK WHERE CARD_NUMBER='" + CARD_NUMBER_TXTBOX.Text + "' AND CARD_HOLDERS_NAME='" + CARD_HOLDERS_NAME_TXTBOX.Text + "' AND PIN='" + pn + "' AND EXP_DT='" + dt + "' AND PAYMENT_TYPE!='" + DDL_CARD_TYPE.SelectedItem.ToString() + "'", cn);
                                                                rd = cmd.ExecuteReader();
                                                                if (rd.Read())
                                                                {
                                                                    rd.Close();
                                                                    cn.Close();
                                                                    Response.Write("<script>alert('INVALID CARD TYPE')</script>");
                                                                }
                                                                else
                                                                {

                                                                    Response.Write("<script>alert('INVALID CREDENTIALS')</script>");
                                                                    Response.Write("<script>alert('PLEASE RE-ENTER CREDENTIALS AGAIN')</script>");
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
    protected void CANCEL_BTN_Click(object sender, EventArgs e)
    {
        string unm = (string)(Session["a"]);
        string a = Convert.ToString(Request.QueryString["p12"]);
        string b = Convert.ToString(Request.QueryString["p13"]);
        cn.Open();
        if (a == "1")
        {
            int a1 = Convert.ToInt32(a);
            cmd = new SqlCommand("DELETE FROM TRANSACT_1 WHERE USERNAME='" + unm + "' AND BILL_ID='" + a1 + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Close();
            cn.Open();
            cmd = new SqlCommand("DELETE FROM TRANSACT", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            Response.Redirect("PRODUCT.aspx");
        }
        else
        {
            cn.Close();
            cn.Open();
            int b1 = Convert.ToInt32(b);
            cmd = new SqlCommand("DELETE FROM TRANSACT_1 WHERE USERNAME='" + unm + "' AND BILL_ID='" + b1 + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Close();
            cn.Open();
            cmd = new SqlCommand("DELETE FROM TRANSACT", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            Response.Redirect("PRODUCT.aspx");
        }
    }
    protected void RESET_PAGE_BTN_Click(object sender, EventArgs e)
    {
        CARD_NUMBER_TXTBOX.Text = string.Empty;
        PIN_TXTBOX.Text = string.Empty;
        CARD_NUMBER_TXTBOX.Text = string.Empty;

    }
}