using UnityEngine;
using System.Collections;

// Copy meshes from children into the parent's Mesh.
// CombineInstance stores the list of meshes.  These are combined
// and assigned to the attached Mesh.

namespace Sainna.Utils
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class MeshCombiner : MonoBehaviour
    {
        void Start()
        {
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length - 1];

            int i = 1;
            while (i < meshFilters.Length)
            {
                combine[i - 1].mesh = meshFilters[i].sharedMesh;
                combine[i - 1].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false);

                i++;
            }

            transform.GetComponent<MeshFilter>().mesh = new Mesh();

            Debug.Log(transform.GetComponent<MeshFilter>().mesh.isReadable);
            transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, true, true, false);
            transform.GetComponent<MeshFilter>().mesh.Optimize();
            transform.gameObject.SetActive(true);
        }
    }
}