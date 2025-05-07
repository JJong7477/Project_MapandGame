using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapPlayer : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;
    FlapGM flapGM = null;
    FlapUI flapUI;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;




    private void Awake()
    {
        flapGM = FlapGM.Instance;
        flapUI = FindObjectOfType<FlapUI>();
    }

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            flapGM.GameStart();
        }

        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                //{
                    flapUI.SetRestart();
                //}
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        flapGM.GameOver();
    }
}
