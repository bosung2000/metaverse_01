using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    public  bool Firstbool = false;
    UiManager uiManager;
    public UiManager UiManager { get { return uiManager; } }
    private void Awake()
    {

        gameManager = this;
        uiManager = FindObjectOfType<UiManager>();

        // 씬 로드 이벤트 등록
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // 씬이 로드될 때 호출되는 메서드
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //처음 들오올때 // 아마도 씬을 다시만들면서 이게 초기화 되고 false로 되는것일 것임 
        //그렇다면 이 값을 영구적으로 저장해서 불러오는 방법이 있을수 있고 
        //
        //if (!Firstbool) 
        //{
        //    UiManager.SetRestart();
        //    Time.timeScale = 0;
        //    Debug.Log("Load Game Scene");
        //}
        //else //계속 REstart를 할때 
        //{

        //}
        
    }

    // Start is called before the first frame update
    void Start()
    {
        UiManager.UpdateScore(0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        UiManager.SetRestart();
       // Time.timeScale = 0;
    }
    public void ReStartGame()
    {
        //Firstbool= true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 1;
    }
    public void GameStart()
    {
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MainScene");
        //Time.timeScale = 1;
        //Firstbool = false;
    }
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score {currentScore}");
        UiManager.UpdateScore(currentScore);
    }


}
