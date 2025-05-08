using Microsoft.AspNetCore.Mvc;
using MvcNetCorePostgresEC2.Models;
using MvcNetCorePostgresEC2.Repositories;

namespace MvcNetCorePostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryHospitales repo;
        public DepartamentosController(RepositoryHospitales repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento departamento = await this.repo.FindDepartamento(id);
            return View(departamento);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.repo.InsertDepartamento(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
    }
}
