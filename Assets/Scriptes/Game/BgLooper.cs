using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numbgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPostion =Vector3.zero; //초기화 
    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles =GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPostion = obstacles[0].transform.position; // 처음 생성 위치 파악 // 그래야지 이후것 생성이 가능 
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPostion = obstacles[i].SetRandomPlace(obstacleLastPostion); //랜덤으로 갯수만큼 생성 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigerd: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x *2;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numbgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPostion = obstacle.SetRandomPlace(obstacleLastPostion);
        }
    }
}
