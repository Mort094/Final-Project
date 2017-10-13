<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <article class="col-sm-6">
            <table class="table">
                <tr>
                    <td>
                        <asp:Label Text="Email:" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tb_email" ValidationGroup="login" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="Du skal skrive din email!"
                            ControlToValidate="tb_email"
                            Display="Static"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>

                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Kodeord:" runat="server" /></td>

                    <td>
                        <asp:TextBox runat="server" ID="tb_password" TextMode="Password" ValidationGroup="login" /></td>

                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Login" ID="btn_login" CssClass="btn btn-primary" runat="server" ValidationGroup="login" OnClick="btn_login_Click" />
                    </td>
                </tr>
                <tr>
                    <td><a href="#">Glemt kodeord?</a></td>
                </tr>

                <tr>
                    <td> <asp:Button Text="Ny bruger?" ID="btn_visopret" CssClass="btn btn-primary btn-sm" OnClick="btn_visopret_Click" runat="server" /></td>
                </tr>

            </table>
        </article>

        <article class="col-sm-6">
            <asp:Panel runat="server" ID="panel_opret" Visible="false">
                <table class="table">
                    <tr>
                        <td class="col-sm-2">
                            <asp:Label Text="Navn:" runat="server" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="tb_OPname" ValidationGroup="opret" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Email:" runat="server" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="tb_OPemail" ValidationGroup="opret" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ErrorMessage="Du skal skrive din email!"
                                ControlToValidate="tb_OPemail"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Kodeord:" runat="server"  /></td>
                        <td>
                            <asp:TextBox runat="server" ID="tb_OPpass" textmode="password" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                ErrorMessage="Kodeord er ikke ens!"
                                ControlToCompare="tb_OPpass"
                                ControlToValidate="tb_OPgen"
                                ValidationGroup="opret"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Gentag Kodeord:" runat="server" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="tb_OPgen" textmode="password" />
                            <asp:CompareValidator ID="CompareValidator2" runat="server"
                                ErrorMessage="Kodeord er ikke ens!"
                                ControlToCompare="tb_OPgen"
                                ControlToValidate="tb_OPpass"
                                ValidationGroup="opret"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="beskrivelse:" runat="server" ValidationGroup="opret" TextMode="MultiLine" Columns="50" Rows="10" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="tb_OPbeskri" ValidationGroup="opret" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label Text="beskrivelse:" runat="server"  /></td>
                        <td>
                            <asp:FileUpload ID="fu_billede" runat="server" ValidationGroup="opret" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button Text="Opret" ID="btn_opret" runat="server" ValidationGroup="opret" OnClick="btn_opret_Click" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </article>
    </section>
</asp:Content>

