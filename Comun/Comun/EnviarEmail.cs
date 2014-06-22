namespace Empresa.Comun
{
    using System;
    using System.Web;
    using System.Net.Mail;
    using System.Net;
    using System.Net.Mime;

    public class EnviarEmail
    {
        public SmtpClient SMTP { get; set; }
        public MailMessage Mensaje { get; set; }


        const string _CONGI1 = "Directorio";
        const string _CONGI2 = "CEmailr";
        const string _CONGI3 = "PEmailr";
         
        string Remail = string.Empty; 
        string pemail = string.Empty;


        private void Setting()
        {
            Remail = "noresponder@inabima.gob.do";
            
                //PanelConfiguracion.TrRegistro.DameDirectorio(_CONGI2);
            pemail = "Ina_1234";
                //PanelConfiguracion.TrRegistro.DameDirectorio(_CONGI3);

            SMTP = new SmtpClient();
            SMTP.Credentials = new System.Net.NetworkCredential(Remail, pemail);
            SMTP.Port = 25;
            SMTP.Host = "mail.inabima.gob.do";
        }

        public EnviarEmail() {
            this.Setting();
        }

        public EnviarEmail(MailMessage mensaje){
            Setting();
            this.Mensaje = mensaje;
        }

        public EnviarEmail(MailMessage mensaje, object[] archivos){
            Setting();
            foreach (object item in archivos) { 
                mensaje.Attachments.Add(new Attachment(item.ToString()));  
            }
            this.Mensaje = mensaje;
        }

        public EnviarEmail(string Destino, string Sujb, string Cuerpo)
        {
            Setting();
            Mensaje = new MailMessage(Remail, Destino, Sujb, Cuerpo);
        }

        public void Enviar()
        {
            try{
                SMTP.Send(this.Mensaje);
            }
            catch (Exception ex) { 
            
            
            }
        }

        public void Enviar(MailMessage mensaje)
        {
            this.Mensaje = mensaje;
            this.Enviar();
        }

        public void Enviar(string Destino, string Sujb, string Cuerpo){
            Mensaje = new MailMessage(Remail, Destino);
            Mensaje.Subject = Sujb;
            Mensaje.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(Cuerpo,new System.Net.Mime.ContentType(MediaTypeNames.Text.Html)));
            this.Enviar();
        }

        public void Enviar(string Destino, string Sujb, string Cuerpo, object[] archivos)
        {
            Mensaje = new MailMessage(Remail, Destino);
            Mensaje.Subject = Sujb;
            Mensaje.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(Cuerpo, new System.Net.Mime.ContentType(MediaTypeNames.Text.Html)));

            foreach(object item in archivos){
                Mensaje.Attachments.Add(new Attachment(item.ToString()));
            }
            this.Enviar();
        }
    }
}
