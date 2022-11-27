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

    bool firstTime = true;


    private void Update()
    {
        if(!firstTime)
        {
            TotalTime = (Time.time - StartTime) / EndTime;
            transform.localScale = Vector3.Slerp(InitialScale, FinalScale, TotalTime);
        }
        else
        {
            StartCoroutine(StartHoleTimer());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Mort");
            StartCoroutine(EndManage.Respawn());
        }
    }
    IEnumerator StartHoleTimer()
    {
        print("Coroutine entrée");
        yield return new WaitForSeconds(5f);
        firstTime = false;
        StartTime = Time.time;
        print("Coroutine Sortie");
    }

}
