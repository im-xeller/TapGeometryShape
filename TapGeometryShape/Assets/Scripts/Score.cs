using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text[] scoreAmountHolders;
    [SerializeField] private Text bestScoreAmountHolder;
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
        for (int i = 0; i < scoreAmountHolders.Length; i++)
        {
            scoreAmountHolders[i].text = s_score.ToString();
        }
        bestScoreAmountHolder.text = s_bestScore.ToString();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("BestScore", s_bestScore);
    }
}
