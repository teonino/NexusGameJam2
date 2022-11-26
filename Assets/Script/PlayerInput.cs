using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Basics Movements")]
    public KeyCode Forward;
    public KeyCode Backward;
    public KeyCode Left;
    public KeyCode Right;
    [Header("Mechanics Movements")]
    public KeyCode Jump;
    public KeyCode slide;
    public KeyCode dash;
    [Header("Player Characteristics")]
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float JumpPoints;
    [SerializeField] private float DashForce;
    [SerializeField] private float DashCooldown;
    [SerializeField] internal bool HaveBoots;
    private float moveY = 0f;
    private float moveX = 0f;
    private Vector3 MoveDir;
    private int hp = 1;

    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;
    [SerializeField] private Collider BoxCollision;
    [SerializeField] private List<bool> DirectionBool;
    internal bool DashIsAvaiable = false;
    private Vector3 direction;
    private Quaternion playerRotation;
    [SerializeField] bool isGrounded = false;

    private void Update()
    {

        if (Input.GetKey(Forward))
        {
            moveY = +1f;
        }
        if (Input.GetKey(Backward))
        {
            moveY = -1f;
        }
        if (Input.GetKey(Left))
        {
            moveX = +1f;
        }
        if (Input.GetKey(Right))
        {
            moveY = -1f;
        }

        MoveDir = new Vector3(moveX, moveY).normalized;
        rb.velocity = MoveDir;

        if (Input.GetKeyDown(Jump))
        {
            if (JumpPoints == 2 && isGrounded)
            {
                print("regular jump");
                rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                JumpPoints -= 1;
                isGrounded = false;
            }
            if (JumpPoints == 1)
            {
                print("Double jump");
                rb.AddForce(Vector3.up * (JumpForce-2), ForceMode.Impulse);
                JumpPoints -= 1;
                isGrounded = false;
            }
            else
            {
                print("no more jump");
            }
            print(JumpPoints);
        }
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position, Vector3.down, out hit, 1.4f))
        {
            JumpPoints = 2;
            isGrounded = true;
        }

        if(Input.GetKeyDown(dash))
        {
            rb.AddForce(Player.transform.forward * DashForce, ForceMode.Impulse);
            StartCoroutine(DashCooldownCoroutine());
            DashIsAvaiable = false;

        }


    }

    private IEnumerator DashCooldownCoroutine()
    {
        yield return new WaitForSeconds(DashCooldown);
        DashIsAvaiable = true;
    }

}
