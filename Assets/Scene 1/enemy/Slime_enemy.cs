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
    [SerializeField]
    private int _HP = 100;
    public AudioClip enemyEffect;
    public AudioClip enemyDead;
    private AudioSource _enemySource;
    // Start is called before the first frame update
    void Start()
    {
        _enemySource = GetComponent<AudioSource>();
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
    private void Move()
    {
        Vector2 direction = _moveRight ? Vector2.right : Vector2.left;
        transform.Translate(direction * _moveSpeed *Time.deltaTime);
    }
    private void Flip()
    {
        Vector2 Scale = transform.localScale;
        Scale.x *= - 1;
        transform.localScale = Scale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _HP -= 25;
            _enemySource.PlayOneShot(enemyEffect);
            Destroy(collision.gameObject);
            if (_HP == 0)
            {
                _enemySource.PlayOneShot(enemyDead);
                Destroy(gameObject,0.2f);
                Destroy(collision.gameObject);
            }
        }
    }
}
