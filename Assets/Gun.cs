using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public GameObject firepoint;
    public Vector3 pointOfCollision;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DetermineWhereProjectileWilLCollide();
        }
    }

    private void DetermineWhereProjectileWilLCollide()
    {
        RaycastHit hitdata;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hitdata))
        {
            targetPoint = hitdata.point;
        } else
        {
            targetPoint = ray.GetPoint(1000);
        }

        pointOfCollision = targetPoint - firepoint.transform.position;
        Debug.DrawRay(firepoint.transform.position, pointOfCollision, Color.cyan, 10000000000000);
    }
}
