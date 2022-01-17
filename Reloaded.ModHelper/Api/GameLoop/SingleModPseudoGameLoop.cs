using System;

namespace Reloaded.ModHelper
{
    internal class SingleModPseudoGameLoop : PseudoGameLoop
    {
        private ModEvent loopEvent = new ModEvent();

        public SingleModPseudoGameLoop(int timeBetweenLoops) : base(timeBetweenLoops)
        {

        }

        public override void Add(Action codeToRun)
        {
            loopEvent.AddListener(codeToRun);
        }

        public override ModEvent GetModEvent()
        {
            return loopEvent;
        }

        public override bool Remove(Action codeToRun)
        {
            return loopEvent.RemoveListener(codeToRun);
        }

        protected override void RunLoop()
        {
            loopEvent.Invoke();
        }
    }
}
