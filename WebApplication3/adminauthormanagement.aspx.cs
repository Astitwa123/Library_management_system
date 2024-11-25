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

    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
      
            
                GridView1.DataBind();
            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkAuthorExists())
            {
                Response.Write("<script>alert('author already exist');</script>");
            }
            else
            {
                addNewAuthor();
            }
        }
        bool checkAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from author_master_table where author_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >=1)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }
        void getUserByID()
        {
           
            
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("Select * from author_master_table where author_id='" + TextBox1.Text.Trim() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        TextBox2.Text = dt.Rows[0][1].ToString();
                    }
                    else { Response.Write("<script>alert('Invalid author id')</script>"); }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                   
                }

            
        }
        void addNewAuthor()
        {
            try{
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                Response.Write("<script>alert('Connected');</script>");
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_table(author_id,author_name) values(@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());
               
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('author added successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getUserByID();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkAuthorExists())
            {
                updateAuthor();
               
            }
            else {
                Response.Write("<script>alert('author do not exist');</script>");
            }
           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                deleteAuthor();

            }
            else
            {
                Response.Write("<script>alert('author do not exist');</script>");
            }
        }
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
         
                SqlCommand cmd = new SqlCommand("UPDATE author_master_table SET author_name=@author_name Where author_id='"+TextBox1.Text.Trim()+"'", con);
            
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('author updated successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Delete from author_master_table Where author_id='" + TextBox1.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('author deleted successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}