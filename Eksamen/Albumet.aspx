<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Albumet.aspx.cs" Inherits="Albumet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="minFlex">
        <article class="col-sm-4">
            <asp:label text="" id="lbl_fejl1" runat="server" />
            <asp:Repeater runat="server" ID="repeater_samegenre">
                <headertemplate>
                    Andre album med samme genre!
                    <br />
                </headertemplate>
                <ItemTemplate>

                    <a href='Albumet.aspx?album=<%# Eval("albumId") %>'><%# Eval("albumTitle") %></a><br />

                </ItemTemplate>
            </asp:Repeater>

        </article>



        <article class="col-sm-8 minFlex">
            <asp:Label Text="" ID="lbl_fejl" runat="server" />
            <asp:Repeater runat="server" ID="repeater_info">
                <headertemplate><table class="table" style="width: 50%;">
                    <tr><th><h4>Album info!</h4></th></tr>
                </headertemplate>
                <ItemTemplate>
                    
                        <tbody class="col-sm-6">
                            <tr>
                                <td>Title: <%# Eval("albumTitle") %></td>
                            </tr>
                            <tr>
                                <td>Genre: <%# Eval("genreName") %></td>
                            </tr>
                            <tr>
                                <td>Pris: <%# Eval("priceValue") %> Grunker</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button Text="Køb" ID="btn_kob" CssClass="btn btn-primary btn-sm" OnClick="btn_kob_Click" runat="server" OnClientClick="return confirm('Du er nu ved at købe dette album, er du sikker på dette?');" />

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href='Anmeldelser.aspx?album=<%# Eval("albumId") %>'>Læs anmeldelser</a></td>
                            </tr>

                        </tbody>
                    </table>
                    <img src='Images/Albums/<%# Eval("albumCover") %>' alt="Album cover" width="200" height="200" />

                </ItemTemplate>
            </asp:Repeater>
        </article>
    </section>

</asp:Content>

