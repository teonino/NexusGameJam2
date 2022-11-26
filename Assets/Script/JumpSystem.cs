using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour
{
    [Header("Commons References")]
    public KeyCode Jump;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;

    [Header("Jump Properties")]
    [SerializeField] private float JumpForce;
    [SerializeField] private float JumpPoints;
    [SerializeField] bool isGrounded = false;


    // Update is called once per frame
    void Update()
    {
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
                rb.AddForce(Vector3.up * (JumpForce - 30), ForceMode.Impulse);
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
    }
}
