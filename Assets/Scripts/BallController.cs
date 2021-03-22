using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Ball Stats")]
    public Vector2 direction;
    public float rotationSpeed;
    [SerializeField] [Range(0f, 50f)] public float _speed;
    [SerializeField] [Range(0f, 0.5f)] public float _speedDif;
    [SerializeField] [Range(0f, 20f)] private float _period;
    [SerializeField] private float _lastChangeTime;
    private float _prevRotationSpeed;

    [Header("External Components")]
    [SerializeField] private GameScore gameScore;
    private PlatformController platformController;

    [Header("Internal Components")]
    [SerializeField] private ParticleSystem trail;
    [SerializeField] private Animator animator;

    public IEnumerator InitCoroutine(float waitingTime = 0f)
    {
        direction = Vector2.zero;

        yield return new WaitForSeconds(waitingTime);
        trail.Pause();
        trail.Clear();
        transform.position = Vector2.zero;
        _speed = 10f;
        rotationSpeed = 0f;
        trail.Play();
        _lastChangeTime = Time.time;
        direction = Random.insideUnitCircle;

    }

    void Awake()
    {
        _period = 10f;
        _speedDif = 2f;
    }

    void Start()
    {
        StartCoroutine(InitCoroutine(3.0f));
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        direction.Normalize();
        transform.Translate(direction * _speed * Time.deltaTime);
        direction = Rotate(direction, rotationSpeed * Time.deltaTime);
    }

    private Vector2 Rotate(Vector2 vector, float degree)
    {
        degree *= Mathf.Deg2Rad;
        vector = new Vector2(Mathf.Cos(degree) * vector.x - Mathf.Sin(degree) * vector.y,
                             Mathf.Sin(degree) * vector.x + Mathf.Cos(degree) * vector.y);
        return vector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ContactPoint2D contact = other.contacts[0];
        direction = Reflect(direction, contact.normal);
        //direction = Rotate(direction, rotationSpeed * reflectionScale * Time.deltaTime);

        _prevRotationSpeed = rotationSpeed;
        rotationSpeed = 0f;

        if (other.gameObject.tag == "Platform")
        {
            animator.Play("BallStrech");
        }
    }

    private Vector2 Reflect(Vector2 vector, Vector2 normal)
    {
        vector -= 2 * (vector * normal) * normal;
        return vector;
    }



    private void OnCollisionExit2D(Collision2D other)
    {
        GameObject obj = other.gameObject;
        rotationSpeed = _prevRotationSpeed;

        if (obj.tag == "Platform")
        {
            platformController = obj.GetComponent<PlatformController>();

            if (obj.name == "Player")
            {
                rotationSpeed += platformController.direction.y * platformController.currentSpeed;
            } else
            {
                rotationSpeed -= platformController.direction.y * platformController.currentSpeed;
            }
        }

        if (obj.tag == "Wall")
        {
            rotationSpeed *= 0.25f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (_lastChangeTime + _period <= Time.time && other.gameObject.name == "Center")
        {
            _lastChangeTime = Time.time;
            _speed += _speedDif;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Field")
        {
            if (transform.position.x > 0)
            {
                gameScore.score.Item1++;
            } else
            {
                gameScore.score.Item2++;
            }

            StartCoroutine(InitCoroutine(2f));

        }
    }
}
