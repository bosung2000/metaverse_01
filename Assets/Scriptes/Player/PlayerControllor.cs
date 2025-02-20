using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControllor : MonoBehaviour
{
    [SerializeField] private LayerMask ConllisionLayers;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertial = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertial).normalized * moveSpeed;
        rb.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // layer를 값을 비교해서 같으면 찾은걸로 인식 
        if (ConllisionLayers.value == (ConllisionLayers.value | (1 << collision.gameObject.layer)))
        {
            // 게임 scenes을 만들고 거기씬으로 로드 해주면 됨 "Flappy_Bird"
            SceneManager.LoadScene("Flappy_Bird");
            Debug.Log("게임 입장");
            //player의 중력을0?
            
        }
    }
}
