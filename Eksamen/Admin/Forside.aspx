<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Forside.aspx.cs" Inherits="Admin_Forside" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <article class="col-sm-6">
            <asp:Label Text="Forside Tekst!:" runat="server" />
            <br /><br />
            <asp:Button Text="Rediger tekts" CssClass="btn btn-primary btn-sm" runat="server" ID="btn_edit" OnClick="btn_edit_Click" />
            <br />
            <br />
            <asp:TextBox runat="server" TextMode="MultiLine" ID="tb_text" Columns="50" Rows="10" />
            <br />
            <br />
            <asp:Button Text="Gem" ID="btn_gem" CssClass="btn btn-primary" runat="server" OnClick="btn_gem_Click" />
        </article>
        <article class="col-sm-6">
            <asp:Repeater runat="server" ID="repeater_text">
                <ItemTemplate>
                    <p>
                        <%# Eval("frontText") %>
                    </p>
                </ItemTemplate>
            </asp:Repeater>
        </article>
    </section>
</asp:Content>

