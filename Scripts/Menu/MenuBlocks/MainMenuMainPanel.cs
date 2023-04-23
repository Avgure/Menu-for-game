using UnityEngine;

namespace Menu
{
    public class MainMenuMainPanel : MenuBlock
    {
        [SerializeField] private GameStateManager _gameStateManager;

        public void StartGame()
        {
            _gameStateManager.LoadNextScene();
        }

        public void ExitGame()
        {
            _gameStateManager.QuitApplication();
        }
    }
}