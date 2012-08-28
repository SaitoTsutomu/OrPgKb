<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="NotAnswer.aspx.cs" Inherits="OrPgKb.NotAnswer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>未解答問題一覧&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbResult" runat="server"></asp:Label></strong><br />
    <asp:ListBox ID="lstList" runat="server" AutoPostBack="True" Height="670px" Width="96%" OnSelectedIndexChanged="lstList_SelectedIndexChanged" ></asp:ListBox>
</asp:Content>
