using System;

namespace Celeste.Mod.AnalogInputDisplay;

public class AnalogInputDisplayModule : EverestModule {
    public static AnalogInputDisplayModule Instance { get; private set; }

    public override Type SettingsType => typeof(AnalogInputDisplayModuleSettings);
    public static AnalogInputDisplayModuleSettings Settings => (AnalogInputDisplayModuleSettings) Instance._Settings;

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
        Everest.Events.Level.OnLoadLevel += modLoadLevel;
    }

    public override void Unload() {
        Everest.Events.Level.OnLoadLevel -= modLoadLevel;
    }

    private void modLoadLevel(Level level, Player.IntroTypes playerIntro, bool isFromLoader){
        level.Add(new AnalogInputDisplay());
    }
}