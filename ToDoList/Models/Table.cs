using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Table
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="Please, enter text!")]
        public string Text { get; set; }
    }
}
