<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDrop.aspx.cs" Inherits="BITCollegeSite.ViewDrop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:DetailsView ID="dvRegister" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="50px" Width="281px" AllowPaging="True" AutoGenerateRows="False" OnPageIndexChanging="dvRegister_PageIndexChanging">
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="RegistrationNumber" HeaderText="Registration" DataFormatString="{0:d}" >
                <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Student.FullName" HeaderText="Student" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Course.Title" HeaderText="Course" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="RegistrationDate" HeaderText="Date" DataFormatString="{0:M\/d\/yyyy}" ApplyFormatInEditMode="True" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Grade" DataFormatString="{0:p}" HeaderText="Grade" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Fields>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
        </asp:DetailsView>
    </p>
    <p>
        <asp:LinkButton ID="lnkDrop" runat="server" OnClick="lnkDrop_Click">Drop Course</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkReturn" runat="server" OnClick="lnkReturn_Click">Return to Registration Listing</asp:LinkButton>
&nbsp;</p>
    <p>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error/Message (visible = true only when displaying error)" Visible="False"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
