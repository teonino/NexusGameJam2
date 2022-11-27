using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicsMovements : MonoBehaviour
{

    [Header("Commons References")]
    public KeyCode Forward;
    public KeyCode Backward;
    public KeyCode Left;
    public KeyCode Right;
    public int deg = 0;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;
    public Animator animator;

    [Header("Movement Property")]
    [SerializeField] public float speed;

    [Header("Anti Falling Damage Boots")]
    [SerializeField] internal bool HaveBoots;


    private void Update()
    {

        Vector3 vec3 = Vector3.zero;
        if (Input.GetKey(Left))
            vec3.x -= 1;
        if (Input.GetKey(Right))
            vec3.x += 1;
        if (Input.GetKey(Forward))
            vec3.z += 1;
        if (Input.GetKey(Backward))
            vec3.z -= 1;
        Vector2 direction = new Vector2(vec3.x, vec3.z);
        deg = getOrientationDeg(vec3);
        if (Input.GetKey(Left) || Input.GetKey(Right) || Input.GetKey(Forward) || Input.GetKey(Backward))
        {
            animator.SetBool("Run", true);
            Vector3 orientation = new Vector3(Mathf.Sin(Mathf.Deg2Rad * deg), 0, Mathf.Cos(Mathf.Deg2Rad * deg)).normalized;
            Player.transform.rotation = Quaternion.Euler(0, deg, 0);
            rb.velocity = new Vector3(orientation.x * speed, rb.velocity.y, orientation.z * speed);
            //rb.velocity.x = orientation.x * speed;
           
            
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);

            animator.SetBool("Run", false);
        }


        //vec3 *= speed;
        


    }

    public int getOrientationDeg(Vector3 vec3)
    {
        if (vec3.x == -1)
        {
            if (vec3.z == 1)
            {
                return 45 * 7;
            }
            else if(vec3.z == -1)
            {
                return 45 * 5;
            }
            else
            {
                return 45 * 6;
            }
        }
        if (vec3.x == 0)
        {
            if (vec3.z == 1)
            {
                return 0;

            }
            else if (vec3.z == -1)
            {
                return 45 * 4;

            }
        }
        if (vec3.x == 1)
        {
            if (vec3.z == 1)
            {
                return 45;

            }
            else if (vec3.z == -1)
            {
                return 45 * 3;

            }
            else
            {
                return 45 * 2;

            }
        }

        return 0;
    }



}
