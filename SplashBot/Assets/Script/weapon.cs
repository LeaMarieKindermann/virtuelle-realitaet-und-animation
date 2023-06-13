using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class weapon : MonoBehaviour
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
        interactableWeapon.selectEntered.AddListener(PickUpWeapon);
        interactableWeapon.selectExited.AddListener(DropWeapon);
        interactableWeapon.activate.AddListener(StartShooting);
        interactableWeapon.deactivate.AddListener(StopShooting);
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
        rigidbody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.impulse);
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
