using UnityEngine;


namespace Pyro
{
    sealed class LaunchKDecal : MonoBehaviour
    {
        public Camera _camera = null;
        public Transform prefab;
        public float force = 100f;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;
                mousePos.y = _camera.pixelHeight - mousePos.y;

                var pos = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _camera.nearClipPlane));

                var projectile = Instantiate(prefab);
                projectile.transform.localScale = Vector3.one * 0.1f;
                projectile.transform.position = pos;
                var rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(_camera.transform.rotation * Vector3.forward * force, ForceMode.Impulse);
            }
        }
    }
}
