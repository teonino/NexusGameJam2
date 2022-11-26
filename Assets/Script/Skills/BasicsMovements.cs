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
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;

    [Header("Movement Property")]
    [SerializeField] public float speed;

    [Header("Anti Falling Damage Boots")]
    [SerializeField] internal bool HaveBoots;


    private void Update()
    {

        /* Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
         Vector3 lookDirection = moveDirection + gameObject.transform.position;
         Player.transform.LookAt(lookDirection);*/

        /*Vector3 inputMovement =new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(inputMovement * Time.deltaTime * speed, Space.World);*/

        if (Input.GetKey(Forward))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            //Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        /*if (Input.GetKey(Forward) && Input.GetKey(Left))
        {
            this.transform.Translate(transform.forward * -transform.right * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(rb.angularVelocity);
        }
        if (Input.GetKey(Forward) && Input.GetKey(Right))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, 45, 0);
        }*/
        if (Input.GetKey(Backward))
        {
            this.transform.Translate(-transform.forward * speed * Time.deltaTime);
            //Player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        /*if (Input.GetKey(Backward) && Input.GetKey(Left))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetKey(Backward) && Input.GetKey(Right))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, -135, 0);
        }*/
        if (Input.GetKey(Left))
        {
            this.transform.Translate(-transform.right * speed * Time.deltaTime);
            //Player.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(Right))
        {
            this.transform.Translate(transform.right * speed * Time.deltaTime);
            //Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        }


    }



}
