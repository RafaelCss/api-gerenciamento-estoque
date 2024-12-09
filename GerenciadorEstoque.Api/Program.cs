using Infra.Configuracao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Carrega o appsettings.local.json apenas no ambiente de desenvolvimento
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.local.json" , optional: true , reloadOnChange: true);
}
builder.Services.AddOpenApi();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraConfiguracao(builder.Configuration);

var app = builder.Build();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json" , "v1");
    });

}
app.UseHttpsRedirection();
 
app.UseAuthorization();

app.MapControllers();

app.Run();
