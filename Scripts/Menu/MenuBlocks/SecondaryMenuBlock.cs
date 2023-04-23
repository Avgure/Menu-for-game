using UnityEngine;

namespace Menu
{
    public class SecondaryMenuBlock : MenuBlock
    {
        [SerializeField] private MenuBlock _parentMenuBlock;

        public void ReturnToParentMenuBlock()
        {
            CloseMenuBlock();
            _parentMenuBlock.OpenMenuBlock();
        }
    }
}