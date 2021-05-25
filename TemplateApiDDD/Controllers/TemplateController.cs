using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApiDDD.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TemplateController : Controller
    {
        private readonly TemplateService TemplateService;

        public TemplateController(TemplateService _TemplateService)
        {
            TemplateService = _TemplateService;
        }

        //Get
        [HttpGet]
        public async Task<IEnumerable<Template>> GetTemplate()
        {
            return await TemplateService.GetAllTemplate();
        }

        //Get/{id}
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<Template>> GetTemplate(int? id)
        {
            if (id == null)
                return BadRequest("Please, provide an Id");
            else
            {
                return await TemplateService.GetByIdTemplate(id);
            }
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<Template>> PostTemplate([FromBody] Template data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Check the data sent.");
            }
            else
            {
                try
                {
                    var datas = await TemplateService.PostTemplate(data);
                    return Ok(datas);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        //Put
        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult<Template>> PutTemplate(int id, [FromBody] Template Template)
        {
            if (id != Template.Id)
            {
                return BadRequest("The given id is not the same as the json id.");
            }
            else
            {
                try
                {
                    var datas = await TemplateService.PutTemplate(Template);
                    return Ok(datas);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        //Delete
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<Template>> DeleteTemplate(int? id)
        {
            if (id == null)
                return BadRequest("Please, provide an Id");
            else
            {
                try
                {
                    var data = await TemplateService.DeleteTemplate(id);
                    return Ok(data);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }
    }
}
