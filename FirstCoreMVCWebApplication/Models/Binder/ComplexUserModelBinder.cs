using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FirstCoreMVCWebApplication.Models.Binder
{
    public class ComplexUserModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var header = bindingContext.HttpContext.Request.Headers;
            var routeData = bindingContext.HttpContext.Request.RouteValues;
            var query = bindingContext.HttpContext.Request.Query;

            var user = new ComplexUser()
            {
                UserName = header["X-UserName"].ToString(),
                Country = routeData["country"].ToString(),
                Age = int.TryParse(query["age"].ToString(), out var age) ? age : 0,
                ReferencedId = query["refId"].ToString()
            };

            bindingContext.Result = ModelBindingResult.Success(user);
            return Task.CompletedTask;
        }
    }
}
