using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject _instructions;
    private void OnTriggerStay(Collider other)
    {
        _instructions.SetActive(true);
        if (other.tag == "Door")
        {
            Animator animator = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("OpenClose");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            _instructions.SetActive(false);
        }
    }
}
