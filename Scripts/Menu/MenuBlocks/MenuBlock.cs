using UnityEngine;

namespace Menu
{
    public abstract class MenuBlock : MonoBehaviour
    {
        public bool IsOpen => isActiveAndEnabled;

        public void OpenMenuBlock()
        {
            gameObject.SetActive(true);
        }

        public void CloseMenuBlock()
        {
            gameObject.SetActive(false);
        }
    }
}