using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados MySQL
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)) // Substitua pela versão do MySQL
    )
);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
