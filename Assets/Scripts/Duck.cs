using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class Duck : MonoBehaviour
{
    [SerializeField] private float velocity = 10f;
    [SerializeField] private float detection = 0.7f;
    [SerializeField] private LayerMask obstacleMask;




    private Vector3 dire;

    private void Start()
    {
        dire = transform.forward;
    }



    private void Update()
    {
        if (Physics.Raycast(transform.position, dire, out RaycastHit hit, detection,
                            obstacleMask, QueryTriggerInteraction.Ignore))
        {
            dire = Vector3.Reflect(dire, hit.normal).normalized;
        }

        transform.position += dire * velocity * Time.deltaTime;

        if (dire != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(dire);
    }
}