using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> Get()
        {
            var departments = await _departmentService.GetDepartments();

            if (departments == null)
            {
                return NotFound("Departamento não encontrado!");
            }

            return Ok(departments);
        }

        [HttpGet("{id:int}", Name = "GetDepartment")]
        public async Task<ActionResult<DepartmentDTO>> GetById(int id)
        {
            var department = await _departmentService.GetById(id);

            if (department == null)
            {
                return NotFound("Departamento não encontrado!");
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DepartmentDTO department)
        {
            if (department == null)
                return BadRequest("Dados Inválidos");

            await _departmentService.Add(department);

            return new CreatedAtRouteResult("GetDepartment", new { id = department.Id}, department);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DepartmentDTO department)
        {
            if (id != department.Id)
                return BadRequest("Dados Inválidos");

            if (department == null)
                return BadRequest("Dados Inválidos");

            await _departmentService.Update(department);

            return Ok(department);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DepartmentDTO>> Delete(int id)
        {
            var department = await _departmentService.GetById(id);

            if (department == null)
                return NotFound("Departamento não encontrado!");

            await _departmentService.Remove(id);

            return Ok(department);
        }
    }
}