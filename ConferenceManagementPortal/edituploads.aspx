<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="edituploads.aspx.cs" Inherits="ConferenceManagementPortal.WebForm10" %>
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
									<h4>Delete Paper</h4>
								</center>
							</div>
						</div>
						<div class="row">
							<div class="col">
								<center>
									<img width="100px" src="imgs/research-paper.png" />
								</center>
							</div>
						</div>
						<div class="row">
							<div class="col">
								<hr>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">
								<label>Member ID</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Your Login ID"></asp:TextBox>
								</div>
							</div>
							<div class="col-md-12">
								<label>Reference ID</label>
								<div class="input-group">
									<asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Enter the Reference ID of paper you want to update/delete"></asp:TextBox>
									<asp:Button for="TextBox1" class="btn btn-dark" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-md-6">
								<label>Title</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Title of the paper"></asp:TextBox>
								</div>
							</div>
							<div class="col-md-6">
								<label>Category</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Category of the paper"></asp:TextBox>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">
								<label>Description</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Description of your paper" TextMode="MultiLine"></asp:TextBox>
								</div>
							</div>
							<div class="col-md-6">
								<label>Uploaded on</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Uploaded on"></asp:TextBox>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-6">
								<asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Update" OnClick="Button2_Click" />
							</div>
							<div class="col-6">
								<asp:Button ID="Button4" class="btn btn-lg btn-block btn-success" runat="server" Text="Delete" OnClick="Button4_Click" />
							</div>
						</div>
					</div>
				</div>
				<a href="homepage.aspx">
					<< Back to Home </a>
						<br>
						<br>
			</div>
			<div class="col-md-7">
				<div class="card">
					<div class="card-body">
						<div class="row">
							<div class="col">
								<center>
									<h4>Your Presented Papers</h4>
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
										<asp:BoundField DataField="book_id" HeaderText="Reference ID" SortExpression="book_id" />
										<asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
										<asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
										<asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
										<asp:BoundField DataField="ContentType" HeaderText="Type" SortExpression="ContentType" />

										<asp:BoundField DataField="upload_date" HeaderText="Uploaded on" InsertVisible="False" SortExpression="upload_date" />



										<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Download">
											<ItemTemplate>
												<asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile" CommandArgument='<%# Eval("book_id") %>'></asp:LinkButton>
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