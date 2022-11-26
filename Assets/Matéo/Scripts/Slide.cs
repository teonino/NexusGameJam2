using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    //public Transform orientation;
    public Rigidbody rb;
    public GameObject playerObj;

    public float maxSlideTime;
    public float slideFroce;
    float slideTimer;

    public float slideYScale;
    float startYScale;

    public KeyCode slide = KeyCode.LeftControl;

    public bool isSliding;

    void Start()
    {
        startYScale =  playerObj.transform.localScale.y;
    }

    private void Update()
    {
        if(Input.GetKeyDown(slide))
        {
            StartSlide();
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

        playerObj.transform.localScale = new Vector3(playerObj.transform.localScale.x, slideYScale, playerObj.transform.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        slideTimer = maxSlideTime;
    }

    void SlideMovement()
    {
        Vector3 inputDirection = playerObj.transform.forward;
        rb.AddForce(inputDirection.normalized * slideFroce, ForceMode.Force);

        slideTimer -= Time.deltaTime;
        if(slideTimer <= 0)
        {
            StopSlide();
        }
    }

    void StopSlide()
    {
        isSliding = false;
        playerObj.transform.localScale = new Vector3(playerObj.transform.localScale.x, startYScale, playerObj.transform.localScale.z);
        
    }
}
