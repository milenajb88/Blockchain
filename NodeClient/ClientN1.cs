using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Newtonsoft.Json;

namespace NodeClient
{
    public class ClientN1
    {
        private HttpClient _client;


        public ClientN1()
        {
            this._client = new HttpClient();
            this._client.BaseAddress = new Uri("http://localhost:51241");
            this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ClientN1(string uri)
        {
            this._client = new HttpClient();
            this._client.BaseAddress = new Uri(uri);
            this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<Ticket> createTicket(Ticket ticket)
        {
            try
            {
                var response = await _client.PostAsync("api/Ticket", stringContent(ticket));

                var resultString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Ticket>(resultString);

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Ticket not saved");
                throw;
            }

        }

        public async Task<Ticket> getTicket(int id)
        {
            try
            {
                var response = await _client.GetAsync("api/Ticket/" + id);

                var resultString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Ticket>(resultString);

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't load ticket");
                throw;
            }

        }

        public async Task<Block> getBlock(int id)
        {
            try
            {
                var response = await _client.GetAsync("api/Block/" + id);

                var resultString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Block>(resultString);

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't load ticket");
                throw;
            }

        }


        public async Task<Block> createBlock(Block Block)
        {
            try
            {
                var response = await _client.PostAsync("api/Block", stringContent(Block));

                var resultString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Block>(resultString);

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Ticket not saved");
                throw;
            }

        }

        private StringContent stringContent(Object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        }

        public async Task<IEnumerable<Block>> getBlocks()
        {
            try
            {
                var response = await _client.GetAsync("api/Block/");

                var resultString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<IEnumerable<Block>>(resultString);

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't load chain");
                throw;
            }

        }

        public async Task<List<Blockchain.Block>> getChainAsync()
        {
            try
            {
                IEnumerable<DAO.Block> result = new List<DAO.Block>();
                result = await Task.Run(async () => { return getBlocks(); }).Result;

                List<Blockchain.Block> chain = new List<Blockchain.Block>();
                foreach (Block b in result)
                {

                    Ticket t = await getTicket(b.IdTicket.Value);
                    DAO.Ticket blockTicket = new DAO.Ticket(t.Id, t.CustomerName, t.AccountId.Value, t.CreateDate.Value, t.ProblemDescription);
                    chain.Add(new Blockchain.Block(b.Id, b.PreviousHash, blockTicket, b.Hash));
                }

                return chain;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't load chain");
                throw;
            }

        }


    }
}
