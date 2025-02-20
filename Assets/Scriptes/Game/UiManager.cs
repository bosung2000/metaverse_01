using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI BestScoreText;
    public Button RestartBotton;
    public Button Exit_Botton;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
       // RestartBotton.gameObject.SetActive(false);
        //Exit_Botton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRestart()
    {
        RestartBotton.gameObject.SetActive(true);
        Exit_Botton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
