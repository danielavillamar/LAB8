using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BooNav : MonoBehaviour
{

    public GameObject[] waypoints;

    private int CWP = 0;
    public float maxWait = 0.0f;
    private float CWPTime = 0.0f;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent && waypoints.Length > 0)
            agent.SetDestination(waypoints[Random.Range(0, waypoints.Length)].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent)
        {
            if(agent.remainingDistance < 0.5f)
            {
                CWPTime += Time.deltaTime;

                if(CWPTime >= maxWait)
                {
                    CWPTime = 0.0f;

                    int temp = CWP;
                    do
                    {
                        CWP = Random.Range(0, waypoints.Length);
                    } while (CWP == temp);

                    agent.SetDestination(waypoints[CWP].transform.position);
                }

            }
        } 
    }
}
