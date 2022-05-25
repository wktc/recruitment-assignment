namespace Common.Domain.ActionContext
{
    public interface IActionContextProvider
    {
        ActionContext ActionContext { get; }

        void RegisterContext(ActionContext actionContext);
    }
}
