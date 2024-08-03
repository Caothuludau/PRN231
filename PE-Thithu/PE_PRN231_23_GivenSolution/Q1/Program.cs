using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Q1.DTOs;
using Q1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DUONGPV14_PRNContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//OData
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<StudentDTO>("Student");
builder.Services.AddControllers().AddOData(opt => opt
    .Select()
    .Expand()
    .Filter()
    .OrderBy()
    .Count()
    .SetMaxTop(20)
.AddRouteComponents("odata", modelBuilder.GetEdmModel())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();