

using Exiled.API.Features;
using System;

namespace TeslaGatesUnderControl
{
    public class TeslaGatesUnderControl : Plugin<Config>
    {
        internal static TeslaGatesUnderControl Instance;

        public override string Name => "TeslaGatesUnderControl";
        public override string Author => "Marco15453";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private EventHandler eventHandler;

        public bool TeslaEnabled = false;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            eventHandler = new EventHandler();

            // Server
            Exiled.Events.Handlers.Server.RoundStarted += eventHandler.onRoundStarted;

            // Player
            Exiled.Events.Handlers.Player.TriggeringTesla += eventHandler.onTeslaGateTrigger;
        }

        private void UnregisterEvents()
        {
            // Server
            Exiled.Events.Handlers.Server.RoundStarted += eventHandler.onRoundStarted;

            // Player
            Exiled.Events.Handlers.Player.TriggeringTesla -= eventHandler.onTeslaGateTrigger;

            eventHandler = null;
        }
    }
}
