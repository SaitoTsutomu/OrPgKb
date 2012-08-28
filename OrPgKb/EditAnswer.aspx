<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="EditAnswer.aspx.cs" Inherits="OrPgKb.EditAnswer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>解答<asp:Label ID="lbMode" runat="server">作成</asp:Label>
        &nbsp;&nbsp; &nbsp;
        <asp:Label ID="lbResult" runat="server"></asp:Label></strong><br />
<table cellpadding="0" cellspacing="0">
<tr><td style="height: 24px">タイトル</td><td style="height: 24px"><asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
    &nbsp; &nbsp;
    <asp:LinkButton ID="btnShowProblem" runat="server" OnClick="btnShowProblem_Click">問題表示</asp:LinkButton>
    &nbsp;
    <asp:LinkButton ID="btnShowAnswer" runat="server" OnClick="btnShowAnswer_Click" Visible="False">解答表示</asp:LinkButton>
</td></tr>
<tr><td>作成者</td><td><asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
    &nbsp; &nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Upload.aspx" Target="_blank">アップロード</asp:HyperLink></td></tr>
</table>
    <asp:TextBox ID="tbAnswer" runat="server" Height="542px" Width="96%" TextMode="MultiLine"></asp:TextBox><br />
    <asp:Button ID="btnAdd" runat="server" Text="作成" Width="79px" OnClick="btnAdd_Click" />
    <asp:Button ID="btnUpdate" runat="server" Text="更新" Width="79px" OnClick="btnUpdate_Click" Visible="False" />
</asp:Content>