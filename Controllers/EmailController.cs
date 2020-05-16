using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKitTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace MailKitTest.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmailController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public EmailController(DatabaseContext context)
    {
      _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> SendEmail(Email emailToSend)
    {
      emailToSend.Sender = "Evan Gilbert";
      emailToSend.EmailAddressFrom = "Evan.Gilbert1212@gmail.com";

      _context.Emails.Add(emailToSend);
      await _context.SaveChangesAsync();

      //send email
      var message = new MimeMessage();

      message.From.Add(new MailboxAddress(emailToSend.Sender, emailToSend.EmailAddressFrom));
      message.To.Add(new MailboxAddress(emailToSend.Recipient, emailToSend.EmailAddressTo));

      message.Subject = emailToSend.EmailSubject;

      message.Body = new TextPart("plain")
      {
        Text = @emailToSend.EmailBody
      };

      using (var client = new SmtpClient())
      {
        client.Connect("smtp.gmail.com", 587, true);

        //Only if SMTP server requires authentication
        client.Authenticate("Evan.Gilbert1212@gmail.com", "O3lC1t41212");

        client.Send(message);
        client.Disconnect(true);
      }

      return Ok();
    }
  }
}