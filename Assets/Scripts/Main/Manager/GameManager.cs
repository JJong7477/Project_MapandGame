using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ChatUI ChatUI {  get; private set; }
    public PlayerController player {  get; private set; }

    private void Awake()
    {
        Instance = this;
        
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        ChatUI = FindObjectOfType<ChatUI>(); //��Ȱ��ȭ�� ��ã��
        ChatUI.gameObject.SetActive(false);
    }
}
