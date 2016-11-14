using System;

namespace SDesk.Model
{
    public class MailTemplate
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int AttachementId { get; set; }
        public Priority Priority { get; set; }
        public DateTime LastEdited { get; set; } //date when it was edited last time
    }
}
