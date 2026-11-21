using UnityEngine;
using UnityEngine.InputSystem;

public class ShootGun : MonoBehaviour
{
    public InputActionReference trig;

    [SerializeField] private Transform barrel;
    [SerializeField] private float range = 200.0f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private LayerMask hitHit = ~0;

    static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
    static readonly int ColorId = Shader.PropertyToID("_Color");

    public bool drawDebug = true;
    private float lastShotTime;

    private void OnEnable()
    {
        trig.action.Enable();
        trig.action.performed += Pressed;
    }

    private void OnDisable()
    {
        trig.action.performed -= Pressed;
    }

    private void Pressed(InputAction.CallbackContext ctx)
    {
        if (Time.time - lastShotTime < fireRate) return;
        lastShotTime = Time.time;
        Fire();
    }

    private void Fire()
    {
        Vector3 origin = barrel.position;
        Vector3 dir = barrel.forward;

        if (Physics.Raycast(origin, dir, out RaycastHit hit, range, hitHit,
                            QueryTriggerInteraction.Ignore))
        {
            OnHit(hit);
            if (drawDebug) Debug.DrawLine(origin, hit.point, Color.blue, 2f);
        }
        else if (drawDebug)
        {
            Debug.DrawRay(origin, dir * range, Color.green, 2f);
        }
    }

    private void OnHit(RaycastHit hit)
    {
        if (TryGetMaterialColor(hit, out Color c))
        {
            Debug.Log($"Color del impacto: {c} | RGB(0-255): " +
                      $"{(int)(c.r * 255)}, {(int)(c.g * 255)}, {(int)(c.b * 255)} | Hex: #{ColorUtility.ToHtmlStringRGB(c)}");
        }
        else
        {
            Debug.Log($"No se pudo obtener el color de {hit.collider.name}");
        }

        if (hit.collider.CompareTag("Smash"))
            Destroy(hit.collider.gameObject);

        Debug.Log($"Golpeaste: {hit.collider.name} | tag: '{hit.collider.tag}' | layer: {LayerMask.LayerToName(hit.collider.gameObject.layer)}");
    }

    private static bool TryGetMaterialColor(RaycastHit hit, out Color color)
    {
        color = Color.white;

        Renderer rend = hit.collider.GetComponentInParent<Renderer>();
        if (rend == null) return false;

        Material mat = rend.sharedMaterial;
        if (mat == null) return false;

        if (mat.HasProperty(BaseColorId)) { color = mat.GetColor(BaseColorId); return true; }
        if (mat.HasProperty(ColorId)) { color = mat.GetColor(ColorId); return true; }

        return false;
    }
}