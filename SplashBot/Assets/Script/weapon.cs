using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] private float recoilForce;
    [SerializeField] private float damage;

    private Rigidbody rigidbody;
    private XRGrabInteractable interactableWeapon;

    protected virtual void Awake() 
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rigidbody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.selectEntered.AddListener(args =>
        {
            PickUpWeapon(args.interactorObject as XRBaseInteractor);
            StartShooting(args.interactorObject as XRBaseInteractor);
        });

        interactableWeapon.selectExited.AddListener(args =>
        {
            DropWeapon(args.interactorObject as XRBaseInteractor);
            StopShooting(args.interactorObject as XRBaseInteractor);
        });
    }

    private void PickUpWeapon(XRBaseInteractor interactor) 
    {
        interactor.GetComponent<MeshHidder>().Hide();
    }

    private void DropWeapon(XRBaseInteractor interactor) 
    {
        interactor.GetComponent<MeshHidder>().Show();
    }

    protected virtual void StartShooting(XRBaseInteractor interactor) 
    {
        throw new NotImplementedException();
    }

    protected virtual void StopShooting(XRBaseInteractor interactor) 
    {
        throw new NotImplementedException();
    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rigidbody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }

    public float GetDamage() 
    {
        return damage;
    }
}
