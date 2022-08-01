using ChallengeBp4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBp4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ClientsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = dbContext.Client.ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                var log = new LogData() { Date = DateTime.Now, Message = ex.Message, Action = "GetAll", StackTrace = ex.StackTrace };
                dbContext.LogData.Add(log);
                dbContext.SaveChanges();
                return BadRequest(log);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var client = dbContext.Client.FirstOrDefault(x => x.Id == id);

                if (client == null)
                    return NotFound();
                else
                    return Ok(client);
            }
            catch (Exception ex)
            {
                var log = new LogData() { Date = DateTime.Now, Message = ex.Message, Action = "GetById", StackTrace = ex.StackTrace };
                dbContext.LogData.Add(log);
                dbContext.SaveChanges();
                return BadRequest(log);
            }
        }

        [HttpGet("search/{name}")]
        public IActionResult Search(string name)
        {
            try
            {
                var clients = dbContext.Client.Where(x => x.Name.Contains(name) || x.Surname.Contains(name));

                if (clients == null)
                    return NotFound();
                else
                    return Ok(clients);
            }
            catch (Exception ex)
            {
                var log = new LogData() { Date = DateTime.Now, Message = ex.Message, Action = "Search",  StackTrace = ex.StackTrace };
                dbContext.LogData.Add(log);
                dbContext.SaveChanges();
                return BadRequest(log);
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.Client.Add(client);
                    dbContext.SaveChanges();
                    return Ok();
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                var log = new LogData() {  Date = DateTime.Now, Message = ex.Message, Action = "Insert", StackTrace = ex.StackTrace };
                dbContext.LogData.Add(log);
                dbContext.SaveChanges();
                return BadRequest(log);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Client client, int id)
        {
            try
            {
                if (client.Id != id)
                    return BadRequest();

                if (ModelState.IsValid)
                {
                    var clientDb = dbContext.Client.FirstOrDefault(x => x.Id == id);

                    if (clientDb != null)
                    {
                        clientDb.Name = client.Name;
                        clientDb.Surname = client.Surname;
                        clientDb.Birthdate = client.Birthdate;
                        clientDb.Address = client.Address;
                        clientDb.CUIT = client.CUIT;
                        clientDb.Email = client.Email;
                        clientDb.Phone = client.Phone;
                        dbContext.SaveChanges();
                        return Ok();
                    }
                    else
                        return NotFound();
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                var log = new LogData() { Date = DateTime.Now, Message = ex.Message, Action = "Update", StackTrace = ex.StackTrace };
                dbContext.LogData.Add(log);
                dbContext.SaveChanges();
                return BadRequest(log);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var client = dbContext.Client.FirstOrDefault(x => x.Id == id);

                if (client == null)
                    return NotFound();

                dbContext.Client.Remove(client);
                dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                var log = new LogData() { Date = DateTime.Now, Message = ex.Message, Action = "Delete", StackTrace = ex.StackTrace };
                dbContext.LogData.Add(log);
                dbContext.SaveChanges();
                return BadRequest(log);
            }
        }
    }
}
