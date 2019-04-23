using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int score { get; private set; }

    private NetworkService _network;
    private GameObject _player;

    public void Startup(NetworkService network)
    {
        Debug.Log("Player Manage is starting up...");
        _network = network;

        status = ManagerStatus.Started;

    }
    
    public void UpdateScore(int deltaScore = 1)
    {
        score += deltaScore;
    }

    public void PlayerJump()
    {
        _player = GameObject.FindWithTag("Player");
        _player.GetComponent<PlayerController>().playerJump();
    }



}
