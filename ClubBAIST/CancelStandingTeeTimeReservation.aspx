<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CancelStandingTeeTimeReservation.aspx.cs" Inherits="CancelStandingTeeTimeReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <br />
        <div id="page">
				<div class="container">
					<div class="row">
						<div class="6u skel-cell-important">
							<section id="content" >
								<header>
									<h2>Cancel Standing Tee Time Reservation</h2></header>
                                </section>
						</div>
			
					</div>

				</div>	
			</div>
     <br />
    <br />
    <asp:Button ID="SignOut" runat="server" OnClick="SignOut_Click" Text="Sign Out" />
    <br />
     <br />
    <asp:Button ID="Cancel" OnClick="Cancel_Click" runat="server" Text="Cancel Standing Reservation" />
    <br />
     <br />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
</asp:Content>

