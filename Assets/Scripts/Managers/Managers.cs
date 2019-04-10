using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(MissionManager))]
[RequireComponent(typeof(DataManager))]
[RequireComponent(typeof(textManager))]

public class Managers : MonoBehaviour
{ 

    public static PlayerManager Player { get; private set; }
    public static MissionManager mission { get; private set; }
    public static DataManager dataMana { get; private set; }
    public static textManager textMana { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Player = GetComponent<PlayerManager>();
        mission = GetComponent<MissionManager>();
        dataMana = GetComponent<DataManager>();
        textMana = GetComponent<textManager>();
        _startSequence = new List<IGameManager>();
       
        _startSequence.Add(Player);
        _startSequence.Add(mission);
        _startSequence.Add(dataMana);
        _startSequence.Add(textMana);

        StartCoroutine(StartupManager());
    }
    private IEnumerator StartupManager()
    {
        NetworkService network = new NetworkService();
        foreach(IGameManager manager in _startSequence)
        {
            manager.Startup(network);
        }
        yield return null;

        //Check if all moduels are set up
        int numModule = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModule)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in _startSequence)
            {
                if(manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if(numReady > lastReady)
            {
                Debug.Log("Progress : " + numReady + " / " + numModule);
                Messenger<int, int>.Broadcast(StartupEvent.MANAGERS_PROGRESS, numReady, numModule);

            }
            yield return null;
        }
        Debug.Log("All moduels are set up");
        Messenger.Broadcast(StartupEvent.MANAGERS_STARTED);
    }

   
}
