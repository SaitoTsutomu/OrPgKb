<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ShowAnswer.aspx.cs" Inherits="OrPgKb.ShowAnswer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>解答 &nbsp; &nbsp;
        <asp:Label ID="lbResult" runat="server"></asp:Label></strong><br />
<table cellpadding="2" cellspacing="0">
<tr><td bgcolor="#feffa3" style="height: 22px">タイトル</td><td style="height: 22px">
    <asp:Label ID="lbTitle" runat="server"></asp:Label>
    &nbsp; &nbsp;
    <asp:LinkButton ID="btnShowProblem" runat="server" OnClick="btnShowProblem_Click">問題表示</asp:LinkButton>
    </td></tr>
<tr><td bgcolor="#feffa3">作成者</td><td>
    <asp:Label ID="lbUser" runat="server"></asp:Label></td></tr>
<tr><td bgcolor="#feffa3">作成時</td><td>
    <asp:Label ID="lbTime" runat="server"></asp:Label></td></tr>
</table>
    <asp:TextBox ID="tbAnswer" runat="server" BackColor="#FFFFC0" Height="352px" Width="96%" BorderStyle="None" TextMode="MultiLine"></asp:TextBox><br />
    &nbsp; &nbsp;
    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="編集" Visible="False" />
    &nbsp; &nbsp;
    <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" Text="削除" Visible="False" /><br />
    <asp:Panel ID="pnlCommentAdd" runat="server" Height="31px" Width="96%">
        &nbsp;コメント
        <asp:TextBox ID="tbComment" runat="server" Width="452px"></asp:TextBox>
        <asp:Button ID="btnAddComment" runat="server" OnClick="btnAddComment_Click" Text="追加" /></asp:Panel>
    <asp:ListBox ID="lstComment" runat="server" Height="166px" OnSelectedIndexChanged="lstComment_SelectedIndexChanged"
        Width="96%" AutoPostBack="True"></asp:ListBox>
</asp:Content>
