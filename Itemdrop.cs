using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;

namespace Itemdrop;

public class Itemdrop : BasePlugin
{
    public override string ModuleName => "ezpug-itemdrop-announcer";

    public override string ModuleVersion => "0.0.1";

    [ConsoleCommand("announce_itemdrop", "SaarLAN Maggi Clique")]
    public void OnItemDrop(CCSPlayerController? player, CommandInfo command)
    {
        if (player != null)
        {
            return;
        }

        if (command.ArgCount < 5)
        {
            return;
        }

        var dropee = command.GetArg(1);
        var item = command.GetArg(2);
        var sound = command.GetArg(3);
        var steamId = command.GetArg(4);

        Console.WriteLine("Player " + dropee + " dropped item " + item);

        var players = Utilities.GetPlayers();
        foreach (var p in players)
        {
            p?.ExecuteClientCommand("play " + sound);
            p?.PrintToCenter($"{dropee} hat {item} bekommen!");
            p?.PrintToChat($" {ChatColors.Red} {dropee} {ChatColors.Default}hat gerade {ChatColors.Green}{item} {ChatColors.Default}gedroppt!");
            if (p?.SteamID.ToString() == steamId)
            {
                p?.PrintToChat($" {ChatColors.Lime}Du kannst deinen Drop nach dem Spiel am Infostand abholen!");
            }
        }
    }
}
