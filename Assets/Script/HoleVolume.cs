using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleVolume : MonoBehaviour
{
    [SerializeField] public EndManager EndManage;
    public Vector3 InitialScale;
    public Vector3 FinalScale;

    private float StartTime;
    public float EndTime;
    public float TotalTime;

    private void Start()
    {
        StartTime = Time.time;
    }

    private void Update()
    {
        TotalTime = (Time.time - StartTime) / EndTime;
        transform.localScale = Vector3.Slerp(InitialScale, FinalScale, TotalTime);    
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EndManage.Respawn();
        }
    }
}
