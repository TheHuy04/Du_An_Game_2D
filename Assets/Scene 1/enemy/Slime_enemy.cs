using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_enemy : MonoBehaviour
{
    [SerializeField]
    private bool _moveRight = false;
    [SerializeField]
    private float _moveSpeed = 3f;
    [SerializeField]
    private float _TimeFlip = 5.0f;
    [SerializeField]
    private float _timeFlipCounter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeFlipCounter -= Time.deltaTime;
        if(_timeFlipCounter < 0)
        {
            _timeFlipCounter = _TimeFlip;
            _moveRight = ! _moveRight;
            Flip();
        }
        Move();
    }
    public void Move()
    {
        Vector2 direction = _moveRight ? Vector2.right : Vector2.left;
        transform.Translate(direction * _moveSpeed *Time.deltaTime);
    }
    public void Flip()
    {
        Vector2 Scale = transform.localScale;
        Scale.x *= - 1;
        transform.localScale = Scale;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
