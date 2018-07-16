using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_Usuarios : System.Web.UI.Page
{
    DropDownList rolNew0 = new DropDownList();
    DropDownList rolNew1 = new DropDownList();
    DropDownList rolNew2 = new DropDownList();
    DropDownList rolNew3 = new DropDownList();
    DropDownList rolNew4 = new DropDownList();
    DropDownList rolNew5 = new DropDownList();
    DropDownList rolNew6 = new DropDownList();
    DropDownList rolNew7 = new DropDownList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

    protected void btnRegis_Click(object sender, EventArgs e)
    {
        if (txtContra1.Text == txtContra2.Text)
        {
            if (System.IO.Path.GetExtension(txtFoto.FileName).ToLower() == ".jpg"|| System.IO.Path.GetExtension(txtFoto.FileName).ToLower() == ".png"|| System.IO.Path.GetExtension(txtFoto.FileName).ToLower() == ".gif")
            {
                int[] roles=null;
                if (txtTipoUs.Visible&& txtTipoUs1.Visible&& txtTipoUs2.Visible&& txtTipoUs3.Visible&& txtTipoUs4.Visible&& txtTipoUs5.Visible&& txtTipoUs6.Visible&& txtTipoUs7.Visible)
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
                }else if (txtTipoUs.Visible && txtTipoUs1.Visible && txtTipoUs2.Visible && txtTipoUs3.Visible && txtTipoUs4.Visible && txtTipoUs5.Visible && txtTipoUs6.Visible && !txtTipoUs7.Visible)
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
                cUsuarios obj = new cUsuarios(0, txtnombre.Text, txtApPa.Text, txtApMa.Text, txtRFC.Text, txtTelefono.Text, txtCorreo.Text, roles, Convert.ToInt32(txtOficina.SelectedValue), txtIngreso.Text, txtContra1.Text, txtFoto.FileName,1);
                obj.GuardaUsuario(Convert.ToInt32(Session["idUsuario"]));
            }
            else
            {
                String alert = "$.alert({title: 'Oh!',theme: 'material',content: 'No es un archivo de imagen válido',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", alert, true);
            }
        }
        else
        {
            String alert = "$.alert({title: 'Oh!',theme: 'material',content: 'Las contraseñas no coinciden',buttons:{cerrar: {text:'Cerrar',btnClass:'btn-info'}}}); ";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", alert, true);
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
}