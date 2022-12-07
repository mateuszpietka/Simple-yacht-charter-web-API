using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using YachtCharterWebApp.Application.DTOs;
using YachtCharterWebApp.Core.Repositories;

namespace YachtCharterWebApp.Controllers
{
    [ApiController]
    [Route("yacht")]
    public class YachtController : ControllerBase
    {
        private readonly IYachtRepository _yachtRepository;

        public YachtController(IYachtRepository yachtRepository)
        {
            _yachtRepository = yachtRepository;
        }

        [HttpGet]
        public IEnumerable<YachtDto> GetAll()
        {
            return _yachtRepository.GetAll().Select(x => new YachtDto(x));
        }

        [HttpGet]
        [Route("{id}")]
        public YachtDto Get([FromRoute] int id)
        {
            var yacht =  _yachtRepository.GetById(id);

            return new YachtDto(yacht);
        }
    }
}
