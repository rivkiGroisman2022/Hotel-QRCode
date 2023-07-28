using QRCoder;
using System.Drawing;
using System.Net.Mail;
using System.Drawing.Imaging;
using MimeKit;

namespace HotelServer
{
    public class EmailManager
    {
        public void SendEmail(string toMail, int roomNumber, string QRvalue)
        {
            try
            {
                void sendHtmlEmail(string from_Email, string to_Email, string body, string from_Name, string Subject)
                {

                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRvalue, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);


                    // Save the QR code as an image file
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    Image qrCodeImage1 = qrCodeImage;

                    //string filePath = $"C:\\Users\\Rivka\\Desktop\\project\\good\\QRCodes\\Qr-Code{roomNumber}{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}.png";
                    string filePath = $"C:\\Users\\Rivka\\Desktop\\project\\good\\QRCodes\\Qr-Code1.png";

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        qrCodeImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imageBytes = memoryStream.ToArray();
                        File.WriteAllBytes(filePath, imageBytes);
                    }

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
                    mail.To.Add(toMail);

                    //set the Email subject
                    mail.Subject = Subject;

                    Attachment attachment = new Attachment(filePath);
                    mail.Attachments.Add(attachment);

                    //set the SMTP info
                    System.Net.NetworkCredential cred = new System.Net.NetworkCredential("m3218463@gmail.com", "suivcjyldlbecybc");
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = cred;
                    //send the email
                    smtp.Send(mail);
                    attachment.Dispose();
                    mail.Dispose();
                }
                sendHtmlEmail("m3218463@gmail.com", toMail, $"<h3>You are invited to room {roomNumber}</h3></br><h4>!Welcome</h4>", "HotelApp", "You have been assigned a room QR-Code");

            }
            catch (Exception ex)
            {

                throw;
            }
        }

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

