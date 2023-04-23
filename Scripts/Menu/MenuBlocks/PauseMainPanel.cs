using UnityEngine;

namespace Menu
{
    public class PauseMainPanel : MenuBlock
    {
        [SerializeField] private GameStateManager _gameStateManager;

        public void ResumeGame()
        {
            CloseMenuBlock();
            _gameStateManager.UnpauseGame();
        }

        public void ExitToMainMenu()
        {
            _gameStateManager.LoadPreviousScene();
        }
    }
}