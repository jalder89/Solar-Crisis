using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarryStart : MonoBehaviour
{
    [SerializeField] private GameObject barry;
    private bool startBarry;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        startBarry = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.25f && startBarry)
        {
            startBarry = false;
            barry.SetActive(true);
        }
    }
}
