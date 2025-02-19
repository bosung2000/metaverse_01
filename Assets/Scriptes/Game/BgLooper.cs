using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numbgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPostion =Vector3.zero; //�ʱ�ȭ 
    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles =GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPostion = obstacles[0].transform.position; // ó�� ���� ��ġ �ľ� // �׷����� ���İ� ������ ���� 
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPostion = obstacles[i].SetRandomPlace(obstacleLastPostion); //�������� ������ŭ ���� 
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
