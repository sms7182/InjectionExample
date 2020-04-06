using InjectionInterface;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EntityModelController : ControllerBase
{


    // public IRepository Repository { get; }
    // public EntityModelController(IRepository repository)
    // {
    //     this.Repository = repository;

    // }

    // [HttpGet("print")]
    // public bool Print()
    // {        
    //     return false;
    // }
    private IComponentInterceptor Interceptor { get; }

    private IHandleService _handleService { get; }
    public EntityModelController(IHandleService handleService, IComponentInterceptor interceptor)
    {
        this.Interceptor = interceptor;
        _handleService = handleService;
    }



    [HttpGet("print")]
    public bool Print()
    {
        _handleService.PrintAll();
        Interceptor.SaveDb();
        return false;
    }

}