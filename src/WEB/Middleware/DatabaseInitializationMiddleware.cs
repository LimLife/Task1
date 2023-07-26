using Application.Interfaces;
using Application.Services;

namespace WEB.Middleware
{
    public class DatabaseInitializationMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseInitializationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRepository repository)
        {
            if (await repository.IsEmptyDataBase() == false)
            {
                var addDefinitionalData = new AddData(repository);
                addDefinitionalData.AddDataToBD();
            }

            await _next(context);
        }
    }
}
