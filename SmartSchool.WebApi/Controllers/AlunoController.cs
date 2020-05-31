using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebApi.Models;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Leonardo",
                Sobrenome = "Ribeiro",
                Telefone = "(27) 98848-1416"
            },
            new Aluno() {
                Id = 2,
                Nome = "Sibele",
                Sobrenome = "Scaranto",
                Telefone = "(27) 98119-7856"
            }
        };

        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não localizado");
            
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno) 
        {
            return Ok(Alunos);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(Alunos);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(Alunos);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(Alunos);
        }
    }
}