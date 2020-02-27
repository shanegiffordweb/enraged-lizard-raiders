using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleNavMeshMove : MonoBehaviour
{
  UnityEngine.AI.NavMeshAgent agent;

  // Start is called before the first frame update
  void Start()
  {
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    // prevent rotation
    transform.rotation = Quaternion.identity;

    // move to mouse click
    if (Input.GetMouseButtonDown(0)) {
      RaycastHit hit;

      if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
        // get only x component of mouse click
        float x = hit.point.x;
        Vector3 destination = new Vector3(x, 0, -2);
        agent.destination = destination;
      }
    }
  }
}
