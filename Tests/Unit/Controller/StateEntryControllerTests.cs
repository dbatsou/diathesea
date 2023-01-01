using System.Net;
using API.Controllers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Tests;

public class StateEntryControllerTests
{
    private readonly ILogger<StateEntryController> _logger = Substitute.For<ILogger<StateEntryController>>();
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    
    [Fact]
    public async Task GetStateEntries_Returns200OK()
    {
        var controller = new StateEntryController(_logger, _mediator);
        
        var request = await controller.GetStateEntries();
        
        var okResult = request.Result as OkObjectResult;
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
    }
    
    [Fact]
    public async Task GetStateEntryById_Returns200OK()
    {
        var controller = new StateEntryController(_logger, _mediator);
        
        var request = await controller.GetStateEntryById(0);
        
        var okResult = request.Result as OkObjectResult;
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
    }

    [Fact]
    public async Task Create_Returns201Created()
    {
        var controller = new StateEntryController(_logger, _mediator);
        var entry = new StateEntry();
        var request = await controller.Create(entry);

        var createdResult = request as CreatedResult;
        Assert.Equal((int) HttpStatusCode.Created, createdResult.StatusCode);
    }
    
    [Fact]
    public async Task Edit_Returns201Created()
    {
        var controller = new StateEntryController(_logger, _mediator);
        var entry = new StateEntry();
        var request = await controller.Edit(entry);

        var okResult = request.Result as OkObjectResult;
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
    }
    
    [Fact]
    public async Task DeleteStateEntryById_Returns201Created()
    {
        var controller = new StateEntryController(_logger, _mediator);
        
        var request = await controller.DeleteStateEntryById(0);

        var okResult = request.Result as OkObjectResult;
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
    }
}