using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Midas : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.Session["idUsuario"] != null)
            {
                lblFecha.Text = DateTime.Now.ToLongDateString();
                LlenaDatosPersonales();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }

    private void LlenaDatosPersonales()
    {
       int PersonaID = Convert.ToInt32(HttpContext.Current.Session["idUsuario"].ToString());
       usuarioDao cu = new usuarioDao(PersonaID);
       cu.traeUno(PersonaID);
       lblNombre.Text = cu.Objeto.Nombre;
       imgFoto.ImageUrl = "Administracion/user/photo/" + cu.Objeto.Foto;
        
    }
    protected void lnkCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Default.aspx");
    }
}
