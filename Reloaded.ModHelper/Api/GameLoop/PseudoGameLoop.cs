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
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override long LoopCount => _loopCount;
        private long _loopCount;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override ITime Time => _time;
        private ITime _time;


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
        /// Used to create the actual loop. Should only be called once when the loop is first started.
        /// </summary>
        public override IGameLoop Initialize()
        {
            if (isLoopCreated) return this;
            
            _time = new PseudoTime(this);
            loopCancellation = new CancellationTokenSource();
            loopTask = new Task(() =>
            {
                while (true)
                {
                    OnUpdate.Prefix.Invoke();
                    RunLoopInternal();
                    RunLoop();
                    OnUpdate.Postfix.Invoke();
                    Thread.Sleep(timeBetweenLoops);
                }
            }, loopCancellation.Token);

            loopTask.Start();
            isLoopCreated = true;
            return this;
        }

        /// <summary>
        /// Executes the code that is suppose to happen each time the loop runs. Used to set 
        /// variables and other important info that keeps the loop functioning correctly. Should not
        /// be used or overrided unless you want to change the base functionality of the class.
        /// </summary>
        protected virtual void RunLoopInternal()
        {
            _loopCount++;
        }

        /// <summary>
        /// Executes the code that is suppose to happen each time the loop runs.
        /// </summary>
        protected virtual void RunLoop() { }

        /// <summary>
        /// Use this to create a <see cref="PseudoGameLoop"/> instance. Using this provides
        /// extra control as to how loop events are stored. 
        /// <br/><br/>If <paramref name="isSharedInstance"/> is true then a game loop
        /// that can be shared between multiple mods will be created. It will separate loop events by calling assembly.
        /// If false then one will be created that stores all loop events together, which is best for a loop used by a single mod
        /// The whole purpose of this is to help separate code from multiple mods.
        /// </summary>
        /// <param name="isSharedInstance">Will this game loop be shared between more than one mod? 
        /// Used to determine how the loop will store loop events.</param>
        /// <param name="timeBetweenLoops">How many milliseconds should pass between each loop iteration.</param>
        /// <returns></returns>
        public static PseudoGameLoop CreateNew(bool isSharedInstance, int timeBetweenLoops = 1)
        {
            return isSharedInstance ? new SharedPseudoGameLoop(timeBetweenLoops) : new SingleModPseudoGameLoop(timeBetweenLoops);
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