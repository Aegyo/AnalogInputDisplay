using System;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.AnalogInputDisplay;

public class AnalogInputDisplayModuleSettings : EverestModuleSettings
{
    public bool Enabled { get; set; } = true;

    [SettingRange(1, 100, true)]
    public int Radius { get; set; } = 20;

    public float MinDisplayThreshold { get; set; } = 0.1f;

    public Indicator InputIndicator { get; set; } = new Indicator(ColorSetting.White);

    public Indicator DashIndicator { get; set; } = new Indicator(ColorSetting.Gray);

    [SettingSubMenu]
    public class Indicator {
        public Indicator() {}
        public Indicator(ColorSetting defaultColor) {
            Color = defaultColor;
        }

        public Color GetXNAColor() {
            string colorName = Enum.GetName(typeof(ColorSetting), Color);
            Color color = (Color)(typeof(Color).GetProperty(colorName)).GetValue(null, null);

            return color;
        }

        public ColorSetting Color { get; set;} = ColorSetting.White;

        [SettingRange(1, 10)]
        public int Thickness { get; set; } = 2;

        [SettingRange(1, 20)]
        public int Length { get; set; } = 10;
    }
}

public enum ColorSetting {
    White,
    Gray,
    Black,
    Red,
    Green,
    Blue,
    Cyan,
    Magenta,
    Yellow,
}
