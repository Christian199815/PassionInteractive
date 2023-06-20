using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public List<DialogueData> Messages = new List<DialogueData>();

    public int currMessageIndex = -1;

    public Text dialogueText;

    public int messageDisplaySeconds = 3;

    private void Start()
    {
        playMessage(2, messageDisplaySeconds);
    }

    // Update is called once per frame
    void Update()
    {
        NextMessage();
    }

    public void playMessage(int messageIndex, int seconds)
    {
        dialogueText.text = Messages[messageIndex].message;
        StartCoroutine(messageTimer(seconds, messageIndex));
        
    }



    public void playRoomMessage(string roomName)
    {
        switch(roomName)
        {
            case "Room1":
                playMessage(16, messageDisplaySeconds);
                break;
            case "Room2":
                playMessage(17, messageDisplaySeconds);
                break;
            case "Room3":
                playMessage(18, messageDisplaySeconds);
                break;
            case "Room4":
                playMessage(19, messageDisplaySeconds);
                break;
            case "Room5":
                playMessage(20, messageDisplaySeconds);
                break;
            case "Room6":
                playMessage(21, messageDisplaySeconds);
                break;
            case "LiftArea1":
                playMessage(2, messageDisplaySeconds);
                break;
            case "LiftArea2":
                playMessage(9, messageDisplaySeconds);
                break;
            case "Hallway":
                playMessage(4, messageDisplaySeconds);
                break;

        }
    }

   IEnumerator messageTimer(int seconds, int messageIndex)
    {
        yield return new WaitForSeconds(seconds);
        currMessageIndex = messageIndex;
        dialogueText.text = "";
    }



    public void RemoveMessage()
    {
        dialogueText.text = "";
    }

    void NextMessage()
    {
        switch (currMessageIndex)
        {
            case 0:
                playMessage(1, messageDisplaySeconds);
                break;
            case 2:
                playMessage(3, messageDisplaySeconds);
                break;
            case 11:
                playMessage(12, messageDisplaySeconds);
                break;
            case 12:
                playMessage(13, messageDisplaySeconds);
                break;
            case 13:
                playMessage(14, messageDisplaySeconds);
                break;
        }

    }
}
