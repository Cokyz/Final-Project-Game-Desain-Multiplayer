using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Lobby : MonoBehaviourPunCallbacks
{
    public static Lobby lobby;

    public GameObject battleButton;
    public GameObject cancleButton;

    private void Awake()
    {
        lobby = this; //Create the singleton, live withing the main menu scene.
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//Connects to master photon server
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon Master Server");
        battleButton.SetActive(true);// player now connected to servers, enables battlebutton to allow join a game
    }

    public void OnBattleButtonClicked()
    {
        battleButton.SetActive(false);
        cancleButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();// join a rondom room
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tired to join a random game but failed. There must be no open games avaliable");
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tired to create a new room but failed, there must already be a room with the same name");
        CreateRoom();
    }

    public void OnCancleButtonClicked()
    {
        cancleButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
