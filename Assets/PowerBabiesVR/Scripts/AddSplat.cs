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
    public SoundCollection SoundCollectionOnImpact;
    private AudioSource AudioSourceToPlay;
    //public Transform SpawnPrefabOnImpact;
    public Color vfxColor = Color.red;
    public float MinScale = .2f;
    public float MaxScale = 1f;
    [HideInInspector]
    public Transform myPowerBaby;

    private float LastDecalTime;
    private Rigidbody rb;
    private SplatParticles splatParticles;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        splatParticles = FindObjectOfType<SplatParticles>();
        LastDecalTime = Time.time;
        AudioSourceToPlay = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Splat Collision 1");
        if (gameObject == null) return; // I may have been destroyed
        Debug.Log("Splat Collision 2");
        ContactPoint hit = other.contacts[0];
        float velocity = hit.thisCollider.attachedRigidbody.velocity.magnitude;
        var splattee = hit.otherCollider.gameObject;

        if (velocity < VelocityThreshold) return;  // Don't splat on small bounces
        Debug.Log("Splat Collision 3");
        if (Time.time - LastDecalTime < ElapsedTimeThreshold) return;  // Don't splat too often
        Debug.Log("Splat Collision 4");
        if (splattee.GetComponent<Throwable>() != null) return;  // Don't splat other throwables
        Debug.Log("Splat Collision 5");
        if (splattee.tag == "splatproof") return;  // Don't splat tagged objects
        Debug.Log("Splat Collision 6");
        if (splattee.transform.root == myPowerBaby) return;  // Don't splat myself
        Debug.Log("Splat Collision 7");
        if (splattee.transform.root == FindObjectOfType<RealtimeAvatarManager>().localAvatar.transform) return;  // Don't splat my own avatar
        Debug.Log("Splat Collision 8!");

        LastDecalTime = Time.time;
        Decal decal = DecalSystem.GetDecal(
            hit.point,
            Quaternion.LookRotation(hit.normal),
            Vector2.one * Random.Range(MinScale, MaxScale),
            decalData, true
        );
        decal.gameObject.transform.parent = hit.otherCollider.transform;
        splatParticles.Launch(hit.point, vfxColor);
        SoundCollectionOnImpact.Play(AudioSourceToPlay);
        //Instantiate(SpawnPrefabOnImpact, hit.point, hit.otherCollider.transform.rotation);
        //Invoke(nameof(DestroyMe), 0.2f);
    }

    private void DestroyMe()
    {
        Debug.Log("Splat Collision Destroyed");
        Realtime.Destroy(gameObject);
    }
}
