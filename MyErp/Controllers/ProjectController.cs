using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

namespace MyErp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContex _context;

        public ProjectController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects
                .Include(x=>x.PeopleProjects)
                .ThenInclude(x=>x.People).ToList();
            return View(projects);
        }
        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            ModelState.Remove("PeopleProjects");
            if (ModelState.IsValid) 
            { 
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpGet]
        public IActionResult PeopleAssign(int id)
        {
            var project = _context.Projects
                .Include(p => p.PeopleProjects)
                .FirstOrDefault(p => p.ID== id);

            var vm = new ProjectViewModel
            {
                ProjectId = id,
                ProjectName = project.Name,
                AllPeoples = _context.Peoples
                .Select(p=> new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList(),
                SelectedPeopleIds = project.PeopleProjects
                .Select(pId => pId.PeopleId).ToList(),
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PeopleAssign(ProjectViewModel vm)
        {
            var project = _context.Projects
                .Include(p => p.PeopleProjects)
                .FirstOrDefault(p => p.ID == vm.ProjectId);
            if (project ==null)
            {
                return NotFound();
            }            
                project.PeopleProjects.Clear();
                project.PeopleProjects = vm.SelectedPeopleIds
                    .Select(p => new PeopleProject { PeopleId = p, ProjectId = p }).ToList();            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
