using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NearNPC
{
    Flap,
    Stack,
    Costume
}


public class NPCManager : MonoBehaviour
{
    FlapNPC flapNPC;
    ChatUI chatUI;

    private NearNPC nearNPC;

    private void Awake()
    {
        flapNPC = GetComponentInChildren<FlapNPC>();
        chatUI = FindObjectOfType<ChatUI>();
    }

    public void SetFlap()
    {
        //chatUI.CloseChatboard();
        flapNPC.StartFlap();
    }


}
