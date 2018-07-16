using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for usuarioDAO
/// </summary>
public class usuarioDao:iDao<usuario,int>
{
    private int idPersonaConsulta;
    private String msj;
    private DataTable tabla;
    private DatosSql sql = new DatosSql();
    private usuario objeto = new usuario();
    private Extras herramientas = new Extras();

    public usuarioDao()
    {
        objeto = new usuario();
    }

    public usuarioDao(int idPersonaConsulta)
    {
        this.idPersonaConsulta = idPersonaConsulta;
    }

    public usuarioDao(String idPersonaConsulta)
    {
        this.idPersonaConsulta = Convert.ToInt32(idPersonaConsulta);
    }

    public usuarioDao(int idPersonaConsulta, usuario objeto)
    {
        this.objeto = objeto;
        this.idPersonaConsulta = idPersonaConsulta;
    }

    public usuarioDao(usuario objeto)
    {
        this.objeto = objeto;
    }

     public bool Acceso(String email,String psw)
     {
        tabla = sql.TraerDataTable("sp_Acceso", email, herramientas.ConvierteMD5(psw));
        foreach (DataRow fila in tabla.Rows)
        {
            objeto.IdUsuario = Convert.ToInt32(fila["idUsuario"].ToString());
            msj = fila["msj"].ToString();
        }
        return (objeto.IdUsuario > 0);
     }

    public int IdPersonaConsulta { get => idPersonaConsulta; set => idPersonaConsulta = value; }
    public string Msj { get => msj; set => msj = value; }
    public DataTable Tabla { get => tabla; }
    public usuario Objeto { get => objeto; set => objeto = value; }

    public bool cambios(int id, usuario objeto)
    {
        tabla = sql.TraerDataTable("sp_Usuario", idPersonaConsulta, 1, objeto.IdUsuario, objeto.Email, objeto.Telefono, 1, objeto.Rfc, objeto.Nombre, objeto.Materno, objeto.Paterno, objeto.FechaNacimiento, objeto.Password, objeto.Usuario, objeto.InfoAdicional, objeto.Foto, objeto.Oficina);
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
        tabla = sql.TraerDataTable("sp_Usuario", idPersonaConsulta, 2, id);
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

    public bool subir(usuario objeto)
    {
        this.objeto = objeto;
        return subir();
    }

    private bool validaEmail(String valida)
    {
        bool respuesta = false;
        String[] validar = valida.Split('{');
        String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        foreach (String email in validar)
        {
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    respuesta = true;
                }
                else
                {
                    msj += "<li>El formato del Correo Electronico no es valido</li>";
                    return false;
                }
            }
            else
            {
                msj += "<li>El formato del Correo Electronico no es valido</li>";
                return false;
            }
        }

