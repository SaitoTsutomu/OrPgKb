<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="OrPgKb.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>ファイルのアップロード&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbResult" runat="server" Text=""></asp:Label></strong><br />
    <br />
    &nbsp;
    <asp:FileUpload ID="FileUpload1" runat="server" Width="80%" />
    <br />
    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="アップロード" />
</asp:Content>
