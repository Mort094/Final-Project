<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Anmeldelse.aspx.cs" Inherits="Anmeldelse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:repeater runat="server" id="repeater_head">
        <ItemTemplate>
            <h1><%# Eval("albumTitle") %></h1>
        </ItemTemplate>
    </asp:repeater>

    <asp:repeater runat="server" id="repeater_content">
        <ItemTemplate>
            <table class="table">
            <tr>
                <td><h4>Overskrift: <%# Eval("ratingTitle") %></h4></td>
            </tr>
            <tr>
                <td>Skrevet: <%# Eval("ratingDate", "{0:d}") %></td>
            </tr>
            <tr>
                <td>Anmeldelse:<br /> <%# Eval("ratingText") %></td>
                <td></td>
            </tr>
           <tr>
               <td>Skrevet af: <%# Eval("userName") %></td>
           </tr>
            
          
         

            </table>
            <hr />
        </ItemTemplate>
    </asp:repeater>
</asp:Content>

