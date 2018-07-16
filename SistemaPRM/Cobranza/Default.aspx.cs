using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Comisiones_Default : System.Web.UI.Page
{

    private int conDocumentos = 0;
    private creadorHtml cHtml = new creadorHtml();
    private email correo = new email();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkEnviaCorreos_Click(object sender, EventArgs e)
    {
        DatosSql sql = new DatosSql();
        DataTable tbl = sql.TraerDataTable("sp_GetPerson", 0, 0);

        foreach (DataRow dr in tbl.Rows)
        {
            if (conDocumentos < 200)
            {
                int idAgente = Convert.ToInt32(dr["Person_ID"].ToString());
                proximos(idAgente, dr);
                cancelacion(idAgente, dr);
            }
        }
    }


    private void cancelacion(int id, DataRow dr)
    {

        String tipo = "Asesor";
        String CorreoDonde = "lizbeth.cruz@prmseguros.com";
        String miMascara = "cobranza.danos1@prmseguros.com";
        int rol = Convert.ToInt32(dr["Role_ID"].ToString());
        if (rol == 1)
        {
            tipo = "Agente";
            CorreoDonde = "daniel.bravo@prmseguros.com";
            miMascara = "cobranza.danos2@prmseguros.com";
        }
        DatosSql sql = new DatosSql();
        DataTable tblCancelado = sql.TraerDataTable("sp_GetReceiptsCollection", id, 1);
        if (tblCancelado.Rows.Count > 0)
        {
            String[] contenedor = urlPDF(tblCancelado, rol);
            String CuerpoCorreo = cHtml.crear("Aviso de Cancelación por Falta de Pago", tipo, dr["Full_Name"].ToString(), tblCancelado, "Por medio de la presente, nos es grato saludarlo y a la vez informarle que de acuerdo a nuestros registros, la(s) póliza(s) a su cargo que se detalla(n) a continuación, han sido canceladas por falta de pago, por lo que sugerimos darle el seguimiento adecuado, a fin de evitar algún contratiempo al asegurado.\n");
            correo.conDocumentos(dr["Email"].ToString(), CuerpoCorreo, "RECIBOS CANCELADOS POR FALTA DE PAGO", contenedor, CorreoDonde);
        }


    }

    private void proximos(int id, DataRow dr)
    {
        DatosSql sql = new DatosSql();
        DataTable tblPendientes = sql.TraerDataTable("sp_GetReceiptsCollection", id);

        String tipo = "Asesor";
        String CorreoDonde = "lizbeth.cruz@prmseguros.com";
        String miMascara = "cobranza.danos1@prmseguros.com";
        if (dr["Role_ID"].ToString() == "1")
        {
            tipo = "Agente";
            CorreoDonde = "daniel.bravo@prmseguros.com";
            miMascara = "cobranza.danos2@prmseguros.com";
        }

        if (tblPendientes.Rows.Count > 0)
        {

            String CuerpoCorreo = "";

            creadorHtml cHtml = new creadorHtml();
            CuerpoCorreo = cHtml.crear("Aviso de Próximo Pago", tipo, dr["Full_Name"].ToString(), tblPendientes, "Por medio de la presente, nos es grato saludarlo y a la vez informarle que de acuerdo a nuestros registros, la(s) póliza(s) a su cargo que se detalla(n) a continuación, , están próximas a pago, por lo que sugerimos darle el seguimiento adecuado, a fin de evitar algún contratiempo al asegurado.\n");
            correo.conDocumentos(dr["Email"].ToString(), CuerpoCorreo, "RECIBOS PENDIENTES DE PAGO", Recibos(tblPendientes), CorreoDonde);
        }
    }


    private String[] urlPDF(DataTable tabla, int tipo)
    {
        String respuesta = "";
        foreach (DataRow dr in tabla.Rows)
        {
            respuesta += GenerarPDF(dr, tipo) + "!";
        }
        return respuesta.Split('!');
    }


    private String GenerarPDF(DataRow dr, int tipo)
    {

        string savePathPDF = Server.MapPath("~/Cobranza/pdf/");
        string fileNamePDF = "carta" + DateTime.Now.ToString("ddMMyyyyHHmmss-") + dr["poliza"].ToString() + ".pdf";
        string pathToCheckPDF = savePathPDF + fileNamePDF;
        DirectoryInfo di = Directory.CreateDirectory(savePathPDF);
        if (tipo == 1)
            GenerarPDF2(dr, pathToCheckPDF, "Ciudad de México a " + DateTime.Now.ToLongDateString(), "Agente ", "cobranza.danos2@prmseguros.com");
        else
            GenerarPDF2(dr, pathToCheckPDF, "Ciudad de México a " + DateTime.Now.ToLongDateString(), "Asesor ", "cobranza.danos1@prmseguros.com");

        return pathToCheckPDF;
    }

    private void GenerarPDF2(DataRow dr, String nombre, String fecha, String email, String tipo)
    {
        var reader = new PdfReader(Server.MapPath("~/Cobranza/pdf/cartaCobranza.pdf"));

        var outStream = new FileStream(nombre, FileMode.Create, FileAccess.Write);
        var stamper = new PdfStamper(reader, outStream);

        stamper.FormFlattening = true;

        AcroFields campos = stamper.AcroFields;

        campos.SetField("email", tipo);
        campos.SetField("fecha", fecha);
        campos.SetField("poliza", dr["poliza"].ToString());
        campos.SetField("recibo", dr["recibo"].ToString());
        campos.SetField("asegurado", dr["asegurado"].ToString());
        campos.SetField("tipo", email);

        stamper.Close();
        reader.Close();

    }


    private DataTable Recibos(DataTable dt)
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add("Documento");
        foreach (DataRow dr in dt.Rows)
        {
            tbl.Rows.Add(Server.MapPath("~/Emision/Receipts/" + dr["Documento"].ToString()));
        }

        return tbl;
    }

}