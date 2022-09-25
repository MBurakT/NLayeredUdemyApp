using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.Dtos;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.Web
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            int id = (int)idValue;

            bool isEntity = await _service.AnyAsync(p => p.Id == id);

            if (isEntity)
            {
                await next.Invoke();
                return;
            }

            ErrorViewModel errorViewModel = new();

            errorViewModel.Errors.Add($"{typeof(T).Name}({id}) not found!");

            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
}
