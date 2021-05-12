using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMenuCamera : MonoBehaviour
{
    public GameObject[] maps;

    private void Start()
    {
        DisableAll();
        maps[Random.Range(0, maps.Length)].SetActive(true);
    }

    private void DisableAll()
    {
        foreach (var _cam in maps)
        {
            _cam.SetActive(false);
        }
    }

}
