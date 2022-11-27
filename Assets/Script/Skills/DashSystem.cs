using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSystem : MonoBehaviour
{
    [Header("Commons References")]
    public KeyCode dash;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Player;
    [SerializeField] private MoonManagement SkillsAccessManagement;
    [Header("Dash Properties")]
    [SerializeField] internal float DashForce;
    [SerializeField] internal float DashCooldown;
    [SerializeField] internal float DashTime;
    internal bool DashIsAvaiable = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dash))
        {
            if (SkillsAccessManagement.SkillsAccess[0])
            {
                if (DashIsAvaiable)
                {
                    print(DashIsAvaiable);
                    rb.AddForce(transform.forward * DashForce, ForceMode.Impulse);
                    StartCoroutine(DashCooldownCoroutine());
                    DashIsAvaiable = false;
                }
            }
            else
            {
                print("Dash is not available");
            }
        }
    }

    private IEnumerator DashCooldownCoroutine()
    {
        yield return new WaitForSeconds(DashCooldown);
        DashIsAvaiable = true;
    }

}
