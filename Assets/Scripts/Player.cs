using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(InputController), typeof(AnimationController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float turnSpeed = 1f;
    private Rigidbody rb;
    private InputController inputController;
    private AnimationController animationController;
    private bool isGameStarted = false;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        inputController = GetComponent<InputController>();
        animationController = GetComponent<AnimationController>();
    }

    private void FixedUpdate()
    {
        if (!isGameStarted)
            return;
        if (inputController.InputValues.magnitude > 0)
            Move();
        Animate();
    }

    private void Animate()
    {
        if (inputController.InputValues.y != 0)
            animationController.PlayAnimation(Animation.Run);
        else
            animationController.PlayAnimation(Animation.Idle);
    }

    private void Move()
    {
        Vector3 eulers = rb.rotation.eulerAngles + Vector3.up * inputController.InputValues.x * turnSpeed;
        Quaternion rot = Quaternion.Euler(eulers);
        rb.MoveRotation(rot);
        rb.MovePosition(rb.position + inputController.InputValues.y * transform.forward * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.isGameStarted)
            return;

        if (other.CompareTag("EndMap"))
        {
            GameManager.Instance.EndGame(true);
            animationController.PlayAnimation(Animation.Dance);
            other.tag = "Untagged";
        }

        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.EndGame(false);
            animationController.PlayAnimation(Animation.Idle);
            other.tag = "Untagged";
        }
    }


    private void Respawn()
    {
        UIManager.Instance.Restart();
    }


    private void GameEnded(bool isWin)
    {
        isGameStarted = false;
    }

    private void GameStarted()
    {
        isGameStarted = true;
    }

    private void OnEnable()
    {
        GameManager.Instance.onGameStarted += GameStarted;
        GameManager.Instance.onGameEnded += GameEnded;
    }

    private void OnDisable()
    {
        GameManager.Instance.onGameStarted -= GameStarted;
        GameManager.Instance.onGameEnded -= GameEnded;
    }
}
