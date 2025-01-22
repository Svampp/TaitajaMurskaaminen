using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDetector : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.instance.inMarketArea = !PlayerController.instance.inMarketArea;
        }
    }
}
