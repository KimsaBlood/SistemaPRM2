using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for personnaSql
/// </summary>
public class personaDao:iDao<persona,int>
{
    private int idPersonaConsulta;
    private String msj;
    private DataTable tabla;
    private DatosSql sql = new DatosSql();
    private persona objeto = new persona();

    public personaDao()
    { 

    }

    private personaDao(persona objeto)
    {
        this.objeto = objeto;
    }

    public personaDao(int idPersonaConsulta)
    {
        this.idPersonaConsulta = idPersonaConsulta;
    }

    public personaDao(String idPersonaConsulta)
    {
        this.idPersonaConsulta = Convert.ToInt32(idPersonaConsulta);
    }


    public int IdPersonaConsulta { get => idPersonaConsulta; set => idPersonaConsulta = value; }
    public string Msj { get => msj; set => msj = value; }
    public DataTable Tabla { get => tabla; }
    public persona Objeto { get => objeto; set => objeto = value; }

    public bool cambios(int id, persona objeto)
    {

        tabla = sql.TraerDataTable("sp_Persona", idPersonaConsulta,1, objeto.IdPersona, objeto.Nombre, objeto.Materno, objeto.Paterno, objeto.FechaNacimiento, objeto.Rfc, objeto.InfoAdicional);
        idPersonaConsulta = 0;
        foreach (DataRow row in tabla.Rows)
        {
            msj = row["msj"].ToString();
            idPersonaConsulta = Convert.ToInt32(row["id"].ToString());
        }
        if (idPersonaConsulta > 0)
            return true;
        else
            return false;
        
    }

    public bool elimina(int id)
    {
        tabla = sql.TraerDataTable("sp_Persona", idPersonaConsulta, 2, id);
        idPersonaConsulta = 0;
        foreach (DataRow row in tabla.Rows)
        {
            msj = row["msj"].ToString();
            idPersonaConsulta = Convert.ToInt32(row["id"].ToString());
        }
        if (idPersonaConsulta > 0)
            return true;
        else
            return false;
    }

    public bool subir(persona objeto)
    {
        this.objeto = objeto;
        return subir();
    }

    public bool subir()
    {
        tabla = sql.TraerDataTable("sp_Persona", idPersonaConsulta, 0, 0, objeto.Nombre, objeto.Materno, objeto.Paterno, objeto.FechaNacimiento, objeto.Rfc, objeto.InfoAdicional);
        idPersonaConsulta = 0;
        foreach (DataRow row in tabla.Rows)
        {
            msj = row["msj"].ToString();
            idPersonaConsulta = Convert.ToInt32(row["id"].ToString());
        }
        if (idPersonaConsulta > 0)
            return true;
        else
            return false;
    }

    public IList<persona> traeTodos()
    {
        List<persona> respuesta = new List<persona>();
        tabla = sql.TraerDataTable("sp_Persona", idPersonaConsulta);
        foreach (DataRow row in tabla.Rows)
        {
            msj = row["msj"].ToString();
            idPersonaConsulta = Convert.ToInt32(row["id"].ToString());
        }
        return respuesta;
    }

    public persona traeUno(int id)
    {

        tabla = sql.TraerDataTable("sp_Persona", idPersonaConsulta);
        foreach (DataRow row in tabla.Rows)
        {
            objeto.IdPersona = Convert.ToInt32(row["id"].ToString());
        }
        return objeto;
    }

    public IList<persona> traeVarios(int id)
    {
        List<persona> respuesta = new List<persona>();
        tabla = sql.TraerDataTable("sp_Persona", idPersonaConsulta);
        foreach (DataRow row in tabla.Rows)
        {
            msj = row["msj"].ToString();
            idPersonaConsulta = Convert.ToInt32(row["id"].ToString());
        }
        return respuesta;
    }



}