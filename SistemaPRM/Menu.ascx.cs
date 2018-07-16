using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            llenaMenuPrincipal();

        }
    }

    private void llenaMenuPrincipal()
    {
        DatosSql sql = new DatosSql();
        DataTable tbl = sql.TraerDataTable("sp_Catalogos", Convert.ToInt32(HttpContext.Current.Session["idUsuario"].ToString()), 14);

        lblMenu.Text = "<ul class='nav nav-stacked' id='accordion1'>";
        foreach (DataRow dr in tbl.Rows)
        {
            if (dr["padre"].ToString().Equals("0"))
            {
                lblMenu.Text += "<li class='panel' class='"+dr["nombre"].ToString().ToUpper()+"'><a data-toggle='collapse' data-parent='#accordion1' href='#collapse" + dr["idMenu"].ToString() + "'>" + dr["nombre"].ToString().ToUpper() + "</b></a>";
                lblMenu.Text += LlenaSubNiveles(dr["idMenu"].ToString(), tbl);
                lblMenu.Text += "</li>";
            }
        }
        lblMenu.Text += "</ul>";
    }
    private String LlenaSubNiveles(String IdPapa, DataTable tbl)
    {
        int i = 0;
        String SubMenu = "";

        SubMenu += "<ul id='collapse" + IdPapa + "' class='collapse nav nav-stacked'>";

        foreach (DataRow dr in tbl.Rows)
        {
            if (dr["padre"].ToString().Equals(IdPapa))
            {
                if (dr["direccion"].ToString() != "")
                {
                    SubMenu += "<li><a  data-toggle='collapse' data-parent='collapse" + IdPapa + "' class='liAnotherLvl' href='#collapse" + dr["idMenu"].ToString() + "' id='" + dr["direccion"].ToString() + "'>" + dr["nombre"].ToString() + "</a>";
                    SubMenu += LlenaSubNiveles(dr["idMenu"].ToString(), tbl);
                    SubMenu += "</li>";
                    i++;
                }
                else
                {
                    SubMenu += "<li><a  data-toggle='collapse' data-parent='collapse" + IdPapa + "' class='liAnotherLvlW' href='#collapse" + dr["idMenu"].ToString() + "' id='" + dr["direccion"].ToString() + "'>" + dr["nombre"].ToString() + "</a>";
                    SubMenu += LlenaSubNiveles(dr["idMenu"].ToString(), tbl);
                    SubMenu += "</li>";
                    i++;
                }

            }
        }

        SubMenu += "</ul>";

        if (i == 0)
        {
            SubMenu = "";
        }

        return SubMenu;
    }

}