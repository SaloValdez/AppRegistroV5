<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Report_Registro.aspx.vb" Inherits="AppRegistro.Report_Registro" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        


    	<div class="row "  >

			<div class="col-md-12 " >
					<section class="panel contenedor"  >
							<header class="panel-heading">
									<p style="text-align:center">Reporte</p>
									<a href="javascript:;" class="fa fa-chevron-down"></a>
									<a href="javascript:;" class="fa fa-times"></a>
								
							</header>
							<div class="panel-body "  >
<!--======================== INICIO CUERPO =======================================================-->
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>

                                        <rsweb:ReportViewer ID="repRegistro" runat="server" Width="1103px"></rsweb:ReportViewer>
                                        
                                       
                                    </ContentTemplate>
                                </asp:UpdatePanel>
<!--======================== FINCUERPO =======================================================-->
							</div>
					</section>
			</div>
	</div>


</asp:Content>
