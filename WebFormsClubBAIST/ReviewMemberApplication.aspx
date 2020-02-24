<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReviewMemberApplication.aspx.cs" Inherits="ReviewMemberApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="page">
				<div class="container">
					<div class="row">
						<div class="6u skel-cell-important">
							<section id="content" >
								<header>
									<h2>Review  Member  Application</h2></header>
                                <br />
    <br />
       <asp:Button ID="SignOut" runat="server" OnClick="SignOut_Click" Text="Sign Out" />
    <br />
    <br />
                           <asp:Label ID="ApplicationIDLable" runat="server" Text="ApplicationID"></asp:Label>
    <asp:TextBox ID="ApplicationID" runat="server"></asp:TextBox>
    <br />
    <br />

    <asp:Button ID="Accept" OnClick="Accept_Click" runat="server" Text="Accept" />
    <asp:Button ID="Deny" OnClick="Deny_Click" runat="server" Text="Deny" />
    <asp:Button ID="Waitlist" OnClick="Waitlist_Click" runat="server" Text="Waitlist" />
    <asp:Button ID="OnHold" OnClick="OnHold_Click" runat="server" Text="Put On Hold" />
    <br />
    <asp:Label ID="Message" runat="server" Text="" ></asp:Label>
    <br />
    <br />
    <br />
               <div class="applications">                 
    <asp:Table  ID="ApplicationsTable" CellPadding="3" CellSpacing="4" BorderStyle="Solid" GridLines ="Both"  runat="server" BackColor="#ffffff" BorderWidth="1" BorderColor="Black">
        
        <asp:TableHeaderRow BorderStyle="Solid"  BorderWidth="1" BorderColor="#000000">
            <asp:TableHeaderCell>ApplicationID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Last Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>First Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Address</asp:TableHeaderCell>
            <asp:TableHeaderCell>Postal Code</asp:TableHeaderCell>
            <asp:TableHeaderCell>Phone</asp:TableHeaderCell>
            <asp:TableHeaderCell>Alternate Phone</asp:TableHeaderCell>
            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
            <asp:TableHeaderCell>Birth Date</asp:TableHeaderCell>
            <asp:TableHeaderCell>Occupation</asp:TableHeaderCell>
            <asp:TableHeaderCell>Company Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Company Address</asp:TableHeaderCell>
            <asp:TableHeaderCell>Company PostalCode</asp:TableHeaderCell>
            <asp:TableHeaderCell>Company Phone</asp:TableHeaderCell>
            <asp:TableHeaderCell>Submit Date</asp:TableHeaderCell>
            <asp:TableHeaderCell>Sex</asp:TableHeaderCell>
            <asp:TableHeaderCell>Wants Share</asp:TableHeaderCell>
            <asp:TableHeaderCell>Waitlisted</asp:TableHeaderCell>
            <asp:TableHeaderCell>On Hold</asp:TableHeaderCell>
            <asp:TableHeaderCell>Shareholder Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Shareholder Date</asp:TableHeaderCell>
            <asp:TableHeaderCell>Shareholder Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Shareholder Date</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
                   </div>
							</section>
						</div>
			
					</div>

				</div>	
			</div>



</asp:Content>

