using System.Collections;
using UnityEngine;

public class TerrainTerraform : MonoBehaviour
{
    [SerializeField] LayerMask terrainLayer;
    [SerializeField] GameObject shovel;

    [SerializeField] float rayLength;
    [SerializeField] float miningRange;
    [SerializeField] float miningEff;


    private MeshFilter meshFilter;
    private MeshCollider meshCollider;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(shovel.transform.position, shovel.transform.TransformDirection(Vector3.up), out hit, 1.25f, terrainLayer))
        {
            TerraformTerrain(hit.point, -0.001f, .5f);
            Debug.DrawRay(shovel.transform.position, shovel.transform.TransformDirection(Vector3.up) * 1, Color.yellow);
            //Debug.Log("Did Hit");
        }
    }


    private Mesh mesh;
    private Vector3[] vertices;
    private void TerraformTerrain(Vector3 position, float height, float range)
    {
        mesh = meshFilter.sharedMesh;
        vertices = mesh.vertices;
        position -= meshFilter.transform.position;

        int i = 0;
        foreach(Vector3 vert in vertices)
        {
            if(Vector2.Distance(new Vector2(vert.x, vert.z), new Vector2(position.x, position.z)) <= range)
            {
                vertices[i] = vert + new Vector3(0, height, 0);
            }
            i++;
        }

        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;

    }
}
