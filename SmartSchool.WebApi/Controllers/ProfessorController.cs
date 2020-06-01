using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebApi.Data;
using SmartSchool.WebApi.Models;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext context;
        public ProfessorController(SmartContext context)  {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = this.context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");
            
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            this.context.Add(professor);
            this.context.SaveChanges();

            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int professorId, Professor professor) {
            var p = this.context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == professorId);
            if (p == null) return BadRequest("Professor não encontrado");
            
            this.context.Update(professor);
            this.context.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int professorId, Professor professor) {
            var p = this.context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == professorId);
            if (p == null) return BadRequest("Professor não encontrado");
            
            this.context.Update(professor);
            this.context.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int professorId) {
            var professor = this.context.Professores.FirstOrDefault(p => p.Id == professorId);
            if (professor == null) return BadRequest("Professor não encontrado");
            
            this.context.Remove(professor);
            this.context.SaveChanges();

            return Ok();
        }

    }
}