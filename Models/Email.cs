namespace MailKitTest.Models
{
  public class Email
  {
    public int ID { get; set; }
    public string Sender { get; set; }
    public string EmailAddressFrom { get; set; }
    public string Recipient { get; set; }
    public string EmailAddressTo { get; set; }
    public string EmailSubject { get; set; }
    public string EmailBody { get; set; }
  }
}