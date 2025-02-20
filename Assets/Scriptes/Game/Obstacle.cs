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
        // y��ǥ�� RanDom 1~3��ŭ ����� ƴ�� ������Ű�鼭 �� �Ʒ��� ����� 
        float holeSize = Random.Range(holeSizMin, holeSizMax);
        float halfHoleSize = holeSize / 2;
        // �ڽ� ������Ʈ���� ��ġ/ �� ƴ�� ũ�⸦ ���� 
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        //x������ 4��ŭ �̵� /������ position���� 
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        //���⼭ �� �� y����? >���⼭ ��ġ�� ��������� �� ���Ʒ��� ƴ�� ����� 
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

}
