using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using HUD;
using UnityEngine;
using System;
using Inventory.Model;

public class PlayerController : MonoBehaviour
{
    [Header(header: "Components: ")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;
    public HungerCounterHandler Hunger;
    [SerializeField] ShopSystem _shopSystem;
    IClothing _currentClothes;

    [Header(header: "Movement: ")]
    [SerializeField] float moveSpeed = 5.0f;
    Vector2 _playerInput;

    public bool CanInteract;
    private void Start()
    {
        _currentClothes = IClothing.Detective;
        CanInteract = false;
    }

    void Update()
    {
        GetPlayerInput();
        if(Input.GetKeyDown(KeyCode.E) && CanInteract)
        {
            _shopSystem.OpenShop();
        }
    }
    void GetPlayerInput()
    {
        _playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        UpdateAnimation();

        UpdateSpriteRotation();
    }
    void UpdateAnimation()
    {
        if (_currentClothes == IClothing.Detective)
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
        else if(_currentClothes == IClothing.Astronaut)
        {
            if (_playerInput != Vector2.zero)
            {
                _animator.Play("Astronaut_Walk");
            }
            else
            {
                _animator.Play("Astronaut_Idle");
            }
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
    public void ChangeClothes(IClothing newClothes)
    {
        _currentClothes = newClothes;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShopSystem shop = collision.GetComponent<ShopSystem>();
        if(shop != null)
        {
            CanInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ShopSystem shop = collision.GetComponent<ShopSystem>();
        if (shop != null)
        {
            CanInteract = false;
        }
    }
}
