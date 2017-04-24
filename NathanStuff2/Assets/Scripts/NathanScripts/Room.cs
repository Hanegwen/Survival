using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    [SerializeField] List<GameObject> itemPrefabsToSpawn;
    [SerializeField] List<Transform> itemSpawnLocations;

    List<InventoryObj> itemsInRoom = new List<InventoryObj>();

    public float airQualityPercentage = 1;

	// Use this for initialization
	void Start ()
    {
	    foreach(Transform spawnLocation in itemSpawnLocations)
        {
            int randomItemIndex = Random.Range(0, itemPrefabsToSpawn.Count);
            GameObject go = Instantiate(itemPrefabsToSpawn[randomItemIndex], spawnLocation.position, Quaternion.identity, spawnLocation) as GameObject;
            itemsInRoom.Add(go.GetComponent<InventoryObj>());
        }
	}

    public void DestroyItemsInRoom()
    {
        for (int i = itemsInRoom.Count - 1; i >= 0; i--)
        {
            Destroy(itemsInRoom[i].gameObject);
            itemsInRoom.Remove(itemsInRoom[i]);

        }
    }

    public void DestroyItemsInRoom(InventoryObj.ItemType typeOfObjectToDestroy)
    {
        for (int i = itemsInRoom.Count - 1; i >= 0; i--)
        {
            if (itemsInRoom[i].itemType == typeOfObjectToDestroy)
            {
                Destroy(itemsInRoom[i].gameObject);
                itemsInRoom.Remove(itemsInRoom[i]);
            }

        }
    }

    public void MakeRoomInaccessible()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    public void MakeRoomAccessible()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
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
