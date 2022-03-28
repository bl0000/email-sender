
using System;
using MimeKit;
using MailKit.Net.Smtp;


namespace MyApplication
{  
  class collectDetails
  {
        public string collectFromName()
        {
            Console.WriteLine("From:");
            string response = Console.ReadLine();
            return response;
        }

        public string collecttToName()
        {
            Console.WriteLine("To (Name):");
            string response = Console.ReadLine();
            return response;
        }
        public string collectAddress()
        {
            Console.WriteLine("To (Address):");
            string response = Console.ReadLine();
            return response;
        }

        public string collectSubject()
        {
            Console.WriteLine("Subject:");
            string response = Console.ReadLine();
            return response;
        }
        public string collectText()
        {
            Console.WriteLine("Text:");
            string response = Console.ReadLine();
            return response;
        }
  }
  class Program
  {
    static void Main(string[] args)
    {
        collectDetails details = new collectDetails();
        
        string fromName = details.collectFromName();
        string toName = details.collecttToName();
        string toAddress = details.collectAddress();

        var mailMessage = new MimeMessage();
        mailMessage.From.Add(new MailboxAddress(fromName, "exampleEmail@example.com"));
        mailMessage.To.Add(new MailboxAddress(toName, toAddress));
        mailMessage.Subject = details.collectSubject();
        mailMessage.Body = new TextPart("plain")
        {
            Text = details.collectText()
        };

        using (var smtpClient = new SmtpClient())
        {
            smtpClient.Connect("smtp.gmail.com", 465, true); // smtp server and port - replace if necessary
            smtpClient.Authenticate("", ""); // put email and password here 
            smtpClient.Send(mailMessage);
            smtpClient.Disconnect(true);
}
    }
  }
}