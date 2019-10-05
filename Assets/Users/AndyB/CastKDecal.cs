using System.Collections;
using System.Collections.Generic;
using kTools.Decals;
using UnityEngine;

public class CastDecal : MonoBehaviour
{

    public Transform prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    void Update1()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var decalTransform = Instantiate(prefab, hit.point, Quaternion.identity);
                decalTransform.localRotation = Quaternion.LookRotation(hit.normal);
                var decal = decalTransform.GetComponent<Decal>();
                decal.SetData(decal.decalData);

//                Vector3 position;
//                Vector3 directionVector = DecalUtil.GetDirectionToNearestFace(m_ActualTarget, out position);
//                m_ActualTarget.SetTransform(position, directionVector, m_ActualTarget.transform.lossyScale);
//                m_ActualTarget.SetData(m_ActualTarget.decalData);

            }

        }
    }
}