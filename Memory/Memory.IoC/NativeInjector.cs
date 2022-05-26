using Memory.Domain.Interfaces.Repositories;
using Memory.Domain.Interfaces.Services;
using Memory.Domain.Services;
using Memory.Infra.Context;
using Memory.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.IoC
{
    public class NativeInjector
    {
        public static void RegisterApp(IServiceCollection service)
        {
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IAnnotationRepository, AnnotationRepository>();

            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IAnnotationService, AnnotationService>();

            service.AddScoped<MemoryContext>();
        }
    }
}
