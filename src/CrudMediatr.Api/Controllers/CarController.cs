using CrudMediatr.Api.Models.Car;
using CrudMediatr.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudMediatr.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly IMediator _mediator;

        public CarController(
            ILogger<CarController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public Task Create(
            CreateCarRequest request,
            CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpPost("Read")]
        public Task<ReadResultModel<CarModel>> Read(
            ReadCarRequest<CarModel> request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("→ Read");
            return _mediator.Send(request, cancellationToken);
        }

        [HttpPost("Update")]
        public Task Update(
            UpdateCarRequest request,
            CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpPost("Delete")]
        public Task UpdDeleteate(
            DeleteCarRequest request,
            CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}
