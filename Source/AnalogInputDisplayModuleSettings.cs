namespace Celeste.Mod.AnalogInputDisplay;

public class AnalogInputDisplayModuleSettings : EverestModuleSettings
{
    public bool Enabled { get; set; } = true;

    [SettingRange(1, 100, true)]
    public int Radius { get; set; } = 20;
    
    [SettingRange(1, 20)]
    public int IndicatorLength { get; set; } = 10;

    public float MinDisplayThreshold { get; set; } = 0.1f;

    [SettingRange(1, 10)]
    public int InputThickness { get; set; } = 2;

    [SettingRange(1, 10)]
    public int ActualDirectionThickness { get; set; } = 3;
}