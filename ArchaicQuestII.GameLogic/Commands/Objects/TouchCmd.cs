using System.Linq;
using ArchaicQuestII.GameLogic.Account;
using ArchaicQuestII.GameLogic.Character;
using ArchaicQuestII.GameLogic.Character.Status;
using ArchaicQuestII.GameLogic.Core;
using ArchaicQuestII.GameLogic.World.Room;

namespace ArchaicQuestII.GameLogic.Commands.Objects;

public class TouchCmd : ICommand
{
    public TouchCmd(ICore core)
    {
        Aliases = new[] {"touch"};
        Description = "You can touch an object to find out how it feels.";
        Usages = new[] {"Type: touch flag"};
        Title = "";
        DeniedStatus = new[]
        {
            CharacterStatus.Status.Busy,
            CharacterStatus.Status.Dead,
            CharacterStatus.Status.Fighting,
            CharacterStatus.Status.Ghost,
            CharacterStatus.Status.Fleeing,
            CharacterStatus.Status.Incapacitated,
            CharacterStatus.Status.Sleeping,
            CharacterStatus.Status.Stunned,
            CharacterStatus.Status.Resting,
            CharacterStatus.Status.Sitting,
        };
        UserRole = UserRole.Player;
        Core = core;
    }
    
    public string[] Aliases { get; }
    public string Description { get; }
    public string[] Usages { get; }
    public string Title { get; }
    public CharacterStatus.Status[] DeniedStatus { get; }
    public UserRole UserRole { get; }
    public ICore Core { get; }

    public void Execute(Player player, Room room, string[] input)
    {
        var target = input.ElementAtOrDefault(1);
        
        if (string.IsNullOrEmpty(target))
        {
            Core.Writer.WriteLine("<p>Touch what?</p>", player.ConnectionId);
            return;
        }
        
        var nthTarget = Helpers.findNth(target);
        var item = Helpers.findRoomObject(nthTarget, room) ?? Helpers.findObjectInInventory(nthTarget, player);

        if (item == null)
        {
            Core.Writer.WriteLine("<p>You don't see that here.</p>", player.ConnectionId);
            return;
        }

        var isDark = Core.RoomActions.RoomIsDark(player, room);

        Core.Writer.WriteLine($"<p class='{(isDark ? "room-dark" : "")}'>{item.Description.Touch}</p>",
            player.ConnectionId);
        Core.Writer.WriteToOthersInRoom($"<p>{player.Name} feels {item.Name.ToLower()}.</p>", room, player);
    }
}