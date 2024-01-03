using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs;
using System;
using System.Net;
using System.Text;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SaldoInteligente.ApiTests.ApiValidations
{
    public class BalanceCheckingStatementTest
    {
        string serverUrl = "https://localhost:7115/api/v1";
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        int randomNumber = new Random().Next(1, 10000);

        public BalanceCheckingStatementTest(ITestOutputHelper output)
        {
            _client = new HttpClient();
            _output = output;
        }

        [Fact]
        public async Task Find_ReturnsOkResponse()
        {
            var statement = new FindRangeDateDTO
            {
                InitialDate = DateTime.Now,
                FinalDate = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(statement);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PatchAsync($"{serverUrl}/BalanceCheckingStatement/Find", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddLooseEntry_ReturnsOkResponse()
        {            

            var statement = new AddLooseEntryDTO
            {
                Value = 100.0m,
                Description = "Test " + randomNumber
            };

            var json = JsonConvert.SerializeObject(statement);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{serverUrl}/BalanceCheckingStatement/AddLoose", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddLooseEntry_Negative()
        {            

            var statement = new AddLooseEntryDTO
            {
                Value = -100.0m,
                Description = "Test negative" + randomNumber
            };

            var json = JsonConvert.SerializeObject(statement);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{serverUrl}/BalanceCheckingStatement/AddLoose", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task<HttpResponseMessage> AddLooseEntry()
        {

            var statement = new AddLooseEntryDTO
            {
                Value = 100.0m,
                Description = "Test same"
            };

            var json = JsonConvert.SerializeObject(statement);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{serverUrl}/BalanceCheckingStatement/AddLoose", content);

            return response;
        }

        [Fact]
        public async Task AddLooseEntry_ReturnsFail_SameName()
        {
            await this.AddLooseEntry();

            var response = await AddLooseEntry();

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            }
        }

        [Fact]
        public async Task AddNotLooseEntry_Negative()
        {            
            var statement = new AddNotLooseEntryDTO
            {
                Value = -100.0m,
                Description = "Test não avulso " + randomNumber,
                InputDate = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(statement);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PostAsync($"{serverUrl}/BalanceCheckingStatement/AddNotLoose", content);
            
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddNotLooseEntry_ReturnsOkResponse()
        {            
            var statement = new AddNotLooseEntryDTO
            {
                Value = 100.0m,
                Description = "Test não avulso " + randomNumber,
                InputDate = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(statement);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PostAsync($"{serverUrl}/BalanceCheckingStatement/AddNotLoose", content);
            
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task<HttpResponseMessage> AddNotLooseEntry()
        {

            var statement = new AddNotLooseEntryDTO
            {
                Value = 100.0m,
                Description = "Test n�o avulso same",
                InputDate = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(statement);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{serverUrl}/BalanceCheckingStatement/AddNotLoose", content);

            return response;
        }

        [Fact]
        public async Task AddNotLooseEntry_ReturnsFail_SameName()
        {
            await this.AddNotLooseEntry();

            var response = await AddNotLooseEntry();

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            }
        }

        [Fact]
        public async Task Change_ReturnsOkResponse()
        {
            
            var statement = new ChangeDTO
            {
                Id = 4,
                Value = 102.0m,
                InputDate = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(statement);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync($"{serverUrl}/BalanceCheckingStatement/Change", content);
            
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Cancel_ReturnsOkResponse()
        {
            var idToCanel = 2;
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{serverUrl}/BalanceCheckingStatement/Cancel/{idToCanel}", content);
            
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}