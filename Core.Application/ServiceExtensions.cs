global using MediatR;
using Core.Application.Features.Queries;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Core.Application;

public static class ServiceExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetAllEmployeesQueryHandler).GetTypeInfo().Assembly);

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(typeof(ApplicationArea).Assembly);
    }
}
