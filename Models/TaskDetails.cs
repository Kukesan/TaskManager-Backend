using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The DueDate field is required.")]
        [DataType(DataType.DateTime)] 
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)] 
        public DateTime DueDate { get; set; }
    }
}
