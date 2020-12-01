using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private MeshRenderer _callButton;
    private int _requiredCoins = 8;
    private Elevator _elevator;
    private bool _buttonColor;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        if (_elevator == null)
        {
            Debug.LogError("The Elevator is Null");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().CoinCount() >= _requiredCoins)
            {
                if (_buttonColor == false)
                {
                    _callButton.material.color = Color.green;
                    _buttonColor = true;
                }
                else if (_buttonColor == true)
                {
                    _callButton.material.color = Color.red;
                    _buttonColor = false;
                }
                
                
                _elevator.CallElevator();
            }
        }
    }
}
