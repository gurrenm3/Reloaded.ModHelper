using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to create a pseudo update loop.
    /// </summary>
    public class UpdateLoop_Old
    {
        /// <summary>
        /// Can be used to hook onto the Update loop.
        /// </summary>
        public static ModEvent OnUpdate { get; private set; } = new ModEvent();
        List<IModBase> currentMods = new List<IModBase>();


        /// <summary>
        /// Default implementation of the UpdateLoop.
        /// </summary>
        public UpdateLoop_Old()
        {

        }

        /// <summary>
        /// Initializes the UpdateLoop with a list of mods that will use the UpdateLoop.
        /// </summary>
        /// <param name="currentMods"></param>
        public UpdateLoop_Old(List<IModBase> currentMods)
        {
            this.currentMods = currentMods;
        }

        /// <summary>
        /// Syncronously starts the UpdateLoop. Use <see cref="StartUpdateLoopAsync"/> to prevent the main thread from getting clogged.
        /// </summary>
        public void StartUpdateLoop()
        {
            while (true)
            {
                FireUpdate();
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Asyncronously starts the UpdateLoop. Won't clog the main thread.
        /// </summary>
        public void StartUpdateLoopAsync()
        {
            Task.Factory.StartNew(() => StartUpdateLoop());
        }

        private void FireUpdate()
        {
            OnUpdate.Invoke();
            for (int i = 0; i < currentMods.Count; i++)
            {
                currentMods[i].Update();
            }
        }
    }
}
