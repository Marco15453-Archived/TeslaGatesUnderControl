using Exiled.API.Interfaces;
using System.ComponentModel;

namespace TeslaGatesUnderControl
{
    public sealed class Config : IConfig
    {
        [Description("Should the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Is tesla gates activated at round start?")]
        public bool IsTeslasActive { get; set; } = true;
    }
}
