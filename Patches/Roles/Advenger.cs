using System;

namespace TownOfUs.Roles
{
    public class Advenger : Role
    {
        public Advenger(PlayerControl player) : base(player)
        {
            Name = "Advenger";
            ImpostorText = () => "Shoot The <color=#FF0000FF>Impostor</color>";
            TaskText = () => "Kill off the impostor but don't kill crewmates";
            Color = Patches.Colors.Advenger;
            LastKilled = DateTime.UtcNow;
            RoleType = RoleEnum.Advenger;
            AddToRoleHistory(RoleType);
        }

        public PlayerControl ClosestPlayer;
        public DateTime LastKilled { get; set; }

        public float AdvengerKillTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastKilled;
            var num = CustomGameOptions.AdvengerKillCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}