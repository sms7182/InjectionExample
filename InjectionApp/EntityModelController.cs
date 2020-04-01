using InjectionInterface;

public class EntityModelController{
    private IHandleService _handleService { get; }
    public EntityModelController(IHandleService handleService)
    {
        _handleService = handleService;
    }

    public void Print(){
        _handleService.PrintAll();
    }

}