﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Form_Usuario.aspx.vb" Inherits="AppRegistro.Form_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        


    	<div class="row "  >

			<div class="col-md-12 " >
					<section class="panel contenedor"  >
							<header class="panel-heading">
									<p style="text-align:center">Mantenimiento Usuario</p>
									<a href="javascript:;" class="fa fa-chevron-down"></a>
									<a href="javascript:;" class="fa fa-times"></a>
								
							</header>
							<div class="panel-body "  >
<!--======================== INICIO CUERPO =======================================================-->
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>


                                        <table class="table_cajas" style="width: 100%;">
                                            <tr class ="filas">
                                                <td class="texto"><asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label></td>
                                                <td><asp:TextBox  ID="txtId" class="form-control caja_chico" runat="server"  disabled="disabled"  Style="text-align:center" ></asp:TextBox></td>
                                            </tr>
                                            <tr class ="filas">
                                                <td class="texto"><asp:Label ID="Label2" runat="server" Text=" Nombre Usuario:"></asp:Label></td>
                                                <td><asp:TextBox ID="txtUsuario" class="form-control caja_mediano" runat="server" style="text-transform:uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox></td>
                                            </tr>
                                             <tr class ="filas">
                                                <td class="texto"><asp:Label ID="Label3" runat="server" Text=" Ingrese Contraseña:"></asp:Label></td>
                                                <td><asp:TextBox ID="txtContrasena" class="form-control caja_mediano" runat="server" style="text-transform:uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox></td>
                                            </tr>
                                        </table>


                                        <div class="border-top-0">  


                                            <hr />
                                        <table style="width: 100%;" class="table_botones">
                                            <tr>
                                                <td>
                                                 <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" />
                                                 <asp:Button ID="btnModificar" class="btn btn-success" runat="server" Text="Modificar" />
                                                 <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server" Text="Eliminar" />
                                                 <asp:Button ID="btnCancelar"   class="btn btn-warning" runat="server" Text="Cancelar" />                                           
                                                <%-- MENSAJES DE ALERTA --%>   <br />
                                                     <asp:TextBox ID="txtCorrecto" runat="server"  class="alert alert-success" disabled="disabled" Text="" style="height:20px; width:50%; margin-top:10px; margin-bottom:5px;"></asp:TextBox>                                       
                                                     <asp:TextBox ID="txtError" runat="server"  class="alert alert-danger" disabled="disabled" Text="" style="height:20px; width:50%; margin-top:10px; margin-bottom:5px;"></asp:TextBox>                                       
                                                </td>                               
                                            </tr>
                                               
                                        </table>
                                             <asp:GridView ID="gwUsuario"  class="table_grid" runat="server" AllowPaging="True" PageSize="5" Width="327px" DataKeyNames="ID">
                                                 <Columns>
                                                     <asp:CommandField ButtonType="Button"  ShowSelectButton="True" />
                                                 </Columns>
                                            </asp:GridView>

                                               
                                        </div>
                                     

                                     
                                       
                                    </ContentTemplate>
                                </asp:UpdatePanel>
<!--======================== FINCUERPO =======================================================-->
							</div>
					</section>
			</div>
	</div>


</asp:Content>
