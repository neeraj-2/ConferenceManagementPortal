<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="uploadedpapers.aspx.cs" Inherits="ConferenceManagementPortal.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		$(document).ready(function() {
			$(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container">
		<div class="row">

			<div class="col-sm-12">
				<center>
					<h3>
						Here is a list of all the uploaded papers by the members</h3>
				</center>
				<div class="row">
					<div class="col-sm-12 col-md-12">
						<asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
							<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
						</asp:Panel>
					</div>
				</div>
				<br />
				<div class="row">
					<div class="card">
						<div class="card-body">

							<div class="row">
								<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cmpDBConnectionString %>" SelectCommand="SELECT * FROM [uploaded_files_tbl]"></asp:SqlDataSource>
								<div class="col">
									<asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
										<Columns>

											<asp:TemplateField>
												<ItemTemplate>
													<div class="container-fluid">
														<div class="row">
															<div class="col-lg-10">
																<div class="row">
																	<div class="col-12">
																		<asp:Label ID="Label1" runat="server" Text='<%# Eval("title") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
																	</div>
																</div>
																<div class="row">
																	<div class="col-12">
																		<span>Presented BY - </span>
																		<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("member_name") %>'></asp:Label>


																	</div>
																</div>


																<div class="row">
																	<div class="col-12">
																		Description -
																		<asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("description") %>'></asp:Label>

																	</div>
																</div>
																<div class="row">
																	<div class="col-12">
																		Uploaded on -
																		<asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("upload_date") %>'></asp:Label>

																	</div>
																</div>
															</div>

														</div>
													</div>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Download">
												<ItemTemplate>
													<asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("ContentType") %>'></asp:Label>
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
			<center>
				<a href="homepage.aspx">
					<< Back to Home</a><span class="clearfix"></span>
						<br />
						<center>
		</div>
	</div>
</asp:Content>