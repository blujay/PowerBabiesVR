﻿using kTools.Decals;
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
        if (gameObject == null) return; //
        ContactPoint hit = other.contacts[0];
        float velocity = hit.thisCollider.attachedRigidbody.velocity.magnitude;
        var splattee = hit.otherCollider.gameObject;

        if (velocity < VelocityThreshold) return;  // Don't splat on small bounces
        if (Time.time - LastDecalTime < ElapsedTimeThreshold) return;  // Don't splat too often
        if (splattee.GetComponent<Throwable>() != null) return;  // Don't splat other throwables
        if (splattee.tag == "splatproof") return;  // Don't splat tagged objects
        if (splattee.transform.root == myPowerBaby) return;  // Don't splat myself
        if (splattee.transform.root == FindObjectOfType<RealtimeAvatarManager>().localAvatar.transform) return;  // Don't splat my own avatar

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
        Invoke(nameof(DestroyMe), 0.2f);
    }

    private void DestroyMe()
    {
        Realtime.Destroy(gameObject);
    }
}
