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

        float radius = 100;
        float indicatorLen = 10;
        float minDisplayThreshold = 0.1F;
        float inputThickness = 2;
        float actualDirectionThickness = 3;
        Vector2 pos = level.WorldToScreen(player.Center);

        GamePadState gamepad = GamePad.GetState(0, GamePadDeadZone.None);
        if (gamepad.ThumbSticks.Left.Length() > minDisplayThreshold)
        {
            Vector2 thumbstick = new Vector2(gamepad.ThumbSticks.Left.X, -gamepad.ThumbSticks.Left.Y);
            drawIndicator(pos, thumbstick, indicatorLen, radius, Color.Red, inputThickness);
            drawIndicator(pos, Input.LastAim, indicatorLen, radius, Color.White, actualDirectionThickness);
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
