using System;
using ArchaicQuestII.GameLogic.Character.Model;
using ArchaicQuestII.GameLogic.Character.Status;
using ArchaicQuestII.GameLogic.Item;
using LiteDB;
using System.Collections.Generic;
using Newtonsoft.Json;
using Money = ArchaicQuestII.GameLogic.Item.Money;

namespace ArchaicQuestII.GameLogic.Character
{
    public class Character
    {
        /// <summary>
        /// Assigned when player logs in.
        /// used to find player in cached dictionary and to send data directly to player
        /// </summary>
        [BsonIgnore]
        public int ConnectionId { get; set; }

        /// <summary>
        /// Associated Account Id
        /// </summary>
        public Guid AccountId { get; set; } = Guid.Empty;

        public Guid Id { get; set; } = Guid.Empty;
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Displays short description of the character in the room
        /// For Players this would work as a 'Pose' and for mobs
        /// will be something like 'A bat flaps around the cavern above.'
        /// </summary>
        [JsonProperty("longName")]
        public string LongName { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("race")]
        public string Race { get; set; }
        [JsonProperty("className")]
        public string ClassName { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("alignmentScore")]
        public int AlignmentScore { get; set; } = 0;
        [JsonProperty("totalExperience")]
        public int TotalExperience { get; set; }
        [JsonProperty("experience")]
        public int Experience { get; set; }
        [JsonProperty("experienceToNextLevel")]
        public int ExperienceToNextLevel { get; set; }
        [JsonProperty("equipped")]
        public Equipment.Equipment Equipped { get; set; } = new Equipment.Equipment();
        [JsonProperty("inventory")]
        public List<Item.Item> Inventory { get; set; } = new List<Item.Item>();
        [JsonProperty("stats")]
        public Stats Stats { get; set; }
        [JsonProperty("status")]
        public CharacterStatus.Status Status { get; set; }
        [JsonProperty("maxStats")]
        public Stats MaxStats { get; set; }
        [JsonProperty("attributes")]
        public Attributes Attributes {get; set; }
        [JsonProperty("maxAttributes")]
        public Attributes MaxAttributes {get; set; }
        [BsonIgnore]
        [JsonProperty("target")]
        public string Target { get; set; }
        [JsonProperty("armorRating")]
        public ArmourRating ArmorRating { get; set; }
        [JsonProperty("money")]
        public Money Money { get; set; }
        [JsonProperty("affects")]
        public Affects Affects { get; set; }
        [JsonProperty("config")]
        public Config Config { get; set; }
        
        
        

        
    }
}
