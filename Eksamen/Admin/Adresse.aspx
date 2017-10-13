<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Adresse.aspx.cs" Inherits="Admin_Adresse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:label text="Navn:" runat="server" />
    <br />
    <asp:textbox runat="server" id="tb_name"></asp:textbox>
    <br />
    <asp:label text="Adresse:" runat="server" />
    <br />
    <asp:textbox runat="server" id="tb_address"></asp:textbox>
    <br />
    <asp:label text="Post nummer:" runat="server" />
    <br />
    <asp:textbox runat="server" id="tb_zip"></asp:textbox>
    <br />
    <asp:label text="Telefonnummer:" runat="server" />
    <br />
    <asp:textbox runat="server" id="tb_phone"></asp:textbox>
    <br />
    <asp:label text="Email:" runat="server" />
    <br />
    <asp:textbox runat="server" id="tb_email"></asp:textbox>
    <br />
    <br />
    <asp:button text="Gem" id="btn_gem" onClick="btn_gem_Click" runat="server" cssClass="btn btn-primary" />

</asp:Content>

