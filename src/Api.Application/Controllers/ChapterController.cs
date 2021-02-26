using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interface.Services;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{

    [EnableCors("Development")]
    [ApiController]
    [Route("api/[controller]")]    
    public class ChapterController : ControllerBase
    {
        private IChapterService _service;

        public ChapterController(IChapterService service)
        {
            this._service = service;
        }

        
        [EnableCors("Development")]
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Chapter>>> Get() 
        { 
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
        [Route("{id}", Name = "GetWithIdChapter")]
        public async Task<ActionResult<Chapter>> Get(Guid id)
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
        public async Task<ActionResult<Chapter>> Post([FromBody] Chapter c)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(c);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithIdChapter", new { id = result.Id })), result);
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
        public async Task<ActionResult<Chapter>> Put([FromBody] Chapter c)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(c);
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
        public async Task<ActionResult<List<Chapter>>> Put([FromBody] Chapter[] c)
        {
                        
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.PutAll(c);
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
        [HttpDelete("{id}")]
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
