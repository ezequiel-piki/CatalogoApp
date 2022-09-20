<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="CatalogoApp.FormularioArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager >    
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
             <label for="txtId" class="form-label">Id:</label>
             <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
             <label for="txtCodigo" class="form-label">Codigo:</label>
             <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
             <label for="txtNombre" class="form-label">Nombre:</label>
             <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
           
            <div class="mb-3">
             <label for="ddlMarca" class="form-label">Marca:</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
             <label for="ddlCategoria" class="form-label">Categoria:</label>
               <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
             <label for="txtPrecio" class="form-label">Precio:</label>
             <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
             <div class="mb-3">
                 <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server"  />
                 <asp:button text="Desactivar" ID="btnDesactivar"  OnClick="btnDesactivar_Click" CssClass="btn btn-warning" runat="server" /> 
                 <a href="ListaArticulos.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
             <div class="mb-3">
             <label for="txtDescripcion" class="form-label">Descripción:</label>
             <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <asp:UpdatePanel runat="server" ID="updatePanel">
                <ContentTemplate>  
                    <div class="mb-3">
                      <label for="txtImagenUrl" class="form-label">Url Imagen:</label>
                      <asp:TextBox 
                          runat="server" 
                          AutoPostBack="true" 
                          ID="txtImagenUrl" 
                          CssClass="form-control" 
                          OnTextChanged="txtImagenUrl_TextChanged"
                          />
                    </div>
                    <asp:Image ImageUrl="https://kursagent.ru/wp-content/uploads/2020/12/placeholder-300x200.png" runat="server" ID="imgArticulo" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
    </div>
  <div class="row">
            <div class="col-6">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate> 
                <div class="mb-3">
                 <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server"  />
                 </div> 
                <%if(ConfirmaEliminacion) { %>
                 <div class="mb-3">
                     <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />    
                 <asp:Button Text="Eliminar" ID="btnConfirmarEliminar" OnClick="btnConfirmarEliminar_Click" CssClass="btn btn-outline-danger" runat="server"  />
                 </div>
                 <%} %>
                </ContentTemplate>
                </asp:UpdatePanel>
             </div>
        </div>
  
 
 

</asp:Content>
