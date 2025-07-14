using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehavior
{
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public Animator animator;

    private CharacterController controller;
    private Vector3 vector3; expected (CS1002)

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (!animator) animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (animator)
        {
            animator.SetFloat("Speed", move.magnitude);
        }
    }
}