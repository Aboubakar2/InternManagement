using InterManagement.Domain.Repositories;
using InternManagement.Infrastructure.Data;
using InternManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // ── Base de données ───────────────────
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));

            // ── Repositories ──────────────────────
            services.AddScoped<ITraineeRepository, TraineeRepository>();

            // services.AddScoped<IMentorRepository, MentorRepository>();
            // services.AddScoped<IPhaseRepository, PhaseRepository>();
            // services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            // services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            return services;
        }
    }
}
