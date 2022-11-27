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

    bool firstTime;

    private void Start()
    {
        StartTime = Time.time;
    }

    private void Update()
    {
        if(!firstTime)
        {
            TotalTime = (Time.time - StartTime) / EndTime;
            transform.localScale = Vector3.Slerp(InitialScale, FinalScale, TotalTime);
        }
        else
        {
            yield return StartCoroutine("WaitAndPrint");
            firstTime = false;
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
        
        print("Coroutine Sortie");
    }
}
