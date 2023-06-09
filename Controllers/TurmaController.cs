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
        public async Task<IActionResult> Register(TurmaViewModel turmaViewModel)
        {
            try
            {   
                var turmaEntity = _mapper.Map<Turma>(turmaViewModel);
                
                await _turmaService.Register(turmaEntity);
                
                turmaViewModel.Id = turmaEntity.Id;

                return StatusCode(StatusCodes.Status201Created,turmaViewModel);
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
        public async Task<IActionResult> Update(TurmaViewModel turmaViewModel,int id)
        {
            try
            {   
                var turmaEntity = _mapper.Map<Turma>(turmaViewModel);

                await _turmaService.Update(turmaEntity, id);

                turmaViewModel.Id = id;

                return Ok(turmaViewModel);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _turmaService.Delete(id);
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