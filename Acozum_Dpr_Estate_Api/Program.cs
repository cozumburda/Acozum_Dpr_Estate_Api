using Acozum_Dpr_Estate_Api.Controllers;
using Acozum_Dpr_Estate_Api.Hubs;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Acozum_Dpr_Estate_Api.Repositories.BottomGridRepositories;
using Acozum_Dpr_Estate_Api.Repositories.CategoryRepository;
using Acozum_Dpr_Estate_Api.Repositories.ContactRepositories;
using Acozum_Dpr_Estate_Api.Repositories.EmployeeRepositories;
using Acozum_Dpr_Estate_Api.Repositories.PopularLocationRepositories;
using Acozum_Dpr_Estate_Api.Repositories.ProductRepository;
using Acozum_Dpr_Estate_Api.Repositories.ServiceRepository;
using Acozum_Dpr_Estate_Api.Repositories.StatisticsRepositories;
using Acozum_Dpr_Estate_Api.Repositories.TestimonialRepositories;
using Acozum_Dpr_Estate_Api.Repositories.ToDoListRepositories;
using Acozum_Dpr_Estate_Api.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
    .AllowCredentials();
    });
});
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
app.Run();
