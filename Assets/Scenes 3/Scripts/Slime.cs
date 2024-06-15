using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
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
        if (_timeFlipCounter < 0)
        {
            _timeFlipCounter = _TimeFlip;
            _moveRight = !_moveRight;
            Flip();
        }
        Move();
    }
    private void Move()
    {
        Vector2 direction = _moveRight ? Vector2.left : Vector2.right;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
    private void Flip()
    {
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    void Die()
    {
        
        Destroy(gameObject);
    }


}

