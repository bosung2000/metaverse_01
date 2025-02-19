using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public string sceneName = "";
    float offsetX;

    private void Start()
    {
        if (target == null)
        {
            return;
        }

        offsetX = transform.position.x - target.position.x;

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log($"ScenName {sceneName}");
    }

    // game������  y���� �����ؾ��ϰ�  map������ y���� ���󰡾��Ѵٴ� ��Ȳ�� �ٸ��� 
    //������ ������ �ڵ尡 ����. / �ذ��� 
    // layer�� tag�ε� �����ҰͰ����� ���� �̸����� �ȵǳ�? >> ����
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position;
        desiredPosition.x = target.position.x + offsetX;

        if (sceneName.Equals("Flappy_Bird"))
        {
            desiredPosition = new Vector3(desiredPosition.x, transform.position.y, -10); // game
        }
        else if (sceneName.Equals("SampleScene"))
        {
            desiredPosition = new Vector3(desiredPosition.x, desiredPosition.y, -10); //map
        }

        transform.position = desiredPosition;
    }

}
