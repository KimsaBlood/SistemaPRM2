<%@ Page Title="" Language="C#" MasterPageFile="~/Midas.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Administracion_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .form-control,.control-label{
            margin-top:5px;
            margin-bottom:5px;
            max-height:28px;
            font-size:12px;
            padding-left:25px;
            padding-right:25px; 
        }.titulo{
             margin-top: 30px; 
             margin-bottom:30px;
             text-align:center; 
         }
        .form-group {
            margin-bottom:30px;
        }.btnRegis{
             width:300px;
             margin-top:20px;
             margin-bottom:30px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView runat="server" ActiveViewIndex="0">
        <asp:View runat="server" ID="viewRegis">
            <div class="row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1"></div>
                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
                    <h2 class="titulo">Información principal del usuario</h2>
                    <hr />
                </div>
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtnombre">Nombre o razón social:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtnombre" CssClass="form-control" required="required" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtApPa">Apellido paterno:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtApPa" CssClass="form-control" required="required" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtApMa">Apellido materno:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtApMa" CssClass="form-control" required="required" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtRFC">RFC:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtRFC" CssClass="form-control" required="required" pattern="^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])([A-Z]|[0-9]){2}([A]|[0-9]){1})?$" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtTelefono">Número telefónico:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" required="required" pattern="^[0-9]{8,}" />
                        </div>
                    </div>
                    
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <br />
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtIngreso">Fecha de ingreso:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtIngreso" CssClass="form-control" required="required" placeholder="dd/mm/aaaa" pattern="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" />
                        </div>
                    </div>
                    <asp:Panel runat="server" ID="panelRol" class="form-group">
                        <label class="control-label col-sm-5" for="txtTipoUs">Tipo de usuario:</label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" ID="txtTipoUs" CssClass="form-control">
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Asesor" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cobranza" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Directiva" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Emisor" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                         </div>
                        <asp:Label runat="server" ID="lblTipoUs1" Visible="false" class="control-label col-sm-5" for="txtTipoUs1">Tipo de usuario:</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" Visible="false" ID="txtTipoUs1" CssClass="form-control">
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Asesor" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cobranza" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Directiva" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Emisor" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                         </div>
                        <asp:Label runat="server" ID="lblTipoUs2" Visible="false" class="control-label col-sm-5" for="txtTipoUs2">Tipo de usuario:</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" Visible="false" ID="txtTipoUs2" CssClass="form-control">
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Asesor" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cobranza" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Directiva" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Emisor" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                         </div>
                        <asp:Label runat="server" ID="lblTipoUs3" Visible="false" class="control-label col-sm-5" for="txtTipoUs3">Tipo de usuario:</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" Visible="false" ID="txtTipoUs3" CssClass="form-control">
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Asesor" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cobranza" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Directiva" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Emisor" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                         </div>
                        <asp:Label runat="server" ID="lblTipoUs4" Visible="false" class="control-label col-sm-5" for="txtTipoUs4">Tipo de usuario:</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" Visible="false" ID="txtTipoUs4" CssClass="form-control">
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Asesor" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cobranza" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Directiva" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Emisor" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                         </div>
                        <asp:Label runat="server" ID="lblTipoUs5" Visible="false" class="control-label col-sm-5" for="txtTipoUs5">Tipo de usuario:</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" Visible="false" ID="txtTipoUs5" CssClass="form-control">
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Asesor" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cobranza" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Directiva" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Emisor" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                         </div>
                        <asp:Label runat="server" ID="lblTipoUs6" Visible="false" class="control-label col-sm-5" for="txtTipoUs6">Tipo de usuario:</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" Visible="false" ID="txtTipoUs6" CssClass="form-control">
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Asesor" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cobranza" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Directiva" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Emisor" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                         </div>
                        <asp:Label runat="server" ID="lblTipoUs7" Visible="false" class="control-label col-sm-5" for="txtTipoUs7">Tipo de usuario:</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" Visible="false" ID="txtTipoUs7" CssClass="form-control">
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Asesor" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cobranza" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Directiva" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Emisor" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                         </div>
                     </asp:Panel>
                    <asp:LinkButton runat="server" ID="btnNuevoRol" OnClick="btnNuevoRol_Click" Text="Agregar" CssClass="btn btn-info" />
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtOficina">Oficina:</label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" ID="txtOficina" CssClass="form-control">
                                <asp:ListItem Text="PRM Chapultepec" Value="0"></asp:ListItem>
                                <asp:ListItem Text="PRM Ecatepec" Value="1"></asp:ListItem>
                                <asp:ListItem Text="PRM Satélite" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtFoto">Fotografía:</label>
                        <div class="col-sm-7">
                            <asp:FileUpload runat="server" ID="txtFoto" CssClass="form-control" required="required" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"></div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <h3>Datos de acceso</h3>
                    <hr />
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtCorreo">Correo electronico:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control" required="required" TextMode="Email" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtContra1">Contraseña:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtContra1" CssClass="form-control" required="required" TextMode="Password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" title="La contraseña debe contener 6 caracteres, una mayúscula, una minúscula y al menos un número" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="txtContra2">Confirmar contraseña:</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" ID="txtContra2" CssClass="form-control" required="required" TextMode="Password" />
                        </div>
                    </div>
                    <center><asp:Button runat="server" ID="btnRegis" CssClass="btn btn-info btnRegis" OnClick="btnRegis_Click" Text="Registrar usuario" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" title="La contraseña debe contener 6 caracteres, una mayúscula, una minúscula y al menos un número" /></center>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>

