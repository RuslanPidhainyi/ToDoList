using ToDoList.Models;
using ToDoList.Servisec;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ToDoList.Services
{
    public class EFServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public EFServiceRepository(AppDbContext context) { _context = context;  }

        public ICollection<Table> FindItem() 
        {
            return _context.Tables.ToList();
        }

        public int Save(Table table)
        {
            try
            {
                var entityEntry = _context.Tables.Add(table);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool ChangeTask(Table? table, TableForEdit tableForEdit)
        {
            try
            {
                if (table != null)
                {
                    table.Text = tableForEdit.Text;

                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException) { return false; }
        }

        public Table? FindId(int? id)
        {
            Table? table = _context.Tables.Where(t => t.Id == id).FirstOrDefault();
            return id == null ? null : table;
        }

        public bool Delete(int? id)
        {
            if(id == null) return false;

            Table? find = _context.Tables.Find(id);

            if (find is not null)
            {
                _context.Tables.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
