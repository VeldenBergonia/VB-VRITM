using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCount : MonoBehaviour
{

    public Gun ammo;
    public TMP_Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammo = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = ammo.currentAmmo.ToString();
    }
}
