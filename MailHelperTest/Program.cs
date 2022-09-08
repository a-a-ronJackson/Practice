using Mail_Helper;
namespace MailHelperTest
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var fromAddress = new MailAddress()
            {
                AddressType = AddressType.FROM,
                Email = "aaron.jackson@covan.com",
                Name = "Aaron Jackson"
            };
            

            var toAddress1 = new MailAddress()
            {
                AddressType = AddressType.TO,
                Email = "james.mansoor@covan.com",
                Name = "James Mansoor"
            };

            var toAddress2 = new MailAddress()
            {
                AddressType = AddressType.TO,
                Email = "tim.phillips@covan.com",
                Name = "Tim Phillips"
            };


            List<MailAddress> mailAddresses = new List<MailAddress>();

            mailAddresses.Add(toAddress1);
            mailAddresses.Add(toAddress2);

            var subject = "MailHelperTest";
            var body = "Testing....";

            MailHelper helper = new MailHelper("colemanwg.mail.protection.outlook.com", new MailAddress() { Name = "No Reply", Email = "noreply@covan.com", AddressType = AddressType.FROM });

            //MailHelper helper = new MailHelper("colemanwg.mail.protection.outlook.com", fromAddress);

            helper.SendSimpleMessage(mailAddresses, subject, body,MimeKit.Text.TextFormat.Plain);
        }
    }
}