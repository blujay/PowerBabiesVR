using UnityEngine;
using UnityEngine.Experimental.VFX;

namespace Pyro
{
    sealed class SplatParticles : MonoBehaviour
    {
        public VisualEffect _vfx;
        VFXEventAttribute _attrib;

        public void Launch(Vector3 pos, Color color)
        {
            Debug.Log(pos);
            if (_attrib == null) _attrib = _vfx.CreateVFXEventAttribute();
            _attrib.SetVector3("position", pos);
            _attrib.SetVector3("color", (Vector4)color);
            _vfx.SendEvent("OnManualSpawn", _attrib);
        }
    }
}
