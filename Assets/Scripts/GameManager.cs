using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EPlayerPref
{
    level,
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerT;

    [Space]
    [SerializeField] public Transform explosionEffect;

    [SerializeField] private TextMeshProUGUI levelText, bulletPerSecText;
    [SerializeField] private EndGamePanel endGamePanel;

    [Space]
    public bool isPlayerOnTheFinishLine = false;

    private int level = 1;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        if (!PlayerPrefs.HasKey(EPlayerPref.level.ToString()))
        {
            PlayerPrefs.SetInt(EPlayerPref.level.ToString(), 1);
            level = 1;
        }
        else
        {
            level = PlayerPrefs.GetInt(EPlayerPref.level.ToString());
        }
    }

    private void Start()
    {
        UpdateBulletPerSecText(1);
        levelText.text = "Level " + level;
    }

    public void FinishTheGame()
    {
        Vibration.Vibrate(50);
        endGamePanel.gameObject.SetActive(true);
        Debug.Log("write finish the game");
        if (isPlayerOnTheFinishLine)
        {
            endGamePanel.Setup(level.ToString(), true);
        }
        else
        {
            endGamePanel.Setup(level.ToString(), false);
        }
        Time.timeScale = 0f;
    }

    public void UpdateBulletPerSecText(int value)
    {
        bulletPerSecText.text = value + "/sec";
    }

    public void NextLevelButton()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt(EPlayerPref.level.ToString(), level + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnExplosionEffect(Transform t)
    {
        Instantiate(explosionEffect, t.position, Quaternion.identity);
    }
}