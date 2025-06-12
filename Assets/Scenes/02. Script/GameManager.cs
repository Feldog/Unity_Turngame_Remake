using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UpdateScoreText();
        }
    }

    private void Awake()
    {
        // Ensure that there is only one instance of GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Start()
    {
        score = 0;
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score.ToString()}";
    }
}
