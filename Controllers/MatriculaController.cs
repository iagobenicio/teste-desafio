using Microsoft.AspNetCore.Mvc;
using teste_desafio.service;
using teste_desafio.domain.entities;
using AutoMapper;
using teste_desafio.viewmodel;
using teste_desafio.failures;

namespace teste_desafio.Controllers
{
    [ApiController]
    [Route("matricula")]
    public class MatriculaController : ControllerBase
    {   
        private readonly IMatriculaService _matriculaService;
        private readonly IMapper _mapper;

        public MatriculaController(IMatriculaService matriculaService, IMapper mapper)
        {
            _matriculaService = matriculaService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult EnrollAluno(MatriculaViewModel matriculaViewModel)
        {   
            try
            {
                var matricula = _mapper.Map<Matricula>(matriculaViewModel);

                _matriculaService.EnrollAluno(matricula);

                var alunoRegistered = _mapper.Map<MatriculaViewModel>(matricula);

                return StatusCode(StatusCodes.Status201Created,alunoRegistered);
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var matriculas = _matriculaService.GetAll();

                var matriculasRelacao = new List<MatriculaRelacaoViewModel>();

                matriculasRelacao = _mapper.Map<List<MatriculaRelacaoViewModel>>(matriculas);

                return Ok(matriculasRelacao);
            }
            catch (Exception e)
            {   
                return BadRequest(new {e.Message});
            }
        }

        [HttpDelete]
        public IActionResult Delete(int alunoId, int turmaId)
        {
            try
            {
                _matriculaService.Delete(alunoId,turmaId);
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