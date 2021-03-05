using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Database;
using TaskBoard.Database.Models;
using TaskBoard.Models;
using TaskBoard.Models.Input;
using TaskBoard.Models.Output;
using TaskStatus = TaskBoard.Infrastructure.TaskStatus;

namespace TaskBoard.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public PopugTaskFilterView Filter { get; set; }


        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet(Name="GetList")]
        public async Task<ActionResult<IEnumerable<PopugTaskView>>> Index([FromForm] PopugTaskFilterView filter)
        {
            var tasksQuery = _mapper.ProjectTo<PopugTaskView>(_context.PopugTasks.AsNoTracking());

            // Фильтр сделаем по рабоче-крестьянски
            if (filter.Id.HasValue)
                tasksQuery = tasksQuery.Where(t => t.Id == filter.Id.Value);
            if (!string.IsNullOrEmpty(filter.Content))
                tasksQuery = tasksQuery.Where(t => t.Content.Contains(filter.Content));
            if (filter.Responsible.HasValue)
                tasksQuery = tasksQuery.Where(t => t.Responsible == filter.Responsible.Value);
            if (filter.Status.HasValue)
                tasksQuery = tasksQuery.Where(t => t.Status == filter.Status.Value);

            //Filter = filter;
            return View(await tasksQuery.ToListAsync());
        }

        [HttpPost(Name = "CreateTask")]
        public async Task<ActionResult> Create([FromForm] PopugTaskCreateView newTask)
        {
            var task = _mapper.Map<PopugTask>(newTask);
            await _context.PopugTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var popugTask = await _mapper.ProjectTo<PopugTaskView>(_context.PopugTasks.AsNoTracking())
                .FirstOrDefaultAsync(m => m.Id == id);
            if (popugTask == null)
                return NotFound();

            return View(popugTask);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var popugTask = await _context.PopugTasks.FindAsync(id);
            _context.PopugTasks.Remove(popugTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var popugTask = await _mapper.ProjectTo<PopugTaskView>(_context.PopugTasks.AsNoTracking())
                .FirstOrDefaultAsync(t => t.Id == id);
            if (popugTask == null)
                return NotFound();
            return View(popugTask);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Responsible,Status")] PopugTaskView popugTask)
        {
            if (id != popugTask.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var task = await _context.PopugTasks.FirstOrDefaultAsync(t => t.Id == id);
                if (task == null)
                    return NotFound();
                task.Status = popugTask.Status;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(popugTask);
        }
    }
}
