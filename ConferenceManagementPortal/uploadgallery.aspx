<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="uploadgallery.aspx.cs" Inherits="ConferenceManagementPortal.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
		$(document).ready(function() {
			$('.table').prepend($("<thead></thead").append($(this).find("tr:first"))).dataTable();
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
                                    <h4>Please provide below details to upload your paper</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" Height="150px" width="100px" src="imgs/publisher.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readUrl(this);" class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <label>User ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" ReadOnly="True" placeholder="Please Provide your login user id here"></asp:TextBox>



                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Paper-Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Paper-Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">


                            <div class="col-md-8">
                                <label>Category</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Like Machine Learning, Data Science, IOT etc"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-12">
                                <label>Paper Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Please provide a short description of your paper here. Thanks" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Upload" OnClick="Button1_Click" />
                            </div>

                        </div>
                    </div>
                </div>
                <a href="homepage.aspx">
                    << Back to Home</a><br>
                        <br>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Uploaded Papers</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cmpDBConnectionString %>" SelectCommand="SELECT * FROM [uploaded_files_tbl]"></asp:SqlDataSource>

                            <div class="col">

                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                        <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                                        <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
                                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" InsertVisible="False" ReadOnly="True" SortExpression="book_id" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="ContentType" HeaderText="ContentType" SortExpression="ContentType" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>