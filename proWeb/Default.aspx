<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Code&nbsp;
        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
    </p>
    <p>
        Name
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </p>
    <p>
        Amount
        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
    </p>
    <p>
        Category
        <asp:DropDownList ID="dropCategory" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Price
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    </p>
    <p>
        Creation Date
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnRead" runat="server" Text="Read" />
        <asp:Button ID="btnReadFirst" runat="server" Text="Read First" />
        <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" />
        <asp:Button ID="btnReadNext" runat="server" Text="Read Next" />
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>
