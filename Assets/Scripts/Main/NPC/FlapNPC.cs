using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlapNPC : BaseNPC
{
    public void StartFlap()
    {
        SceneManager.LoadScene("FlapScene");
    }

    public override void TalkInfo()
    {
        Invoke(nameof(StartFlap), 3f);
    }
}
