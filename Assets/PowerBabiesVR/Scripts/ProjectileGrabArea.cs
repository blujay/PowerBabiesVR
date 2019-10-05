using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ProjectileGrabArea : MonoBehaviour
{
    [SerializeField] BoxCollider GrabCollider;
    [SerializeField] GameObject ProjectileToGrab;

    [SerializeField] [Range(0, 1)] float PlayerHeightRatio;

    Player player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGrabAreaTransform();

        TryGrab(player.leftHand);
        TryGrab(player.rightHand);
    }

    void TryGrab (Hand hand)
    {
        var handGrab = hand.GetGrabStarting(explicitType: GrabTypes.Pinch);
        if (handGrab == GrabTypes.None)
            return;

        Debug.Log($"TRIGGER DETECTED {hand}");

        bool inGrabBounds = GrabCollider.bounds.Contains(hand.transform.position);
        if (!inGrabBounds)
            return;

        // grabbing code
        Debug.Log($"GRABBING!!! {hand}");
    }

    void UpdateGrabAreaTransform ()
    {
        var grabAreaScale = GrabCollider.size;
        grabAreaScale.y = player.eyeHeight * PlayerHeightRatio;
        GrabCollider.size = grabAreaScale;

        var grabAreaPos = GrabCollider.transform.position;
        grabAreaPos.x = player.feetPositionGuess.x;
        grabAreaPos.y = grabAreaScale.y * 0.5f;
        grabAreaPos.z = player.feetPositionGuess.z;
        GrabCollider.transform.position = grabAreaPos;
    }
}
