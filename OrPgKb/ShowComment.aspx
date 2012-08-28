<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ShowComment.aspx.cs" Inherits="OrPgKb.ShowComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>コメント &nbsp; &nbsp;
        <asp:Label ID="lbResult" runat="server"></asp:Label></strong><br />
<table cellpadding="2" cellspacing="0">
<tr><td bgcolor="#FFD0A0">作成者</td><td>
    <asp:Label ID="lbUser" runat="server"></asp:Label>
    &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="btnShowAnswer" runat="server" OnClick="btnShowAnswer_Click">解答表示</asp:LinkButton>
</td></tr>
<tr><td bgcolor="#FFD0A0">作成時</td><td>
    <asp:Label ID="lbTime" runat="server"></asp:Label></td></tr>
</table>
    <asp:Label ID="lbComment" runat="server" BackColor="#FFE0C0" Height="28px" Width="96%"></asp:Label><br />
    &nbsp; &nbsp;
    <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" Text="削除" Visible="False" /><br />
</asp:Content>
