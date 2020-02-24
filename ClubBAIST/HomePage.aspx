<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
					<div class="row">
						<div class="6u skel-cell-important">
							<section id="content" >
								<header>
									<h2>Welcom To ClubBAIST Managment System</h2></header>
                                <br />
                                <br />
                                <asp:Button ID="SignOut" runat="server" OnClick="SignOut_Click" Text="Sign Out" />
                                <br />
                                <br />
                                Please Use The Navigation Bar

                                </section>
						</div>
			
					</div>

				</div>	
			
    <br />


</asp:Content>

