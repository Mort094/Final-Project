<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Albums.aspx.cs" Inherits="Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:repeater runat="server" id="re_content">
        <HeaderTemplate>
            <table class="table">
                <thead>
                    <tr>
                        <td></td>
                        <td><h5><asp:linkbutton text="Album" runat="server" id="lbtn_title" onclick="lbtn_title_Click"/></h5></td>
                        <td><h5><asp:linkbutton text="Kunstner" runat="server" id="lbtn_artist" onclick="lbtn_artist_Click" /></h5></td>
                        <td><h5><asp:linkbutton text="Genre" runat="server" id="lbtn_genre" onclick="lbtn_genre_Click"/></h5></td>
                        <td><h5><asp:linkbutton text="Udgivelses år" runat="server" id="lbtn_date" onclick="lbtn_date_Click" /></h5></td>
                    </tr>
                </thead>

        </HeaderTemplate>
        <ItemTemplate>
            <tr><td class="col-sm-2">
                <img src='Images/Albums/Large/<%# Eval("albumCover") %>' alt="Album Cover billede" width="100" />
                </td>
                <td><h4><a href='Albumet.aspx?album=<%# Eval("albumId") %>'><%# Eval("albumTitle") %></a></h4></td>
                <td><h5><%# Eval("albumArtist") %></h5></td>
                <td><h5><%# Eval("genreName") %></h5</td>
                <td><h5><%# Eval("albumDate", "{0:d}") %></h5</td>
            </tr>     
        </ItemTemplate>
        <FooterTemplate>
            </table>

        </FooterTemplate>
    </asp:repeater>

    <asp:literal id="Literal_Pager" runat="server"></asp:literal>
</asp:Content>

