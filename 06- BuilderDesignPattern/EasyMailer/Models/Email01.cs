namespace EasyMailer.Models;
public class Email01
{
    public Email01(List<string> to, string from, string subject, string body, EmailType emailType)
    {
        // اعتبار سنجی داده های ورودی در این قسمت باید انجام بشه 
        To.AddRange(to);
        From = from;
        Subject = subject;
        Body = body;
        EmailType = emailType;
    }


    public Email01(List<string> to, string from, string subject, string body, EmailType emailType, List<string> cc) : this(to, from, subject, body, emailType)
    {
        // اعتبار سنجی داده های ورودی در این قسمت باید انجام بشه 
        Cc.AddRange(cc);
    }


    public Email01(List<string> to, string from, string subject, string body, EmailType emailType, List<string> cc, List<string> bcc) : this(to, from, subject, body, emailType, cc)
    {
        // اعتبار سنجی داده های ورودی در این قسمت باید انجام بشه 
        bcc.AddRange(bcc);
    }


    public Email01(List<string> to, string from, string subject, string body, EmailType emailType, List<string> cc, List<string> bcc, EmailPriority priority) : this(to, from, subject, body, emailType, cc, bcc)
    {
        // اعتبار سنجی داده های ورودی در این قسمت باید انجام بشه 
        Priority = priority;
    }


    public Email01(List<string> to, string from, string subject, string body, EmailType emailType, List<string> cc, List<string> bcc, EmailPriority priority, List<string> attachments) : this(to, from, subject, body, emailType, cc, bcc, priority)
    {
        // اعتبار سنجی داده های ورودی در این قسمت باید انجام بشه 
        Attachments.AddRange(attachments);
    }

    // اجباری
    public List<string> To { get; set; } = new();

    // اجباری
    public string From { get; set; }

    // اجباری
    public string Subject { get; set; }

    // اجباری
    public string Body { get; set; }

    // اجباری
    // if EmailType = Promotional then Priority must Be Low
    // if EmailType = Transactional then Priority must Be High
    public EmailType EmailType { get; set; }
    public List<string> Cc { get; set; } = new();
    public List<string> Bcc { get; set; } = new();
    public EmailPriority Priority { get; set; } = EmailPriority.Normal;
    public List<string> Attachments { get; set; } = new();
}
