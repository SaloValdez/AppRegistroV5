<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Form_Registro.aspx.vb" Inherits="AppRegistro.Form_Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        


    	<div class="row "  >

			<div class="col-md-12 " >
					<section class="panel contenedor"  >
							<header class="panel-heading">
									<p style="text-align:center">Mantenimiento Registro</p>
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
                                                 <td>

                                                       <div class="input-group m-bot15 ">
                                                        
                                                              <span class="input-group-btn">
                                                                  <a href="Report_Registro.aspx"> <Button type="button" class="btn btn-default btn-success" ID="btnB"><i class="fa fa-print"></i> Ver Reporte</Button>  </a>
                                                              </span>
                                                        </div>



                                                 </td>
                                            </tr>
                                            <tr class ="filas">
                                                <td class="texto"><asp:Label ID="Label5" runat="server" Text="Alumno :"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="droAlumno" runat="server"  class="form-control"  Width="250px" ></asp:DropDownList></td>
                                            </tr>

                                            <tr class ="filas">
                                                <td class="texto"><asp:Label ID="Label6" runat="server" Text=" Curso :"></asp:Label></td>
                                                <td><asp:DropDownList ID="droCurso" runat="server"  class="form-control col-xs-4"  Width="250px"></asp:DropDownList></td>
                                            </tr>
                                            <tr class ="filas">
                                                <td class="texto"><asp:Label ID="Label7" runat="server" Text="Docente :"></asp:Label></td>
                                                <td><asp:DropDownList ID="droDocente" runat="server"  class="form-control col-xs-4"  Width="250px"></asp:DropDownList></td>
                                            </tr>

                                           
                                        </table >
                                      
                                        <table class="table_cajas" style="width: 70%;">
                                               <tr class ="filas">
                                                <td class="texto">
                                                    <asp:Label ID="Label2" runat="server" Text=" Nota 1:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNota1" class="form-control caja_chico" runat="server" style="text-transform:uppercase; text-align:center;" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox></td>
                                                 <td class="texto">
                                                     <asp:Label ID="Label3" runat="server" Text=" Nota 2:"></asp:Label>
                                                 </td>
                                                <td>
                                                    <asp:TextBox ID="txtNota2" class="form-control caja_chico" runat="server" style="text-transform:uppercase; text-align:center;" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox></td> 
                                                 <td class="texto">
                                                     <asp:Label ID="Label8" runat="server" Text=" Nota 3:"></asp:Label>
                                                 </td>
                                                <td><asp:TextBox ID="txtNota3" class="form-control caja_chico" runat="server" style="text-transform:uppercase; text-align:center;" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox></td>                                                     
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
                                             <asp:GridView ID="gwRegistro"  class="table_grid" runat="server" AllowPaging="True" PageSize="5" Width="1090px" DataKeyNames="ID">
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
