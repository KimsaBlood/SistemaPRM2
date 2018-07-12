using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Index : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnLogin_Click1(object sender, EventArgs e)
    {

        usuarioDao usuario = new usuarioDao();

       
        if (usuario.Acceso(txtUsuario.Text, txtPsw.Text))
        {
            Session.Add("idUsuario", usuario.Objeto.IdUsuario);
            Server.Transfer("Inicio/Default.aspx", true);
        }
        else
        {
            String alert = "$.alert({title: 'Oh!',theme: 'material',content: '"+usuario.Msj+"',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", alert, true);
        }
    }
}