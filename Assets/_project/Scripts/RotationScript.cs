using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private float m_RotationSpeed = 100f;
    [Header("Max scale")]
    public Vector3 mMinScale;
    [Header("Min scale")]
    public Vector3 mMaxScale;
    [Header("Scaling Speed")]
    public Vector3 mScaleSpeed;

    private Vector3 currentScaleSpeed;

    void Start()
    {
        currentScaleSpeed = mScaleSpeed;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, m_RotationSpeed * Time.deltaTime);
        if (transform.localScale.x <= mMinScale.x || transform.localScale.x >= mMaxScale.x)
        {
            currentScaleSpeed.x *= -1;
        }

        if (transform.localScale.y <= mMinScale.y || transform.localScale.y >= mMaxScale.y)
        {
            currentScaleSpeed.y *= -1;
        }

        if (transform.localScale.z <= mMinScale.z || transform.localScale.z >= mMaxScale.z)
        {
            currentScaleSpeed.z *= -1;
        }

        transform.localScale = transform.localScale + currentScaleSpeed * Time.deltaTime;
    }
}

