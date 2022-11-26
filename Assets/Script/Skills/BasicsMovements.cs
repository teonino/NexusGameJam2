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

    [Header("Movement Property")]
    [SerializeField] public float speed;

    [Header("Anti Falling Damage Boots")]
    [SerializeField] internal bool HaveBoots;

    public CharacterController characterController;


    private void Update()
    {

        /* Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
         Vector3 lookDirection = moveDirection + gameObject.transform.position;
         Player.transform.LookAt(lookDirection);*/

        /*Vector3 inputMovement =new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(inputMovement * Time.deltaTime * speed, Space.World);*/

        Vector3 vec3 = Vector3.zero;
        if (Input.GetKey(Left))
            vec3.x -= 1;
        if (Input.GetKey(Right))
            vec3.x += 1;
        if (Input.GetKey(Forward))
            vec3.z += 1;
        if (Input.GetKey(Backward))
            vec3.z -= 1;


        deg = getOrientationDeg(vec3);
        Vector3 orientation = new Vector3(Mathf.Sin(Mathf.Deg2Rad * deg), 0f, Mathf.Cos(Mathf.Deg2Rad * deg));
        Player.transform.rotation = Quaternion.Euler(0,deg,0);


        vec3 *= speed;
        characterController.SimpleMove(vec3);

        /*
        if (Input.GetKey(Forward))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(Forward) && Input.GetKey(Left))
        {
            this.transform.Translate(transform.forward + -transform.right * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        if (Input.GetKey(Forward) && Input.GetKey(Right))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        if (Input.GetKey(Backward))
        {
            this.transform.Translate(-transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (Input.GetKey(Backward) && Input.GetKey(Left))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, 225, 0);
        }
        if (Input.GetKey(Backward) && Input.GetKey(Right))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetKey(Left))
        {
            this.transform.Translate(-transform.right * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(Right))
        {
            this.transform.Translate(transform.right * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        */


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
