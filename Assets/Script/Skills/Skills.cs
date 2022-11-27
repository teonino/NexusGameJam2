using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public KeyCode Skill = KeyCode.E;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;
    public BasicsMovements basicsMovements;
    [SerializeField] private MoonManagement SkillsAccessManagement;
    public float maxSlideTime;
    public float slideFroce;
    float slideTimer;
    float startSpeed;
    public float slideYScale;
    float startYScale;
    public Animator animator;
    public bool isSliding;
    float speedDV;
    [SerializeField] internal float DashForce;
    [SerializeField] internal float DashCooldown;
    [SerializeField] internal float DashTime;
    internal bool DashIsAvaiable = true;

    void Start()
    {
        startYScale = Player.transform.localScale.y;
        startSpeed = basicsMovements.speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(Skill) && SkillsAccessManagement.SkillsAccess[0])
        {
            if (DashIsAvaiable)
            {
                animator.SetTrigger("Dash");
                rb.AddForce(Player.transform.forward * DashForce, ForceMode.Impulse);
                StartCoroutine(DashCooldownCoroutine());
                DashIsAvaiable = false;
            }
        }

        if (Input.GetKey(Skill) && SkillsAccessManagement.SkillsAccess[2])
        {
            StartSlide();
        }
        else
        {
            StopSlide();
        }

    }

    private void FixedUpdate()
    {
        if (isSliding)
        {
            SlideMovement();
        }
    }
    void StartSlide()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Slide", true);
        isSliding = true;

        gameObject.GetComponentInChildren<CapsuleCollider>().height = slideYScale;
        rb.AddForce(Vector3.down * 150f, ForceMode.Impulse);

        slideTimer = maxSlideTime;


    }

    void SlideMovement()
    {
        Vector3 inputDirection = Player.transform.forward;
        rb.AddForce(inputDirection.normalized * slideFroce, ForceMode.Force);

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
        gameObject.GetComponentInChildren<CapsuleCollider>().height = startYScale;
        basicsMovements.speed = startSpeed;
        animator.SetBool("Slide", false);
        animator.SetBool("Run", false);
    }


    private IEnumerator DashCooldownCoroutine()
    {
        yield return new WaitForSeconds(DashCooldown);
        DashIsAvaiable = true;
    }
}
