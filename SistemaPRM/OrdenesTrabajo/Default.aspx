<%@ Page Title="" Language="C#" MasterPageFile="~/Midas.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Comisiones_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="controlador" runat="server" ActiveViewIndex="0">
        <asp:View ID="contenidoOT" runat="server">
            <!-- com-->
            <asp:Panel runat="server" ID="principal">
                <asp:Label runat="server" ID="idOT" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="rama" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="subRamo" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="conducto" Visible="false"></asp:Label>
                <!---->
                 <table style="width: 90%; border: none; text-align: right;">
                    <tr>
                        <td style="padding-right: 30px; width: 25%; height: 35px;">
                                <asp:Label ID="lblFolio" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <h3><asp:Label ID="lblFecha" runat="server"></asp:Label></h3>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 30px; width: 20%; height: 35px;">Tipo de Orden de Trabajo:</td>
                        <td>
                            <asp:DropDownList ID="ddlOrdenTrabajo" runat="server" OnSelectedIndexChanged="ddlOrdenTrabajo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 30px; width: 20%; height: 35px;">Ramo:</td>
                        <td>
                            <asp:DropDownList ID="ddlRamo" runat="server" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 30px; width: 20%; height: 35px;">SubRamo:</td>
                        <td>
                            <asp:DropDownList ID="ddlSubRamo" runat="server" OnSelectedIndexChanged="ddlSubRamo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 30px; width: 20%; height: 35px;">Conducto:</td>
                        <td>
                            <asp:DropDownList ID="ddlCOnducto" runat="server" OnSelectedIndexChanged="ddlCOnducto_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="1" Text="AGENTE"></asp:ListItem>
                                <asp:ListItem Value="2" Text="ASESOR"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 30px; width: 20%; height: 35px;">¿Quien solicito?:</td>
                        <td>
                            <asp:DropDownList ID="ddlSolicito" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="busqueda">

            </asp:Panel>
            <asp:Panel runat="server" ID="datosContratante">

            </asp:Panel>
            <asp:Panel runat="server" ID="datosAsegurado">
                <!---->

            </asp:Panel>
            <asp:Panel runat="server" ID="detalle">
                <!---->

            </asp:Panel>
            <asp:Panel runat="server" ID="emision">
                <!---->

            </asp:Panel>
            <asp:Panel runat="server" ID="infoAdicional">
                <!---->

            </asp:Panel>
            <asp:Panel runat="server" ID="documentos">
                <!---->

            </asp:Panel>
        </asp:View>
        <asp:View ID="">
            <!-- por Periodo-->
        </asp:View>
        <asp:View>
            <!-- -->
        </asp:View>
    </asp:MultiView>
</asp:Content>

