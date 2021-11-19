using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    [Range(0, 180f)] public float angle = 45f;

    public float maxTurnSpeed = 90f;

    
    public Transform target;

    [HideInInspector] public bool outOfRange;
    [HideInInspector] public bool aimed;


   

    void OnDrawGizmos()
    {

        float range = 20f;
        float dashLineSize = 2f;
        var turret = transform;
        Vector3 origin = turret.position;
        var hardpoint = turret.parent;
        
        if (!hardpoint) return;
        Vector3 from = Quaternion.AngleAxis(-angle, hardpoint.up) * hardpoint.forward;
        
        Handles.color = new Color(0, 1, 0, .2f);
        Handles.DrawSolidArc(origin, turret.up, from, angle * 2, range);

        if (!target) return;
        
        Vector3 projection = Vector3.ProjectOnPlane(target.position - turret.position, hardpoint.up);

        // projection line
        Handles.color = Color.white;
        Handles.DrawDottedLine(target.position, turret.position + projection, dashLineSize);
        
        // do not draw target indicator when out of angle
        if (Vector3.Angle(hardpoint.forward, projection) > angle) return;
        
        // target line
        Handles.color = Color.red;
        Handles.DrawLine(turret.position, turret.position + projection);
        
        // range line
        Handles.color = Color.green;
        Handles.DrawWireArc(origin, turret.up, from, angle * 2, projection.magnitude);
        Handles.DrawSolidDisc(turret.position + projection, turret.up, .5f);

    }

    void Update()
    {
        Vector3 targetPosition = target.position;
        Aim(targetPosition);
    }

    void Aim(Vector3 targetPoint)
    {
        var turret = transform;
        var hardpoint = turret.parent;

        Vector3 direction = targetPoint - turret.position;
        direction = Vector3.ProjectOnPlane(direction, hardpoint.up);
        float signedAngle = Vector3.SignedAngle(hardpoint.forward, direction, hardpoint.up);

        outOfRange = false;
        if (Mathf.Abs(signedAngle) > angle)
        {
            outOfRange = true;
            direction = hardpoint.rotation * Quaternion.Euler(0, Mathf.Clamp(signedAngle, -angle, angle), 0) *
                        Vector3.forward;
        }

        Quaternion rotation = Quaternion.LookRotation(direction, hardpoint.up);

        aimed = false;
        if (rotation == transform.rotation && !outOfRange)
        {
            aimed = true;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxTurnSpeed * Time.deltaTime);
    }
}