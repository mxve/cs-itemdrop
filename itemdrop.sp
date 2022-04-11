public Plugin myinfo =
{
	name = "Drop announcer",
	author = "mxve",
	description = "Announce player & item dropped | SaarLAN.PUG",
	version = "0.1",
	url = "https://github.com/mxve/sourcemod-itemdrop"
};

public void OnPluginStart()
{
    RegAdminCmd("announce_itemdrop", Command_ItemDrop, ADMFLAG_GENERIC, "announces item drops");
}

public Action Command_ItemDrop(int client, int args)
{
    char name[128];
    GetCmdArg(1, name, sizeof(name));

    char item[128];
    GetCmdArg(2, item, sizeof(item));

    char sound[128];
    GetCmdArg(3, sound, sizeof(sound));

    PrintToChatAll(" \x07%s \x01hat gerade \x07%s \x01gedroppt!", name, item);
    PrintToChatAll(" \x06Du kannst deinen Drop nach dem Spiel am Infostand abholen.", name, item);

    for (int i = 1; i <= MaxClients; i++)
    {
        if (IsClientInGame(i))
        {
            ClientCommand(i, "play %s", sound);
        }
    }

    return Plugin_Handled;
}