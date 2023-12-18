using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicalSalon.API.Controllers.Base;
using MusicalSalon.Database.DbWorkers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : DbControllerBase<ReceiptsDbWorker, Receipt> {
    }
}
