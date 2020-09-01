using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class GetDemoRepository : IGetDemoRepository
    {
        private readonly summerwellContext _dbContext;

        public GetDemoRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DemoModel> GetDemo(string name)
        {
            List<Conference> conferences = _dbContext.Conference.Include(x => x.ConferenceType).ToList();
            List<DemoModel> demoModels = conferences.Select(a => new DemoModel() { Id = a.ConferenceId, Name = a.ConferenceType.DictionaryConferenceTypeName }).ToList();
            HttpClient client = new HttpClient();
            var response = client.GetAsync("http://localhost:2794/api/Home/{DemoName}");
           // string content = response.Content.ReadAsStringAsync();



            return demoModels;
        }
    }
}
