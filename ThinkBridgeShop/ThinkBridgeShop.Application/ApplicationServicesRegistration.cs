using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ThinkBridgeShop.Application.Features.Products.Queries.GetProducts;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.CreateProduct;
using ThinkBridgeShop.Application.Features.Products.Commands.UpdateProduct;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;
using ThinkBridgeShop.Application.Common.PipeLineBehavior;
using FluentValidation;

namespace ThinkBridgeShop.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            services.AddMediatR(typeof(CreateProductCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateProductCommandHandler).Assembly);
            services.AddMediatR(typeof(DeleteProductCommandHandler).Assembly);
            services.AddMediatR(typeof(GetProductsQueryHandler).Assembly);

            return services;
        }
    }
}

