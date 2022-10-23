using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerT;
    [SerializeField] private TextMeshProUGUI levelText, bulletPerSecText;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        UpdateBulletPerSecText(1);
        levelText.text = "Level " + 1;
    }

    public void UpdateBulletPerSecText(int value)
    {
        bulletPerSecText.text = value + "/sec";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}