using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private int BulletSpeed;
    [SerializeField]
    private float destroyTimer;
    public bool hasGrenade;
    public int grenadeCount;
    InventoryManager IM;

    public Rigidbody launchPrefab;
    // Use this for initialization
    void Start()
    {
        IM = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && hasGrenade == true )
        {

            ShootObject();
        }

    }

    public void ShootObject()
    {
        if (IM.isInventoryMenuShowing == false)
        {
            grenadeCount--;
            var launchPrefab = (GameObject)Instantiate(prefab, Player.transform.position, Player.transform.rotation);
            launchPrefab.GetComponent<Rigidbody>().velocity = launchPrefab.transform.forward * BulletSpeed;

            Destroy(launchPrefab, destroyTimer);
            if (grenadeCount <= 0)
            {
                hasGrenade = false;
            }
        }
    }



}
