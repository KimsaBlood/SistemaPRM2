<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Index"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" runat="server" media="screen" href="~/css/Index.css" />
    <link rel="stylesheet" runat="server" media="screen" href="~/css/miTema.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>
    
    <script>

        function myFunction() {
            if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) //IF IE > 10
            {
                alert('Se recomienda abrir el sitio en cualquier otro navegador para que funcionen todos los complementos');
            }

        }
    </script>
    <style>
        
    </style>
    <title>::.PRM.::</title>
</head>
<body onload="myFunction()">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-3 col-xs-1"></div>
            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-10">
                <img src="<%=Page.ResolveUrl("~/images/PRM.png") %>" class="headImg shadowfilter" />
                <h2 class="headTitle">Bienvenido a <b>MIDAS</b></h2>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-3 col-xs-1"></div> 
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-3 col-xs-1"></div>
            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-10">
                <div class="panel panel-info">
                    <div class="panel-heading">Inicio de sesión</div>
                        <div class="panel-body">
                            <form id="form1" runat="server">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Correo electronico" required="required"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtPsw" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña" required="required"></asp:TextBox>
                                </div>
                                <div class="input-group rememberMe">
                                    <label><asp:CheckBox ID="chRemember" runat="server" CssClass="checkRemember"/>Recordar contraseña<asp:Button ID="btnLogin" runat="server" CssClass="btn btn-info btnLogin pull-right" OnClick="btnLogin_Click1" Text="Ingresar"/></label>
                                </div>
                            </form>
                        </div>  
                    <div class="panel-footer pForgotten"><p>¿Olvido su contraseña o tiene problemas para ingresar?</p></div>
                </div>
            </div>
        <div class="col-lg-4 col-md-4 col-sm-3 col-xs-1"></div> 
    </div>
</div>
</body>
</html>
