using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Reflection;
using XXLY.CarFinancingRentSystem._2004A.API;
using XXLY.CarFinancingRentSystem._2004A.Dapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//APIע��
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "XXLY.CarFinancingRentSystem.2004A.API", Version = "v1" });

    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
    //��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
    var xmlPath = Path.Combine(basePath, "APIDemo.xml");
    c.IncludeXmlComments(xmlPath, true);//true:��ʾ������ע��
    c.OrderActionsBy(o => o.RelativePath);

    //jwt
    c.OperationFilter<Swashbuckle.AspNetCore.Filters.AddResponseHeadersFilter>();
    c.OperationFilter<Swashbuckle.AspNetCore.Filters.AppendAuthorizeToSummaryOperationFilter>();
    c.OperationFilter<Swashbuckle.AspNetCore.Filters.SecurityRequirementsOperationFilter>();
    //��header�����Token�����ݵ���̨
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
});
//��Сд
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.PropertyNamingPolicy = null);
//�������ݿ�
builder.Services.AddSingleton(db =>
    new DapperDbContext(
        builder.Configuration.GetConnectionString("Servers"),
        XXLY.CarFinancingRentSystem._2004A.Domain.Sql.MySql
    )
);
//����
builder.Services.AddCors((x) =>
{
    x.AddPolicy("k", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
//�쳣����
builder.Services.AddMvc(x =>
{
    x.Filters.Add(typeof(ExceptionHandling));
});
//��֤Token
builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x => {
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = "http://localhost:5238",
        ValidIssuer = "http://localhost:5238",
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes("1111111111111111")
            )
    };
});

//ע��autofac module
builder.Host.UseServiceProviderFactory(new Autofac.Extensions.DependencyInjection.AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<Autofac.ContainerBuilder>(builder =>
{
    //��Ҫ����Autofac����ռ� 
    builder.RegisterModule<XXLY.CarFinancingRentSystem._2004A.API.AutofacDependencyInjection>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("k");
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.Run();