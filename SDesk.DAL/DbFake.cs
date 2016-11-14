using System;
using System.Collections.Generic;
using SDesk.Model;

namespace SDesk.DAL
{
    //Only for studying needs
    public class DbFake
    {
        public static List<Mail> Mails { get; set; }

        public static List<Attachement> Attachements { get; set; }

        public static List<JiraItem> JiraItems { get; set; }

        static DbFake()
        {
            Mails = new List<Mail>(new[]
            {
                new Mail
                {
                    Id = 1,
                    Body = "Test body",
                    Cc = "copy@gmail.com",
                    Priority = Priority.High,
                    Received = DateTime.Now,
                    Saved = DateTime.Now,
                    Sender = "sender@gmail.com",
                    Subject = "Test",
                    To = "me@gmail.com"
                },
                new Mail
                {
                    Id = 2,
                    Body = "Other Test body",
                    Cc = "copy@gmail.com",
                    Priority = Priority.High,
                    Received = DateTime.Now,
                    Saved = DateTime.Now,
                    Sender = "sender@gmail.com",
                    Subject = "Other Test",
                    To = "me@gmail.com"
                }
            });

            Attachements = new List<Attachement>(new[]
            {
                new Attachement
                {
                    Id = 1,
                    FileExtention = "test1",
                    FileName = "other_test_name",
                    Path = "~/some_path",
                    MailId = 1,
                    StatusId = 0
                },
                new Attachement
                {
                    Id = 2,
                    FileExtention = "test2",
                    FileName = "other_test_name",
                    Path = "~/other_some_path",
                    MailId = 2,
                    StatusId = 1
                }
            });

            JiraItems = new List<JiraItem>(new []
            {
                new JiraItem
                {
                    JiraItemId = 1,
                    JiraNumber = 1,
                    RequestIdType = 1,
                    JiraSourceId = 1
                },
                new JiraItem
                {
                    JiraItemId = 2,
                    JiraNumber = 2,
                    RequestIdType = 2,
                    JiraSourceId = 2
                }
            });
        }
    }
}
