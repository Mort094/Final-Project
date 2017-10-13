<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="minFlex">

        <article class="col-sm-12">
            <asp:Label Text="" ID="lbl_fejl" runat="server" />
            <asp:Repeater runat="server" ID="repeater_info">

                <ItemTemplate>
                    <div class="col-sm-4">
                        <h3>Dine informationer</h3>
                        <table class="table">
                            <tr>
                                <td class="col-sm-4">Navn: <%# Eval("userName") %></td>
                            </tr>
                            <tr>
                                <td class="col-sm-4">Beskrivelse: <%# Eval("userDescription") %></td>
                            </tr>
                            <tr>
                                <td class="col-sm-4">Grunker: <%# Eval("userGrunker") %></td>
                            </tr>
                            <tr>
                                <td class="col-sm-4">Email: <%# Eval("userEmail") %></td>
                            </tr>

                        </table>
                    </div>
                    <div class="col-sm-4">
                        <img src='Images/Users/Scaled/<%# Eval("userImg") %>' alt="Dit profil billede" />

                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater runat="server" ID="repeater_latests">
                <HeaderTemplate>
                    <div class="col-sm-4">
                        <a href='Anmeldelser.aspx'>Læs dine anmendelser</a>

                        <h2>Seneste køb</h2>
                </HeaderTemplate>
                <ItemTemplate>
                    <img src="Images/Albums/Small/<%# Eval("albumCover") %>" alt="Alternate Text" />
                    <%# Eval("albumTitle") %><br />

                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

        </article>

    </section>
    <article class="col-sm-6">
        <br />
        <asp:Button Text="Ret din information" ID="btn_retProfil" CssClass="btn btn-primary" OnClick="btn_retProfil_Click" Visible="false" runat="server" />

        <asp:Label Text="" ID="lbl_fejl2" runat="server" />
        <asp:Panel runat="server" ID="panel_ret" Visible="false">
            <table class="table">
                <tr>
                    <td class="col-sm-2">
                        <asp:Label Text="Navn:" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_name" ValidationGroup="update" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Email:" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_email" ValidationGroup="update" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ErrorMessage="Du skal skrive din email!"
                            ControlToValidate="tb_email"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Kodeord:" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_pass" />
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ErrorMessage="Kodeord er ikke ens!"
                            ControlToCompare="tb_pass"
                            ControlToValidate="tb_gen"
                            ValidationGroup="update"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Gentag Kodeord:" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_gen" />
                        <asp:CompareValidator ID="CompareValidator2" runat="server"
                            ErrorMessage="Kodeord er ikke ens!"
                            ControlToCompare="tb_gen"
                            ControlToValidate="tb_pass"
                            ValidationGroup="update"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="beskrivelse:" runat="server"  /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_beskri" ValidationGroup="update" TextMode="MultiLine" Columns="50" Rows="10" /></td>
                </tr>
                <tr>
                    <td><asp:Label Text="Profil billede:" runat="server"  /></td>
                    <td>
                        <asp:FileUpload ID="fu_billede" runat="server" ValidationGroup="update" />
                        <asp:HiddenField runat="server" ID="hf_billede"></asp:HiddenField>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Gem" ID="btn_gem" runat="server" cssClass="btn btn-primary" OnClick="btn_gem_Click" ValidationGroup="update" /></td>
                </tr>
            </table>
        </asp:Panel>
    </article>
</asp:Content>

