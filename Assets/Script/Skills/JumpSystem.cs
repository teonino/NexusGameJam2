using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour
{
    [Header("Commons References")]
    public KeyCode Jump;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;
    [SerializeField] private MoonManagement SkillsAccessManagement;
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
            else if (JumpPoints == 1)
            {
                if (SkillsAccessManagement.SkillsAccess[1])
                {
                    print("Double jump");
                    rb.AddForce(Vector3.up * (JumpForce - 30), ForceMode.Impulse);
                    JumpPoints -= 1;
                    isGrounded = false;
                }
                else
                {
                    print("Double jump is not available");
                }
            }
            else
            {
                print("no more jump");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            JumpPoints = 2;
            isGrounded = true;
        }
    }

}
