using System.Linq;
using ArchaicQuestII.GameLogic.Account;
using ArchaicQuestII.GameLogic.Character;
using ArchaicQuestII.GameLogic.Character.Status;
using ArchaicQuestII.GameLogic.Core;
using ArchaicQuestII.GameLogic.Effect;
using ArchaicQuestII.GameLogic.Utilities;
using ArchaicQuestII.GameLogic.World.Room;

namespace ArchaicQuestII.GameLogic.Commands.Skills
{
    public class LungCmd : SkillCore, ICommand
    {
        public LungCmd()
            : base()
        {
            Aliases = new[] { "lunge" };
            Description =
                "Does what it says, a strong slash of your weapon. Weapon max damage + 1d10";
            Usages = new[] { "Type: lung bob" };
            DeniedStatus = new[]
            {
                CharacterStatus.Status.Sleeping,
                CharacterStatus.Status.Resting,
                CharacterStatus.Status.Dead,
                CharacterStatus.Status.Mounted,
                CharacterStatus.Status.Stunned
            };
            Title = SkillName.Lunge.ToString();
            UserRole = UserRole.Player;
        }

        public string[] Aliases { get; }
        public string Description { get; }
        public string[] Usages { get; }
        public string Title { get; }
        public CharacterStatus.Status[] DeniedStatus { get; }
        public UserRole UserRole { get; }

        public void Execute(Player player, Room room, string[] input)
        {
            if (!player.HasSkill(SkillName.Lunge))
                return;

            if (player.Equipped.Wielded == null)
            {
                Services.Instance.Writer.WriteLine(
                    "You need to have a weapon equipped to do this.",
                    player
                );
                return;
            }

            var obj = input.ElementAtOrDefault(1)?.ToLower() ?? player.Target;
            if (string.IsNullOrEmpty(obj))
            {
                Services.Instance.Writer.WriteLine("Lunge What!?.", player);
                return;
            }

            var target = FindTargetInRoom(obj, room, player);
            if (target == null)
            {
                return;
            }

            var textToTarget = string.Empty;
            var textToRoom = string.Empty;

            var skillSuccess = player.RollSkill(
                SkillName.Lunge,
                true,
                $"You attempt to lunge at {target.Name} but miss."
            );
            if (!skillSuccess)
            {
                textToTarget = $"{player.Name} tries to lunge at you but misses.";
                textToRoom = $"{player.Name} tries to lunge at {target.Name} but misses.";

                EmoteAction(textToTarget, textToRoom, target.Name, room, player);
                player.FailedSkill(SkillName.Lunge, true);
                player.Lag += 1;
                return;
            }

            var weaponDam = player.Equipped.Wielded.Damage.Maximum;
            var str = player.Attributes.Attribute[EffectLocation.Strength];
            var damage = DiceBag.Roll(3, 1, 6) + str / 5 + weaponDam;

            DamagePlayer(SkillName.Lunge.ToString(), damage, player, target, room);

            player.Lag += 1;
        }
    }
}
