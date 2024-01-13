﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class powerGraphic : MonoBehaviour
{

    public TMP_Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerManager pm = powerManager.Instance;

        float charge = pm.Charge;

        int chargeInteger = (int)charge;

        text.text = "Power: " + chargeInteger.ToString() + "%";
    }
}
