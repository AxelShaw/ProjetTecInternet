using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Api;
using Application.UseCases;
using Application.UseCases.Actu.UseCaseActu;
using Application.UseCases.Actu.UseCaseCommentMovie;
using Application.UseCases.CommentMovies.UseCaseCommentMovie;
using Application.UseCases.Favorie.UseCaseCommentMovie;
using Application.UseCases.Favorie.UseCaseFavorie;
using Application.UseCases.RatingMovies.UseCaseRatingMovie;
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
            services.AddScoped<IRatingMovieRepository, RatingMovieRepository>();
            services.AddScoped<ICommentMovieRepository, CommentMovieRepository>();
            services.AddScoped<IFavorieRepository, FavorieRepository>();
            services.AddScoped<IActuRepository, ActuRepository>();
            
            services.AddTransient<IJwtAuthentificationManager, JwtAuthentificationManager>();

            services.AddScoped<UseCaseFetchAllMovies>();
            services.AddScoped<UseCaseFetchAllUsers>();
            services.AddScoped<UseCaseFetchAllRatingMovies>();
            services.AddScoped<UseCaseFetchAllCommentMovies>();
            services.AddScoped<UseCaseFetchAllFavorie>();
            services.AddScoped<UseCaseFetchAllActu>();

            services.AddScoped<UseCaseCreateMovie>();
            services.AddScoped<UseCaseCreateUser>();
            services.AddScoped<UseCaseCreateRatingMovie>();
            services.AddScoped<UseCaseCreateCommentMovie>();
            services.AddScoped<UseCaseCreateFavorie>();
            services.AddScoped<UseCaseCreateActu>();

            services.AddScoped<UseCaseFetchMovieById>();
            services.AddScoped<UseCaseFetchUserById>();
            services.AddScoped<UseCaseFetchRatingMovieById>();
            services.AddScoped<UseCaseFetchCommentMovieById>();
            services.AddScoped<UseCaseFetchFavorieById>();
            services.AddScoped<UseCaseFetchActuById>();

            services.AddScoped<UseCaseDeleteMovie>();
            services.AddScoped<UseCaseDeleteUser>();
            services.AddScoped<UseCaseDeleteRatingMovie>();
            services.AddScoped<UseCaseDeleteCommentMovie>();
            services.AddScoped<UseCaseDeleteCommentMovieById>();
            services.AddScoped<UseCaseDeleteCommentMovieByUser>();
            services.AddScoped<UseCaseDeleteFavorie>();
            services.AddScoped<UseCaseDeleteFavorieByUser>();
            services.AddScoped<UseCaseDeleteFavorieById>();
            services.AddScoped<UseCaseDeleteActu>();
            services.AddScoped<UseCaseDeleteByIdActu>();

            services.AddScoped<UseCaseUpdateMovie>();
            services.AddScoped<UseCaseUpdateUser>();
            services.AddScoped<UseCaseUpdateRatingMovie>();
            services.AddScoped<UseCaseUpdateCommentMovie>();
            services.AddScoped<UseCaseUpdateFavorie>();
            services.AddScoped<UseCaseUpdateActu>();

            services.AddScoped<UseCaseFetchMovieByName>();
            services.AddScoped<UseCaseFetchByNameUser>();
            services.AddScoped<UseCaseFetchAllRatingMoviesDown>();
            services.AddScoped<UseCaseFetchAllRatingMoviesTop>();
            services.AddScoped<UseCaseFetchAllRatingMoviesTopHome>();
            services.AddScoped<UseCaseFetchAllRatingMoviesDownHome>();
            services.AddScoped<UseCaseFetchMovieByGenre>();
            
            
                    
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

