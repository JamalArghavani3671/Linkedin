namespace EasyMailer.Models;

// در روش قبلی بیلدر، ما نمی تونستیم روی ترتیب گام ها برای ساخت ایمیل کنترلی داشته باشیم که روش OrderedBuilder رو اینجا میخواهیم پیاده سازی کنیم  که ترتیب مشخص میشه اما انعطاف پذیری پایین میاد
public class Email03
{
    private Email03()
    {

    }
    public List<string> To { get; private set; } = new();
    public string From { get; private set; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public List<string> Cc { get; private set; } = new();
    public List<string> Bcc { get; private set; } = new();
    public EmailPriority Priority { get; private set; }
    public List<string> Attachments { get; private set; } = new();


    public static ISetFromStep Builder() => new Email03Builder();

    private class Email03Builder : ISetFromStep, ISetToStep, ISetSubjectStep, ISetBodyStep, ISetOptionalValuesStep
    {
        private readonly Email03 _email = new();

        public ISetToStep SetFrom(string from) { _email.From = from; return this; }
        public ISetSubjectStep SetTo(string to) { _email.To.AddRange(to); return this; }
        public ISetBodyStep SetSubject(string subject) { _email.Subject = subject; return this; }
        public ISetOptionalValuesStep SetBody(string body) { _email.Body = body; return this; }
        public Email03 Build() => _email;

        public ISetOptionalValuesStep AddCc(string cc)
        {
            _email.Cc.Add(cc);
            return this;
        }

        public ISetOptionalValuesStep AddBcc(string bcc)
        {
            _email.Bcc.Add(bcc);
            return this;
        }

        public ISetOptionalValuesStep SetPriority(EmailPriority priority = EmailPriority.Normal)
        {
            _email.Priority = priority;
            return this;
        }

        public ISetOptionalValuesStep AddAttachment(string attachment)
        {
            _email.Attachments.Add(attachment);
            return this;
        }
    }
}




public interface ISetFromStep
{
    ISetToStep SetFrom(string from);
}
public interface ISetToStep
{
    ISetSubjectStep SetTo(string to);
}

public interface ISetSubjectStep
{
    ISetBodyStep SetSubject(string subject);
}

public interface ISetBodyStep
{
    ISetOptionalValuesStep SetBody(string body);
}

public interface ISetOptionalValuesStep
{
    ISetOptionalValuesStep AddCc(string cc);
    ISetOptionalValuesStep AddBcc(string bcc);
    ISetOptionalValuesStep SetPriority(EmailPriority priority = EmailPriority.Normal);
    ISetOptionalValuesStep AddAttachment(string attachment);
    Email03 Build();
}