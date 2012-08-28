<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="InfoUser.aspx.cs" Inherits="OrPgKb.InfoUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong><asp:Label ID="lbUser" runat="server" Text=""></asp:Label> さんの情報 &nbsp;&nbsp;
        <asp:Label ID="lbResult" runat="server"></asp:Label><br />
    </strong>
<table>
<tr><td align="right">
出題数 ：</td><td><asp:Label ID="lbNProblem" runat="server" Text=""></asp:Label></td></tr>
<tr><td align="right">
解答数 ：</td><td><asp:Label ID="lbNAnswer" runat="server" Text=""></asp:Label>
</td></tr>
<tr><td align="right">
カバー率 ：</td><td><asp:Label ID="lbRate" runat="server" Text=""></asp:Label>
</td></tr>
<tr><td align="right">
コメント数 ：</td><td><asp:Label ID="lbNComment" runat="server" Text=""></asp:Label>
</td></tr>
</table>
    <asp:ListBox ID="lstAnswer" runat="server" AutoPostBack="True" Height="562px" OnSelectedIndexChanged="lstAnswer_SelectedIndexChanged"
        Width="96%"></asp:ListBox>
</asp:Content>
