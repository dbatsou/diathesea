using System.Net;
using API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Tests;

public class StateControllerTests
{
    private readonly ILogger<StateController> _logger = Substitute.For<ILogger<StateController>>();
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    
    [Fact]
    public async Task GetStates_Returns200OK()
    {
        var controller = new StateController(_logger, _mediator);
        
        var request = await controller.GetStates();
        
        var okResult = request.Result as OkObjectResult;
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
    }
    
    [Fact]
    public async Task GetStatesForParentStateId_Returns200OK()
    {
        var controller = new StateController(_logger, _mediator);
        
        var request = await controller.GetStatesForParentStateId(0);
        
        var okResult = request.Result as OkObjectResult;
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
    }

    [Fact]
    public async Task GetStateById_Returns200OK()
    {
        var controller = new StateController(_logger, _mediator);

        var request = await controller.GetStateById(0);

        var okResult = request.Result as OkObjectResult;
        Assert.Equal((int) HttpStatusCode.OK, okResult.StatusCode);
    }
}