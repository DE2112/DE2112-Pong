using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [Header("Sprite Stats")]
    private Vector3 _spriteRotation;
    private float _rotationSpeed;

    [Header("Ball Controller")]
    [SerializeField] private BallController ballController;

    void Start()
    {
        _spriteRotation = Vector3.forward;
    }

    void Update()
    {
        _rotationSpeed = ballController.rotationSpeed;
        transform.Rotate(_spriteRotation * _rotationSpeed * Time.deltaTime * 10f);
    }
}
