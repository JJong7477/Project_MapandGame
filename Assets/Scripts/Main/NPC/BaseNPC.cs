using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseNPC : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject dialog;

    int inputCount = 0;
    [SerializeField] protected string npcName;
    [SerializeField] protected string[] talk;




    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    public void ShowDialog()
    {
        if (inputCount >= talk.Length)
        {
            TalkInfo();
        }
        else
        {
            gameManager.ChatUI.Show(npcName, talk[inputCount]);
        }
        inputCount++;
    }

    //public virtual void ShowNPCName()
    //{

    //}

    //public void EndDialog()
    //{

    //}

    public abstract void TalkInfo();
}
