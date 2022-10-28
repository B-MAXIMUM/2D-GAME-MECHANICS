using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBitch : MonoBehaviour
{
    public GameObject PlayerFx;
    public GameObject ExplosionFx;
    public GameObject EnemyFx;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("player"))
        {
            Instantiate(PlayerFx, other.transform.position, PlayerFx.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}

