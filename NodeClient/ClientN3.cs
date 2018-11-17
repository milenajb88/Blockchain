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
    public class ClientN3
    {
        private HttpClient _client;


        public ClientN3()
        {
            this._client = new HttpClient();
            //Change uri to n3
            this._client.BaseAddress = new Uri("http://localhost:51241");
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


    }
}
