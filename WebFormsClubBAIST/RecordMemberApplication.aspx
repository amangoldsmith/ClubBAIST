<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecordMemberApplication.aspx.cs" Inherits="RecordMemberApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="page">
				<div class="container">
					<div class="row">
						<div class="6u skel-cell-important">
							<section id="content" >
								<header>
									<h2>Record  Member  Application</h2>
								</header>
                           

      <asp:Table ID="ApplicationTable" runat="server" GridLines="None">
          <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="SignOut" runat="server" OnClick="SignOut_Click" Text="Sign Out" />
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>LastName:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>Occupation:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Occupation" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>FirstName:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>Company Name:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="CompanyName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Address:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>Company Address:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="CompanyAddress" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>PostalCode:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="PostalCode" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>Company PostalCode:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="CompanyPostalCode" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Phone:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>Company Phone:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="CompanyPhone" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Alternate Phone:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="AltPhone" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

                <asp:TableRow>
            <asp:TableCell>Email:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Email" TextMode="Email" runat="server"></asp:TextBox>
            </asp:TableCell>
                    <asp:TableCell>Passowrd:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

                <asp:TableRow>
            <asp:TableCell>Date of Birth:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="DateofBirth" TextMode="Date" runat="server" Text="mm/dd/yyyy"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Sex:</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="Sexlist" runat="server">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Buy Share:</asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="Share" runat="server" />
            </asp:TableCell>
        </asp:TableRow>

         <asp:TableRow>
            <asp:TableCell>Application Date: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="SubmitDate" TextMode="Date" runat="server" Text="mm/dd/yyyy"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>
    <br />
    <br />
    <asp:Table ID="Shareholdertable" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                ShareHolders Name:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="ShareholderName1" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                ShareHolders Name:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="ShareholderName2" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

                <asp:TableRow>
            <asp:TableCell>
                Date:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="ShareholderDate1"  TextMode="Date" runat="server" Text="mm/dd/yyyy"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                Date:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="ShareholderDate2" TextMode="Date" runat="server" Text="mm/dd/yyyy"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Button ID="Submit" onclick="Submit_Click" runat="server" Text="Submit" />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
							</section>
						</div>
			
					</div>

				</div>	
			</div>



</asp:Content>

