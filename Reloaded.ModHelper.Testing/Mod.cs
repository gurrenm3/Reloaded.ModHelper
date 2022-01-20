using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;

namespace Reloaded.ModHelper.Testing
{
    public class Mod : ReloadedMod
    {
        GameLoop gameLoop;

        public Mod(IReloadedHooks hooks, ILogger logger) : base(hooks, logger)
        {
            gameLoop = PseudoGameLoop.CreateNew(false).Initialize();
            gameLoop.Run(() =>
            {
                if(Keyboard.IsKeyPressed(KeyCode.UpArrow))
                {
                    logger.WriteLine("Key Pressed");
                }
            });
        }
    }
}
