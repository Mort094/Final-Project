<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kontakt.aspx.cs" Inherits="Kontakt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>

        <p>Hvis du har spørgsmål eller kommentarer til DJ Grunk eller en af hans venner på biblioteket er du velkommen til at komme forbi. Vi har åbent på biblioteket alle hver- og lørdage. Du kan ogås ringe eller skrive, eller brug formularen nederst til højre så skal vi nok sørge for at DJ Grunk får din besked.</p>
    </div>

    <br />
    <hr />
    <section class="minFlex">
        <article class="col-sm-6">
            <asp:Repeater runat="server" ID="repeater_info">
                <HeaderTemplate>
                    <h4>Find os her!</h4>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table">
                        <tr>
                            <td class="col-sm-2"><%# Eval("infoName") %></td>
                        </tr>
                        <tr>
                            <td><%# Eval("infoAddress") %> </td>

                        </tr>
                        <tr>
                            <td><%# Eval("infoZip") %></td>
                        </tr>
                        <tr>
                            <td><%# Eval("infoPhone") %></td>
                        </tr>
                        <tr>
                            <td><%# Eval("infoEmail") %></td>
                        </tr>

                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </article>
        <article class="col-sm-6">
            <asp:Repeater runat="server" ID="repeater_time">
                <HeaderTemplate>
                    <h4>Åbningstider</h4>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table">
                        <tr>
                            <td><%# Eval("timeDay") %>: <%# Eval("timeOpen") %> - <%# Eval("timeClose") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </article>
    </section>
    <hr />
    <h2>Kontakt DJ Grunk og hans venner.</h2>
    <table class="table">
        <tr>
            <td class="col-sm-2">Navn:</td>
            <td>
                <asp:TextBox runat="server" ID="tb_name" /></td>
        </tr>
        <tr>
            <td>Adresse:</td>
            <td>
                <asp:TextBox runat="server" ID="tb_address" /></td>
        </tr>
        <tr>
            <td>Telefonnummer:</td>
            <td>
                <asp:TextBox runat="server" ID="tb_phone" /></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox runat="server" ID="tb_email" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="Du skal skrive din email!"
                            ControlToValidate="tb_email"
                            Display="Static"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Spørgsmål eller Kommentar:</td>
            <td>
                <asp:TextBox runat="server" ID="tb_text" TextMode="MultiLine" Rows="10" Columns="50" Style="resize: none;" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="Send" ID="btn_send" runat="server" CssClass="btn btn-primary" OnClick="btn_send_Click" /></td>
        </tr>
    </table>
</asp:Content>

