using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlienSurvivalGame.Core.Singleton;
using Unity.Netcode;
public class PlayeerManager : Singleton<PlayeerManager>
{
    private NetworkVariable<int> playersInGame = new NetworkVariable<int>();

    public int PlayersInGame
    {
        get
        {
            return playersInGame.Value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            if(IsServer)
            {
                playersInGame.Value++;
            }
        };
         NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            if(IsServer)
            {
                playersInGame.Value--;
            }
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
