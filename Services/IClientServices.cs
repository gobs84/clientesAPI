using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace Services
{
    public interface IClientServices
    {
        IEnumerable<ClientDTO> GetAll();
        ClientDTO GetClient(string id);
        ClientDTO CreateClient(ClientDTO client);
        ClientDTO UpdateClient(string id, ClientDTO client);
        void DeleteClient(string id);
    }
}
