using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private int initialBallCount;
    private int remainingBallCount;
    private int penalty = 0;
    private int score = 0;

    void Start()
    {
        initialBallCount = GameObject.FindGameObjectsWithTag("gameball").Length;
        winTextObject.SetActive(false);
        RefreshScore();
    }

    public void RefreshScore()
    {
        remainingBallCount = GameObject.FindGameObjectsWithTag("gameball").Length;
        Debug.Log(remainingBallCount);

        score = initialBallCount - remainingBallCount - penalty;

        countText.text = "Score: " + score.ToString();

        winTextObject.SetActive(remainingBallCount == 1);
    }

    public void AddPenalty()
    {
        penalty++;
        RefreshScore();
    }
}