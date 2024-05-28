using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    [SerializeField]
    private bool _moveRight = true;
    [SerializeField]
    private float _moveSpeed = 5f;
   
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private BoxCollider2D _boxCollider2D;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    private void Move()
    {
        var horizonatalInput = Input.GetAxis("Horizontal");
        transform.localPosition += new Vector3(horizonatalInput, 0, 0)
        * _moveSpeed * Time.deltaTime;
        if (horizonatalInput > 0)
        {
            _moveRight = true;
            _animator.SetBool("IsRun", true);

        }
        else if (horizonatalInput < 0)
        {
            _moveRight = false;
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }
        transform.localScale = _moveRight ?
            new Vector2(0.7f, 0.7f)
            : new Vector2(-0.7f, 0.7f);
    }
   
}
