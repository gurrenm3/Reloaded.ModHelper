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
    public class PseudoGameLoop : GameLoop, IDisposable
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
                    OnUpdate.Invoke();
                    Thread.Sleep(timeBetweenLoops);
                }
            }, loopCancellation.Token);

            
            loopTask.Start();
            isLoopCreated = true;
            return this;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                loopCancellation.Cancel();
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
