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
    [SerializeField] private float speed;

    [Header("Anti Falling Damage Boots")]
    [SerializeField] internal bool HaveBoots;
    private int hp = 1;


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
