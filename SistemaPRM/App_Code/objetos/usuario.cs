using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for usuario
/// </summary>
public class usuario:persona
{
    private int idUsuario;
    private String telefono;
    private String email;
    private int[] roles;
    private int oficina;
    private String fechaIngreso;
    private String foto;
    private String password;
    private String _usuario;
    private int estado;

    public usuario()
    {

    }

    public usuario(int idUsuario)
    {
        this.idUsuario = idUsuario;
    }

    public usuario(string usuario)
    {
        _usuario = usuario;
    }

    public usuario(string password, string usuario)
    {
        this.password = password;
        _usuario = usuario;
    }

    public usuario(int idUsuario,string nombre, string paterno, string materno, string  fechaNacimiento, string infoAdicional, string rfc,  string telefono, string email, int[] roles, int oficina, string fechaIngreso, string password,string usuario, string foto)
    {
        this.idUsuario = idUsuario;
        this.Nombre = nombre;
        this.Paterno = paterno;
        this.Materno = materno;
        this.FechaNacimiento = fechaNacimiento;
        this.InfoAdicional = infoAdicional;
        this.Rfc = rfc;
        this.telefono = telefono;
        this.email = email;
        this.roles = roles;
        this.oficina = oficina;
        this.Usuario = usuario;
        this.fechaIngreso = fechaIngreso;
        this.password = password;
        this.foto = foto;
    }

    public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string Email { get => email; set => email = value; }
    public int[] Roles { get => roles; set => roles = value; }
    public int Oficina { get => oficina; set => oficina = value; }
    public string FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
    public string Password { get => password; set => password = value; }
    public string Foto { get => foto; set => foto = value; }
    public int EstadoU { get => estado; set => estado = value; }
    public string Usuario { get => _usuario; set => _usuario = value; }
}