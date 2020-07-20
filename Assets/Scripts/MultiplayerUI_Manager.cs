using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MultiplayerUI_Manager : MonoBehaviourPunCallbacks
{
    public GameObject withFriendsButton;
    public GameObject publicMatchButton;
    public GameObject LoginUI;
    public GameObject letsGO;

    static public bool withFriends = false;          //aishika

    [Header("Connection Status UI")]
    public GameObject uI_ConnectionStatusGameobject;
    public Text connectionStatusText;
    public bool showConnectionStatus = false;

    public InputField playerNameInputField;

    public GameObject closebutton;

    void Update()
    {
        if (showConnectionStatus)
        {
            connectionStatusText.text = "Connection Status: " + PhotonNetwork.NetworkClientState;

        }

    }
    public void withFriendsButtonClicked()
    {
        withFriends = true;                   //aishika
        if (PhotonNetwork.IsConnected)
        {

        }
        else
        {
            withFriendsButton.SetActive(false);
            publicMatchButton.SetActive(false);
            LoginUI.SetActive(true);
            closebutton.SetActive(false);
        }
    }

    public void PublicMatchButtonClicked()           //aishika
    {
        withFriends = false;             
        if (PhotonNetwork.IsConnected)
        {

        }
        else
        {
            withFriendsButton.SetActive(false);
            publicMatchButton.SetActive(false);
            LoginUI.SetActive(true);
            closebutton.SetActive(false);
        }
    }
    public void OnEnterGameButtonClicked()
    {

        string playerName = playerNameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            withFriendsButton.SetActive(false);
            publicMatchButton.SetActive(false);
            LoginUI.SetActive(false);

            closebutton.SetActive(true);

            showConnectionStatus = true;
            uI_ConnectionStatusGameobject.SetActive(true);


            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LocalPlayer.NickName = playerName;

                PhotonNetwork.ConnectUsingSettings();
            }

        }
        else
        {
            Debug.Log("Player name is invalid or empty!");
        }


    }

    public override void OnConnected()
    {
        Debug.Log("We connected to Internet");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to Photon Server");
        letsGO.SetActive(true);
        LoginUI.SetActive(false);
        uI_ConnectionStatusGameobject.SetActive(false);


    }

    public void OnLetsGoButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Scene_PlayerSelection");
    }

    public void OnExitButtonYESClicked()
    {
        Application.Quit();
    }
    
}
