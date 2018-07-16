using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// clase  especifica para validar fechas y darles fromato
/// </summary>
public class fechas
{
    private String fecha;
    private String formato;
    private Boolean respuesta;
    private DateTime fechaBuena;

    public fechas()
    {
        fecha = "";
        formato = "";
        respuesta = false;
    }

    public fechas(string fecha, string formato)
    {
        this.fecha = fecha;
        this.formato = formato;
        respuesta = false;
    }

    public string Fecha { get => fecha; set => fecha = value; }
    public string Formato { get => formato; set => formato = value; }
    public bool Respuesta { get => respuesta;  }
    public DateTime FechaBuena { get => fechaBuena; set => fechaBuena = value; }

    public bool verifica()
    {
        return DateTime.TryParseExact(fecha, formato, null, DateTimeStyles.None, out fechaBuena);
    }

    public bool verifica(String fecha, String formato)
    {
        return DateTime.TryParseExact(fecha, formato, null, DateTimeStyles.None, out fechaBuena);
    }

}