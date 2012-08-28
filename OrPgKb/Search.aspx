<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="OrPgKb.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>「<asp:Label ID="lbSearch" runat="server" Text=""></asp:Label>」の検索結果</strong><br />
    <br />
    問題の検索結果&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbRes1" runat="server" Text=""></asp:Label><br />
    <asp:ListBox ID="lstProblem" runat="server" AutoPostBack="True" Height="190px" Width="96%" OnSelectedIndexChanged="lstProblem_SelectedIndexChanged" ></asp:ListBox><br />
    解答の検索結果&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbRes2" runat="server" Text=""></asp:Label><br />
    <asp:ListBox ID="lstAnswer" runat="server" AutoPostBack="True" Height="190px" Width="96%" OnSelectedIndexChanged="lstAnswer_SelectedIndexChanged" ></asp:ListBox><br />
    コメントの検索結果&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbRes3" runat="server" Text=""></asp:Label><br />
    <asp:ListBox ID="lstComment" runat="server" AutoPostBack="True" Height="190px" Width="96%" OnSelectedIndexChanged="lstComment_SelectedIndexChanged" ></asp:ListBox>
</asp:Content>
