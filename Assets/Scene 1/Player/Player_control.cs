using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_control : MonoBehaviour
{

    
    public float moveSpeed = 5f;
    
    public bool _isMovingRight = true;
    private Rigidbody2D _rigidbody2D;
    
    public float _jumpForce = 5f;
    
    public GameObject _bulletPrefab;
    
    public Transform _arrow;

    public bool Climb;

    public TextMeshProUGUI _CoinText;
    private int _coins = 0;

    public TextMeshProUGUI _LivesText;
    private static  int _Lives = 3;

    public GameObject _GameOverPanel;

    private BoxCollider2D _boxCollider2D;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _CoinText.text = _coins.ToString();
        _LivesText.text = _Lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Fire();
        if( Climb)
        {
            var lenThang = Input.GetAxisRaw("Horizontal");
            var lenThang2 = Input.GetAxisRaw("Vertical");
            _rigidbody2D.velocity = new Vector3 (lenThang *1f, lenThang2 *3f, 0f);
        }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("lander"))
        {
            _rigidbody2D.gravityScale = 0;
            Climb = true;
            _animator.SetBool("Is_land", true);
        }
        else if (collision.CompareTag("enemy"))
        {
            _Lives -= 1;
            if (_Lives > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                _GameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            _coins += collision.gameObject.GetComponent<Coins>().coinvaule;
            _CoinText.text = _coins.ToString();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("lander"))
        {
            _rigidbody2D.gravityScale = 1f;
            Climb= false;
            _animator.SetBool("Is_land", false);
        }
    }

}
