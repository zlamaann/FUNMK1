using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : MonoBehaviour
{
    [SerializeField] ParticleSystem theMachinegun;
    [SerializeField] ParticleSystem theCartridgeEmitter;

    public enum pickMachinegun
    {
        Lewis,
    }
    [SerializeField] public pickMachinegun machinegunType; // Výběr v inspektoru.

    [Tooltip("Pouze pro testování - hodnoty je nutno dopsat do kódu (machinegunTypeStats).")]
    [SerializeField] float demage;
    [SerializeField] float rateOfFire; // ran za vteřinu
    [SerializeField] float maxAmmo;
    [SerializeField] float currentAmmo;
    [SerializeField] float reloadSpeed;

    bool gunsFiring;
    bool gunsHasAmmo;
    public bool gunIsReloading; // mělo by se zabránit nabíjení více zbraní najednou

    // Start is called before the first frame update
    void Start()
    {
        machinegunTypeStats();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponControll();
    }

    public void WeaponControll()
    {

        if ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1")) && currentAmmo > 0)
        {
            if (theMachinegun.isPlaying == false)
            {
                theMachinegun.Play();
                gunsFiring = true;
            }
        }
        else
        {
            theMachinegun.Stop();
            gunsFiring = false;
        }
    }

    private void machinegunTypeStats() // Statistiky zbraní podle typu.
    {
        switch(machinegunType.ToString())
        {
            case "Lewis":

                demage = 10;
                maxAmmo = 97;
                currentAmmo = 97;
                reloadSpeed = 16;
                rateOfFire = 10;

                break;

            default:
                Debug.Log("Nebyl nalezen typ machinegun");
                break;
        }
    }
}
