
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CustomerAcountManagement.Service;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        //string fromMail = "aayala12238@gmail.com";
        //string fromPassword = "0583212238";

        //MailMessage message = new MailMessage();
        //message.From = new MailAddress(fromMail);
        //message.Subject = subject;
        //message.To.Add(new MailAddress(email));
        //message.Body = "<html><body> " + htmlMessage + " </body></html>";
        //message.IsBodyHtml = true;

        //var smtpClient = new SmtpClient("smtp.gmail.com")
        //{
        //    Port = 25,
        //    //Port = 587,
        //    Credentials = new NetworkCredential(fromMail, fromPassword),
        //    EnableSsl = true,
        //};
        //smtpClient.Send(message);
        string from = "324857648@mby.co.il";
        MailMessage message = new MailMessage();
        message.From = new MailAddress(from);
        message.To.Add(new MailAddress(email));
        string mailbody = htmlMessage;
        message.Subject = subject;
        message.Body = mailbody;
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(from, "Student@264");
        client.Host = "smtp.office365.com";
        client.Port = 587;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
