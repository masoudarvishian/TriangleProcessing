using UnityEngine;

namespace MySamples.TriangleProcessing.Scripts
{
    public class TrianglesProcessing : MonoBehaviour
    {
        private float _moveSpeed;
        private float _colorSpeed;
        private MeshFilter _meshFilter;
        private Mesh _mesh;
        private Renderer _renderer;
        private Vector3[] _triangleVertices;
        private float _maxHeight;

        private void Start()
        {
            _maxHeight = 1.5f;
            _moveSpeed = 0.2f;
            _colorSpeed = 0.15f;
            
            _renderer = GetComponent<Renderer>();
            _triangleVertices = new Vector3[3];
            _mesh = new Mesh();
            _meshFilter = GetComponent<MeshFilter>();

            _meshFilter.mesh = _mesh;
            
            SetupTriangle();
        }
        
        private void SetupTriangle()
        {
            var triangles = new int[3];

            _triangleVertices[0] = new Vector3(0, 0, 0);
            _triangleVertices[1] = new Vector3(1, 0, 0);
            _triangleVertices[2] = new Vector3(-1, 0, 0);

            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;

            _mesh.vertices = _triangleVertices;
            _mesh.triangles = triangles;
        }

        private void Update()
        {
            _triangleVertices[0].y += _moveSpeed * Time.deltaTime;

            var modifiedColor = _renderer.material.color;
            
            modifiedColor.a -= _colorSpeed * Time.deltaTime;

            if (modifiedColor.a <= 0)
                modifiedColor.a = 0;

            if (_triangleVertices[0].y >= _maxHeight)
            {
                _triangleVertices[0].y = 0;
                modifiedColor.a = 1;
            }

            _renderer.material.color = modifiedColor;
            
            _mesh.vertices = _triangleVertices;
        }
    }
}
