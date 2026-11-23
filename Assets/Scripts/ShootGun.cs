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
            if (GlobalVariables.isRed && IsRedColor(c))
            {
                GlobalVariables.correct += 1;
                Debug.Log($"amount of corrects: {GlobalVariables.correct}");
                GlobalVariables.isCorrect = true;
            }
        }

        if (hit.collider.CompareTag("Smash"))
        {
            // Destruye la raíz del pato (Duck(Clone)), no solo el hijo "Bird"
            Duck duck = hit.collider.GetComponentInParent<Duck>();
            GameObject target = duck != null ? duck.gameObject : hit.collider.transform.root.gameObject;
            Destroy(target);
        }
    }

    private static bool TryGetMaterialColor(RaycastHit hit, out Color color)
    {
        color = Color.white;

        Renderer rend = hit.collider.GetComponentInParent<Renderer>();
        if (rend == null) rend = hit.collider.GetComponentInChildren<Renderer>();
        if (rend == null) return false;

        Material mat = rend.material;
        if (mat == null) return false;

        if (mat.HasProperty(BaseColorId)) { color = mat.GetColor(BaseColorId); return true; }
        if (mat.HasProperty(ColorId)) { color = mat.GetColor(ColorId); return true; }

        return false;
    }

    private static bool IsRedColor(Color c, float tolerance = 0.1f)
    {
        return c.r > 1f - tolerance && c.g < tolerance && c.b < tolerance;
    }
}