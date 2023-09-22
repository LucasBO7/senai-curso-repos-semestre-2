using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository { get; set; }

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }



    }
}
