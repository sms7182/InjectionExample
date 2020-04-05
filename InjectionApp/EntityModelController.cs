using InjectionInterface;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EntityModelController:ControllerBase
{
    private IHandleService _handleService { get; }
    public EntityModelController(IHandleService handleService)
    {
        _handleService = handleService;
    }
    // public IRepository Repository { get; }
    // public EntityModelController(IRepository repository)
    // {
    //     this.Repository = repository;

    // }
    
    [HttpGet("print")]
    public bool Print()
    {
        _handleService.PrintAll();
        return false;
    }

}