<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ListProblem.aspx.cs" Inherits="OrPgKb.ListProblem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>問題一覧
        <asp:Label ID="lbResult" runat="server"></asp:Label></strong><br />
    <asp:ListBox ID="lstList" runat="server" AutoPostBack="True" Height="670px" Width="96%" OnSelectedIndexChanged="lstList_SelectedIndexChanged"></asp:ListBox>
</asp:Content>