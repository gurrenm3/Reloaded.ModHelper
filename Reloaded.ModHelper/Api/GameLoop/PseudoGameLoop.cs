using System;
using System.Threading;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A <see cref="GameLoop"/> that isn't connected to the Game's actual loop.
    /// <br/>Using this will allow access to Update behaviors but it won't be in sync with the game.
    /// To have a <see cref="GameLoop"/> that is syncronized with the game you will need to create a class
    /// that impliments <see cref="GameLoop"/> and hooks the Game's update loop.
    /// </summary>
    public abstract class PseudoGameLoop : GameLoop, IDisposable
    {
        private CancellationTokenSource loopCancellation;
        private Task loopTask;
        private int timeBetweenLoops;
        private bool isLoopCreated;
        private bool disposedValue;

        /// <summary>
        /// Creates a default instance of a pseudo-GameLoop.
        /// </summary>
        /// <param name="timeBetweenLoops">How many milliseconds should pass between each loop iteration.</param>
        public PseudoGameLoop(int timeBetweenLoops = 1) : base()
        {
            this.timeBetweenLoops = timeBetweenLoops;
        }

        /// <summary>
        /// Used to create the actual loop.
        /// </summary>
        public override GameLoop Create()
        {
            if (isLoopCreated) return this;

            Time.Initialize(this);
            loopCancellation = new CancellationTokenSource();
            loopTask = new Task(() =>
            {
                while (true)
                {
                    RunLoop();
                    Thread.Sleep(timeBetweenLoops);
                }
            }, loopCancellation.Token);

            
            loopTask.Start();
            isLoopCreated = true;
            return this;
        }

        /// <summary>
        /// Get's the mod event associated with the mod that called this method.
        /// </summary>
        /// <returns></returns>
        public abstract ModEvent GetModEvent();

        /// <summary>
        /// Used to set what happens when the loop is suppose to run. 
        /// </summary>
        protected abstract void RunLoop();

        /// <summary>
        /// Use this to create a <see cref="PseudoGameLoop"/> instance. Using this provides
        /// extra control as to how the loop stores update events. 
        /// <br/><br/>If <paramref name="isSharedInstance"/> is true
        /// then a game loop that can be shared between multiple mods will be created. If false then one will be created
        /// that can only be used for a single mod. This is done to help separate code from multiple mods.
        /// </summary>
        /// <param name="isSharedInstance">Will this game loop be shared between more than one mod? 
        /// Used to determine how the loop will store update events.</param>
        /// <param name="timeBetweenLoops">How many milliseconds should pass between each loop iteration.</param>
        /// <returns></returns>
        public static PseudoGameLoop CreateLoop(bool isSharedInstance, int timeBetweenLoops = 1)
        {
            return isSharedInstance ? new MultiModPseudoGameLoop(timeBetweenLoops) : new SingleModPseudoGameLoop(timeBetweenLoops);
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue) return;
            loopCancellation.Cancel();
            disposedValue = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}