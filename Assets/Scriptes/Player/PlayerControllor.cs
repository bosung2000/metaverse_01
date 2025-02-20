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
        // layer�� ���� ���ؼ� ������ ã���ɷ� �ν� 
        if (ConllisionLayers.value == (ConllisionLayers.value | (1 << collision.gameObject.layer)))
        {
            // ���� scenes�� ����� �ű������ �ε� ���ָ� �� "Flappy_Bird"
            SceneManager.LoadScene("Flappy_Bird");
            Debug.Log("���� ����");
            //player�� �߷���0?
            
        }
    }
}
