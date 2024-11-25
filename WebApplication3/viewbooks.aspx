<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="WebApplication3.viewbooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($("tr:first-child"))).dataTable();
       });


   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container-fluid">
     <div class="row">
       


         <div class="col-md-7">
             <div class="card">
                 <div class="card-body">

                     <div class="row">
                         <div class="col">
                             <center>
                                 <h4>Book Inventory List</h4>

                                 <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="Your Books Info"></asp:Label>
                             </center>
                         </div>
                     </div>

                     <div class="row">
                         <div class="col">
                             <hr />

                         </div>
                     </div>
                     <div class="row">
                         <asp:SqlDataSource
                             ID="SqlDataSource1"
                             runat="server"
                             ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>"
                             ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString2.ProviderName %>"
                             SelectCommand="SELECT * FROM [book_master_table]"></asp:SqlDataSource>

                         <div class="col">
                             <asp:GridView
                                 CssClass="table table-striped table-bordered"
                                 ID="GridView1"
                                 runat="server"
                                 DataSourceID="SqlDataSource1"
                                 AutoGenerateColumns="False">
                                 <Columns>
                                     <asp:BoundField DataField="book_id" HeaderText="Book ID" ReadOnly="true" SortExpression="book_id" />


                                     <asp:TemplateField HeaderText="Book Image">
                                         <ItemTemplate>
                                             <div class="container-fluid">
                                                 <div class="row">
                                                     <div class="col-lg-10">
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                             </div>
                                                         </div>
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 <span>Author - </span>
                                                                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                 &nbsp;| <span><span>&nbsp;</span>Genre - </span>
                                                                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                 &nbsp;| 
                                               
                                                                 <span>Language -<span>&nbsp;</span>
                                                                     <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                                 </span>
                                                             </div>
                                                         </div>
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 Publisher -
                                               
                                                                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                 &nbsp;| Publish Date -
                                               
                                                                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                 &nbsp;| Pages -
                                               
                                                                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                 &nbsp;| Edition -
                                               
                                                                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                             </div>
                                                         </div>
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 Cost -
                                               
                                                                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                 &nbsp;| Actual Stock -
                                               
                                                                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                 &nbsp;| Available Stock -
                                               
                                                                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                             </div>
                                                         </div>
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 Description -
                                               
                                                                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>
                                                             </div>
                                                         </div>
                                                     </div>
                                                     <div class="col-lg-2">
                                                         <asp:Image
                                                             ID="BookImage"
                                                             runat="server"
                                                             ImageUrl='<%# Eval("book_img_link") %>'
                                                             Width="100px"
                                                             Height="150px"
                                                             AlternateText="Book Image" />
                                                     </div>
                                                 </div>
                                             </div>

                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                             </asp:GridView>
                         </div>
                     </div>










                 </div>
             </div>
         </div>
     </div>
 </div>
</asp:Content>
