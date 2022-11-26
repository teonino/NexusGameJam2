using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{

    [Header("Commons References")]
    public KeyCode slide = KeyCode.LeftControl;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;
    public BasicsMovements basicsMovements;
    [SerializeField] private MoonManagement SkillsAccessManagement;
    [Header("Dash Properties")]
    public float maxSlideTime;
    public float slideFroce;
    float slideTimer;
    float startSpeed;
    public float slideYScale;
    float startYScale;



    public bool isSliding;

    float speedDV;

    void Start()
    {
        startYScale =  Player.transform.localScale.y;
        startSpeed = basicsMovements.speed;
    }

    private void Update()
    {
        if(Input.GetKey(slide))
        {
            if (SkillsAccessManagement.SkillsAccess[2])
            {
                StartSlide();
            }
            else
            {
                print("Slide is not available");
            }
        }
        else
        {
            StopSlide();
        }
    }

    private void FixedUpdate()
    {
        if(isSliding)
        {
            SlideMovement();
        }
    }
    void StartSlide()
    {
        isSliding = true;

        Player.transform.localScale = new Vector3(Player.transform.localScale.x, slideYScale, Player.transform.localScale.z);
        rb.AddForce(Vector3.down * 150f, ForceMode.Impulse);

        slideTimer = maxSlideTime;
    }

    void SlideMovement()
    {
        //Vector3 inputDirection = playerObj.transform.forward;
        //rb.AddForce(inputDirection.normalized * slideFroce, ForceMode.Force);

        basicsMovements.speed = Mathf.SmoothDamp(basicsMovements.speed, 0.2f, ref speedDV, 1.5f);

        /*slideTimer -= Time.deltaTime;
        if(slideTimer <= 0)
        {
            StopSlide();
        }*/
    }

    void StopSlide()
    {
        isSliding = false;
        Player.transform.localScale = new Vector3(Player.transform.localScale.x, startYScale, Player.transform.localScale.z);
        basicsMovements.speed = startSpeed;
    }
}
