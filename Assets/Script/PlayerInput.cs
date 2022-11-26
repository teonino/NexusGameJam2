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
    private int hp = 1;

    [Header("Components")]
    [SerializeField] private CharacterController CC;
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
            CC.Move(Vector3.forward * speed * Time.deltaTime);
            playerRotation = Quaternion.Euler(Player.transform.rotation.x, 0, Player.transform.rotation.z);
            Player.transform.rotation = playerRotation;
            for (int i = 0; i < DirectionBool.Count; i++)
            {
                DirectionBool[i] = false;
            }
            DirectionBool[0] = true;
        }
        if (Input.GetKey(Backward))
        {
            CC.Move(Vector3.back * speed * Time.deltaTime);
            Player.transform.Rotate(speed * Vector3.back * Time.deltaTime);
            playerRotation = Quaternion.Euler(Player.transform.rotation.x, -180, Player.transform.rotation.z);
            Player.transform.rotation = playerRotation;
            for (int i = 0; i < DirectionBool.Count; i++)
            {
                DirectionBool[i] = false;
            }
            DirectionBool[1] = true;
        }
        if (Input.GetKey(Left))
        {
            CC.Move(Vector3.left * speed * Time.deltaTime);
            Player.transform.Rotate(speed * Vector3.left * Time.deltaTime);
            playerRotation = Quaternion.Euler(Player.transform.rotation.x, -90, Player.transform.rotation.z);
            Player.transform.rotation = playerRotation;
            for (int i = 0; i < DirectionBool.Count; i++)
            {
                DirectionBool[i] = false;
            }
            DirectionBool[2] = true;
        }
        if (Input.GetKey(Right))
        {
            CC.Move(Vector3.right * speed * Time.deltaTime);
            Player.transform.Rotate(speed * Vector3.right * Time.deltaTime);
            playerRotation = Quaternion.Euler(Player.transform.rotation.x, 90, Player.transform.rotation.z);
            Player.transform.rotation = playerRotation;
            for (int i = 0; i < DirectionBool.Count; i++)
            {
                DirectionBool[i] = false;
            }
            DirectionBool[3] = true;
        }
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
            if (DirectionBool[0])
            {
                rb.AddForce(Vector3.forward * DashForce, ForceMode.Impulse);
                StartCoroutine(DashCooldownCoroutine());
                DashIsAvaiable = false;
            }
            if (DirectionBool[1])
            {
                rb.AddForce(Vector3.back * DashForce, ForceMode.Impulse);
                StartCoroutine(DashCooldownCoroutine());
                DashIsAvaiable = false;
            }
            if (DirectionBool[2])
            {
                rb.AddForce(Vector3.left * DashForce, ForceMode.Impulse);
                StartCoroutine(DashCooldownCoroutine());
                DashIsAvaiable = false;
            }
            if (DirectionBool[3])
            {
                rb.AddForce(Vector3.right * DashForce, ForceMode.Impulse);
                StartCoroutine(DashCooldownCoroutine());
                DashIsAvaiable = false;
            }
        }


    }

    private IEnumerator DashCooldownCoroutine()
    {
        yield return new WaitForSeconds(DashCooldown);
        DashIsAvaiable = true;
    }

}
