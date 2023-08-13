using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Chunk[] chunksPrefabs;


    // Start is called before the first frame update    
    void Start()
    {
        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            Chunk chunkToCreate = chunksPrefabs[Random.Range(0, chunksPrefabs.Length)];

            if (i > 0)
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            
            Chunk chunkIstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkIstance.GetLength() / 2; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
