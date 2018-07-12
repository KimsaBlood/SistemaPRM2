
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ordenTrabajo
{
    private int idOrdenTrabajo;
    private persona asesor;
    private int estadoNumero;
    private String estadoOrden;
    private persona cliente;
    private String folio;

    public ordenTrabajo()
    {
        
    }

    public int IdOrdenTrabajo { get => idOrdenTrabajo; set => idOrdenTrabajo = value; }
    public persona Asesor { get => asesor; set => asesor = value; }
    public int EstadoNumero { get => estadoNumero; set => estadoNumero = value; }
    public string EstadoOrden { get => estadoOrden; set => estadoOrden = value; }
    public persona Cliente { get => cliente; set => cliente = value; }
    public string Folio { get => folio; set => folio = value; }
}