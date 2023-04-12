﻿using ArchaicQuestII.DataAccess;
using ArchaicQuestII.GameLogic.Character;
using ArchaicQuestII.GameLogic.Client;
using ArchaicQuestII.GameLogic.Combat;
using ArchaicQuestII.GameLogic.Skill.Skills;
using ArchaicQuestII.GameLogic.Spell;
using ArchaicQuestII.GameLogic.Commands;
using System;
using Microsoft.AspNetCore.SignalR;
using ArchaicQuestII.GameLogic.Hubs;

namespace ArchaicQuestII.GameLogic.Core
{
    public sealed class Services
    {
        public Cache Cache { get; private set; }
        public IWriteToClient Writer { get; private set; }
        public IDataBase DataBase { get; private set; }
        public IPlayerDataBase PlayerDataBase { get; private set; }
        public IUpdateClientUI UpdateClient { get; private set; }
        public ICombat Combat { get; private set; }
        public IMobScripts MobScripts { get; private set; }
        public IPassiveSkills PassiveSkills { get; private set; }
        public IFormulas Formulas { get; private set; }
        public IErrorLog ErrorLog { get; private set; }
        public ITime Time { get; private set; }
        public IDamage Damage { get; private set; }
        public ISpellList SpellList { get; private set; }
        public IWeather Weather { get; private set; }
        public ICharacterHandler CharacterHandler { get; private set; }
        public ILoopHandler GameLoop { get; private set; }
        public ICommandHandler CommandHandler { get; private set; }
        public IHubContext<GameHub> Hub { get; private set; }

        private static readonly Lazy<Services> lazy = new Lazy<Services>(() => new Services());

        public static Services Instance
        {
            get { return lazy.Value; }
        }

        private Services()
        {
            Cache = new Cache();
        }

        public void InitServices(
            IWriteToClient writeToClient,
            IDataBase dataBase,
            IUpdateClientUI updateClient,
            ICombat combat,
            IPlayerDataBase playerDataBase,
            IMobScripts mobScripts,
            IErrorLog errorLog,
            IPassiveSkills passiveSkills,
            IFormulas formulas,
            ITime time,
            IDamage damage,
            ISpellList spellList,
            IWeather weather,
            ICharacterHandler characterHandler,
            ILoopHandler gameLoop,
            ICommandHandler commandHandler,
            IHubContext<GameHub> hub
        )
        {
            Writer = writeToClient;
            DataBase = dataBase;
            UpdateClient = updateClient;
            Combat = combat;
            PlayerDataBase = playerDataBase;
            MobScripts = mobScripts;
            ErrorLog = errorLog;
            PassiveSkills = passiveSkills;
            Formulas = formulas;
            Time = time;
            Damage = damage;
            SpellList = spellList;
            Weather = weather;
            CharacterHandler = characterHandler;
            GameLoop = gameLoop;
            CommandHandler = commandHandler;
            Hub = hub;
        }
    }
}
