using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditionController : ControllerBase
    {
        private readonly ILogger<EditionController> logger;

        private readonly IEditionService editionService;

        public EditionController(ILogger<EditionController> logger, IEditionService editionService)
        {
            this.logger = logger;
            this.editionService = editionService;
        }

        [HttpGet]
        public List<Edition> Get()
        {
            try
            {
                return editionService.GetAll(0, 10);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