        return respuesta;
    }

    public bool subir()
    {
        if (objeto.Nombre != "" )
        {
            if (validaEmail(objeto.Email))
            {
                if (objeto.FechaIngreso == "")
                {
                    tabla = sql.TraerDataTable("sp_Usuario", idPersonaConsulta, 0, 0, objeto.Email, objeto.Telefono, 1, objeto.Rfc, objeto.Nombre, objeto.Materno, objeto.Paterno, objeto.FechaNacimiento,herramientas.ConvierteMD5(objeto.Password), objeto.Usuario, objeto.InfoAdicional,objeto.FechaIngreso, objeto.Foto, objeto.Oficina);
                    objeto.IdUsuario = 0;
                    foreach (DataRow row in tabla.Rows)
                    {
                        msj = row["msj"].ToString();
                        objeto.IdUsuario = Convert.ToInt32(row["id"].ToString());
                    }
                    if (objeto.IdUsuario > 0)
                    {
                        tabla = sql.TraerDataTable("sp_AgregaRoles", idPersonaConsulta, objeto.IdUsuario,roles(objeto.Roles));
                        foreach (DataRow row in tabla.Rows)
                        {
                            msj = row["msj"].ToString();
                            IdPersonaConsulta = Convert.ToInt32(row["valido"].ToString());
                        }
                        return (idPersonaConsulta == 1);
                    }
                    else
                        return false;
                }
                else
                {
                    if (herramientas.validaFecha(objeto.FechaIngreso, "dd/MM/yyyy"))
                    {
                        tabla = sql.TraerDataTable("sp_Usuario", idPersonaConsulta, 0, 0, objeto.Email, objeto.Telefono, 1, objeto.Rfc, objeto.Nombre, objeto.Materno, objeto.Paterno, objeto.FechaNacimiento, objeto.Password, objeto.Usuario, objeto.InfoAdicional, objeto.Foto, objeto.Oficina);
                        objeto.IdUsuario = 0;
                        foreach (DataRow row in tabla.Rows)
                        {
                            msj = row["msj"].ToString();
                            objeto.IdUsuario = Convert.ToInt32(row["id"].ToString());
                        }
                        if (objeto.IdUsuario > 0)
                        {
                            tabla = sql.TraerDataTable("sp_AgregaRoles", idPersonaConsulta, roles(objeto.Roles));
                            foreach (DataRow row in tabla.Rows)
                            {
                                msj = row["msj"].ToString();
                                IdPersonaConsulta = Convert.ToInt32(row["valido"].ToString());
                            }
                            return (idPersonaConsulta == 1);
                        }
                        else
                            return false;
                    }
                    else
                    {
                        msj = "La fecha de ingreso no es valida.";
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }      
        }
        else
        {
            msj = "Se ocupa un nombre para continuar.";
            return false;
        } 
    }

    private String roles(int[] rol )
    {
        string resultado = "";
        foreach(int numero in rol)
        {
            resultado += numero + ","; 
        }
        return resultado;
    }

    public IList<usuario> traeTodos()
    {
        List<usuario> respuesta = new List<usuario>();
        tabla = sql.TraerDataTable("sp_Usuario", idPersonaConsulta);
        foreach (DataRow row in tabla.Rows)
        {
            msj = row["msj"].ToString();
            idPersonaConsulta = Convert.ToInt32(row["id"].ToString());
        }
        return respuesta;
    }

    public usuario traeUno(int id)
    {
        objeto.IdUsuario = id;
        tabla = sql.TraerDataTable("sp_Usuario", idPersonaConsulta, 3 , objeto.IdUsuario);
        foreach (DataRow row in tabla.Rows)
        {
            objeto.IdPersona = id;
            objeto.Nombre = row["nombreCompleto"].ToString();
            objeto.Foto = row["foto"].ToString();
            objeto.Telefono = row["telefono"].ToString();
            objeto.Email = row["email"].ToString();
            objeto.Rfc = row["rfc"].ToString();
        }
        return objeto;
    }
    public IList<usuario> traeVarios(int id)
    {
        List<usuario> respuesta = new List<usuario>();
        tabla = sql.TraerDataTable("sp_Usuario", idPersonaConsulta, 4 , id);
        foreach (DataRow row in tabla.Rows)
        {
            objeto.IdPersona = Convert.ToInt16(row["idUsuario"].ToString());
            objeto.Nombre = row["nombreCompleto"].ToString();
            objeto.Foto = row["foto"].ToString();
            objeto.Telefono = row["telefono"].ToString();
            objeto.Email = row["email"].ToString();
            objeto.Rfc = row["rfc"].ToString();
        }
        return respuesta;
    }
    public IList<usuario> traeVarios(String id)
    {
        List<usuario> respuesta = new List<usuario>();
        tabla = sql.TraerDataTable("sp_Usuario", idPersonaConsulta, 5,0, id);
        foreach (DataRow row in tabla.Rows)
        {
            objeto.IdPersona = Convert.ToInt16(row["idUsuario"].ToString());
            objeto.Nombre = row["nombreCompleto"].ToString();
            objeto.Foto = row["foto"].ToString();
            objeto.Telefono = row["telefono"].ToString();
            objeto.Email = row["email"].ToString();
            objeto.Rfc = row["rfc"].ToString();
        }
        return respuesta;
    }
}