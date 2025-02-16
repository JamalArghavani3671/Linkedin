using EasyMailer;
using EasyMailer.Models;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        // استفاده از کانستراکتورهای مختلف برای ساخت ایمیل 
        var emailWithoutBuilder = new Email01(new List<string> { "customer1@example.com", "customer2@example.com" },
                              "noreply@example.com",
                              "Welcome!",
                              "Thank you for signing up.", EmailType.Transactional);
        Console.WriteLine(emailWithoutBuilder.ToString());



        // استفاده از FluentBuilder برای ساخت ایمیل
        var email1 = Email02.Builder()
            .AddTo("jamal@gmail.com")
            .SetFrom("noreply@example.com")
            .SetSubject("hello")
            .SetBody("body")
            .Build();


        var email2 = Email02.Builder()
            .AddTo(new List<string> { "jamal@gmail.com", "ali@gmail.com" })
            .SetFrom("noreply@example.com")
            .SetSubject("hello")
            .SetBody("body")
            .Build();


        var emailWithBuilder = Email02.Builder()
            .AddTo("customer1@example.com")
            .AddTo("customer2@example.com")
            .SetFrom("noreply@example.com")
            .SetSubject("Welcome!")
            .SetBody("Thank you for signing up.")
            .AddCc("manager1@example.com")
            .AddCc("manager2@example.com")
            .AddBcc("admin@example.com")
            .SetPriority(EmailPriority.High)
            .AddAttachment("file1.pdf")
            .Build();
        Console.WriteLine(emailWithBuilder);



        // استفاده از OrderedBuilder به منظور ساخت ایمیل با ترتیب مشخص 
        var email3 = Email03.Builder()
            .SetFrom("noreply@example.com")
            .SetTo("customer1@example.com")
            .SetSubject("Welcome!")
            .SetBody("Thank you for signing up.")
            .AddCc("manager1@example.com")
            .AddBcc("admin@example.com")
            .Build();

        var email = Email03.Builder()
            .SetFrom("")
            .SetTo("")
            .SetSubject("")
            .SetBody("")
            .AddCc("")
            .Build();

        // استفاده از 
        Console.ReadKey();
    }
}