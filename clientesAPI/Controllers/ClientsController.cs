using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;
using Services.Models;

namespace clientesAPI.Controllers
{
    [Route("client-management/clients")]
    public class ClientsController : ControllerBase
    {
        private IClientServices _clientServices;
        private IConfiguration _configuration;

        public ClientsController(IClientServices clientServices, IConfiguration configuration) {
            _clientServices = clientServices;
            _configuration = configuration;
        }

        
        // GET api/clients
        [HttpGet]
        public IEnumerable<ClientDTO> Get()
        {
            return _clientServices.GetAll();
        }

        // GET api/clients/MT-000065
        [HttpGet("{id}")]
        public ClientDTO Get([FromRoute] string id)
        {
            return _clientServices.GetClient(id);
        }

        // POST api/clients
        [HttpPost]
        public IActionResult Post([FromBody] ClientDTO client)
        {
            return Ok(_clientServices.CreateClient(client));
        }

        // PUT api/clients/MT-000065
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] ClientDTO client)
        {
            return Ok(_clientServices.UpdateClient(id, client));
        }

        // DELETE api/clients/MT-000065
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            _clientServices.DeleteClient(id);
            return Ok();
        }
    }
}