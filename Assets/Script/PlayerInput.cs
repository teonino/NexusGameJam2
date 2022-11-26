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

    [Header("Player Characteristics")]
    [SerializeField] private float speed;
    [SerializeField] internal bool HaveBoots;
    private int hp = 1;

    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;
    [SerializeField] private Collider BoxCollision;
    [SerializeField] private List<bool> DirectionBool;
    private Vector3 direction;
    private Quaternion playerRotation;


    private void Update()
    {

        if (Input.GetKey(Forward))
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(Backward))
        {
            this.transform.Translate(-transform.forward * speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Euler(0, -180, 0);
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


    }



}
