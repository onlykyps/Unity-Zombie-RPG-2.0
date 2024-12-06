using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour
{
   [ContextMenu("Conevrt to regular mesh")]
   void Convert()
   {
      SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
      MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
      MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

      meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
      meshRenderer.sharedMaterial = skinnedMeshRenderer.sharedMaterial;

      DestroyImmediate(skinnedMeshRenderer);
      DestroyImmediate(this);
   }


   //// Start is called once before the first execution of Update after the MonoBehaviour is created
   //void Start()
   //{

   //}

   //// Update is called once per frame
   //void Update()
   //{

   //}
}
