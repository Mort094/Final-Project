<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Albums.aspx.cs" Inherits="Admin_Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <article class="col-sm-6">
            <table class="table">
                <tr>
                    <td class="col-sm-2">
                        <asp:Label Text="Title:" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_title" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Artist:" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_artist" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Udgivelses år:" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_date" />

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Pris:" runat="server" /></td>
                    <td>
                        <asp:DropDownList ID="dd_price" runat="server" DataTextField="priceValue" Style="color: black;" DataValueField="priceId"></asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Genre:" runat="server" /></td>
                    <td>
                        <asp:DropDownList ID="dd_genre" runat="server" DataTextField="genreName" Style="color: black;" DataValueField="genreId"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:FileUpload ID="fu_billede" runat="server" />
                        <asp:HiddenField ID="hf_billede" runat="server" />
                        
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Opret" ID="btn_opret" CssClass="btn btn-primary" runat="server" OnClick="btn_opret_Click" />
                        <asp:Button Text="Gem" ID="btn_gem" CssClass="btn btn-primary" runat="server" Visible="false" OnClick="btn_gem_Click" />
                        <asp:Label Text="" ID="lbl_fejl" runat="server" />
                    </td>

                </tr>
            </table>
        </article>
        <article class="col-sm-6">
            <asp:Repeater runat="server" ID="re_content" OnItemCommand="re_content_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>

                                <td class="col-sm-2">Album title</td>
                                <td class="col-sm-6">Cover</td>
                                <td class="col-sm-2">Ret</td>
                                <td class="col-sm-2">Slet</td>


                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="col-sm-2"><%# Eval("albumTitle") %></td>
                        <td class="col-sm-6">
                            <img src="../Images/Albums/Small/<%# Eval("albumCover") %>" /></td>
                        <td class="col-sm-2">
                            <asp:Button Text="Ret" CssClass="btn btn-warning btn-sm" runat="server" CommandArgument='<%# Eval("albumId") %>' CommandName="edit" /></td>
                        <td class="col-sm-2">
                            <asp:Button Text="Slet" CssClass="btn btn-danger btn-sm" runat="server" CommandArgument='<%# Eval("albumId") %>' CommandName="delete" OnClientClick="return confirm('You are about to delete this album, are you sure about this?');" /></td>

                    </tr>

                </ItemTemplate>
                <FooterTemplate></table></FooterTemplate>
            </asp:Repeater>
        </article>
    </section>
</asp:Content>

