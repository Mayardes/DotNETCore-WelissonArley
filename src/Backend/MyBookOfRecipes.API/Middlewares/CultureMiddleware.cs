using System.Globalization;

namespace MyBookOfRecipes.API.Middlewares
{
    public class CultureMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {

            var getAllCulture = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var requestedLanguage = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("pt-BR");

            if (!string.IsNullOrEmpty(requestedLanguage) && getAllCulture.Any(x => x.Name == requestedLanguage))
            {
                cultureInfo = new CultureInfo(requestedLanguage);
            } 

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await next(context);
        }
    }
}
