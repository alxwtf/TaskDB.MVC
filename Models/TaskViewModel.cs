using System;
using System.ComponentModel.DataAnnotations;

namespace TaskDB.MVC
{
    public class TaskModel
    {
        public Guid id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Теги")]
        public string Tag { get; set; }
        [Required]
        [Display(Name = "Дата создания")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Дата завершения")]
        public DateTime? Date { get; set; }

        public string userid { get; set; }

    }
}