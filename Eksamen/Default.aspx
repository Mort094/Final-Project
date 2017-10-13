<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="minFlex">
        <article class="col-sm-4">
            <h1>Velkommen Hos DJ Grunk</h1>
            <asp:repeater runat="server" id="repeater_front">    
                    <ItemTemplate><%# Eval("frontText") %></ItemTemplate>
            </asp:repeater>
        </article>
        <article class="col-sm-4">
            <asp:repeater runat="server" id="repeater_top">
                <HeaderTemplate>Mest solgte albums!<br /></HeaderTemplate>
                <ItemTemplate><a href='Albumet.aspx?album=<%# Eval("albumId") %>'><img src='Images/Albums/Small/<%# Eval("albumCover") %>'> <%# Eval("albumTitle") %></a>
                    <br />
                </ItemTemplate>
            </asp:repeater>
        </article>
        <article class="col-sm-4">
            <asp:repeater runat="server" id="repeater_random">
                <HeaderTemplate>Random albums!<br /></HeaderTemplate>
                <ItemTemplate><a href='Albumet.aspx?album=<%# Eval("albumId") %>'><img src='Images/Albums/Small/<%# Eval("albumCover") %>'> <%# Eval("albumTitle") %></a><br /></ItemTemplate>
            </asp:repeater>
        </article>
    </section>

</asp:Content>

