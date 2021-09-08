using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace TeslaGatesUnderControl
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class TeslaCommand : ICommand
    {
        public string Command { get; } = "tesla";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Enables or Disables all Tesla Gates";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player p = Player.Get((CommandSender)sender);

            if(p != null && !p.CheckPermission("tguc.tesla"))
            {
                response = "You need the 'tguc.tesla' permission to use this Command!";
                return false;
            }

            if(arguments.IsEmpty() || (arguments.At(0) != "on" && arguments.At(0) != "off"))
            {
                response = "You missing the argument on or off!";
                return false;
            }

            if(arguments.At(0) == "on" && !TeslaGatesUnderControl.Instance.TeslaEnabled)
            {
                TeslaGatesUnderControl.Instance.TeslaEnabled = true;
                response = "The Tesla Gates will trigger and has been enabled for this Round!";
                return true;
            } else if(arguments.At(0) == "off" && TeslaGatesUnderControl.Instance.TeslaEnabled)
            {
                TeslaGatesUnderControl.Instance.TeslaEnabled = false;
                response = "The Telsa Gates will no longer trigger and has been disabled for this Round!";
                return true;
            } else
            {
                response = $"The Tesla Gate are already {(TeslaGatesUnderControl.Instance.TeslaEnabled ? "Enabled": "Disabled")}!";
                return false;
            }
        }
    }
}
