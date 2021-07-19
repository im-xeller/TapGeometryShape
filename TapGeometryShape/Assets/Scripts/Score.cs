using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreAmountHolder;
    private static int s_score;
    private static int s_bestScore;

    public static void IncreaseScore()
    {
        s_score++;
        if (s_score > s_bestScore)
        {
            s_bestScore = s_score;
        }
    }

    private void Start()
    {
        s_bestScore = PlayerPrefs.GetInt("BestScore");
        s_score = 0;
    }

    private void Update()
    {
        scoreAmountHolder.text = s_score.ToString();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("BestScore", s_bestScore);
    }
}
