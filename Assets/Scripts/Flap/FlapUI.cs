using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlapUI : MonoBehaviour
{
    public Image flapOver;
    public TextMeshProUGUI startGame;
    public TextMeshProUGUI nowScore;
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI currentScore;
    public GameObject scoreBox;

    private FlapGM flapGM;
    public FlapUI flapUI;

    public Button restartBtn;
    public Button exitBtn;

    int bestRecord = 0;
    int currentRecord = 0;

    public int BestRecord { get => bestRecord; }
    public int CurrentRecord { get => currentRecord; }
    private const string BestRecordKey = "BestRecord";

    private void Awake()
    {
        flapGM = FlapGM.Instance;
    }

    public void Start()
    {
        flapOver.gameObject.SetActive(false);
        scoreBox.gameObject.SetActive(true);

        bestRecord = PlayerPrefs.GetInt(BestRecordKey, 0);
        bestScore.text = bestRecord.ToString();
    }

    public void SetRestart()
    {
        restartBtn.onClick.RemoveAllListeners();
        exitBtn.onClick.RemoveAllListeners();

        flapOver.gameObject.SetActive(true);
        scoreBox.gameObject.SetActive(false);

        UpdateBestRecord();

        restartBtn.onClick.AddListener(OnClickRestartButton);
        exitBtn.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickRestartButton()
    {
        flapGM.RestartGame();
    }

    public void OnClickExitButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void UpdateScore(int score)
    {
        currentRecord = score;
        currentScore.text = score.ToString();
        nowScore.text = score.ToString();
    }

    public void UpdateBestRecord()
    {
        if (BestRecord < currentRecord)
        {
            bestRecord = currentRecord;
            bestScore.text = bestRecord.ToString();
            PlayerPrefs.SetInt(BestRecordKey, bestRecord);
        }
    }
}
