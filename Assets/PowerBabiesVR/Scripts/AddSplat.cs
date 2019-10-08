using kTools.Decals;
using Pyro;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Normal.Realtime;

public class AddSplat : MonoBehaviour
{

    public ScriptableDecal decalData;
    public float VelocityThreshold = 0.1f;
    public float ElapsedTimeThreshold = 0.2f;
    public Color vfxColor = Color.red;
    public float MinScale = .2f;
    public float MaxScale = 1f;

    private float LastDecalTime;
    private Rigidbody rb;
    private SplatParticles splatParticles;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        splatParticles = FindObjectOfType<SplatParticles>();
        LastDecalTime = Time.time;
    }

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint hit = other.contacts[0];
        float velocity = hit.thisCollider.attachedRigidbody.velocity.magnitude;
        if (velocity < VelocityThreshold) return;
        if (Time.time - LastDecalTime < ElapsedTimeThreshold) return;
        if (hit.otherCollider.gameObject.GetComponent<Throwable>() != null) return;
        if (hit.otherCollider.gameObject.tag == "splatproof") return;
        LastDecalTime = Time.time;
        Decal decal = DecalSystem.GetDecal(
            hit.point,
            Quaternion.LookRotation(hit.normal),
            Vector2.one * Random.Range(MinScale, MaxScale),
            decalData, true
        );
        decal.gameObject.transform.parent = hit.otherCollider.transform;
        splatParticles.Launch(hit.point, vfxColor);
        Invoke(nameof(DestroyMe), 0.2f);
    }

    private void DestroyMe()
    {
        //Destroy(gameObject);
        var rt = FindObjectOfType<Realtime>();
        rt.Destroy(gameObject);
    }
}
