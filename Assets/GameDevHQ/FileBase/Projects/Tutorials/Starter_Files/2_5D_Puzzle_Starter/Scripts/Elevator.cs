using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    private Transform _curTarget;
    private float _speed = 1.5f;
    public void CallElevator()
    {
        //know the current position of the elevator
        if (transform.position == PointA.position)
        {
            _curTarget = PointB;
        }
        else if (transform.position == PointB.position)
        {
            _curTarget = PointA;
        }
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _curTarget.position, _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
