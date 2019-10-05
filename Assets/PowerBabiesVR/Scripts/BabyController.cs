using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BabyController : MonoBehaviour
{
    [SerializeField] GameObject Walker;
    [SerializeField] GameObject Cam;

    Player Player;

    void Awake()
    {
        Player = GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PointWalkerInLookDir();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWalkerPos();
    }

    void UpdateWalkerPos()
    {
        var walkerPos = Walker.transform.position;
        walkerPos.x = Player.feetPositionGuess.x;
        walkerPos.z = Player.feetPositionGuess.z;
        Walker.transform.position = walkerPos;
    }

    void PointWalkerInLookDir()
    {
        var walkerRot = Walker.transform.rotation.eulerAngles;
        walkerRot.y = Cam.transform.rotation.eulerAngles.y;
        Walker.transform.rotation = Quaternion.Euler(walkerRot);
    }
}
