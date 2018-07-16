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
        if (!IsPostBack)
        {
            if (Session["idUsuario"] != null)
            {
                Server.Transfer("Midas.aspx", true);
            }
        }
    }


    protected void btnLogin_Click1(object sender, EventArgs e)
    {
        cUsuarios obj = new cUsuarios(txtUsuario.Text, txtPsw.Text);

        String msj = obj.Ingresar();
        if (msj.Equals("Acceso correcto"))
        {
            Session.Add("idUsuario", obj.PersonID);
            Server.Transfer("Midas.aspx", true);
        }
        else if(msj.Equals("Contrase?a incorrecta"))
        {
            String alert= "$.alert({title: 'Oh!',theme: 'material',content: 'Contraseña incorrecta',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", alert, true);
        }
        else if (msj.Equals("Usuario incorrecto"))
        {
            String alert = "$.alert({title: 'Oh!',theme: 'material',content: 'Usuario inexistente',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", alert, true);
        }
    }
}