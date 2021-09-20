using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Out : MonoBehaviour
{
    public void OUT(bool Out)
    {
        if (Out){
            Application.Quit();
        }
    }
}
