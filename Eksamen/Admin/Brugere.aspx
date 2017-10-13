<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Brugere.aspx.cs" Inherits="Admin_Brugere" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="table">
        <tr>
            <td>Navn:  
                <br />
                <asp:TextBox runat="server" ID="tb_name" /></td>
        </tr>
        <tr>
            <td>Email
                        <br />
                <asp:TextBox runat="server" ID="tb_email" /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Ugyldig email"
                    ControlToValidate="tb_email"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Password
                        <br />
                <asp:TextBox runat="server" ID="tb_password" /></td>
        </tr>
        <tr>
            <td>Beskrivelse
                <br />
                <asp:TextBox runat="server" id="tb_descri" />
            </td>
        </tr>
        <tr>
            <td>Rolle:
                        <br />
                <asp:DropDownList ID="dd_role" runat="server" DataTextField="roleName" DataValueField="roleId" Style="color: black;"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>
             
                <asp:Button Text="Gem" CssClass="btn btn-primary btn-sm" runat="server" ID="btn_gem" OnClick="btn_gem_Click" />
                <asp:Label Text="" ID="lbl_fejl" runat="server" />
            </td>
        </tr>

    </table>
    <asp:Button Text="Reset alle" ID="btn_reset" OnClick="btn_reset_Click" runat="server" />

    <hr />

    <asp:Repeater runat="server" ID="repeater_data" OnItemCommand="repeater_data_ItemCommand" >
        <ItemTemplate>
            <table class="table">

                <tr>
                    <td class="col-xs-3"><%# Eval("userName") %></td>
                    <td class="col-xs-3"><%# Eval("userEmail") %></td>
                    <td class="col-xs-3"><%# Eval("roleName") %></td>
                    <td class="col-xs-3"><%# Eval("userGrunker") %> </td>
                    <td class="col-xs-3">
                        <asp:Button Text="Ret" CssClass="btn-success" runat="server" CommandArgument='<%# Eval("userId") %>' CommandName="edit" /></td>
                    <td><asp:Button Text="Giv grunker" CssClass="btn-success" runat="server" CommandArgument='<%# Eval("userId") %>' CommandName="give" /></td>
                    <td class="col-xs-3">
                        <asp:Button Text="Slet" CssClass="btn-danger" runat="server" CommandArgument='<%# Eval("userId") %>' CommandName="delete" OnClientClick="return confirm('You are about to delete this user, are you sure about this?');" /></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

