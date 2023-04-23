using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainUserInputGetter : MonoBehaviour
{
    public UnityEvent OnPressingEscapeKey;
    public UnityEvent OnPressingEnterKey;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPressingEscapeKey?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            OnPressingEnterKey?.Invoke();
        }
    }
}