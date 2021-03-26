<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="BITCollegeSite.CourseRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblStudentName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblCourseSelector" runat="server" Text="Course Selector:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCourses" runat="server" Height="21px" Width="162px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblNotes" runat="server" Text="Registration Notes:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNotes" runat="server" Width="296px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNotes" runat="server" ControlToValidate="txtNotes" Enabled="False" ErrorMessage="Registration notes is required"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click">Register</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkReturn" runat="server" OnClick="lnkReturn_Click">Return to Registration Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error/Message - " Visible="False"></asp:Label>
    </p>
    <p>
    </p>
</asp:Content>
