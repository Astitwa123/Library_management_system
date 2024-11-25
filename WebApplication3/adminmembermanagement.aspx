<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="WebApplication3.adminmembermanagement" %>

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

                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Full Name"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Book ID" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-success" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle mr-1"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-warning" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="far fa-pause-circle mr-1"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle mr-1"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="DOB" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="State" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Pin Code" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col md-12">
                                <label>Full Postal Address</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            

                            <div class="col-8 mx-auto">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete User Permanantly" OnClick="Button4_Click" />

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
                                    <h4>Member List</h4>

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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString4 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString4.ProviderName %>" SelectCommand="SELECT * FROM [member_master_table]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
                                   
                                </asp:GridView>
                            </div>
                        </div>









                    </div>
                </div>
            </div>
        </div>
    </div>
    <a href="homepage.aspx"><< Back to Home</a>
</asp:Content>
