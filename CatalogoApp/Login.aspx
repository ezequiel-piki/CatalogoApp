<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoApp.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h1>Login</h1>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtPassword" />
            </div>
            <asp:Button Text="Ingresar" ID="btnLogin" runat="server" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
            <a href="/">cancelar</a>
        </div>
    </div>
</asp:Content>
