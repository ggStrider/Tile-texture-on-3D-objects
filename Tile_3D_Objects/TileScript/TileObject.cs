using UnityEngine;

namespace TileScript
{
    [ExecuteInEditMode]
    public class TileObject : MonoBehaviour
    {
        [SerializeField] private Vector2 _tileDelta;

#if UNITY_EDITOR
        private MeshRenderer _meshRenderer;
        private Material _material;

        private bool _gotMaterial;
#endif
        
        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            if (_meshRenderer == null) return;

            _material = _meshRenderer.sharedMaterial;
            if (_material == null)
            {
                Debug.Log("There is no shared material on the MeshRenderer.");
                return;
            }

            _material.mainTextureScale = _tileDelta;
        }
        
#if UNITY_EDITOR
        private void Update()
        {
            if (_material != null)
            {
                _material.mainTextureScale = _tileDelta;
            }
            else
            {
                GetMaterial();
            }
        }

        private void GetMaterial()
        {
            _meshRenderer = GetComponent<MeshRenderer>();

            if (_meshRenderer == null)
            {
                Debug.Log("There are no mesh renderers");
                return;
            }

            if (_meshRenderer.sharedMaterial == null)
            {
                Debug.Log("MeshRenderer shared material == null, or you didn't put a texture on the object");
                return;
            }
            
            _material = _meshRenderer.sharedMaterial;
        }
#endif
    }
}