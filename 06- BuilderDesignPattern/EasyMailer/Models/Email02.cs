namespace EasyMailer.Models;


public class Email02
{
    // کانستراکتور private تعریف شد تا امکان نمونه سازی از کلاس فراهم نباشد و تنها زا طریق بیلدر، بتوانیم پروپرتی ها را مقدار دهی کنیم 
    private Email02()
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


    public static Email02Builder Builder() => new Email02Builder();

    public class Email02Builder
    {
        private readonly Email02 _email = new();

        // ولدیشن های مربوط به هر پروپرتی رو میتونیم در قسمت مربوط به تنظیم مقدار هر پروپرتی انجام بدیم که خوانایی بالایی داره
        // میتونیم نام متدها رو به نحوی انتخاب کنیم که مرتبط با بیزینس باشه و خواننده ی کد به راحتی کد رو متوجه بشه 
        // روش های مختلفی برای بیلدر هست اما ما در اینجا روش کلاسیک رو پیاده سازی نکردیم، در روش کلاسیک یک کلاس director هم داریم که دیگه نمیتونیم متدها رو به صورت chain فراخوانی کنیم اما در این روش به صورت chain فراخوانی کردیم
        // در این روش نمی تونیم ترتیب گام ها رو مشخص کنیم و روی این موضوع کنترلی نداریم
        public Email02Builder AddTo(string to)
        {
            if (!string.IsNullOrWhiteSpace(to))
            {
                _email.To.Add(to);
            }
            return this;
        }

        public Email02Builder AddTo(IEnumerable<string> toList)
        {
            _email.To.AddRange(toList.Where(t => !string.IsNullOrWhiteSpace(t)));
            return this;
        }

        public Email02Builder SetFrom(string from)
        {
            _email.From = from;
            return this;
        }

        public Email02Builder SetSubject(string subject)
        {
            _email.Subject = subject;
            return this;
        }

        public Email02Builder SetBody(string body)
        {
            _email.Body = body;
            return this;
        }

        public Email02Builder AddCc(string cc)
        {
            if (!string.IsNullOrWhiteSpace(cc))
            {
                _email.Cc.Add(cc);
            }
            return this;
        }

        public Email02Builder AddCc(IEnumerable<string> ccList)
        {
            _email.Cc.AddRange(ccList.Where(c => !string.IsNullOrWhiteSpace(c)));
            return this;
        }

        public Email02Builder AddBcc(string bcc)
        {
            if (!string.IsNullOrWhiteSpace(bcc))
            {
                _email.Bcc.Add(bcc);
            }
            return this;
        }

        public Email02Builder AddBcc(IEnumerable<string> bccList)
        {
            _email.Bcc.AddRange(bccList.Where(b => !string.IsNullOrWhiteSpace(b)));
            return this;
        }

        public Email02Builder SetPriority(EmailPriority priority = EmailPriority.Normal)
        {
            _email.Priority = priority;
            return this;
        }

        public Email02Builder AddAttachment(string attachment)
        {
            if (!string.IsNullOrWhiteSpace(attachment))
            {
                _email.Attachments.Add(attachment);
            }
            return this;
        }

        public Email02Builder AddAttachments(IEnumerable<string> attachments)
        {
            _email.Attachments.AddRange(attachments.Where(a => !string.IsNullOrWhiteSpace(a)));
            return this;
        }

        public Email02 Build()
        {
            // Validate required fields
            if (!_email.To.Any() || string.IsNullOrEmpty(_email.From) ||
                string.IsNullOrEmpty(_email.Subject) || string.IsNullOrEmpty(_email.Body))
            {
                throw new InvalidOperationException("To, From, Subject, and Body are required.");
            }

            return _email;
        }
    }
}