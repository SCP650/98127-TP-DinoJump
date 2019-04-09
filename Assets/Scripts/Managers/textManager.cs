using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    

    public void Startup(NetworkService network)
    {
        Debug.Log("Player Manage is starting up...");
        _network = network;
        Managers.dataMana.GetDict();
        status = ManagerStatus.Started;
    }


}
