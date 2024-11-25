<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="WebApplication3.asminbookissuing" %>

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
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>

                                    <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your Books Info"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books.png" />

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />

                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member ID"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Go" OnClick="Button1_Click" />
                                     
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Issue" OnClick="Button2_Click" />

                            </div>
                           
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-success" runat="server" Text="Return" OnClick="Button4_Click" />

                            </div>
                        </div>

                    </div>
                </div>
            </div>


            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book  List</h4>

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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString6 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString6.ProviderName %>" SelectCommand="SELECT * FROM [book_issue_table]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
                            </div>
                        </div>









                    </div>
                </div>
            </div>
        </div>
    </div>
    <a href="homepage.aspx"><< Back to Home</a>
</asp:Content>
