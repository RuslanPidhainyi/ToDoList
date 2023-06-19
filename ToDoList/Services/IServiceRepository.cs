using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Servisec
{
    public interface IServiceRepository
    {
        public ICollection<Table> FindItem();

        public int Save(Table table);

        public bool ChangeTask(Table? table, TableForEdit tableForEdit);
        
        public Table? FindId(int? id);

        public bool Delete(int? id);
    }
}
