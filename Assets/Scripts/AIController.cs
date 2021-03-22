using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float _speedScale;

    [SerializeField] private PlatformController platformController;
    [SerializeField] private Transform ballPos;

    void Start()
    {
        _speedScale = 0.3f;
        platformController.speed *= _speedScale;
    }

    void Update()
    {
        platformController.target = ballPos.position;
    }
}
