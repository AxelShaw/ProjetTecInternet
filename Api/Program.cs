using Api;
using Application.UseCases;
using Application.UseCases.CommentMovies.UseCaseCommentMovie;
using Application.UseCases.RatingMovies.UseCaseRatingMovie;
using Application.UseCases.Series.UseCaseSerie;
using Infrastructure.Ef;
using Infrastructure.Utils;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();
builder.Services.AddScoped<MovieContextProvider>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISerieRepository, SerieRepository>();
builder.Services.AddScoped<IRatingMovieRepository, RatingMovieRepository>();
builder.Services.AddScoped<ICommentMovieRepository, CommentMovieRepository>();

builder.Services.AddScoped<UseCaseFetchAllMovies>();
builder.Services.AddScoped<UseCaseFetchAllUsers>();
builder.Services.AddScoped<UseCaseFetchAllSeries>();
builder.Services.AddScoped<UseCaseFetchAllRatingMovies>();
builder.Services.AddScoped<UseCaseFetchAllCommentMovies>();

builder.Services.AddScoped<UseCaseCreateMovie>();
builder.Services.AddScoped<UseCaseCreateUser>();
builder.Services.AddScoped<UseCaseCreateSerie>();
builder.Services.AddScoped<UseCaseCreateRatingMovie>();
builder.Services.AddScoped<UseCaseCreateCommentMovie>();

builder.Services.AddScoped<UseCaseFetchMovieById>();
builder.Services.AddScoped<UseCaseFetchUserById>();
builder.Services.AddScoped<UseCaseFetchSerieById>();
builder.Services.AddScoped<UseCaseFetchRatingMovieById>();
builder.Services.AddScoped<UseCaseFetchCommentMovieById>();

builder.Services.AddScoped<UseCaseDeleteMovie>();
builder.Services.AddScoped<UseCaseDeleteUser>();
builder.Services.AddScoped<UseCaseDeleteSerie>();
builder.Services.AddScoped<UseCaseDeleteRatingMovie>();
builder.Services.AddScoped<UseCaseDeleteCommentMovie>();

builder.Services.AddScoped<UseCaseUpdateMovie>();
builder.Services.AddScoped<UseCaseUpdateUser>();
builder.Services.AddScoped<UseCaseUpdateSerie>();
builder.Services.AddScoped<UseCaseUpdateRatingMovie>();
builder.Services.AddScoped<UseCaseUpdateCommentMovie>();

builder.Services.AddScoped<UseCaseFetchMovieByName>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Dev", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Dev");

app.UseAuthorization();

app.MapControllers();

app.Run();