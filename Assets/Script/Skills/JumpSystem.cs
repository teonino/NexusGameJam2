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
    [SerializeField] bool isGrounded = true;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Jump))
        {
            if (JumpPoints == 2 && isGrounded)
            {
                print("regular jump");
                animator.SetTrigger("Jump");
                rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                //gameObject.transform.Translate(Vector3.up * JumpForce);
                //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * JumpForce, rb.velocity.z);
                JumpPoints -= 1;
                isGrounded = false;
            }
            else if (JumpPoints == 1)
            {
                if (SkillsAccessManagement.SkillsAccess[1])
                {
                    animator.SetTrigger("Jump");
                    print("Double jump");
                    //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * JumpForce, rb.velocity.z);
                    rb.AddForce(Vector3.up * (JumpForce/0.5f), ForceMode.Impulse);
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
