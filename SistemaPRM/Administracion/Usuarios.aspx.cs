using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_Usuarios : System.Web.UI.Page
{
    private Extras herrmientas = new Extras();
    private string idUsuarioActual = "";
    private string mensaje = "";
    private usuarioDao usuDao;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["v"] != null)
            {
                switch (Convert.ToChar(Request.QueryString["v"].ToString()))
                {

                    case '0':
                        mvUsuarios.ActiveViewIndex = 0;
                        if(idUsuario.Text ==  "0" || idUsuario.Text == "")
                        {

                        }
                        else
                        {

                        }
                        rellenaDropDown();
                        break;

                    case '1':

                        mvUsuarios.ActiveViewIndex = 1;

                        break;
                }
            }
        }
    }

    protected void btnRegis_Click(object sender, EventArgs e)
    {
        idUsuarioActual = Session["idUsuario"].ToString();
        if (idUsuario.Text == "0" || idUsuario.Text == "")
        {
            nuevoUsuario();
        }
        else
        {
            modificaUsuario();
        }
    }
    protected void btnNuevoRol_Click(object sender, EventArgs e)
    {
        if (panelRol.FindControl("txtTipoUs").Visible == true && panelRol.FindControl("txtTipoUs1").Visible == false)
        {
            txtTipoUs.Enabled = false;
            lblTipoUs1.Visible = true;
            txtTipoUs1.Visible = true;
            txtTipoUs1.Items.Remove(txtTipoUs1.Items.FindByValue(txtTipoUs.SelectedValue));
        }else if(panelRol.FindControl("txtTipoUs1").Visible == true && panelRol.FindControl("txtTipoUs2").Visible == false)
        {
            txtTipoUs1.Enabled = false;
            lblTipoUs2.Visible = true;
            txtTipoUs2.Visible = true;
            txtTipoUs2.Items.Remove(txtTipoUs2.Items.FindByValue(txtTipoUs.SelectedValue));
            txtTipoUs2.Items.Remove(txtTipoUs2.Items.FindByValue(txtTipoUs1.SelectedValue));
        }
        else if (panelRol.FindControl("txtTipoUs2").Visible == true && panelRol.FindControl("txtTipoUs3").Visible == false)
        {
            txtTipoUs2.Enabled = false;
            lblTipoUs3.Visible = true;
            txtTipoUs3.Visible = true;
            txtTipoUs3.Items.Remove(txtTipoUs3.Items.FindByValue(txtTipoUs.SelectedValue));
            txtTipoUs3.Items.Remove(txtTipoUs3.Items.FindByValue(txtTipoUs1.SelectedValue));
            txtTipoUs3.Items.Remove(txtTipoUs3.Items.FindByValue(txtTipoUs2.SelectedValue));
        }
        else if (panelRol.FindControl("txtTipoUs3").Visible == true && panelRol.FindControl("txtTipoUs4").Visible == false)
        {
            txtTipoUs3.Enabled = false;
            lblTipoUs4.Visible = true;
            txtTipoUs4.Visible = true;
            txtTipoUs4.Items.Remove(txtTipoUs4.Items.FindByValue(txtTipoUs.SelectedValue));
            txtTipoUs4.Items.Remove(txtTipoUs4.Items.FindByValue(txtTipoUs1.SelectedValue));
            txtTipoUs4.Items.Remove(txtTipoUs4.Items.FindByValue(txtTipoUs2.SelectedValue));
            txtTipoUs4.Items.Remove(txtTipoUs4.Items.FindByValue(txtTipoUs3.SelectedValue));
        }
        else if (panelRol.FindControl("txtTipoUs4").Visible == true && panelRol.FindControl("txtTipoUs5").Visible == false)
        {
            txtTipoUs4.Enabled = false;
            lblTipoUs5.Visible = true;
            txtTipoUs5.Visible = true;
            txtTipoUs5.Items.Remove(txtTipoUs5.Items.FindByValue(txtTipoUs.SelectedValue));
            txtTipoUs5.Items.Remove(txtTipoUs5.Items.FindByValue(txtTipoUs1.SelectedValue));
            txtTipoUs5.Items.Remove(txtTipoUs5.Items.FindByValue(txtTipoUs2.SelectedValue));
            txtTipoUs5.Items.Remove(txtTipoUs5.Items.FindByValue(txtTipoUs3.SelectedValue));
            txtTipoUs5.Items.Remove(txtTipoUs5.Items.FindByValue(txtTipoUs4.SelectedValue));
        }
        else if (panelRol.FindControl("txtTipoUs5").Visible == true && panelRol.FindControl("txtTipoUs6").Visible == false)
        {
            txtTipoUs5.Enabled = false;
            lblTipoUs6.Visible = true;
            txtTipoUs6.Visible = true;
            txtTipoUs6.Items.Remove(txtTipoUs6.Items.FindByValue(txtTipoUs.SelectedValue));
            txtTipoUs6.Items.Remove(txtTipoUs6.Items.FindByValue(txtTipoUs1.SelectedValue));
            txtTipoUs6.Items.Remove(txtTipoUs6.Items.FindByValue(txtTipoUs2.SelectedValue));
            txtTipoUs6.Items.Remove(txtTipoUs6.Items.FindByValue(txtTipoUs3.SelectedValue));
            txtTipoUs6.Items.Remove(txtTipoUs6.Items.FindByValue(txtTipoUs4.SelectedValue));
            txtTipoUs6.Items.Remove(txtTipoUs6.Items.FindByValue(txtTipoUs5.SelectedValue));
        }
        else if (panelRol.FindControl("txtTipoUs6").Visible == true && panelRol.FindControl("txtTipoUs7").Visible == false)
        {
            txtTipoUs6.Enabled = false;
            lblTipoUs7.Visible = true;
            txtTipoUs7.Visible = true;
            txtTipoUs7.Items.Remove(txtTipoUs7.Items.FindByValue(txtTipoUs.SelectedValue));
            txtTipoUs7.Items.Remove(txtTipoUs7.Items.FindByValue(txtTipoUs1.SelectedValue));
            txtTipoUs7.Items.Remove(txtTipoUs7.Items.FindByValue(txtTipoUs2.SelectedValue));
            txtTipoUs7.Items.Remove(txtTipoUs7.Items.FindByValue(txtTipoUs3.SelectedValue));
            txtTipoUs7.Items.Remove(txtTipoUs7.Items.FindByValue(txtTipoUs4.SelectedValue));
            txtTipoUs7.Items.Remove(txtTipoUs7.Items.FindByValue(txtTipoUs5.SelectedValue));
            txtTipoUs7.Items.Remove(txtTipoUs7.Items.FindByValue(txtTipoUs6.SelectedValue));
        }
        else
        {
            String alert = "$.alert({title: 'Oh!',theme: 'material',content: 'Este usuario no puede tener mas roles',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", alert, true);
        }
    }   

    private void rellenaDropDown()
    {
        idUsuarioActual = Session["idUsuario"].ToString();

        txtTipoUs.DataSource = herrmientas.traeCatalogo(idUsuarioActual, 9);
        txtTipoUs.DataValueField = "idRol";
        txtTipoUs.DataTextField = "descripcionRol";
        txtTipoUs.DataBind();

        txtTipoUs1.DataSource = herrmientas.Tabla;
        txtTipoUs1.DataValueField = "idRol";
        txtTipoUs1.DataTextField = "descripcionRol";
        txtTipoUs1.DataBind();

        txtTipoUs2.DataSource = herrmientas.Tabla;
        txtTipoUs2.DataValueField = "idRol";
        txtTipoUs2.DataTextField = "descripcionRol";
        txtTipoUs2.DataBind();

        txtTipoUs3.DataSource = herrmientas.Tabla;
        txtTipoUs3.DataValueField = "idRol";
        txtTipoUs3.DataTextField = "descripcionRol";
        txtTipoUs3.DataBind();

        txtTipoUs4.DataSource = herrmientas.Tabla;
        txtTipoUs4.DataValueField = "idRol";
        txtTipoUs4.DataTextField = "descripcionRol";
        txtTipoUs4.DataBind();

        txtTipoUs5.DataSource = herrmientas.Tabla;
        txtTipoUs5.DataValueField = "idRol";
        txtTipoUs5.DataTextField = "descripcionRol";
        txtTipoUs5.DataBind();

        txtTipoUs6.DataSource = herrmientas.Tabla;
        txtTipoUs6.DataValueField = "idRol";
        txtTipoUs6.DataTextField = "descripcionRol";
        txtTipoUs6.DataBind();

        txtTipoUs7.DataSource = herrmientas.Tabla;
        txtTipoUs7.DataValueField = "idRol";
        txtTipoUs7.DataTextField = "descripcionRol";
        txtTipoUs7.DataBind();

        txtOficina.DataSource = herrmientas.traeCatalogo(idUsuarioActual, 1);
        txtOficina.DataValueField = "idOficina";
        txtOficina.DataTextField = "descripcionOficina";
        txtOficina.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        idUsuarioActual = Session["idUsuario"].ToString();
        usuDao = new usuarioDao(idUsuarioActual);
        usuDao.traeVarios(txtBusqueda.Text);
        tbl_Usuario.DataSource = usuDao.Tabla;
        tbl_Usuario.DataBind();
    }

    private void nuevoUsuario()
    {
        if (txtContra1.Text != "" && txtContra2.Text != "")
        {
            if (txtContra1.Text == txtContra2.Text)
            {
                if (System.IO.Path.GetExtension(txtFoto.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(txtFoto.FileName).ToLower() == ".png" || System.IO.Path.GetExtension(txtFoto.FileName).ToLower() == ".gif")
                {
                    int[] roles = getRoles();
                    usuarioDao usuDao = new usuarioDao(idUsuarioActual);
                    usuario contenedorUsuario = new usuario(0, txtnombre.Text, txtApPa.Text, txtApMa.Text, "", "", txtRFC.Text, txtTelefono.Text, txtCorreo.Text, roles, Convert.ToInt32(txtOficina.SelectedValue), txtIngreso.Text, txtContra1.Text, txtCorreo.Text, txtFoto.FileName);
                    if (usuDao.subir(contenedorUsuario))
                    {
                        mensaje = "$.alert({title: 'Oh!',theme: 'material',content: '" + usuDao.Msj + "',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
                        idUsuario.Text = usuDao.Objeto.IdUsuario + "";
                    }
                    else
                    {
                        mensaje = "$.alert({title: 'Oh!',theme: 'material',content: '" + usuDao.Msj + "',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", mensaje, true);
                }
                else
                {
                    mensaje = "$.alert({title: 'Oh!',theme: 'material',content: 'No es un archivo de imagen válido',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", mensaje, true);
                }
            }
            else
            {
                mensaje = "$.alert({title: 'Oh!',theme: 'material',content: 'Las contraseñas no coinciden',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", mensaje, true);
            }
        }
        else
        {
            mensaje = "$.alert({title: 'Oh!',theme: 'material',content: 'Las contraseñas no son validas.',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", mensaje, true);
        }
    }

    private void modificaUsuario()
    {

    }

    private int[] getRoles()
    {
        int[] roles = null;
        if (txtTipoUs.Visible && txtTipoUs1.Visible && txtTipoUs2.Visible && txtTipoUs3.Visible && txtTipoUs4.Visible && txtTipoUs5.Visible && txtTipoUs6.Visible && txtTipoUs7.Visible)
        {
            roles = new int[8];
            roles[0] = Convert.ToInt32(txtTipoUs.SelectedValue);
            roles[1] = Convert.ToInt32(txtTipoUs1.SelectedValue);
            roles[2] = Convert.ToInt32(txtTipoUs2.SelectedValue);
            roles[3] = Convert.ToInt32(txtTipoUs3.SelectedValue);
            roles[4] = Convert.ToInt32(txtTipoUs4.SelectedValue);
            roles[5] = Convert.ToInt32(txtTipoUs5.SelectedValue);
            roles[6] = Convert.ToInt32(txtTipoUs6.SelectedValue);
            roles[7] = Convert.ToInt32(txtTipoUs7.SelectedValue);
        }
        else if (txtTipoUs.Visible && txtTipoUs1.Visible && txtTipoUs2.Visible && txtTipoUs3.Visible && txtTipoUs4.Visible && txtTipoUs5.Visible && txtTipoUs6.Visible && !txtTipoUs7.Visible)
        {
            roles = new int[7];
            roles[0] = Convert.ToInt32(txtTipoUs.SelectedValue);
            roles[1] = Convert.ToInt32(txtTipoUs1.SelectedValue);
            roles[2] = Convert.ToInt32(txtTipoUs2.SelectedValue);
            roles[3] = Convert.ToInt32(txtTipoUs3.SelectedValue);
            roles[4] = Convert.ToInt32(txtTipoUs4.SelectedValue);
            roles[5] = Convert.ToInt32(txtTipoUs5.SelectedValue);
            roles[6] = Convert.ToInt32(txtTipoUs6.SelectedValue);
        }
        else if (txtTipoUs.Visible && txtTipoUs1.Visible && txtTipoUs2.Visible && txtTipoUs3.Visible && txtTipoUs4.Visible && txtTipoUs5.Visible && !txtTipoUs6.Visible && !txtTipoUs7.Visible)
        {
            roles = new int[6];
            roles[0] = Convert.ToInt32(txtTipoUs.SelectedValue);
            roles[1] = Convert.ToInt32(txtTipoUs1.SelectedValue);
            roles[2] = Convert.ToInt32(txtTipoUs2.SelectedValue);
            roles[3] = Convert.ToInt32(txtTipoUs3.SelectedValue);
            roles[4] = Convert.ToInt32(txtTipoUs4.SelectedValue);
            roles[5] = Convert.ToInt32(txtTipoUs5.SelectedValue);
        }
        else if (txtTipoUs.Visible && txtTipoUs1.Visible && txtTipoUs2.Visible && txtTipoUs3.Visible && txtTipoUs4.Visible && !txtTipoUs5.Visible && !txtTipoUs6.Visible && !txtTipoUs7.Visible)
        {
            roles = new int[5];
            roles[0] = Convert.ToInt32(txtTipoUs.SelectedValue);
            roles[1] = Convert.ToInt32(txtTipoUs1.SelectedValue);
            roles[2] = Convert.ToInt32(txtTipoUs2.SelectedValue);
            roles[3] = Convert.ToInt32(txtTipoUs3.SelectedValue);
            roles[4] = Convert.ToInt32(txtTipoUs4.SelectedValue);
        }
        else if (txtTipoUs.Visible && txtTipoUs1.Visible && txtTipoUs2.Visible && txtTipoUs3.Visible && !txtTipoUs4.Visible && !txtTipoUs5.Visible && !txtTipoUs6.Visible && !txtTipoUs7.Visible)
        {
            roles = new int[4];
            roles[0] = Convert.ToInt32(txtTipoUs.SelectedValue);
            roles[1] = Convert.ToInt32(txtTipoUs1.SelectedValue);
            roles[2] = Convert.ToInt32(txtTipoUs2.SelectedValue);
            roles[3] = Convert.ToInt32(txtTipoUs3.SelectedValue);
        }
        else if (txtTipoUs.Visible && txtTipoUs1.Visible && txtTipoUs2.Visible && !txtTipoUs3.Visible && !txtTipoUs4.Visible && !txtTipoUs5.Visible && !txtTipoUs6.Visible && !txtTipoUs7.Visible)
        {
            roles = new int[3];
            roles[0] = Convert.ToInt32(txtTipoUs.SelectedValue);
            roles[1] = Convert.ToInt32(txtTipoUs1.SelectedValue);
            roles[2] = Convert.ToInt32(txtTipoUs2.SelectedValue);
        }
        else if (txtTipoUs.Visible && txtTipoUs1.Visible && !txtTipoUs2.Visible && !txtTipoUs3.Visible && !txtTipoUs4.Visible && !txtTipoUs5.Visible && !txtTipoUs6.Visible && !txtTipoUs7.Visible)
        {
            roles = new int[2];
            roles[0] = Convert.ToInt32(txtTipoUs.SelectedValue);
            roles[1] = Convert.ToInt32(txtTipoUs1.SelectedValue);
        }
        else if (txtTipoUs.Visible && !txtTipoUs1.Visible && !txtTipoUs2.Visible && !txtTipoUs3.Visible && !txtTipoUs4.Visible && !txtTipoUs5.Visible && !txtTipoUs6.Visible && !txtTipoUs7.Visible)
        {
            roles = new int[1];
            roles[0] = Convert.ToInt32(txtTipoUs.SelectedValue);
        }
        return roles;
    }

    private void traeInfoUsuario()
    {
        txtRFC.Text = usuDao.Objeto.Rfc;
        txtTelefono.Text = usuDao.Objeto.Telefono;
        txtCorreo.Text = usuDao.Objeto.Email;
        //roles;
        //  Convert.ToInt32(txtOficina.SelectedValue, 
        txtIngreso.Text = usuDao.Objeto.FechaIngreso;
        txtnombre.Text = usuDao.Objeto.Nombre;
        txtApMa.Text = usuDao.Objeto.Materno;
        txtApPa.Text = usuDao.Objeto.Paterno;
        txtCorreo.Text = usuDao.Objeto.Email;
    }
}