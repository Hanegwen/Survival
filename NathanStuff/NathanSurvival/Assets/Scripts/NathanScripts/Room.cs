using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    [SerializeField] List<GameObject> itemPrefabsToSpawn;
    [SerializeField] List<Transform> itemSpawnLocations;

    List<IInteractible> itemsInRoom = new List<IInteractible>();

    float airQualityPercentage = 1;

	// Use this for initialization
	void Start ()
    {
	    foreach(Transform spawnLocation in itemSpawnLocations)
        {
            int randomItemIndex = Random.Range(0, itemPrefabsToSpawn.Count);
            GameObject go = Instantiate(itemPrefabsToSpawn[randomItemIndex], spawnLocation.position, Quaternion.identity, spawnLocation) as GameObject;
            itemsInRoom.Add(go.GetComponent<IInteractible>());
        }
	}

    public void DestroyItemsInRoom()
    {
        for (int i = itemsInRoom.Count - 1; i >= 0; i--)
        {
            itemsInRoom.Remove(itemsInRoom[i]);
            Destroy(itemsInRoom[i].gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player)
        {
            player.SetCurrentRoom(this);
        }
    }
}
