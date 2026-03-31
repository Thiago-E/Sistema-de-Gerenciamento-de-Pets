using GerenciamentoDePets.BdContextGerenciamentoDePetsContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//adiconar os controlerS


//adiciona o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Contatos",
        Description = "Aplicação para gerenciamneto de contatos",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Francisco Hugo",
            Url = new Uri("https://www.linkedin.com/in/francisco-hugo-ximenes-sales-308ab53a7/")
        },
        License = new OpenApiLicense
        {
            Name = "Exemplo de licensa",
            Url = new Uri("https://example.com/license")
        }
    });

    //Usando a autentiação do swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT: "
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
});

builder.Services.AddDbContext<GerenciamentoDePetsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DeafultConnection")));


app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger(options => { });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.MapControllers();
app.UseAuthentication();

builder.Services.AddControllers();  
builder.Services.AddOpenApi();

app.Run();
