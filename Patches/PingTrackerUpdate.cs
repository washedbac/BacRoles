using HarmonyLib;
using UnityEngine;

namespace TownOfUs
{
    //[HarmonyPriority(Priority.VeryHigh)] // to show this message first, or be overrided if any plugins do
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingTracker_Update
    {

        [HarmonyPostfix]
        public static void Postfix(PingTracker __instance)
        {
            var position = __instance.GetComponent<AspectPosition>();
            position.DistanceFromEdge = new Vector3(3.6f, 0.1f, 0);
            position.AdjustPosition();
            var host = GameData.Instance?.GetHost();

            __instance.text.text =
                "<size=2><color=#00FF00FF>BacRoles v" + TownOfUs.VersionString + "</color>" + TownOfUs.DevString + TownOfUs.VersionTag + "\n" +
                $"Ping: {AmongUsClient.Instance?.Ping}ms\n" +
                (!MeetingHud.Instance
                    ? "<color=#00FF00FF>Modded By: washed bac &</color>\n" +
                    "<color=#00FF00FF>50 IQ & KayinTOR</color>\n" : "") +
                (AmongUsClient.Instance?.GameState != InnerNet.InnerNetClient.GameStates.Started
                    ? "<color=#00FF00FF>Formerly: Town Of Us</color>\n" +
                     $"Host: {host?.PlayerName}" : "") +
                    "</size>";
        }
    }
}
