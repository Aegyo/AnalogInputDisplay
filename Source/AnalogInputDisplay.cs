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
        Player player = Scene.Tracker.GetEntity<Player>();
        Level level = SceneAs<Level>();
        if (level == null) return;
        if (player == null) return;

        AnalogInputDisplayModuleSettings settings = AnalogInputDisplayModule.Settings;
        float radius = settings.Radius * 5f;
        Vector2 pos = level.WorldToScreen(player.Center);

        GamePadState gamepad = GamePad.GetState(0, GamePadDeadZone.None);
        if (gamepad.ThumbSticks.Left.Length() > settings.MinDisplayThreshold)
        {
            Vector2 thumbstick = new Vector2(gamepad.ThumbSticks.Left.X, -gamepad.ThumbSticks.Left.Y);
            drawIndicator(pos, thumbstick, settings.IndicatorLength, radius, Color.Red, settings.InputThickness);
            drawIndicator(pos, Input.LastAim, settings.IndicatorLength, radius, Color.White, settings.ActualDirectionThickness);
        }
    }

    private static Vector2 translateVec(Vector2 initial, float angleRad, float distance)
    {
        return new Vector2(initial.X + (distance * MathF.Cos(angleRad)), initial.Y + (distance * MathF.Sin(angleRad)));
    }

    private void drawIndicator(Vector2 origin, Vector2 direction, float length, float radius, Color color, float thickness = 1)
    {
        Vector2 start = translateVec(origin, direction.Angle(), radius - length);
        Vector2 end = translateVec(origin, direction.Angle(), radius);
        Draw.Line(start, end, color, thickness);
    }
}
