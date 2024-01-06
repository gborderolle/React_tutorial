using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace WebAPI_tutorial_peliculas.Utilities
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var propertyName = bindingContext.ModelName;
            var valueProvider = bindingContext.ValueProvider.GetValue(propertyName);
            if (valueProvider == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            try
            {
                var decentralizedValue = JsonConvert.DeserializeObject<T>(valueProvider.FirstValue);
                bindingContext.Result = ModelBindingResult.Success(decentralizedValue);
            }
            catch
            {
                bindingContext.ModelState.TryAddModelError(propertyName, "Valor inválido para tipo List<T>");
            }
            return Task.CompletedTask;
        }

    }
}