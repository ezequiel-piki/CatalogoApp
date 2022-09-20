<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <p>Bienvenido al catalogo de Articulos, tu lugar para ver los mejores articulos...</p>
    <div class="row row-cols-1 row-cols-md-3 g-4">
       
         <%-- <%foreach (dominio.Articulo articulo in ListaArticulos)
            {
          %>
             <div class="col">
             <div class="card h-100">
             <img src="<%:articulo.ImagenUrl%>" class="card-img-top" alt="...">
             <div class="card-body">
             <h5 class="card-title"> <%:articulo.Nombre%></h5>
             <p class="card-text"><%:articulo.Descripcion%></p>
                 <a href="DetalleArticulo.aspx?id=<%:articulo.Id%>" class="btn btn-secondary">Detalle</a>
               </div>
              </div>
             </div>

          <% 
             } 
          %>--%>

        <asp:Repeater id="repRepeater" runat="server">
            <ItemTemplate>
                 <div class="col">
             <div class="card h-100">
             <img src="<%# Eval("ImagenUrl")%>" class="card-img-top" alt="...">
             <div class="card-body">
             <h5 class="card-title"> <%#Eval("Nombre")%></h5>
             <p class="card-text"><%#Eval("Descripcion")%></p>
                 <a href="DetalleArticulo.aspx?id=<%#Eval("Id")%>" class="btn btn-secondary">Detalle</a>
                 <asp:Button Text="Ejemplo" CssClass="btn btn-primary" ID="btnEjemplo" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnEjemplo_Click"/>
               </div>
              </div>
             </div>
            </ItemTemplate>
        </asp:Repeater>
  
    </div>
</asp:Content>
