using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private ChatUI chatUI;

    private BaseNPC currentNPC;

    private bool isNPCNearby = false;
    private bool hasTalked = false;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            //Debug.Log("close");
            isNPCNearby = true;
            currentNPC = other.GetComponentInParent<BaseNPC>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            //Debug.Log("far");
            isNPCNearby = false;
            hasTalked = false;
            currentNPC = null;
            //chatUI.CloseChatboard();
        }
    }

    public void OnTalk(InputValue inputValue)
    {
        if (isNPCNearby)
        {
            if (currentNPC != null)
            { 
                //hasTalked = true;
                currentNPC.ShowDialog(); 
            }
        }
    }
}
