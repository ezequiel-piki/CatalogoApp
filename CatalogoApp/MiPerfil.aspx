<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="CatalogoApp.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label Text="Email" runat="server"  CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"/>
            </div>
            <div class="mb-3">
                <asp:Label Text="Apellido" CssClass="form-label" runat="server" />
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido"/>
            </div>
            <div class="mb-3">
                <asp:Label Text="Fecha de Nacimiento" CssClass="form-label" runat="server" />
                <asp:TextBox CssClass="form-control" ID="txtFechaNacimiento" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label Text="Imagen Perfil" runat="server" CssClass="form-label" />
                <input type="file" ID="txtImagen" class="form-control" runat="server" />
            </div>
            <asp:Image ImageUrl="https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-1-scaled-1150x647.png" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>
</asp:Content>
