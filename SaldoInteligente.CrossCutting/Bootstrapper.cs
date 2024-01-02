using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SaldoInteligente.Domain.Contracts.Repositories;
using SaldoInteligente.Domain.Contracts.Services;
using SaldoInteligente.Domain.Contracts.UtilsServices;
using SaldoInteligente.Domain.Contracts.ValidationsServices;
using SaldoInteligente.Domain.Core.Notifications;
using SaldoInteligente.Infrastructure.ORM;
using SaldoInteligente.Infrastructure.Repositories;
using SaldoInteligente.Services.AutoMapper;
using SaldoInteligente.Services.Service;
using SaldoInteligente.Services.Utils;
using SaldoInteligente.Services.Validations;

namespace SaldoInteligente.CrossCutting.Dependencies
{
    public class Bootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddScoped<BankAccountContext>();

            #region Others
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());
            services.AddScoped<IMapper>(
                sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            #endregion

            #region Services
            services.AddScoped<IErrorService, ErrorService>();
            services.AddScoped<IBalanceCheckingStatementValidationService, BalanceCheckingStatementValidationService>();
            services.AddScoped<IBalanceCheckingStatementService, BalanceCheckingStatementService>();
            #endregion

            #region Repositories
            services.AddScoped<IBalanceCheckingStatementRepository, BalanceCheckingStatementRepository>();
            #endregion
        }
    }
}
