using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Grappring : MonoBehaviour
{
    public DistanceJoint2D disJoint;
    public LineRenderer lineRenderer;

    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit && hit.collider.gameObject.tag == "Rock")
            {
                disJoint.enabled = true;
                lineRenderer.enabled = true;
                disJoint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();

            }
        }
        if (lineRenderer.enabled == true)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.transform.position);
        }
        if (Input.GetMouseButtonUp(0))
        {
            disJoint.enabled = false;
            lineRenderer.enabled = false;
        }
    }
}
