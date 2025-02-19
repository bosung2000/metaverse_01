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

    // game에선는  y축을 고정해야하고  map에서는 y축을 따라가야한다는 상황이 다르다 
    //하지만 나머지 코드가 같다. / 해결방법 
    // layer랑 tag로도 가능할것같은데 씬의 이름으로 안되나? >> 성공
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
