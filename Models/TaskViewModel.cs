using System;
using System.ComponentModel.DataAnnotations;

namespace TaskDB.MVC
{
    public class TaskModel
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Tag { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? Date { get; set; }
    }
}