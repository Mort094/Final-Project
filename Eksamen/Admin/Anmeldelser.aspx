<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Anmeldelser.aspx.cs" Inherits="Admin_Anmeldelser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater runat="server" ID="re_content" OnItemCommand="re_content_ItemCommand">
        <HeaderTemplate>
            <table class="table">
                <thead>
                    <tr>
                        <td class="col-sm-2">
                            <asp:LinkButton Text="Alle" runat="server" ID="lbtn_all" OnClick="lbtn_all_Click" /></td>
                        <td class="col-sm-1">Rating title</td>
                        <td class="col-sm-1">Skrevet den</td>
                        <td class="col-sm-5">Tekst</td>
                        <td class="col-sm-1">
                            <asp:LinkButton Text="Godkendte" runat="server" ID="lbtn_ok" OnClick="lbtn_ok_Click" /></td>
                        <td class="col-sm-1">
                            <asp:LinkButton Text="Ikke Godkendte" runat="server" ID="lbtn_nook" OnClick="lbtn_nook_Click" /></td>
                        <td class="col-sm-1">Slet</td>

                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="col-sm-2"><%# Eval("albumTitle") %> | <%# Eval("albumArtist") %></td>
                <td class="col-sm-1"><%# Eval("ratingTitle") %></td>
                <td class="col-sm-1"><%# Eval("ratingDate", "{0:d}") %></td>
                <td class="col-sm-5"><%# Eval("ratingText") %></td>
                <td class="col-sm-1">
                    <asp:Button Text="Godkendt" CssClass="btn btn-success btn-sm" runat="server" CommandArgument='<%# Eval("ratingId") %>' CommandName="ok" /></td>
                <td class="col-sm-1">
                    <asp:Button Text="Ikke godkendt" CssClass="btn btn-warning btn-sm" runat="server" CommandArgument='<%# Eval("ratingId") %>' CommandName="notok" /></td>
                <td class="col-sm-1">
                    <asp:Button Text="Slet" CssClass="btn btn-danger btn-sm" runat="server" CommandArgument='<%# Eval("ratingId") %>' CommandName="delete" OnClientClick="return confirm('You are about to delete this user, are you sure about this?');" /></td>

            </tr>

        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
</asp:Content>

