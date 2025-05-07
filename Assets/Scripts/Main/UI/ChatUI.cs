using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatUI : MonoBehaviour
{
    [SerializeField] private TMP_Text talkText;
    [SerializeField] private TMP_Text nameText;

    public void Show(string name, string text)
    {
        text = text.Replace("\\n", "\n");
        talkText.text = text;
        nameText.text = name;

        if(string.IsNullOrEmpty(text))
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
