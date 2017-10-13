<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Tider.aspx.cs" Inherits="Admin_Tider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <article class="col-sm-6">
            <asp:Repeater runat="server" ID="repeater_time" OnItemCommand="repeater_time_ItemCommand">
                <ItemTemplate>
                    <table class="table">
                        <tr>
                            <td class="col-sm-2"><%# Eval("timeDay") %></td>
                            <td class="col-sm-2"><%# Eval("timeOpen") %> </td>
                            <td class="col-sm-2"><%# Eval("timeClose") %></td>
                            <td class="col-sm-2">
                                <asp:Button Text="Ret" runat="server" CssClass="btn btn-primary btn-sm" CommandName="edit" CommandArgument='<%# Eval("timeId") %>'/></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </article>
        <article class="col-sm-6">
            <asp:Label Text="Dag" runat="server" id="lbl_day"/>
            <br />
            <asp:TextBox runat="server" id="tb_openTime"/>
            <br /><br />
            <asp:TextBox runat="server" id="tb_closeTime"/>
            <br />
            <br />
            <asp:Button Text="Gem" ID="btn_gem" CssClass="btn btn-primary btn-sm" OnClick="btn_gem_Click" runat="server" />
            
        </article>
    </section>
</asp:Content>

