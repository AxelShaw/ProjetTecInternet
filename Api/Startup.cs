using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Api;
using Application.UseCases;
using Application.UseCases.CommentMovies.UseCaseCommentMovie;
using Application.UseCases.CommentSeries.UseCase;
using Application.UseCases.RatingMovies.UseCaseRatingMovie;
using Application.UseCases.RatingSerie.UseCaseRatingSerie;
using Application.UseCases.Series.UseCaseSerie;
using Infrastructure.Ef;
using Infrastructure.Utils;

namespace ProjetTi;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>

            {

                options.AddPolicy(

                    name:"AllowOrigin",

                    builder => {

                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                    });

            });
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtApi", Version = "v1" });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["cookie"];
                        return Task.CompletedTask;
                    },
                };
            });
            
            // Add services to the container.

            services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddScoped<MovieContextProvider>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<IRatingMovieRepository, RatingMovieRepository>();
            services.AddScoped<IRatingSerieRepository, RatingSerieRepository>();
            services.AddScoped<ICommentMovieRepository, CommentMovieRepository>();
            services.AddScoped<ICommentSerieRepository, CommentSerieRepository>();
            
            services.AddTransient<IJwtAuthentificationManager, JwtAuthentificationManager>();

            services.AddScoped<UseCaseFetchAllMovies>();
            services.AddScoped<UseCaseFetchAllUsers>();
            services.AddScoped<UseCaseFetchAllSeries>();
            services.AddScoped<UseCaseFetchAllRatingMovies>();
            services.AddScoped<UseCaseFetchAllRatingSeries>();
            services.AddScoped<UseCaseFetchAllCommentMovies>();
            services.AddScoped<UseCaseFetchAllCommentSeries>();

            services.AddScoped<UseCaseCreateMovie>();
            services.AddScoped<UseCaseCreateUser>();
            services.AddScoped<UseCaseCreateSerie>();
            services.AddScoped<UseCaseCreateRatingMovie>();
            services.AddScoped<UseCaseCreateRatingSerie>();
            services.AddScoped<UseCaseCreateCommentMovie>();
            services.AddScoped<UseCaseCreateCommentSerie>();

            services.AddScoped<UseCaseFetchMovieById>();
            services.AddScoped<UseCaseFetchUserById>();
            services.AddScoped<UseCaseFetchSerieById>();
            services.AddScoped<UseCaseFetchRatingMovieById>();
            services.AddScoped<UseCaseFetchRatingSerieById>();
            services.AddScoped<UseCaseFetchCommentMovieById>();
            services.AddScoped<UseCaseFetchCommentSerieById>();

            services.AddScoped<UseCaseDeleteMovie>();
            services.AddScoped<UseCaseDeleteUser>();
            services.AddScoped<UseCaseDeleteSerie>();
            services.AddScoped<UseCaseDeleteRatingMovie>();
            services.AddScoped<UseCaseDeleteRatingSerie>();
            services.AddScoped<UseCaseDeleteCommentMovie>();
            services.AddScoped<UseCaseDeleteCommentSerie>();

            services.AddScoped<UseCaseUpdateMovie>();
            services.AddScoped<UseCaseUpdateUser>();
            services.AddScoped<UseCaseUpdateSerie>();
            services.AddScoped<UseCaseUpdateRatingMovie>();
            services.AddScoped<UseCaseUpdateRatingSerie>();
            services.AddScoped<UseCaseUpdateCommentMovie>();
            services.AddScoped<UseCaseUpdateCommentSerie>();

            services.AddScoped<UseCaseFetchMovieByName>();
            
            services.AddScoped<UseCaseFetchAllRatingMoviesDown>();
            services.AddScoped<UseCaseFetchAllRatingMoviesTop>();
            services.AddScoped<UseCaseFetchLastIdMovie>();
                    
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JwtApi v1"));
            }
            
            app.UseCors("AllowOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

