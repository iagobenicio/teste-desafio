using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using teste_desafio.domain.entities;
using teste_desafio.failures;
using teste_desafio.service;
using teste_desafio.viewmodel;

namespace teste_desafio.Controllers
{
    [ApiController]
    [Route("turma")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;
        private readonly IMapper _mapper;

        public TurmaController(ITurmaService turmaService, IMapper mapper)
        {

            _turmaService = turmaService;
            _mapper = mapper;

        }

        [HttpPost]
        public IActionResult Register(TurmaViewModel turmaViewModel)
        {
            try
            {   
                var turmaEntity = _mapper.Map<Turma>(turmaViewModel);

                _turmaService.Register(turmaEntity);
                
                var turmaRegistered = _mapper.Map<TurmaViewModel>(turmaEntity);

                return StatusCode(StatusCodes.Status201Created,turmaRegistered);
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }
            

        }

        [HttpGet("listar")]
        public IActionResult GetAll()
        {
            try
            {
                var turmas = _turmaService.GetAll();

                var turmasViewModel = _mapper.Map<List<TurmaViewModel>>(turmas);

                return Ok(turmasViewModel);

            }
            catch (Exception e)
            {
               return BadRequest(new {e.Message});
            }

        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Update(TurmaViewModel turmaViewModel,int id)
        {
            try
            {   
                var turmaEntity = _mapper.Map<Turma>(turmaViewModel);

                _turmaService.Update(turmaEntity, id);

                var turmaUpdated = _mapper.Map<TurmaViewModel>(turmaEntity);

                return Ok(turmaUpdated);
            }
            catch (EntityNotFound e)
            {
                return NotFound(new {e.Message});
            }
            catch (Exception e)
            {
               return BadRequest(new {e.Message});
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _turmaService.Delete(id);
                return Ok();
            }
            catch (EntityNotFound e)
            {
                return NotFound(new {e.Message});
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }

        }
   
    }
}