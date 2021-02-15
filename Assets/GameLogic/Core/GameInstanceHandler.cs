using UnityEngine;

namespace TestProject.DevOOP.Core
{
    /// <summary>
    /// This class self create on game scene and instantiate main core class.
    /// </summary>
    /// <remarks>Use <see cref="RuntimeInitializeOnLoadMethodAttribute"/></remarks>
    /// <seealso cref="GameInitialization"/>
    internal sealed class GameInstanceHandler : MonoSingleton<GameInstanceHandler>
    {
        //test
        private bool _speedUp;

        [RuntimeInitializeOnLoadMethod]
        internal static void GameInitialization()
        {
            _Debug.Log("Start Game!", DebugColor.green);
            var _self = GameInstanceHandler.Instance;
            _self.gameObject.name = ">>GameInstanceHandler<<";

            Mediator.Instance.SetInstance(new NavigationHandler());
            Mediator.Instance.SetInstance(new BattleHandler());
            Mediator.Instance.SetInstance(new CaptureHandler());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_speedUp)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 3;
                }

                _speedUp = !_speedUp;
            }
        }
    }
}