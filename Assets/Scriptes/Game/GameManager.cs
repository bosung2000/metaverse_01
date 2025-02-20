using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    private void Awake()
    {
        gameManager = this; // ������ ������ ������ �ֱ⋚���� awake���� ���� / start���� �ν��Ͻ� ���
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("GameOver");

    }
    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //���� ������� ���� ������ 
    }
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score {currentScore}");
    }
}
