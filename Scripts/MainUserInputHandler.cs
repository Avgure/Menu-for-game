using UnityEngine;
using Menu;
using Unity.VisualScripting;

public class MainUserInputHandler : MonoBehaviour
{
    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private MenuBlocksManager _menuBlocksManager;
    [SerializeField] private MenuBlock _menuBlockToOpen;

    public void RespondToEscapeKey()
    {
        bool menuIsOpen = _menuBlocksManager.AtLeastOneMenuIsOpen;

        if (menuIsOpen)
        {
            MenuBlock currentMenuBlock = _menuBlocksManager.CurrentMenuBlock;

            if (_menuBlocksManager.CurrentMenuBlock is SecondaryMenuBlock secondaruBlock)
            {
                secondaruBlock.ReturnToParentMenuBlock();
            }
            else if (_gameStateManager.ActiveSceneIndex != 0)
            {
                currentMenuBlock.CloseMenuBlock();
                _gameStateManager.UnpauseGame();
            }
            else _gameStateManager.QuitApplication();
        }
        else
        {
            _gameStateManager.PauseGame();
            _menuBlockToOpen.OpenMenuBlock();
        }
    }
}