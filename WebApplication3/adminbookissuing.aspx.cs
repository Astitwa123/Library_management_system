using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{

    public partial class asminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }

        //Return
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExist() && checkIfBookExist())
            {
                if (checkIfIssuingEntryExist())
                {
                    returnBook();
                }
                

            }
            else
            {
                Response.Write("<script>alert('Wrong book ID or Member ID')</script>");
            }
        }

        //go
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }
        //issue
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExist() && checkIfBookExist())
            {
                if (checkIfIssuingEntryExist())
                {
                    Response.Write("<script>alert('This member already have this book')</script>");
                }
                else
                {
                    issueBook();
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong book ID or Member ID')</script>");
            }
        }
        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("Insert into book_issue_table (member_id,member_name,book_id,book_name,issue_date,due_date) values (@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);


                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("Update book_master_table set current_stock=current_stock-1 Where book_id='"+TextBox1.Text.Trim()+"'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book issued successfully');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>" + ex.Message + "</script>");
            }
           
        }
        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("Delete from book_issue_table where book_id='" + TextBox1.Text.Trim() + "' AND member_id='" + TextBox2.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {

                    cmd = new SqlCommand("Update book_master_table set current_stock=current_stock+1 where book_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('book returned successfully');</script>");
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>" + ex.Message + "</script>");
            }

        }
        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("Select * from book_master_table WHERE book_id='" + TextBox1.Text.Trim() + "' AND current_stock>0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>" + ex.Message + "</script>");
            }
            return false;
        }
        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("Select full_name from member_master_table WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>" + ex.Message + "</script>");
            }
            return false;
        }
        bool checkIfIssuingEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("Select * from book_issue_table WHERE member_id='" + TextBox2.Text.Trim() + "' AND book_id='"+TextBox1.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>" + ex.Message + "</script>");
            }
            return false;
        }
        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("Select book_name from book_master_table WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong book ID')</script>");

                }
                cmd = new SqlCommand("Select full_name from member_master_table WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong book ID')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>"+ex.Message+"</script>");
            }
        }
    }
}