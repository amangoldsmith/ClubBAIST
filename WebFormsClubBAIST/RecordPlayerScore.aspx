<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecordPlayerScore.aspx.cs" Inherits="RecordPlayerScore" %>

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
									<h2>Record Player Score</h2></header>
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
    Tee: <asp:DropDownList ID="TeeList" runat="server">
        <asp:ListItem>Red</asp:ListItem>
        <asp:ListItem>White</asp:ListItem>
        <asp:ListItem>Blue</asp:ListItem>
         </asp:DropDownList>
    Course Rating: <asp:TextBox ID="Rating" TextMode="Number" runat="server"></asp:TextBox>
    Slope: <asp:TextBox ID="Slope" runat="server" TextMode="Number"></asp:TextBox>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>Hole:</asp:TableCell>
            <asp:TableCell>1</asp:TableCell>
            <asp:TableCell>2</asp:TableCell>
            <asp:TableCell>3</asp:TableCell>
            <asp:TableCell>4</asp:TableCell>
            <asp:TableCell>5</asp:TableCell>
            <asp:TableCell>6</asp:TableCell>
            <asp:TableCell>7</asp:TableCell>
            <asp:TableCell>8</asp:TableCell>
            <asp:TableCell>9</asp:TableCell>
            <asp:TableCell>Total</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Shots:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S1"   runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S2" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S3" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S4" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S5" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S6" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S7" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell> 
                <asp:TextBox  Width="33" ID="S8" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox Width="33" ID="S9" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox Width="33" ID="Front9Total" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

        <asp:Table ID="Table2" runat="server">
        <asp:TableRow>
            <asp:TableCell>Hole:</asp:TableCell>
            <asp:TableCell>10</asp:TableCell>
            <asp:TableCell>11</asp:TableCell>
            <asp:TableCell>12</asp:TableCell>
            <asp:TableCell>13</asp:TableCell>
            <asp:TableCell>14</asp:TableCell>
            <asp:TableCell>15</asp:TableCell>
            <asp:TableCell>16</asp:TableCell>
            <asp:TableCell>17</asp:TableCell>
            <asp:TableCell>18</asp:TableCell>
            <asp:TableCell>Total</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Shots:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S10" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S11" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S12" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S13" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S14" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S15" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  Width="33" ID="S16" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox   Width="33" ID="S17" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox Width="33" ID="S18" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox Width="33" ID="Back9Total" runat="server" Text="0" Enabled="True" ReadOnly="True"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button ID="CalculateTotal" runat="server" OnClick="CalculateTotal_Click" Text="Claculate Total Scores" />

    <asp:Button ID="Edit" runat="server" OnClick="Edit_Click" Text="Edit Scores" Enabled="False" />
    <br />
    <br />
    <asp:Button ID="Record" OnClick="Record_Click" runat="server" Enabled="false" Text="Record Score" />
    <br />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
    
    <br />
    <asp:Label ID="HandicapFactorLabel" runat="server" Text="Handicap Factor: "></asp:Label>
    <br />
    <br />
    <asp:Button ID="HandicapFactor" runat="server" OnClick="HandicapFactor_Click" Text="Calculate Handicap Factor" />
    
</asp:Content>

