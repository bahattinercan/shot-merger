using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText, titleText, impressionText;
    [SerializeField] private GameObject nextLevelbutton, restartButton;

    public void Setup(string level, bool isWin)
    {
        levelText.text = "Level " + level;
        if (isWin)
        {
            restartButton.SetActive(false);
            titleText.text = "Victory!";
            impressionText.text = "Amazing!";
        }
        else
        {
            nextLevelbutton.SetActive(false);
            titleText.text = "Lose!";
            impressionText.text = "Nice Try!";
        }
    }
}