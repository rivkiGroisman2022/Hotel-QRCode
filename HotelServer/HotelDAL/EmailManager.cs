using System.Drawing;
using System.Net.Mail;
using System.Drawing.Imaging;
using MimeKit;

namespace HotelDAL
{
    public class EmailManager
    {

        public void SendErrorEmail(string functionName, string errorMsg)
        {
            try
            {
                void sendHtmlEmail(string from_Email, string to_Email, string body, string from_Name, string Subject)
                {
                    //create an instance of new mail message
                    MailMessage mail = new MailMessage();

                    //set the HTML format to true
                    mail.IsBodyHtml = true;

                    //create Alrternative HTML view
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");

                    mail.AlternateViews.Add(htmlView);

                    //set the "from email" address and specify a friendly 'from' name
                    mail.From = new MailAddress(from_Email, from_Name);

                    //set the "to" email address
                    mail.To.Add("rivki2655@gmail.com");

                    //set the Email subject
                    mail.Subject = Subject;

                    //set the SMTP info
                    System.Net.NetworkCredential cred = new System.Net.NetworkCredential("m3218463@gmail.com", "suivcjyldlbecybc");
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = cred;
                    //send the email
                    smtp.Send(mail);
                    mail.Dispose();
                }
                sendHtmlEmail("m3218463@gmail.com", "rivki2655@gmail.com", $"An error occurred in finction {functionName}. the error message is {errorMsg}", "HotelApp", "An error occurred");

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

