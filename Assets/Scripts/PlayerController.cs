using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(1f, 5f)] private float _speedScale;
    [SerializeField] private PlatformController platformController;

    private void Start()
    {
        _speedScale = 2.5f;
        platformController.speed *= _speedScale;
    }

    void Update ()
    {
        platformController.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
