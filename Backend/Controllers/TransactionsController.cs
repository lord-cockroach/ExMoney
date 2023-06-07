using ExMoney.SharedLibs;
using ExMoney.SharedLibs.DTOs;
using AutoMapper;
using ExMoney.Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExMoney.Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionsController: ControllerBase
    {
        private readonly IMapper mapper;
        private readonly BackendDbContext db;

        public TransactionsController(IMapper mapper, BackendDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet("list")]
        public Task<List<Transaction>> List(string userId)
        {
            return db.Transactions.ToListAsync();
        }

        [HttpGet("latest/{userId}")]
        public IEnumerable<Transaction> ListLatests(string userId, int count)
        {
            var latestTransactions = db.Transactions.OrderByDescending(t => t.Date).Take(count);
            return latestTransactions;
        }

        [HttpGet("ongoing/{userId}")]
        public IEnumerable<Transaction> ListOngoing(string userId, int count)
        {
            var ongoingTransactions = db.Transactions.Where(t => t.Status == TransactionStatus.Processing).Take(count);
            return ongoingTransactions;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Transaction>> Add(string userId, TransactionCreateDTO data)
        {
            var transaction = mapper.Map<Transaction>(data);

            //TOD0: define rate
            transaction.Rate = Random.Shared.NextDouble() * Random.Shared.Next(maxValue: 900, minValue: 1);
            transaction.Date = DateTime.Now;
            transaction.Status = TransactionStatus.Accepted;

            try
            {
                db.Transactions.Add(transaction);
                await db.SaveChangesAsync();
                //TODO: propagate transaction created, prompt for payment  
            }
            catch (System.Exception)
            {
                return new ObjectResult(new ProblemDetails
                {
                    Status = 500,
                    Title = "Unknow error"
                });
            }


            return Created(nameof(Add), transaction);
        }

    }
}
