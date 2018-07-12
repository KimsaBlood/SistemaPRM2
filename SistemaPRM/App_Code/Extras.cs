using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.IO;
using System.Drawing;
using System.Globalization;
/// <summary>
/// Descripción breve de Extras
/// </summary> 
public class Extras
{
    private DatosSql sql = new DatosSql();
    private DateTime  fechaFinal;
    private DataTable tabla;

    public DataTable Tabla { get => tabla; set => tabla = value; }

    public Extras()
    {

    }

   public String EscribeExcel(String Ruta, DataTable tbl)
    {
        FileInfo newFile = new FileInfo(Ruta);
        if (newFile.Exists)
        {
            newFile.Delete();  // ensures we create a new workbook
            newFile = new FileInfo(Ruta);
        }
        using (ExcelPackage package = new ExcelPackage(newFile))
        {
            // add a new worksheet to the empty workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Correos Newsletter");

            int columna = 0;
            for (int i = 0; i < tbl.Columns.Count; i++)
            {
                columna++;
                worksheet.Cells[1, columna].Value = tbl.Columns[i].ColumnName;

            }
            int fila = 2;
            foreach (DataRow dr in tbl.Rows)
            {
                columna = 0;
                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    columna++;
                    worksheet.Cells[fila, columna].Value = dr[i].ToString();

                }
                fila++;
            }

            //Formato
            using (var range = worksheet.Cells[1, 1, 1, columna])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(32, 108, 174));
                range.Style.Font.Color.SetColor(Color.White);
            }
            worksheet.Cells.AutoFitColumns(0);
            package.Save();

        }
        return newFile.Name;
    }

    public String encriptaB64(string texto)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(texto);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public String decriptaB64(string textoEncriptado)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(textoEncriptado);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }


    public string ConvierteMD5(string str)
    {
        MD5 md5 = MD5CryptoServiceProvider.Create();
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] stream = null;
        StringBuilder sb = new StringBuilder();

        stream = md5.ComputeHash(encoding.GetBytes(str));
        for (int i = 0; i < stream.Length; i++)
            sb.AppendFormat("{0:x2}", stream[i]);
        return sb.ToString();

    }


    public String EscribeExcel(String Ruta, DataTable tbl, String Libro)
    {
        FileInfo newFile = new FileInfo(Ruta);
        if (newFile.Exists)
        {
            newFile.Delete();  // ensures we create a new workbook
            newFile = new FileInfo(Ruta);
        }
        using (ExcelPackage package = new ExcelPackage(newFile))
        {
            // add a new worksheet to the empty workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(Libro);

            int columna = 0;
            for (int i = 0; i < tbl.Columns.Count; i++)
            {
                columna++;
                worksheet.Cells[1, columna].Value = tbl.Columns[i].ColumnName;

            }
            int fila = 2;
            foreach (DataRow dr in tbl.Rows)
            {
                columna = 0;
                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    columna++;
                    worksheet.Cells[fila, columna].Value = dr[i].ToString();

                }
                fila++;
            }

            //Formato
            using (var range = worksheet.Cells[1, 1, 1, columna])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(32, 108, 174));
                range.Style.Font.Color.SetColor(Color.White);
            }
            worksheet.Cells.AutoFitColumns(0);
            package.Save();

        }
        return newFile.Name;
    }

    public DataTable traeCatalogo(string personaConsulta, int opcion, int otro, int otromas)
    {
        tabla = sql.TraerDataTable("sp_Catalogos", personaConsulta, opcion,otro,otromas);
        return tabla;
    }

    public DataTable traeCatalogo(string personaConsulta, int opcion, int otro)
    {
        tabla = sql.TraerDataTable("sp_Catalogos", personaConsulta, opcion,otro);
        return tabla;
    }

    public DataTable traeCatalogo(string personaConsulta, int opcion)
    {
        tabla = sql.TraerDataTable("sp_Catalogos", personaConsulta, opcion);
        return tabla;
    }

    public DataTable traeCatalogo(int personaConsulta, int opcion)
    {
        tabla  = sql.TraerDataTable("sp_Catalogos", personaConsulta, opcion);
        return tabla;
    }

    public bool validaFecha(String fecha, String pattern)
    {
       return DateTime.TryParseExact(fecha, pattern, CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AdjustToUniversal,out fechaFinal);
        
    }
}