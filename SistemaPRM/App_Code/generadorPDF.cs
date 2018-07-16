using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for generadorPDF
/// </summary>
public class generadorPDF
{
    #region contenido

    private String nombreArchivo;
    private String direccionGuardar;
    private String mascara;
    private String titulo;
    private String server;

    private iTextSharp.text.Font titulos = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 11, iTextSharp.text.Font.BOLD);
    private iTextSharp.text.Font encabezados = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD);
    private iTextSharp.text.Font normal = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL);

    private PdfWriter writer;
    private Document documento;
    private MemoryStream output = new MemoryStream();

    public string NombreArchivo { get => nombreArchivo; set => nombreArchivo = value; }
    public string DireccionGuardar { get => direccionGuardar; set => direccionGuardar = value; }
    public string Mascara { get => mascara; set => mascara = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public Font Titulos { get => titulos; set => titulos = value; }
    public Font Encabezados { get => encabezados; set => encabezados = value; }
    public Font Normal { get => normal; set => normal = value; }
    public string Server { get => server; set => server = value; }
    #endregion
    #region metodos

    public generadorPDF(bool lado)
    {
        documento = new Document();
        if (lado)
        {
            //vertical
            documento = new Document();
            documento.SetPageSize(iTextSharp.text.PageSize.LETTER);
        }
        else {
            //horizontal
            documento = new Document();
            documento.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
        }
        writer = PdfWriter.GetInstance(documento, output);
        documento.Open();
    }


    private byte[] generaPDFVertical(DataTable tabla)
    {
        return output.ToArray();
    }

    private byte[] generaPDFHorizontal(DataTable tabla)
    {

        return output.ToArray();
    }

    public void conLogo(bool lado)
    {
        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(server+"../images/PRM.png");
        img.ScaleToFit(95F, 75F);
        
        if (lado)
        {
            //derecha
            img.SetAbsolutePosition((documento.Right - 80), ((documento.Top) - 20));
        }
        else
        {
            img.SetAbsolutePosition((documento.Right - 80), ((documento.Top) - 20));

        }
        documento.Add(img);
    }

    #endregion

}