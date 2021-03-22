using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("Platform Stats")]
    public Vector2 target;
    public Vector2 direction;
    [SerializeField] [Range(0f, 25f)] public float speed;
    [SerializeField] [Range(0f, 25f)] public float currentSpeed;
    [SerializeField] private float _pos;

    void Awake()
    {
        direction = new Vector2();
        speed = 20f;
        currentSpeed = speed;
    }

    void Update()
    {
        _pos = transform.position.y;
        if (Mathf.Abs(_pos) <= 12.4 || Mathf.Abs(target.y) <= 12.4)
        {
            direction.y = target.y - _pos;
            direction.Normalize();

            if (Mathf.Abs(_pos - target.y) < 1.5f)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0f, 10f * Time.deltaTime);
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, speed, 10f * Time.deltaTime);
            }
        } else
        {
            direction.y = 0;
        }

        transform.Translate(direction * currentSpeed * Time.deltaTime);
    }
}
