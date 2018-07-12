using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for creadorHtml
/// </summary>
public class creadorHtml
{
    private String titulo;
    private String contenido;
    private String otro;
    private String cabeza;
    private String cuerpo;

    public creadorHtml()
    {
        cabeza = "        <title>Cobranza Midas</title>\n" +
            "        <meta charset='UTF-8'>\n" +
            "        <meta name='viewport' content='width=device-width, initial-scale=1.0'>\n" +
            "        <style>\n" +
            "            table {\n" +
            "                border: 1px solid #3F7FBF;\n" +
            "                border-collapse: collapse;\n" +
            "                text-align: center;\n" +
            "                width: 100%;\n" +
            "            }\n" +
            "            tr{\n" +
            "               border: 1px solid #3F7FBF;\n" +
            "            }\n" +
            "            tr:nth-child(even){\n" +
            "                background-color: #f2f2f2;\n" +
            "            }\n" +
            "            th{\n" +
            "                padding:10px;\n" +
            "                color: white;\n" +
            "            }\n" +
            "            td{\n" +
            "                padding: 5px;\n" +
            "                border: 1px solid #3F7FBF;\n" +
            "            }\n" +
            "            div{\n" +
            "                display: inline-block;\n" +
            "                width: 100%;\n" +
            "                height: auto;\n" +
            "                padding-top: 15px;\n" +
            "                font-family: 'Helvetica Neue', 'Helvetica', 'Arial', sans-serif;\n" +
            "            }\n" +
            "        </style>\n";

    }

    public String crear(String titulo, String tipo, String nombre, DataTable tabla, String cuerpo)
    {
        return "\n" +
            " <head>\n" + cabeza + "</head>\n" +
            " <body>\n" +
            "        <div style='width: 95%;margin-left: 2.5%;'>\n" +
            "            <div style='text-align: center'><h2>"+titulo+"</h2></div>\n" +
            "            <div style='text-align: right;'><h3>Ciudad de México a " + DateTime.Now.ToLongDateString() + "</h3></div>\n" +
            "            <div style='text-align: left'><h3>Estimado " + tipo + ": " + nombre.ToUpper() + "</h3> </div>\n" +
            "            <div>\n" +
            "                <div>\n" +
            "                    <p>\n" +
            cuerpo+
            "                    </p>\n" +
            "                </div>\n" +
                            Correo(tabla) +
            "            </div>\n" +
            "            <div style='text-align: center'>\n" +
            "                <h3>ATENTAMENTE<br>\n" +
            "                    Promo Risk México<br>\n" +
            "                Cobranza MIDAS</h3>\n" +
            "            </div>\n" +
            "        </div>\n" +
            "</body>\n"; ;
    }

    private String Correo(DataTable dt)
    {
        String html = "<table >";
        //add header row
        html += "<tr style='background-color:#3F7FBF;  padding-top: 10px; padding-left: 10px; padding-right: 10px;font-weight: 500; letter-spacing: 110%;'>\n";
        for (int i = 0; i < dt.Columns.Count - 1; i++)
            html += "<th>" + dt.Columns[i].ColumnName + "</th>";
        html += "</tr>";
        //add rows
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            html += "<tr >";
            for (int j = 0; j < dt.Columns.Count - 1; j++)
                html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        return html;
    }


}