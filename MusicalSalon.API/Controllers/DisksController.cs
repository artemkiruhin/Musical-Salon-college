using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicalSalon.API.Controllers.Base;
using MusicalSalon.Database.DbWorkers;
using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DisksController : DbControllerBase<DisksDbWorker, Disk> {
        public DisksController() : base() {
        }
    }
}
