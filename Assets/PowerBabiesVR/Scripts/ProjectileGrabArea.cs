using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ProjectileGrabArea : MonoBehaviour
{
    [SerializeField] Collider GrabCollider;
    [SerializeField] GameObject ProjectileToGrab;

    Player player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        var leftHandGrab = player.leftHand.GetGrabStarting(explicitType: GrabTypes.Grip);
        if (leftHandGrab != GrabTypes.None)
            TryGrab(player.leftHand);

        var rightHandGrab = player.rightHand.GetGrabStarting(explicitType: GrabTypes.Grip);
        if (rightHandGrab != GrabTypes.None)
            TryGrab(player.rightHand);
    }

    void TryGrab (Hand hand)
    {
        bool inGrabBounds = GrabCollider.bounds.Contains(hand.transform.position);
        if (!inGrabBounds)
            return;

        // grabbing code
        Debug.Log($"GRABBING!!! {hand}");
    }


}
