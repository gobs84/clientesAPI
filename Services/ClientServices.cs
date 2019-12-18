using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Services.Models;

namespace Services
{
    public class ClientServices : IClientServices
    {
        public IEnumerable<ClientDTO> GetAll()
        {
            ClientDTO cl1 = new ClientDTO();
            cl1.Name = "Marwin";
            cl1.LastName = "Torrez";
            cl1.CI = "47623444";
            cl1.Phone = 65824365;
            cl1.Address = "Atahuallpa 1031";
            cl1.Ranking = 5;
            cl1.ClientId = "MT-47623444";
            ClientDTO cl2 = new ClientDTO();
            cl2.Name = "Veimar";
            cl2.LastName = "Choque";
            cl2.CI = "63695635";
            cl2.Phone = 54325245;
            cl2.Address = "Atahuallpa 1031";
            cl2.Ranking = 3;
            cl2.ClientId = "VC-63695635";
            return new List<ClientDTO>() {cl1, cl2};
        }
        
        public ClientDTO GetClient(string id)
        {
            List<ClientDTO> clients = new List<ClientDTO>() {
                new ClientDTO() { Name = "Marwin", LastName = "Torrez", CI = "47623444", Phone = 65824365, Address = "Atahuallpa 1031", Ranking = 5, ClientId = "MT-47623444"},
                new ClientDTO() { Name = "Veimar", LastName = "Choque", CI = "63695635", Phone = 54325245, Address = "Atahuallpa 1031", Ranking = 3, ClientId = "VC-63695635"}
            };
            ClientDTO cl = new ClientDTO();
            ClientDTO clientfinded = clients.Find(x => x.ClientId == id);
            if(clientfinded != null)
            {
                cl = clientfinded;
            }
            else
            {
                throw new ServicesException("The client doesn't exist", 404);
            }
            return cl;
        }

        public ClientDTO CreateClient(ClientDTO client)
        {
            try
            {
                if (client == null)
                {
                    throw new ServicesException("Client data is null", 400);
                }
                else if (String.IsNullOrEmpty(client.Name) | String.IsNullOrEmpty(client.LastName) | String.IsNullOrEmpty(client.CI))
                {
                    throw new ServicesException("Client Name, Lastname or CI is empty", 400);
                }
                else
                {
                    string id = createId(client.Name, client.LastName, client.CI);
                    client.ClientId = id;
                    Console.WriteLine($"cliente creado: \n CI: {client.CI},Nombre: {client.Name} {client.LastName}\n ID: {id}");
                    return client;
                }
            }
            catch (ServicesException ex)
            {
                throw ex;
            }

        }

        public ClientDTO UpdateClient(string id, ClientDTO client)
        {
            List<ClientDTO> clients = new List<ClientDTO>() {
                new ClientDTO() { Name = "Marwin", LastName = "Torrez", CI = "47623444", Phone = 65824365, Address = "Atahuallpa 1031", Ranking = 5, ClientId = "MT-47623444"},
                new ClientDTO() { Name = "Veimar", LastName = "Choque", CI = "63695635", Phone = 54325245, Address = "Atahuallpa 1031", Ranking = 3, ClientId = "VC-63695635"}
            };
            try
            {
                ClientDTO clientfinded = clients.Find(x => x.ClientId == id);
                if (clientfinded != null)
                {
                    if (client == null)
                    {
                        throw new ServicesException("Client data is null", 400);
                    }
                    else if (String.IsNullOrEmpty(client.Name) | String.IsNullOrEmpty(client.LastName) | String.IsNullOrEmpty(client.CI))
                    {
                        throw new ServicesException("Client Name, Lastname or CI is empty", 400);
                    }
                    else
                    {
                        string nid = createId(client.Name, client.LastName, client.CI);
                        Console.WriteLine($"cliente modificado: \n CI: {client.CI}, \n Nombre: {client.Name} {client.LastName} \n Su ID: {id}");
                        client.Name = "Modified Name";
                        client.ClientId = nid;
                        return client;
                    }
                }
                else
                {
                    throw new ServicesException("The client doesn't exist", 404);
                }
            }
            catch (ServicesException ex)
            {
                throw ex;
            }

        }

        public void DeleteClient(string id)
        {
            List<ClientDTO> clients = new List<ClientDTO>() {
                new ClientDTO() { Name = "Marwin", LastName = "Torrez", CI = "47623444", Phone = 65824365, Address = "Atahuallpa 1031", Ranking = 5, ClientId = "MT-47623444"},
                new ClientDTO() { Name = "Veimar", LastName = "Choque", CI = "63695635", Phone = 54325245, Address = "Atahuallpa 1031", Ranking = 3, ClientId = "VC-63695635"}
            };
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    throw new ServicesException("Client ID is empty", 400);
                }
                else
                {
                    ClientDTO clientfinded = clients.Find(x => x.ClientId == id);
                    if (clientfinded != null)
                    {
                        Console.WriteLine($"cliente eliminado con ID: \n CI: {id}");
                    }
                    else
                    {
                        throw new ServicesException("The client doesn't exist", 404);
                    }
                }
            }
            catch (ServicesException ex)
            {
                throw ex;
            }
            
        }

        private string createId(string name, string lastName, string ci)
        {
            string clientId = $"{name.Substring(0, 1)}{lastName.Substring(0, 1)}-{ci}";
            return clientId;
        }
    }
}
