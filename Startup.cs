using Microsoft.AspNetCore.Builder;
using MuleReplacementPOC.Services;

namespace MuleReplacementPOC
{
    public class Startup
    {
        public void ConfigureServicess(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient<ExpenseTrackerService>();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
