<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookStandingTeeTimeReservation.aspx.cs" Inherits="BookStandingTeeTimeReservation" %>

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
									<h2>BookStandingTeeTimeReservation</h2></header>
                                </section>
						</div>
			
					</div>

				</div>	
			</div>
     <br />
    <br />
    <asp:Table ID="StandingReservationTable" runat="server" Width="989px" >
        <asp:TableRow>
            
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                MemberName:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="MemberName1" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                MemberNumber:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="MemberNumber1" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                MemberName:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="MemberName2" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                MemberNumber:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="MemberNumber2" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                MemberName:
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="MemberName3" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                MemberNumber:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="MemberNumber3" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                Requested Day of Week:
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="DayOfWeek" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                Requested Tee Time:
            </asp:TableCell>
            <asp:TableCell>
                   Hour: <asp:DropDownList ID="Hour" runat="server">
                        
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        
                        
                          </asp:DropDownList>
                    Minute:<asp:DropDownList ID="Minute" runat="server">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        
                           </asp:DropDownList>
                    AMorPM <asp:DropDownList ID="AMorPM"  runat="server" OnSelectedIndexChanged="AMorPM_SelectedIndexChanged"  AutoPostBack="True">
                        <asp:ListItem>AM</asp:ListItem>
                        <asp:ListItem>PM</asp:ListItem>
                           </asp:DropDownList><br />
                            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                Requested Start Date:
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="StartDate" runat="server" TextMode="Date"></asp:TextBox><br />
            </asp:TableCell>
            <asp:TableCell>
                Requested End Date:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="EndDate" runat="server" TextMode="Date"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <br />
    <br />

    <asp:Button ID="BookStandingReservation" OnClick="BookStandingReservation_Click" runat="server" Text="Book Standing Reservation" />
    <br />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
    <br />
</asp:Content>

