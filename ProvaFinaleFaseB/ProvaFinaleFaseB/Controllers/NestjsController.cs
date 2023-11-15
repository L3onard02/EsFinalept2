using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProvaFinaleFaseB.DTOs;
using ProvaFinaleFaseB.Entities;
using ProvaFinaleFaseB.Repository;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaFinaleFaseB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NestjsController : ControllerBase
    {
        private ILogsRepository _logsRepository;
        public NestjsController(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

       


        // PUT api/<NestjsController>/5
        [HttpPut("ordina/{id}")]
        async public Task<ActionResult<string>> Ordina(int id, [FromBody] Ordina_vendiDTO giacenzaDTO)
        {
            try
            {
                string path = $"http://localhost:3000/prodotto/ordina/{id}";

                using (HttpClient client = new HttpClient())
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(giacenzaDTO),
                                                        Encoding.UTF8, "application/json");

                    var risposta = await client.PatchAsync(path, stringContent);
                    var content = await risposta.Content.ReadAsStringAsync();

                    if (risposta.IsSuccessStatusCode)
                    {
                        LogsEntity logE = new LogsEntity
                        {
                            Messaggio = "Ordine effettuato",
                            TimeStamp = DateTime.Now,
                            EndpointUrl = path
                        };

                        await _logsRepository.PostLog(logE);

                        return Ok(content); 
                    }
                    else
                    {
                        

                        return StatusCode((int)risposta.StatusCode, content); 
                    }
                }
            }
            catch (Exception ex)
            {
          
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta."); 
            }

          
        }
        [HttpPut("vendi/{id}")]
        async public Task<ActionResult<string>> vendi( int id,[FromBody] Ordina_vendiDTO giacenzaDTO)
        {



            try
            {
                string path = $"http://localhost:3000/prodotto/ordina/{id}";

                using (HttpClient client = new HttpClient())
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(giacenzaDTO),
                                                        Encoding.UTF8, "application/json");

                    var risposta = await client.PatchAsync(path, stringContent);
                    var content = await risposta.Content.ReadAsStringAsync();

                    if (risposta.IsSuccessStatusCode)
                    {
                        LogsEntity logE = new LogsEntity
                        {
                            Messaggio = "vendita effettuata",
                            TimeStamp = DateTime.Now,
                            EndpointUrl = path
                        };

                        await _logsRepository.PostLog(logE);

                        return Ok(content);
                    }
                    else
                    {


                        return StatusCode((int)risposta.StatusCode, content);
                    }
                }
            }
            catch (Exception ex)
            {


                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta.");
            }
        }

       
    }
}
