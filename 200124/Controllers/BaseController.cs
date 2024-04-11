using _200124.Comon;
using _200124.Models;
using _200124.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _200124.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : Base
    {
        private IBaseRepository<T> _repository;
        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        [Authorize(Roles = "ADMIN , SUBADMIN , CUSTOMER")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<T>>> GetAll(bool isAsc = true , int index = 1, int size = 3)
        {
            var result = await _repository.GetAll(isAsc, index, size);
            return Ok(result);

        }
        [Authorize(Roles = "ADMIN , SUBADMIN , CUSTOMER")]
        [HttpPost]
        [Route("FullFilter")]
        public async Task<ActionResult<List<T>>> FullFilter([FromBody] GetRequestDTO requestDTO)
        {
            var result = await _repository.FullFilter(requestDTO);
            return Ok(result);
        }
        [Authorize(Roles = "ADMIN , SUBADMIN , CUSTOMER")]
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Class>> GetById(int id)
        {
            var result = await (_repository.GetById(id));
            return Ok(result);
        }
        [Authorize(Roles = "ADMIN , SUBADMIN")]
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Class>> Create(T entity)
        {
            var result = await _repository.Create( entity);
            return Ok(result);
        }
        [Authorize(Roles = "ADMIN , SUBADMIN")]
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Class>> Update(T entity)
        {
            var result = await (_repository.Update(entity));
            return Ok(result);
        }
        [Authorize(Roles = "ADMIN , SUBADMIN")]
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<Class>> Delete(int id)
        {
            var result = await (_repository.Delete(id));
            return Ok(result);
        }


    }
}
