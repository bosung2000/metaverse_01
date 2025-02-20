using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizMin = 1f;
    public float holeSizMax =3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player=collision.GetComponent<Player>();

        if (player !=null)
        {
            gameManager.AddScore(1);
        }
    }


    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        // y좌표를 RanDom 1~3만큼 만들고 틈은 고정지키면서 위 아래로 만들기 
        float holeSize = Random.Range(holeSizMin, holeSizMax);
        float halfHoleSize = holeSize / 2;
        // 자식 오브젝트들의 위치/ 측 틈의 크기를 조정 
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        //x축으로 4만큼 이동 /마지막 position에서 
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        //여기서 왜 또 y축을? >여기서 위치를 잡아줌으로 써 위아래로 틈이 생기게 
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

}
