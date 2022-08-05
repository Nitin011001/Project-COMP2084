using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Project_comp2084.Models;
using Project_comp2084.Data;
using Project_comp2084.Controllers;


namespace Project_comp2084.Tests
{
    public class TestsHelp
    {
        protected readonly DbContextOptions<ApplicationDbContext> _opts;

        public TestsHelp()
        {
            _opts = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestJobCntl").Options;
        }

        protected List<Client> MakeFakeclients(int i)
        {
            var jobs = new List<Client>();
            for (int j = 0; j < i; j++)
            {
                jobs.Add(new Client
                {
                    CompanyName = $"test{j}",
                    Location = $"testSec{j}",
                    
                });
            }
            return jobs;
        }

        protected List<Vehicle> MakeFakeVehicles(int i)
        {
            var cad = new List<Vehicle>();
            for (int j = 0; j < i; j++)
            {
                cad.Add(new Vehicle
                {
                    type = $"test{j}",
                    Cost = j*1000,
                });
            }
            return cad;
        }

    }
}
