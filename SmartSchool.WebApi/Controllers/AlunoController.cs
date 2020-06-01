using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebApi.Data;
using SmartSchool.WebApi.Models;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext context;
        public AlunoController(SmartContext context) {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não localizado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            context.Add(aluno);
            context.SaveChanges();
           
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var a = context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (a == null) return BadRequest("Aluno não localizado");

            context.Update(aluno);
            context.SaveChanges();
            
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var a = context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (a == null) return BadRequest("Aluno não localizado");

            context.Update(aluno);
            context.SaveChanges();
            
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var a = context.Alunos.FirstOrDefault(a => a.Id == id);
            if (a == null) return BadRequest("Aluno não localizado");

            context.Remove(id);
            context.SaveChanges();

            return Ok();
        }
    }
}