﻿using ArchaicQuestII.GameLogic.Character;
using ArchaicQuestII.GameLogic.Client;
using ArchaicQuestII.GameLogic.Commands;
using ArchaicQuestII.GameLogic.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ArchaicQuestII.API.Configuration.IoC.GameLogicExtensions
{
    public static class CoreFunctionalityExtensions
    {
        public static IServiceCollection AddCoreFunctionality(this IServiceCollection services)
        {
            services.AddSingleton<IDamage, Damage>();
            services.AddSingleton<ILoopHandler, LoopHandler>();
            services.AddSingleton<IUpdateClientUI, UpdateClientUI>();
            services.AddSingleton<IMobScripts, MobScripts>();
            services.AddSingleton<ITime, Time>();
            services.AddSingleton<ICharacterHandler, CharacterHandler>();
            services.AddSingleton<IQuestLog, QuestLog>();
            services.AddSingleton<IWeather, Weather>();
            services.AddSingleton<ICommandHandler, CommandHandler>();
            services.AddSingleton<IErrorLog, ErrorLog>();

            return services;
        }
    }
}
