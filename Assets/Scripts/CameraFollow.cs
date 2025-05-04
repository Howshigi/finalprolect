using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3[] offsets;
    private int currentOffsetIndex = 0;
    public float followSpeed = 5f;

    void Start()
    {
        if (offsets.Length == 0)
        {
            offsets = new Vector3[]
            {
                new Vector3(0, 2, -3),   // ใกล้
                new Vector3(0, 4, -6),   // กลาง
                new Vector3(0, 10, -15)   // ไกล
            };
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentOffsetIndex = (currentOffsetIndex + 1) % offsets.Length;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offsets[currentOffsetIndex];
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.LookAt(target);  // กล้องมองตัวละครตลอด
    }
}
