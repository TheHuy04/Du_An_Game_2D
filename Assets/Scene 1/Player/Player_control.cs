using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private bool _isMovingRight = true;
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform _arrow;

    private BoxCollider2D _boxCollider2D;
    private Animator _animator;
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
        Jump();
        Fire();
    }
    private void Move()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.localPosition += new Vector3(horizontalInput, 0, 0)
           * moveSpeed * Time.deltaTime;
        if (horizontalInput > 0)
        {
            //qua phai
            _isMovingRight = true;
            _animator.SetBool("IsRun", true);
        }
        else if (horizontalInput < 0)
        {
            //qua trai
            _isMovingRight = false;
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }
        transform.localScale = _isMovingRight ?
           new Vector2(0.7f, 0.7f)
           : new Vector2(-0.7f, 0.7f);
    }
    private void Jump()
    {
        var check = _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Flat_form"));
        if (check == false)
        {
            return;
        }
        var verticalInput = Input.GetKeyDown(KeyCode.Space) ? 1 : 0;
        if (verticalInput > 0)
        {
            _animator.SetBool("IsJump", true);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }
        else
        {
            _animator.SetBool("IsJump", false);
        }
    }
    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.SetBool("IsAttack", true);
            //tao vien dan tai vi tri sung
            var bullet = Instantiate(_bulletPrefab, _arrow.position, Quaternion.identity);
            // cho vien dan bay theo huong nhan vat:        
            var velocity = new Vector3(50f, 0);
            if (_isMovingRight == false)
            {
                velocity.x *= -1;
                
            }
            bullet.GetComponent<Rigidbody2D>().velocity = velocity;
            // huy dan sau 2s
            Destroy(bullet, 1f);          
        }
        else
        {
            _animator.SetBool("IsAttack", false);
        }
        
    }

}
