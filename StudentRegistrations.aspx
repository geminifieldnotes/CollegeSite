<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegistrations.aspx.cs" Inherits="BITCollegeSite.StudentRegistrations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblStudentName" runat="server">Label Test</asp:Label>
    </p>
    <asp:GridView ID="gvRegistrations" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvRegistrations_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Course.CourseNumber" HeaderText="Course">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Course.Title" HeaderText="Title">
            <ItemStyle Width="160px" />
            </asp:BoundField>
            <asp:BoundField DataField="Course.CourseType" HeaderText="Course Type">
            <ItemStyle Width="95px" />
            </asp:BoundField>
            <asp:BoundField DataField="Course.TuitionAmount" DataFormatString="{0:c}" HeaderText="Tuition">
            <ItemStyle HorizontalAlign="Right" Width="110px" />
            </asp:BoundField>
            <asp:BoundField DataField="Grade" DataFormatString="{0:p}" HeaderText="Grade">
            <ItemStyle HorizontalAlign="Right" Width="110px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <p>
        <asp:Label ID="lblInstructions" runat="server" Text="Click the Select link beside a registration (above) to View or Drop the course"></asp:Label>
    </p>
    <p>
        <asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click">Click Here to Register for a Course</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Error/Message (visible = true only when displaying error)" ForeColor="Red" Visible="False"></asp:Label>
    </p>
</asp:Content>
