using Microsoft.AspNetCore.Mvc;
using teste_desafio.service;
using AutoMapper;
using teste_desafio.viewmodel;
using teste_desafio.domain.entities;
using teste_desafio.failures;

namespace teste_desafio.Controllers
{
    [ApiController]
    [Route("aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoservice;
        private readonly IMapper _mapper;
  
        public AlunoController(IAlunoService alunoService, IMapper mapper)
        {

            _alunoservice = alunoService;
            _mapper = mapper;

        }


        [HttpPost]
        public IActionResult Register(AlunoViewModel alunoViewModel, int turmaId)
        {

            try
            {   
                var alunoEntity = _mapper.Map<Aluno>(alunoViewModel);

                _alunoservice.Register(alunoEntity,turmaId);

                var alunoRegistered = _mapper.Map<AlunoViewModel>(alunoEntity);

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
                var alunosEntity = _alunoservice.GetAll();

                var alunosViewModel = _mapper.Map<List<AlunoViewModel>>(alunosEntity);

                return Ok(alunosViewModel);

            }
            catch (Exception e)
            {
                
                return BadRequest(new {e.Message});
            }
 
        }

        [HttpPatch]
        public IActionResult Update(AlunoViewModel alunoViewModel, int id)
        {
            try
            {   

                var alunoEntity = _mapper.Map<Aluno>(alunoViewModel);

                _alunoservice.Update(alunoEntity,id);

                var alunoUpdated = _mapper.Map<AlunoViewModel>(alunoEntity);

                return Ok(alunoUpdated);


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
                _alunoservice.Delete(id);
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