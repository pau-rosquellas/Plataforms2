﻿using Photon.Pun;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;

public class MainMenu : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private TextMeshProUGUI waitingStatusText = null;
    

    
    public static string[] maps = { "SampleScene", "Level2", "Level3"};

    private bool isConnecting = false;

    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 2;

    private void Awake() 
    {
      PhotonNetwork.AutomaticallySyncScene = true;
      Debug.Log(PlayerPrefs.GetInt("skinChoosen"));
      
    }



    public void FindOpponent()
    {
        isConnecting = true;

        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);

        waitingStatusText.text = "Searching...";

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        } 
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("ConnectedToMaster");

        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);
        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Nobody is waiting for opponents, creating new room");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Client succesfully joined a room");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if (playerCount != MaxPlayersPerRoom)
        {
            waitingStatusText.text = "Waiting For Opponent";
            Debug.Log("Client is waiting for opponent");
        }
        else
        {
            waitingStatusText.text = "Opponent found";
            Debug.Log("Matching is ready to begin");
            
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;

            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");
            
            PhotonNetwork.LoadLevel(randomMap());
            
        }
    }

    public static void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public String randomMap(){
        int num = Random.Range(0, 3);
        
        return maps[2];
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void shopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void skinSelector()
    {
        SceneManager.LoadScene("SelectSkin");
    }

   

}
