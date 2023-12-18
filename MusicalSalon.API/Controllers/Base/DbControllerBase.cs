using Microsoft.AspNetCore.Mvc;
using MusicalSalon.Database.DbWorkers.Base;
using MusicalSalon.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicalSalon.API.Controllers.Base {
    public abstract class DbControllerBase<T, Y> : ControllerBase where T : IDbWorker<Y>, new() {
        private readonly IDbWorker<Y> _dbWorker;

        public DbControllerBase() {
            _dbWorker = new T();
        }

        [HttpGet("all")]
        public IEnumerable<Y> GetAll() => _dbWorker.GetAll();

        [HttpPost("delete")]
        public void Delete(int id) => _dbWorker.Delete(id);

        [HttpPost("add")]
        public void Add([FromBody] Y entity) => _dbWorker.Add(entity);

        [HttpPost("edit")]
        public void Edit([FromBody] Y updatedEntity) => _dbWorker.Edit(updatedEntity);

        [HttpGet("{id}")]
        public Y GetById(int id) => _dbWorker.GetById(id);

    }
}
