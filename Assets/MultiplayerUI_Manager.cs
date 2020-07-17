using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiplayerUI_Manager : MonoBehaviour
{
    [SerializeField] GameObject withFriends;
    [SerializeField] GameObject joinRandomRoom;
    [SerializeField] InputField playerNamefield;
    [SerializeField] GameObject loginBox;
    private string playerName;

    void Start()
    {
        withFriends.SetActive(true);
        joinRandomRoom.SetActive(true);
        loginBox.SetActive(false);
    }

    public void PlayWithFriendsButton()
    {
        withFriends.SetActive(false);
        joinRandomRoom.SetActive(false);
        loginBox.SetActive(true);
    }

    public void EnterButtonClick()
    {
        withFriends.SetActive(false);
        joinRandomRoom.SetActive(false);
        loginBox.SetActive(true);

        playerName = playerNamefield.text;
        if(!string.IsNullOrEmpty(playerName))
        {
            SceneLoader.Instance.LoadScene("Scene_Loading");
        }
    }
}
