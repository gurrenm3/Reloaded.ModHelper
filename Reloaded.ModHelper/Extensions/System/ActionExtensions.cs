﻿using System;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for System.Action
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Run all actions in the list.
        /// </summary>
        /// <param name="actions">list of actions to invoke</param>
        public static void InvokeAll(this List<Action> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                try
                {
                    actions[i].Invoke();
                }
                catch (Exception ex)
                {
                    ConsoleUtils.WriteError(ex.Message);
                }
            }
        }

        /// <summary>
        /// Run all actions in the list.
        /// </summary>
        /// <typeparam name="T">argument type</typeparam>
        /// <param name="actions">list of actions to invoke</param>
        /// <param name="argument">argument to pass in while invoking</param>
        public static void InvokeAll<T>(this List<Action<T>> actions, T argument)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                try
                {
                    actions[i].Invoke(argument);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.WriteException(ex);
                }
            }
        }

        /// <summary>
        /// Run all actions in the list.
        /// </summary>
        /// <typeparam name="T1">argument type1</typeparam>
        /// <typeparam name="T2">argument type2</typeparam>
        /// <param name="actions">list of actions to invoke</param>
        /// <param name="argument1">argument to pass in while invoking</param>
        /// <param name="argument2">argument to pass in while invoking</param>
        public static void InvokeAll<T1, T2>(this List<Action<T1, T2>> actions, T1 argument1, T2 argument2)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                try
                {
                    actions[i].Invoke(argument1, argument2);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.WriteException(ex);
                }
            }
        }

        /// <summary>
        /// Run all actions in the list.
        /// </summary>
        /// <typeparam name="T1">argument type1</typeparam>
        /// <typeparam name="T2">argument type2</typeparam>
        /// <typeparam name="T3">argument type3</typeparam>
        /// <param name="actions">list of actions to invoke</param>
        /// <param name="argument1">argument to pass in while invoking</param>
        /// <param name="argument2">argument to pass in while invoking</param>
        /// <param name="argument3">argument to pass in while invoking</param>
        public static void InvokeAll<T1, T2, T3>(this List<Action<T1, T2, T3>> actions, T1 argument1, T2 argument2, T3 argument3)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                try
                {
                    actions[i].Invoke(argument1, argument2, argument3);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.WriteException(ex);
                }
            }
        }

        /// <summary>
        /// Run all actions in the list.
        /// </summary>
        /// <typeparam name="T1">argument type1</typeparam>
        /// <typeparam name="T2">argument type2</typeparam>
        /// <typeparam name="T3">argument type3</typeparam>
        /// <typeparam name="T4">argument type4</typeparam>
        /// <param name="actions">list of actions to invoke</param>
        /// <param name="argument1">argument to pass in while invoking</param>
        /// <param name="argument2">argument to pass in while invoking</param>
        /// <param name="argument3">argument to pass in while invoking</param>
        /// <param name="argument4">argument to pass in while invoking</param>
        public static void InvokeAll<T1, T2, T3, T4>(this List<Action<T1, T2, T3, T4>> actions, T1 argument1, T2 argument2, T3 argument3, T4 argument4)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                try
                {
                    actions[i].Invoke(argument1, argument2, argument3, argument4);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.WriteException(ex);
                }
            }
        }

        /// <summary>
        /// Run all actions in the list.
        /// </summary>
        /// <typeparam name="T1">argument type1</typeparam>
        /// <typeparam name="T2">argument type2</typeparam>
        /// <typeparam name="T3">argument type3</typeparam>
        /// <typeparam name="T4">argument type4</typeparam>
        /// <typeparam name="T5">argument type5</typeparam>
        /// <param name="actions">list of actions to invoke</param>
        /// <param name="argument1">argument to pass in while invoking</param>
        /// <param name="argument2">argument to pass in while invoking</param>
        /// <param name="argument3">argument to pass in while invoking</param>
        /// <param name="argument4">argument to pass in while invoking</param>
        /// <param name="argument5">argument to pass in while invoking</param>
        public static void InvokeAll<T1, T2, T3, T4, T5>(this List<Action<T1, T2, T3, T4, T5>> actions, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5)
        {
            for (int i = 0; i < actions.Count; i++)
            {               
                try
                {
                    actions[i].Invoke(argument1, argument2, argument3, argument4, argument5);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.WriteException(ex);
                }
            }
        }
    }
}