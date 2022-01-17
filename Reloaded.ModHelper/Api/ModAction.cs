using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A wrapper class for <see cref="Action"/> that provides extra control for how the Action gets invoked.
    /// </summary>
    public class ModAction
    {
        /// <summary>
        /// Creates a ModAction out of a <see cref="Action"/>.
        /// </summary>
        /// <param name="action"></param>
        public static implicit operator ModAction(Action action) => new ModAction(action);

        /// <summary>
        /// The code to run when this ModAction is invoked.
        /// </summary>
        public Action CodeToRun { get; set; }

        /// <summary>
        /// Specifies a condition that must be true for this ModAction to invoke.
        /// If none is provided then it will always invoke when <see cref="Invoke"/> is called.
        /// </summary>
        public Func<bool> InvokeCondition { get; set; }

        /// <summary>
        /// The number of times this has been invoked.
        /// </summary>
        public int InvokeCount { get; private set; }

        /// <summary>
        /// Should this only be allowed to run once?
        /// </summary>
        public bool OnlyRunOnce { get; set; }


        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ModAction() 
        {
            InvokeCount = 0;
        }

        /// <summary>
        /// Creates an instance of this class and provides the code to run when this gets invoked.
        /// </summary>
        /// <param name="codeToRun"></param>
        public ModAction(Action codeToRun) :base()
        {
            CodeToRun = codeToRun;
        }

        /// <summary>
        /// Attempts to execute this ModAction. If <see cref="InvokeCondition"/> was
        /// provided then it will only run if the condition is true. If 
        /// <see cref="OnlyRunOnce"/> is true and this has already run, it will not run.
        /// </summary>
        public void Invoke()
        {
            if ((OnlyRunOnce && InvokeCount >= 1) || (InvokeCondition != null && !InvokeCondition()))
                return;

            CodeToRun.Invoke();
            InvokeCount++;
        }
    }
}
