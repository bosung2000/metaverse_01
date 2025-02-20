using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;
    Collider2D _collider;
    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    

    bool isFlap = false;

    public bool godMode = false;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        gameManager = GameManager.Instance;
    }

    // 매 프레임마다 호출
    void Update()
    {

        if (isDead) //죽은경우 
        {
            
        }
        else //안죽은 경우 
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }
    //fixed update는 update 다음으로 실행? NO
    //fixed update는  고정된 시간 간격으로 실행 > 물리연산에 적합 /프레임속도와 무관
    private void FixedUpdate()
    {
        if (isDead) return;
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10), -90, 90);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        isDead = true;
        

        animator.SetInteger("isDie", 1);
        Debug.Log("Die");
        gameManager.GameOver();

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
    //    if (obstacle != null &&collision.CompareTag("Obstacle"))
    //    {
    //        gameManager.AddScore(1);
    //    }
    //}

}
