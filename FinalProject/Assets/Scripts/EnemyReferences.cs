using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class EnemyReferences : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;

    [Header("Stats")]
    public float pathUpdateDelay = 0.2f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
