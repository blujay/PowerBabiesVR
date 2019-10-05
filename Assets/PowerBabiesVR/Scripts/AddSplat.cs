using kTools.Decals;
using UnityEngine;

public class AddSplat : MonoBehaviour
{

    public Transform decalPrefab;
    public Rigidbody rb;
    public float VelocityThreshold = 0.1f;
    public float MinScale = .2f;
    public float MaxScale = 1f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        ContactPoint hit = other.contacts[0];
        float velocity = hit.thisCollider.attachedRigidbody.velocity.magnitude;
        if (velocity < VelocityThreshold) return;
        Transform decalTransform = Instantiate(decalPrefab, hit.point, Quaternion.identity);
        decalTransform.localRotation = Quaternion.LookRotation(hit.normal);
        decalTransform.localScale = Vector3.one * Random.Range(MinScale, MaxScale);
        var decal = decalTransform.GetComponent<Decal>();
        decal.SetData(decal.decalData);
    }
}
