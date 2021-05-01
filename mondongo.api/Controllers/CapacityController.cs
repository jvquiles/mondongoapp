using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mondongo.domain.services.capacity;

namespace mondongo.api.Controllers
{
    [ApiController]
    [Route("api/capacity")]
    public class CapacityController : ControllerBase
    {
        private readonly ILogger<CapacityController> logger;
        private readonly ICapacityRepository capacityRepository;

        public CapacityController(ILogger<CapacityController> logger, ICapacityRepository capacityRepository)
        {
            this.logger = logger;
            this.capacityRepository = capacityRepository;
        }

        [HttpGet]
        public int Get()
        {
            int capacity = this.capacityRepository.GetCurrent();
            return capacity;
        }

        [HttpPost("Increase")]
        public void Increase()
        {
            this.capacityRepository.Increase();
        }

        [HttpPost("Decrease")]
        public void Decrease()
        {
            this.capacityRepository.Decrease();
        }
    }
}