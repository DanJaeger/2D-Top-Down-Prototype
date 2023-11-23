using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(header: "Components: ")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;

    [Header(header: "Movement: ")]
    [SerializeField] float moveSpeed = 5.0f;
    Vector2 _playerInput;

    BoundsHandler _boundsHandler;
    Collider2D[] _bounds;
    void Start()
    {
        GetLevelBounds();
    }
    void GetLevelBounds()
    {
        _boundsHandler = GameObject.FindGameObjectWithTag("BoundHandler").GetComponent<BoundsHandler>();
        if (_boundsHandler != null)
        {
            _bounds = _boundsHandler.LevelBounds;
        }
        else
        {
            Debug.LogError("Bounds Handler NOT found on the scene!");
        }
    }
    void Update()
    {
        GetPlayerInput();
    }
    void GetPlayerInput()
    {
        if (IsOnBounds())
        {
            _playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            UpdateAnimation();
        }

        UpdateSpriteRotation();
    }
    void UpdateAnimation()
    {
        if (_playerInput != Vector2.zero)
        {
            _animator.Play("Detective_Walk");
        }
        else
        {
            _animator.Play("Detective_Idle");
        }
    }
    void UpdateSpriteRotation()
    {
        if (_playerInput.x < 0)
             _spriteRenderer.flipX = true;
        else if(_playerInput.x > 0)
            _spriteRenderer.flipX = false;
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    
    void MoveCharacter()
    {
        Vector2 forceToApply = _playerInput * moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + forceToApply);
    }

    bool IsOnBounds()
    {
        //Vector3 newPosition = transform.position;
        //foreach (Collider2D collider in _bounds)
        //{
        //    newPosition.x = Mathf.Clamp(newPosition.x, collider.bounds.min.x, collider.bounds.max.x);
        //    newPosition.y = Mathf.Clamp(newPosition.y, collider.bounds.min.y, collider.bounds.max.y);
        //}
        return true;
    }

}
