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
        //cUsuarios obj = new cUsuarios(txtUsuario.Text, txtPsw.Text);

        //String Mensaje = obj.ValidaUsr();
        int i = 0;
        if (i != 1)
        {
            // Session.Add("Person_ID", obj.PersonID);
            Server.Transfer("Midas.aspx", true);


        }
        else
        {
            String alert= "$.alert({title: 'Oh!',theme: 'material',content: 'Correo electronico o contraseña incorrectos',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", alert, true);
        }
    }
}