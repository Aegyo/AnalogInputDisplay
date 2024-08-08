using System;

namespace Celeste.Mod.AnalogInputDisplay;

public class AnalogInputDisplayModule : EverestModule {
    public static AnalogInputDisplayModule Instance { get; private set; }

    public override Type SettingsType => typeof(AnalogInputDisplayModuleSettings);
    public static AnalogInputDisplayModuleSettings Settings => (AnalogInputDisplayModuleSettings) Instance._Settings;

    public override Type SessionType => typeof(AnalogInputDisplayModuleSession);
    public static AnalogInputDisplayModuleSession Session => (AnalogInputDisplayModuleSession) Instance._Session;

    public override Type SaveDataType => typeof(AnalogInputDisplayModuleSaveData);
    public static AnalogInputDisplayModuleSaveData SaveData => (AnalogInputDisplayModuleSaveData) Instance._SaveData;

    public AnalogInputDisplayModule() {
        Instance = this;
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(AnalogInputDisplayModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(AnalogInputDisplayModule), LogLevel.Info);
#endif
    }

    public override void Load() {
        // TODO: apply any hooks that should always be active
    }

    public override void Unload() {
        // TODO: unapply any hooks applied in Load()
    }
}