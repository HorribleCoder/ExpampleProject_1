using System;
using UnityEngine;

using TestProject.DevOOP.Core;
using TestProject.DevOOP.Units;
using TestProject.DevOOP.GamePool;

namespace TestProject.DevOOP
{
    /// <summary>
    /// This class for usability things and functions...
    /// </summary>
    internal sealed class GameUtility 
    {
        /// <summary>
        /// This function Get Unity Comonent in current GameObject.
        /// </summary>
        /// <param name="owner">Current object.</param>
        /// <param name="componentType">Unity component type.</param>
        /// <param name="component">Result component referense.</param>
        /// <returns>Component status on current GameObject - <see cref="Boolean"/>.</returns>
        internal static bool TryGetComponentInObject(GameObject owner, Type componentType, out Component component)
        {
            component = default;
            component = owner.GetComponent(componentType);
            return component != default;
        }
        /// <summary>
        /// Function for process in game error whit exception.
        /// </summary>
        /// <param name="e">Some Exception.</param>
        internal static void ExceptionHandler(Exception e)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.unityLogger.LogException(e);
            UnityEngine.Debug.Break();
            UnityEditor.EditorApplication.isPlaying = false;
#else
            //todo error send
#endif
        }

        internal static void RegisterUnitInGame(BaseGameUnit unit)
        {
            Mediator.Instance.GetInstanceByType<BattleHandler>().AddUnit(unit);
        }

        internal static void UnregisterUnitInGame(BaseGameUnit unit)
        {
            Mediator.Instance.GetInstanceByType<BattleHandler>().RemoveUnit(unit);
        }

        internal static T GetEventArgByType<T>()
            where T: EventArgs
        {
            return (T)Mediator.Instance.GetInstanceByType<UnitEventArgsPool>().Get(typeof(T));
        }
    }
}