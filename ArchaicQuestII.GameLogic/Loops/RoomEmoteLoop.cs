﻿using System.Collections.Generic;
using System.Linq;
using ArchaicQuestII.GameLogic.Core;
using ArchaicQuestII.GameLogic.Utilities;
using ArchaicQuestII.GameLogic.World.Room;

namespace ArchaicQuestII.GameLogic.Loops
{
    public class RoomEmoteLoop : ILoop
    {
        public int TickDelay => 45000;
        public bool ConfigureAwait => false;
        private List<Room> _rooms = new List<Room>();

        public void PreTick()
        {
            _rooms = Services.Instance.Cache
                .GetAllRooms()
                .Where(x => x.Players.Any() && x.Emotes.Any())
                .ToList();
        }

        public void Tick()
        {
            //Console.WriteLine("RoomEmoteLoop");

            foreach (var room in _rooms)
            {
                if (DiceBag.Roll(1, 1, 10) < 7)
                {
                    continue;
                }

                var emote = room.Emotes[DiceBag.Roll(1, 0, room.Emotes.Count - 1)];

                foreach (var player in room.Players)
                {
                    Services.Instance.Writer.WriteLine(
                        $"<p class='room-emote'>{emote}</p>",
                        player
                    );
                }
            }
        }

        public void PostTick()
        {
            _rooms.Clear();
        }
    }
}
