using Bogus;
using BulkInsert.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkInsert.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(ILogger<ApplicationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("InsertBillInformation")]
        public async Task<IActionResult> InsertBillInformation(
            [FromServices] ApplicationDbContext _context)
        {
            for (int i = 0; i < 500; i++)
            {
                var bills = GetBillInformation();

                var sw = new Stopwatch();
                sw.Start();

                foreach (var bill in bills)
                {
                    _context.Add(bill);
                }

                await _context.SaveChangesAsync();

                sw.Stop();

                var numberOfTrackingEntites = _context
                    .ChangeTracker.Entries().Count();

                _context.ChangeTracker.Clear();

                _logger.LogInformation($"{i} - " +
                    $"ElapsedMilliseconds : {sw.ElapsedMilliseconds} - " +
                    $"NumberOfTrackingEntites : {numberOfTrackingEntites}");
            }
            return Ok();
        }

        private List<ElectricityBill> GetBillInformation()
        {
            var customerId = 1;

            var fakeBills = new Faker<ElectricityBill>()
                .RuleFor(o => o.CustomerID, f => customerId++)
                .RuleFor(o => o.BillingPeriodStart, f => f.Date.Past(2))
                .RuleFor(o => o.BillingPeriodEnd, (f, o) => o.BillingPeriodStart.AddDays(f.Random.Number(28, 31)))
                .RuleFor(o => o.TotalUsageKWh, f => f.Random.Long(200, 1000))
                .Generate(2000);

            return fakeBills;
        }
    }
}
