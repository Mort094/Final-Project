<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Anmeldelser.aspx.cs" Inherits="Anmeldelser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:panel runat="server" id="panel_comment" visible="false">
        <table class="table">
            <tr>
                <td class="col-sm-1">Title:</td>
                <td><asp:textbox runat="server" ID="tb_title" /></td>
            </tr>
              <tr>
                <td>Text:</td>
                <td><asp:textbox runat="server" id="tb_text" textmode="multiline" columns="50" rows="10" style="resize:none;" /></td>
            </tr>
              <tr>
                <td><asp:button text="Send anmeldelse" runat="server" CssClass="btn btn-primary" id="btn_send" onclick="btn_send_Click" />
                    <asp:label text="" id="lbl_fejl" runat="server" />
                </td>
                
            </tr>
              
        </table>
    </asp:panel>
    <asp:repeater runat="server" id="repeater_content">
        <headerTemplate>
            <table class="table">
                <tr><th>Cover</th>
                    <th>Album</th>
                    <th>Kunstner
                    </th>
                    <th>Genre</th>
                    <th>Udgivelses År</th>
                </tr>
        </headerTemplate>
        <ItemTemplate>
            
            <tr><td class="col-sm-2">
                <img src='Images/Albums/Large/<%# Eval("albumCover") %>' alt="Album Cover billede" width="100" /></td>

                <td><h4> <a href='Anmeldelse.aspx?Anmeldelse=<%# Eval("albumId") %>'><%# Eval("albumTitle") %></a></h4></td>
                <td><h5><%# Eval("albumArtist") %></h5></td>
                <td><h5><%# Eval("genreName") %></h5</td>
                <td><h5><%# Eval("albumDate", "{0:d}") %></h5</td>
           </tr> 

            
          
        </ItemTemplate>
        <footertemplate>
            </table>
        </footertemplate>
    </asp:repeater>
    <br />

</asp:Content>

