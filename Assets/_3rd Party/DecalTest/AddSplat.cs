using kTools.Decals;
using UnityEngine;

public class AddSplat : MonoBehaviour
{

    public Transform decalPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        var hit = other.contacts[0];
        var decalTransform = Instantiate(decalPrefab, hit.point, Quaternion.identity);
        decalTransform.localRotation = Quaternion.LookRotation(hit.normal);
        var decal = decalTransform.GetComponent<Decal>();
        decal.SetData(decal.decalData);
    }
}
