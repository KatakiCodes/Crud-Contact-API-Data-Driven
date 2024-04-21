using AgendaAPI.Models;
using System.Threading.Tasks;
using AgendaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace AgendaAPI.Controllers
{
    [Route("contact")]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get([FromServices] DataContext dataContext){
                var contactList = await dataContext.Contact.AsNoTracking().ToListAsync();
                return Ok(contactList);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Contact>> GetById(int id, [FromServices]DataContext dataContext){
            var contact = await dataContext.Contact.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            if(contact == null)
                return NotFound(new{message="Contacto nao encontrado!"});
            return Ok(contact);
        }
        //Comment to test check chenges of vscode gitHub
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Contact>> Post(
            [FromServices]DataContext dataContext,
            [FromBody]Contact model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                dataContext.Contact.Add(model);
                await dataContext.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new {message = "Nao foi possivel criar este contacto!"});
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Contact>> Put(
            int id,
            [FromServices] DataContext dataContext,
            [FromBody] Contact model
        )
        {
            Contact contact = await dataContext.Contact.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            if(contact == null)
                return BadRequest(new{message = "Nao foi possivel encontrar este contacto!"});
            try
            {
                dataContext.Entry<Contact>(model).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                return Ok(new {message = "Contacto atualizado com sucesso!"});
            }
            catch
            {
                return BadRequest(new{message = "Nao foi possivel alterar este contacto!"});
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(
            int id,
            [FromServices] DataContext dataContext,
            [FromBody] Contact model
        )
        {
            Contact contact = await dataContext.Contact.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            if(contact == null)
                return BadRequest(new {message = "Nao foi possivel encontrar este contacto!"});
            try
            {
                dataContext.Contact.Remove(model);
                await dataContext.SaveChangesAsync();
                return Ok(new {message = "Contacto excluido com sucesso!"});
            }
            catch
            {
                return BadRequest(new {message = "Nao foi possivel excluir este contacto!"});
            }
        }
    }
}