using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamFollow : MonoBehaviour
{
    [SerializeField] private Transform Follow_Target;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float damping;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 movePosition = Follow_Target.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
