using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ProjectileGrabArea : MonoBehaviour
{
    [SerializeField] BoxCollider GrabCollider;
    [SerializeField] GameObject ProjectileToGrab;
    [SerializeField] GameObject Cam;

    [SerializeField] [Range(0, 1)] float PlayerHeightRatio;

    Player Player;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGrabAreaTransform();

        TryGrab(Player.leftHand);
        TryGrab(Player.rightHand);
    }

    void TryGrab (Hand hand)
    {
        var handGrab = hand.GetGrabStarting(explicitType: GrabTypes.Pinch);
        if (handGrab == GrabTypes.None)
            return;

        bool inGrabBounds = GrabCollider.bounds.Contains(hand.transform.position);
        if (!inGrabBounds)
            return;

        // grabbing code
        Debug.Log($"GRABBING!!! {hand}");
    }

    void UpdateGrabAreaTransform ()
    {
        var grabAreaScale = GrabCollider.size;
        grabAreaScale.y = Player.eyeHeight * PlayerHeightRatio;
        GrabCollider.size = grabAreaScale;

        var grabAreaPos = GrabCollider.transform.position;
        grabAreaPos.x = Player.feetPositionGuess.x;
        grabAreaPos.y = grabAreaScale.y * 0.5f;
        grabAreaPos.z = Player.feetPositionGuess.z;
        GrabCollider.transform.position = grabAreaPos;
    }
}
