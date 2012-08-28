<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ShowProblem.aspx.cs" Inherits="OrPgKb.ShowProblem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>問題 &nbsp; &nbsp;
        <asp:Label ID="lbResult" runat="server"></asp:Label></strong><br />
<table cellpadding="2" cellspacing="0">
<tr><td bgcolor="PowderBlue">タイトル</td><td>
    <asp:Label ID="lbTitle" runat="server"></asp:Label></td></tr>
<tr><td bgcolor="PowderBlue">カテゴリ</td><td>
    <asp:Label ID="lbCate" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="btnListProblem" runat="server" OnClick="btnListProblem_Click">問題一覧</asp:LinkButton></td></tr>
<tr><td bgcolor="PowderBlue">作成者</td><td>
    <asp:Label ID="lbUser" runat="server"></asp:Label></td></tr>
<tr><td bgcolor="PowderBlue">作成時</td><td>
    <asp:Label ID="lbTime" runat="server"></asp:Label></td></tr>
</table>
    <asp:Panel ID="Panel1" runat="server" BackColor="#D0FFFF" Height="382px" ScrollBars="Both"
        Width="96%">
    <asp:Label ID="lbProblem" runat="server" BorderStyle="None"
        Height="339px" Width="693px"></asp:Label></asp:Panel>
    &nbsp; 
    <asp:Button ID="btnAnswer" runat="server" Text="回答する" Width="79px" OnClick="btnAnswer_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="編集" Visible="False" />
    &nbsp; &nbsp;
    <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" Text="削除" Visible="False" /><br />
    <br />
    <asp:ListBox ID="lstAnswer" runat="server" AutoPostBack="True" Height="141px" OnSelectedIndexChanged="lstAnswer_SelectedIndexChanged"
        Width="96%"></asp:ListBox>
</asp:Content>

