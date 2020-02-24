<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CancelTeeTimeReservation.aspx.cs" Inherits="CancelTeeTimeReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="page">
				<div class="container">
					<div class="row">
						<div class="6u skel-cell-important">
							<section id="content" >
								<header>
									<h2>Cancel Tee Time Reservation</h2></header>
                                </section>
						</div>
			
					</div>

				</div>	
			</div>
    <br />
                    <asp:Button ID="SignOut" runat="server" OnClick="SignOut_Click" Text="Sign Out" />

    <asp:Label ID="Message" runat="server" Text="" ForeColor="Red"></asp:Label><br /><br />
        
                Your Current TeeTime Reservations
        <br />
        <asp:ListBox ID="ReservationList" runat="server"></asp:ListBox>
        <br />
        <asp:Button ID="CancelReservation"  OnClick="CancelReservation_Click" runat="server" Text="Cancel Reservation" />
        <br />
        <br />




</asp:Content>

