using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Servisec;

namespace ToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IServiceRepository _context;
        public ToDoListController(IServiceRepository serviceRepository) { _context = serviceRepository; }

        public IActionResult Index()
        {
            return View( _context.FindItem());
        }

        [HttpGet]
        public IActionResult Add() { return View(); }

        [HttpPost]
        public IActionResult Add(Table table)
        {
            if(ModelState.IsValid)
            {
                _context.Save(table);
                return RedirectToAction(nameof(Index));
            }
            else { return View(table); }
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int? Id) {

            Table? table = _context.FindId(Id);
            if(table == null) { return NotFound(); }

            ViewBag.Id = table.Id;
            ViewBag.Text = table.Text;

            return View();
        }


        [HttpPost]
        public IActionResult Edit([FromForm]TableForEdit tableForEdit)
        {
            if(ModelState.IsValid) {
                Table? table = _context.FindId(tableForEdit.Id);
                _context.ChangeTask(table, tableForEdit);
                return RedirectToAction(nameof(Index));
            }
            return View(tableForEdit);
        }


        public IActionResult Delete([FromRoute] int? id)
        {
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
