using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class MenuBlocksManager : MonoBehaviour
    {
        public bool AtLeastOneMenuIsOpen => IsAtLeastOneMenuIsOpen();
        public MenuBlock CurrentMenuBlock => GetCurrentMenuBlock();

        [SerializeField] private List<MenuBlock> _menuBlocks;

        private MenuBlock GetCurrentMenuBlock()
        {
            return _menuBlocks.Find(menuBlock => menuBlock.isActiveAndEnabled == true);
        }

        private bool IsAtLeastOneMenuIsOpen()
        {
            return GetCurrentMenuBlock() != null;
        }
    }
}