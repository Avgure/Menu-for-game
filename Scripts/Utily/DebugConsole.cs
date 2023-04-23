using System.Collections;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
    [SerializeField] private uint _queueSize = 15;

    private Queue _logQueue = new Queue();

    void Start()
    {
        Debug.Log("Started up logging.");
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        _logQueue.Enqueue("[" + type + "] : " + logString);
        if (type == LogType.Exception)
            _logQueue.Enqueue(stackTrace);
        while (_logQueue.Count > _queueSize)
            _logQueue.Dequeue();
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 400, 0, 400, Screen.height));
        GUILayout.Label("\n" + string.Join("\n", _logQueue.ToArray()));
        GUILayout.EndArea();
    }
}