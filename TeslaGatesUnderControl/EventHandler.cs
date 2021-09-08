using Exiled.Events.EventArgs;

namespace TeslaGatesUnderControl
{
    internal sealed class EventHandler
    {

        public void onRoundStarted()
        {
            TeslaGatesUnderControl.Instance.TeslaEnabled = TeslaGatesUnderControl.Instance.Config.IsTeslasActive;
        }

        public void onTeslaGateTrigger(TriggeringTeslaEventArgs ev)
        {
            if (TeslaGatesUnderControl.Instance.TeslaEnabled) return;

            ev.IsTriggerable = false;
        }
    }
}
