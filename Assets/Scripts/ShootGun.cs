using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShootGun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //trigger detection variable
    public InputActionReference trig;
    //transform of the canon aka point of the barrel
    public Transform canon;

    // the prefab of the bullet
    public GameObject bulletPrefab;

    //velocity of the bullet
    public float velocity = 100.00f;

    //bullet life span
    public float ali = 5.0f;

    public Vector3 offset;


    private void OnEnable()
    {
        trig.action.Enable();
        trig.action.performed += pressed;
    }

    private void OnDisable()
    {
        trig.action.performed -= pressed;
    }

    private void pressed(InputAction.CallbackContext context)
    {
        Fire();
    }

    private void Fire()
    {
        Vector3 spawnPos = canon.TransformPoint(offset);
        Debug.DrawRay(canon.position, canon.forward * 10f, Color.green, 10f);
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, canon.rotation);

        if (bullet.TryGetComponent(out Collider bulletCol))
        {
            foreach (Collider c in transform.root.GetComponentsInChildren<Collider>())
                Physics.IgnoreCollision(bulletCol, c);
        }

        if (bullet.TryGetComponent(out Rigidbody rb))
        {
            rb.useGravity = false;
            rb.linearVelocity = canon.forward * velocity;
        }

        Destroy(bullet, ali);
    }
}
