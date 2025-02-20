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
        gameManager = this; // 순서의 오류가 있을수 있기떄문에 awake에서 생성 / start에서 인스턴스 사용
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //지금 사용중인 씬을 보여줌 
    }
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score {currentScore}");
    }
}
