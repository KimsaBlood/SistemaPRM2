using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

public class email
{

    private System.Net.NetworkCredential credencial;
    private SmtpClient smtpServer;
    private MailMessage mail = new MailMessage();

    private String cuerpo = "";
    private String asunto = "";
    private String paraQuien = "";

    public MailMessage Mail { get => mail; set => mail = value; }
    public string Cuerpo { get => cuerpo; set => cuerpo = value; }
    public string Asunto { get => asunto; set => asunto = value; }
    public string ParaQuien { get => paraQuien; set => paraQuien = value; }

    public email()
    {
        credencial = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["usrMail"], System.Configuration.ConfigurationManager.AppSettings["pswMail"]);
        smtpServer = new SmtpClient();
        smtpServer.Host = System.Configuration.ConfigurationManager.AppSettings["serverMail"];
        smtpServer.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["puertoMail"]);
        smtpServer.Credentials = credencial;
        smtpServer.EnableSsl = false;

        mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["mailCotizaciones"], "PROMORISK MÉXICO", Encoding.UTF8);

        mail.IsBodyHtml = true;

    }

    public email(string cuerpo, string asunto, string paraQuien)
    {
        this.cuerpo = cuerpo;
        this.asunto = asunto;
        this.paraQuien = paraQuien;
        credencial = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["usrMail"], System.Configuration.ConfigurationManager.AppSettings["pswMail"]);
        smtpServer = new SmtpClient();
        smtpServer.Host = System.Configuration.ConfigurationManager.AppSettings["serverMail"];
        smtpServer.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["puertoMail"]);
        smtpServer.Credentials = credencial;
        smtpServer.EnableSsl = false;

        mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["mailCotizaciones"], "PROMORISK MÉXICO", Encoding.UTF8);

        mail.IsBodyHtml = true;

    }

    public Boolean mandaEmail(string paraQuien, string cuerpo, string asunto)
    {
        try
        {
            mail.Subject = asunto;
            mail.To.Add(paraQuien);
          //  mail.CC.Add("erick.hernandez@prmseguros.com");
            //mail.CC.Add("lizbeth.cruz@prmseguros.com");
            mail.Body = cuerpo;
            smtpServer.Send(mail);
            return true;
        }

        catch (Exception ex)
        {
           // GuardaExcepcion(ex.Message);
            return false;
        }
    }

    public Boolean conDocumentos(string paraQuien, string cuerpo, string asunto, DataTable archivos, string donde)
    {
        try
        {
            mail.Subject = asunto;
            mail.To.Add(paraQuien);
           // mail.CC.Add("erick.hernandez@prmseguros.com");
            mail.Body = cuerpo;
            if (archivos.Rows.Count > 0)
            {
                foreach (DataRow dr in archivos.Rows)
                {

                    mail.Attachments.Add(new Attachment(@dr["Documento"].ToString()));
                }
            }
            smtpServer.Send(mail);
            return true;
        }

        catch (Exception ex)
        {
            return false;
            // GuardaExcepcion(ex.Message);
        }
    }

    public Boolean mandaEmail()
    {
        try
        {
            mail.Subject = asunto;
            mail.To.Add(paraQuien);
         //   mail.CC.Add("erick.hernandez@prmseguros.com");
            mail.Body = cuerpo;
            smtpServer.Send(mail);
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }

    public Boolean conDocumentos(string correo, string cuerpo, string titulo, String[] archivos, string donde)
    {

        this.paraQuien = correo;
        this.cuerpo = cuerpo;
        this.Asunto = titulo;
        mail.Subject = asunto;
        mail.To.Add(paraQuien);

        //mail.CC.Add("erick.hernandez@prmseguros.com");
        //mail.CC.Add(donde);
        mail.Body = this.cuerpo;
        if (archivos.Count() > 0)
        {
            foreach (String dr in archivos)
            {
                if (dr != "" && dr != null)
                    mail.Attachments.Add(new Attachment(dr));
            }
        }
        try
        {
            smtpServer.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            //  GuardaExcepcion(ex.Message);
            return false;
        }
    }
}