using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;

namespace Reloaded.ModHelper.Testing
{
    public class Mod : ReloadedMod
    {
        GameLoop gameLoop;

        public Mod(IReloadedHooks hooks, ILogger logger) : base(hooks, logger)
        {
            gameLoop = PseudoGameLoop.CreateNew(true).Initialize();
            gameLoop.Run(() =>
            {
                if(Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    logger.WriteLine("Key Pressed");
                }
            });
        }
    }
}
