using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkController : MonoBehaviour
{
    [SerializeField] private TMP_Text talkText;

    public void Show(string text)
    {
        talkText.text = text;
        this.gameObject.SetActive(true);
    }
}
