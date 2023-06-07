using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimEvents : MonoBehaviour
{
    [SerializeField] private GameObject logo;

    public void LogoDisolved()
    {
        logo.SetActive(false);
    }
}
