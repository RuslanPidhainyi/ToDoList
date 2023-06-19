using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TableForEdit
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please, enter text!")]
        public string Text { get; set; }
    }
}
