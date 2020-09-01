using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Conference> demos = _dbContext.Conference.ToList();

            List<DemoModel> demoModels = demos.Select(a => new DemoModel() { Id = a.ConferenceId, Name = a.ConferenceName }).ToList();

            return demoModels;
        }
    }
}
