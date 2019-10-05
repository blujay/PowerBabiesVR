using kTools.Decals;
using Pyro;
using UnityEngine;

public class AddSplat : MonoBehaviour
{

    public ScriptableDecal decalData;
    public float VelocityThreshold = 0.1f;
    public Color vfxColor = Color.red;
    public float MinScale = .2f;
    public float MaxScale = 1f;

    private Rigidbody rb;
    private SplatParticles splatParticles;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        splatParticles = FindObjectOfType<SplatParticles>();
    }

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint hit = other.contacts[0];
        float velocity = hit.thisCollider.attachedRigidbody.velocity.magnitude;
        if (velocity < VelocityThreshold) return;

        Decal decal = DecalSystem.GetDecal(
            hit.point,
            Quaternion.LookRotation(hit.normal),
            Vector2.one * Random.Range(MinScale, MaxScale),
            decalData, true
        );
//        decal.SetActive(true);
//        Transform decalTransform = Instantiate(decalPrefab, hit.point, Quaternion.identity);
//        decalTransform.localRotation = Quaternion.LookRotation(hit.normal);
//        decalTransform.localScale = Vector3.one * Random.Range(MinScale, MaxScale);
//        var decal = decalTransform.GetComponent<Decal>();
        splatParticles.Launch(hit.point, vfxColor);
    }
}
