using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D Body;
    public GameObject barrel;
    int walkingspeed = 5;
    float horizontal;
    float vertical;
    private Ray ray;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
        mousePosition.x - transform.localPosition.x,mousePosition.y - transform.localPosition.y);

        transform.up = direction;


        // shooting PEW PEW -------X

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("omg");
            Debug.DrawRay(barrel.transform.position, transform.up);
            ray = new Ray(barrel.transform.position, transform.up);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit");
                if (hit.collider.tag.Equals("NPC")) {
                    Destroy(hit.collider.gameObject);
                    Debug.Log("enemydown");
                }

            }
        }
    }

    private void FixedUpdate()
    {
        Body.velocity = new Vector2(horizontal * walkingspeed, vertical * walkingspeed);
    }
}
