using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.AnalogInputDisplay; 
public class AnalogInputDisplay : Entity {
    public AnalogInputDisplay() {
        AddTag(Tags.HUD);
    }

    public override void Render() {
        Player player = Scene.Tracker.GetEntity<Player>();
        Level level = SceneAs<Level>();
        if (level == null) return;
        if (player == null) return;

        Vector2 pos = level.WorldToScreen(player.Position);
        pos.Y -= 32f;
        Draw.Circle(pos, 100, Color.White, 32);
    }
}
