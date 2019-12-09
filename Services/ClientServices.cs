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
            ClientDTO cl = new ClientDTO();
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
            if (id==cl1.ClientId)
            {
                cl = cl1;
            }
            else
            {
                cl = cl2;
            }
            return cl;
        }

        public ClientDTO CreateClient(ClientDTO client)
        {
            try
            {
                string id = createId(client.Name, client.LastName, client.CI);
                Console.WriteLine($"cliente creado: \n CI: {client.CI},Nombre: {client.Name} {client.LastName}\n ID: {id}");
                client.ClientId = id;
                return client;
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        public ClientDTO UpdateClient(string id, ClientDTO client)
        {
            try
            {
                string nid = createId(client.Name, client.LastName, client.CI);
                Console.WriteLine($"cliente modificado: \n CI: {client.CI}, \n Nombre: {client.Name} {client.LastName} \n Su ID: {id}");
                client.Name = "Modified Name";
                client.ClientId = nid;
                return client;
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        public void DeleteClient(string id)
        {
            try
            {
                //Console.WriteLine($"cliente eliminado con ID: \n CI: {id}");
                throw new ArgumentNullException("soy un error");
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        private string createId(string name, string lastName, string ci)
        {
            string clientId = $"{name.Substring(0, 1)}{lastName.Substring(0, 1)}-{ci}";
            return clientId;
        }
    }
}
