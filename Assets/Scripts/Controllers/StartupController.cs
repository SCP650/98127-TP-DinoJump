using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartupController : MonoBehaviour
{
    [SerializeField] private Slider progressBar;

    private void Awake()
    {
        Messenger<int, int>.AddListener(StartupEvent.MANAGERS_PROGRESS, OnManagerProgress);
        Messenger.AddListener(StartupEvent.MANAGERS_STARTED, OnManagerStarted);

    }

    private void OnDestroy()
    {
        Messenger<int, int>.RemoveListener(StartupEvent.MANAGERS_PROGRESS, OnManagerProgress);
        Messenger.RemoveListener(StartupEvent.MANAGERS_STARTED, OnManagerStarted);

    }

    private void OnManagerProgress(int numReady, int numFinished)
    {
        float percent =(float) numReady / numFinished;
        progressBar.value = percent;
    }

    private void OnManagerStarted()
    {
        Managers.mission.GoToNext();
    }

}
