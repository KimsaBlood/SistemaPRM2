using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Comisiones_Default : System.Web.UI.Page
{
    private string idUsuarioConsulta = "";
    private Extras herramientas = new Extras();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["v"] != null)
                {
                    switch (Convert.ToChar(Request.QueryString["v"].ToString()))
                    {
                        case '0':
                            controlador.ActiveViewIndex = 0;

                            rellenaDropDown();
                            break;

                        case '1':


                            break;
                    }
                }
            }
        }
    }

    private void rellenaDropDown()
    {
        ddlOrdenTrabajo.DataSource = herramientas.traeCatalogo(idUsuarioConsulta, 17);
        ddlOrdenTrabajo.DataValueField = "idTipoOrdenTrabajo";
        ddlOrdenTrabajo.DataTextField = "descripcion";
        ddlOrdenTrabajo.DataBind();

        ddlRamo.DataSource = herramientas.traeCatalogo(idUsuarioConsulta, 18, 0);
        ddlRamo.DataValueField = "idRama";
        ddlRamo.DataTextField = "descripcionRama";
        ddlRamo.DataBind();

        if (rama.Text != "" && rama.Text != "0")
        {
            ddlRamo.SelectedValue = rama.Text;

            ddlSubRamo.Enabled = true;
            ddlSubRamo.DataSource = herramientas.traeCatalogo(idUsuarioConsulta, 18, Convert.ToInt32(rama.Text));
            ddlSubRamo.DataValueField = "idRama";
            ddlSubRamo.DataTextField = "descripcionRama";
            ddlSubRamo.DataBind();

            if (subRamo.Text != "" && subRamo.Text != "0")
            {
                ddlSubRamo.SelectedValue = rama.Text;
                ddlCOnducto.Enabled = true;

                 if(conducto.Text != "" && conducto.Text != "0")
                 {
                    ddlSolicito.Enabled = true;

                    ddlSolicito.DataSource = herramientas.traeCatalogo(idUsuarioConsulta, 15, Convert.ToInt32(ddlCOnducto.Text));
                    ddlSolicito.DataValueField = "idUsuario";
                    ddlSolicito.DataTextField = "nombreCompleto";
                    ddlSolicito.DataBind();
                }
                else
                {
                    ddlSolicito.Enabled = true;
                }
            }
            else
            {
                ddlSolicito.Enabled = false;
            }
        }
        else
        {
            ddlSubRamo.Enabled = false;
            ddlCOnducto.Enabled = false;
            ddlSolicito.Enabled = false;
        }
    }

    protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
    {
        rama.Text = ddlRamo.SelectedValue;
        rellenaDropDown();
    }

    protected void ddlOrdenTrabajo_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void ddlSubRamo_SelectedIndexChanged(object sender, EventArgs e)
    {
        subRamo.Text = ddlSubRamo.SelectedValue;
        rellenaDropDown();
    }

    protected void ddlCOnducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        conducto.Text = ddlCOnducto.SelectedValue;
        rellenaDropDown();
    }
}