using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
 public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    private Button startServerButton;

    [SerializeField]
    private Button startHostButton; 
    [SerializeField]
    private TextMeshProUGUI playerInGameText; 

    private void Awake()
    {
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        print("onclick 0");
        startHostButton.onClick.AddListener(HostClickEvent);

        startServerButton.onClick.AddListener(ServerClickEvent);

        startClientButton.onClick.AddListener(ClientClickEvent);
    }

    // Update is called once per frame
    void Update()
    {
        //playerInGameText.text = $"Players in game: {PlayeerManager.Instance.PlayersInGame}"; 
    }

    public void ClientClickEvent()
    {
        if(NetworkManager.Singleton.StartClient())
        {
            print("Client started...");
        }
        else
        {
            print("Client could not be started...");
        }
    }
    public void ServerClickEvent()
    {
        if(NetworkManager.Singleton.StartServer())
        {
            print("Server started...");
        }
        else
        {
            print("Server could not be started...");
        }
    }
    public void HostClickEvent()
    {
        print("onclick 1");
        if(NetworkManager.Singleton.StartHost())
        {
             print("Host started...");
        }
        else
        {
            print("Host could not be started...");
        }
    }
}
