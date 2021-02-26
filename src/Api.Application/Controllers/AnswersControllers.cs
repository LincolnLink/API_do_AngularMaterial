using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface.Services;

namespace Api.Application.Controllers
{

    [EnableCors("Development")]
    [ApiController] //Define que é WebApi
    [Route("api/[controller]")] //Define um roteamento
    public class AnswersController : ControllerBase
    {

        private IAnswerService _service;

        public AnswersController(IAnswerService service)
        {
            this._service = service;

        }

        [EnableCors("Development")]
        [HttpGet]
        [Route("")]            
        public async Task<ActionResult<List<Answer>>> Get() //faz referencia do service
        {
            //parametro removido: [FromServices] IUserService service

            // Pegando o contexto, sem precisar ir na camada de Data e service!
            //[FromServices] DataContext context

            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida!
            }

            try
            {
                return Ok(await _service.GetAll());
                //return Ok(await service.GetAll());
            }
            catch (ArgumentException e) //trata erros de controller!
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        //localhost:5000/api/Answers/id
        [EnableCors("Development")]
        [HttpGet]
        [Route("{id}", Name = "GetAnswer")]           
        public async Task<ActionResult> Get(Guid id)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida!
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e) //trata erros de controller!
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [EnableCors("Development")]
        [HttpPost]
        [Route("")]     
        public async Task<ActionResult<Answer>> Post([FromBody] Answer a)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(a);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetAnswer", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /*
        [EnableCors("Development")]
        [HttpPut]
        [Route("")]       
        public async Task<ActionResult<Answer>> Put([FromBody] Answer a)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(a);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
        */

        [EnableCors("Development")]
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<List<Answer>>> Put([FromBody] Answer[] a)
        {

            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.PutAll(a);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [EnableCors("Development")]
        [HttpDelete("{id}")] //("{id}")
        [Route("{id}")]       
        public async Task<ActionResult> Delete(Guid id)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Delete(id);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}