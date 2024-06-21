using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private  NavMeshAgent agent;
    public Transform goal;
    public GameObject player;
    public float dodgerange;
    public Rigidbody2D rb;
    public float dodgemultiplier;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.destination = goal.position;
        if (Vector2.Distance(transform.position,player.transform.position) <= dodgerange)
        {
            float playerinputx = Input.GetAxis("Horizontal");
            float playerinputy = Input.GetAxis("Vertical");
            Vector2 npcdodge = new Vector2(-playerinputx * dodgemultiplier, -playerinputy * dodgemultiplier);
            rb.velocity = npcdodge;
        } else
        {
            rb.velocity = Vector2.zero;
        };
    }
}
