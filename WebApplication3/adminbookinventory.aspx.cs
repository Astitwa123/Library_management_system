using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static int global_actual_stock, global_current_stock, global_issued_books;
        string global_filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fullAuthorPublisherValues();
            }
            
            GridView1.DataBind();
        }

        void fullAuthorPublisherValues()
        {
            try
            {
                SqlConnection con=new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed) { 
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select author_name from author_master_table;",con);
                SqlDataAdapter da=new SqlDataAdapter(cmd); 
                DataTable dt=new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "author_name";
                DropDownList2.DataBind();

                cmd = new SqlCommand("Select publisher_name from publisher_master_table;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "publisher_name";
                DropDownList1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
        bool checkBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from book_master_table where book_id='" + TextBox1.Text.Trim() + "' OR book_name='"+TextBox2.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if(checkBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book Id');</script>");
            }
            else {
                addNewBook();
            }
        }
        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres=genres.Remove(genres.Length - 1);
                string filepath = "~/book_inventory/books1.png";
                string filename=Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) ;
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Insert Into book_master_table (book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values (@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name",DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>aler('Book added');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex) {
                Response.Write("script>" + ex.Message + "</script>");
            }
        }
        //go
        protected void Button5_Click(object sender, EventArgs e)
        {
            getUserByID();
        }
        //update
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateBookById();
        }
        //delete
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist()) {
                deleteBook();

            }
            else
            {
                Response.Write("<script>alert('Book do not exist with this id');</script>");
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
                SqlCommand cmd = new SqlCommand("Select * from book_master_table where book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    DropDownList.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    
                    TextBox5.Text = dt.Rows[0]["edition"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox9.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox8.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox10.Text = dt.Rows[0]["book_description"].ToString().Trim();
                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');

                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }

                    }
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books=global_actual_stock-global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                }
                else { Response.Write("<script>alert('Invalid book id')</script>"); }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }
        bool checkIfBookExist()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from book_master_table where book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
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
        void updateBookById()
        {
            if (checkIfBookExist())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox7.Text.Trim());

                    if (global_actual_stock != actual_stock)
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual stock value cannot be less than the issued books');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox7.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres += ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string filepath = "~/book_invengory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (string.IsNullOrEmpty(filename))
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE book_master_table SET book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link WHERE book_id=@book_id", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@edition", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    // Add the missing @book_id parameter
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book updated successfully');</script>");

                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        void deleteBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Delete from book_master_table Where book_id='" + TextBox1.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('author deleted successfully');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }

}