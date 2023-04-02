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
        public async Task<IActionResult> Register(AlunoViewModel alunoViewModel, int turmaId)
        {

            try
            {   
                var alunoEntity = _mapper.Map<Aluno>(alunoViewModel);

                await _alunoservice.Register(alunoEntity,turmaId);

                alunoViewModel.Id = alunoEntity.Id;

                return StatusCode(StatusCodes.Status201Created,alunoViewModel);
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
        public async Task<IActionResult> Update(AlunoUpdateViewModel alunoUpdateViewModel, int id)
        {
            try
            {   

                var alunoEntity = _mapper.Map<Aluno>(alunoUpdateViewModel);

                await _alunoservice.Update(alunoEntity,id);

                alunoUpdateViewModel.Id = id;

                return Ok(alunoUpdateViewModel);


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
                await _alunoservice.Delete(id);
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