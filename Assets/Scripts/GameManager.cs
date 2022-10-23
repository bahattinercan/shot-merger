using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerT;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }
}