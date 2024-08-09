using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Monocle;

namespace Celeste.Mod.AnalogInputDisplay;
public class AnalogInputDisplay : Entity
{
    public AnalogInputDisplay()
    {
        AddTag(Tags.HUD);
    }

    public override void Render()
    {
        AnalogInputDisplayModuleSettings settings = AnalogInputDisplayModule.Settings;
        if (!settings.Enabled) return;

        Player player = Scene.Tracker.GetEntity<Player>();
        Level level = SceneAs<Level>();
        if (level == null) return;
        if (player == null) return;

        float radius = settings.Radius * 5f;
        Vector2 pos = level.WorldToScreen(player.Center);

        GamePadState gamepad = GamePad.GetState(0, GamePadDeadZone.None);
        if (gamepad.ThumbSticks.Left.Length() > settings.MinDisplayThreshold)
        {
            Vector2 thumbstick = new Vector2(gamepad.ThumbSticks.Left.X, -gamepad.ThumbSticks.Left.Y);
            drawIndicator(pos, thumbstick, radius, settings.InputIndicator);
            drawIndicator(pos, Input.LastAim, radius, settings.DashIndicator);
        }
    }

    private static Vector2 translateVec(Vector2 initial, float angleRad, float distance)
    {
        Vector2 offset = distance * new Vector2(MathF.Cos(angleRad), MathF.Sin(angleRad));
        return initial + offset;
    }

    private void drawIndicator(Vector2 origin, Vector2 direction, float radius, AnalogInputDisplayModuleSettings.Indicator indicator)
    {
        Vector2 start = translateVec(origin, direction.Angle(), radius - indicator.Length);
        Vector2 end = translateVec(origin, direction.Angle(), radius);
        Draw.Line(start, end, indicator.GetXNAColor(), indicator.Thickness);
    }
}
