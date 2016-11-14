using System;

namespace SDesk.Model
{
    public class Request
    {
        public long Id { get; set; }
        public long MailId { get; set; }
        public string Subject { get; set; }
        public long SenderId { get; set; } //parserd internal id in the company
        public string Description { get; set; }
        public int AttachemetId { get; set; } //save on disk, thus we have to have an object for that
        public Priority Priority { get; set; }
        public int LocationId { get; set; } //FK to dictionary table
        public int StatusId { get; set; } //FK to dictionary table
        public DateTime Created { get; set; }
        public int RequestTypeId { get; set; } //FK to ...
        public int ImpactId { get; set; } //FK to ...
        public long AssigneeId { get; set; } //internal user id 
    }
}
