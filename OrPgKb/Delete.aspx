<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="OrPgKb.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;削除しますか？<br />
    &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:LinkButton ID="btnYes" runat="server" OnClick="btnYes_Click">はい</asp:LinkButton>
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:LinkButton ID="btnNo" runat="server" OnClick="btnNo_Click">いいえ</asp:LinkButton><br />
    <br />
    &nbsp; &nbsp;
    <asp:Label ID="lbResult" runat="server"></asp:Label>
</asp:Content>

