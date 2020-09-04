﻿using ConferencePlanner.Api.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace ConferencePlanner.Api.Swagger
{
    public static class SwaggerExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="authority"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Conference Planner API",
                        Version = "v1"
                    }
                );

                c.CustomSchemaIds(type => type.ToString());

                var documentedAssemblies = new[]
                {
                    typeof(ConferenceController).Assembly,
                    typeof(HomeController).Assembly,
                    typeof(CityController).Assembly,
                    typeof(DictionaryConferenceTypeController).Assembly,
                    typeof(CountryController).Assembly,
                    typeof(ParticipantController).Assembly,
                    typeof(DictionaryCountyController).Assembly,
                    typeof(DictionaryCategoryController).Assembly,
                    typeof(ParticipantController).Assembly,
                };
                 
            });

            return services;
        }
    }
}