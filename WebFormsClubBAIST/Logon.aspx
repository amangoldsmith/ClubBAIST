<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Logon.aspx.cs" Inherits="Logon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
					<div class="row">
						<div class="6u skel-cell-important">
							<section id="content" >
								<header>
									<h2>Logon</h2></header>
                                </section>
						</div>
			
					</div>

				</div>	
			
      <div style="margin-top:5%;margin-left:30%">
        <asp:Table ID="Table1" runat="server">  
            <asp:TableRow>
                <asp:TableCell>
                     Member Number:
                </asp:TableCell>
                <asp:TableCell>
                     <asp:TextBox ID="MemberNumber" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Password:
                </asp:TableCell>
                <asp:TableCell>
                     <asp:TextBox ID="Password" runat="server"></asp:TextBox>
                </asp:TableCell>
                </asp:TableRow>
        </asp:Table>
    <asp:Button ID="Login" OnClick="Login_Click" runat="server" Text="Login" /><br />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
          </div>
</asp:Content>

