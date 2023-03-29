using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using teste_desafio.service;
using teste_desafio.viewmodel;

namespace teste_desafio.Controllers
{   
    [ApiController]
    [Route("turma")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {

            _turmaService = turmaService;

        }

        [HttpPost]
        public IActionResult Add(TurmaViewModel turmaViewModel)
        {
            try
            {
                _turmaService.Save(turmaViewModel);
                return Ok();
            }
            catch (Exception e)
            {
                NotFound(new {e.Message});
            }
            return NotFound();

        }

        [HttpGet("listar")]
        public IActionResult GetAll()
        {
            try
            {
                var turmas = _turmaService.GetAll();
                return Ok(turmas);

            }
            catch (Exception e)
            {
                BadRequest(new {e.Message});
            }
            return BadRequest();

        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Update(TurmaViewModel turmaViewModel,int id)
        {
            try
            {
                _turmaService.Update(turmaViewModel, id);
                return Ok();
            }
            catch (Exception e)
            {
                BadRequest(new {e.Message});
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _turmaService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                BadRequest(new {e.Message});
            }
            return BadRequest();
        }
   
    }
}