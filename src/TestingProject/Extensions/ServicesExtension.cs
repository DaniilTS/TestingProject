namespace TestingProject.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton(builder.Configuration);
        }
    }
}
