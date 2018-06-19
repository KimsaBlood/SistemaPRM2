using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class persona
{
    private int idPersona;
    private String nombre;
    private String paterno;
    private String materno;
    private String fechaNacimiento;
    private String infoAdicional;
    private String rfc;
    private int estado;

    public persona()
    {
    }

    public persona(string nombre, string paterno, string materno, string fechaNacimiento, string infoAdicional, string rfc)
    {
        this.nombre = nombre;
        this.paterno = paterno;
        this.materno = materno;
        this.fechaNacimiento = fechaNacimiento;
        this.infoAdicional = infoAdicional;
        this.rfc = rfc;
    }

    public persona(string nombre, string paterno, string materno, string fechaNacimiento, string infoAdicional, string rfc, int estado)
    {
        this.nombre = nombre;
        this.paterno = paterno;
        this.materno = materno;
        this.fechaNacimiento = fechaNacimiento;
        this.infoAdicional = infoAdicional;
        this.rfc = rfc;
        this.estado = estado;
    }

    public persona(int idPersona, string nombre, string paterno, string materno, string fechaNacimiento, string infoAdicional, string rfc, int estado)
    {
        this.idPersona = idPersona;
        this.nombre = nombre;
        this.paterno = paterno;
        this.materno = materno;
        this.fechaNacimiento = fechaNacimiento;
        this.infoAdicional = infoAdicional;
        this.rfc = rfc;
        this.estado = estado;
    }

    public int IdPersona { get => idPersona; set => idPersona = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Paterno { get => paterno; set => paterno = value; }
    public string Materno { get => materno; set => materno = value; }
    public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    public string InfoAdicional { get => infoAdicional; set => infoAdicional = value; }
    public string Rfc { get => rfc; set => rfc = value; }
    public int Estado { get => estado; set => estado = value; }
}