using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FirstCoreMVCWebApplication.Models.Binder
{
    public class ComplexUserModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(ComplexUser))
                return new ComplexUserModelBinder();
            return null;
        }
    }
}
