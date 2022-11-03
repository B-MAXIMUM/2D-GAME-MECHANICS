using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1;
    public GameObject ExplosionFx;
    private Rigidbody2D _enemyRb;
    private GameObject _Player;
    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        _Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = (_Player.transform.position - transform.position).normalized;
        _enemyRb.AddForce(lookDirection * Speed);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("die bitch"))
        {
            Instantiate(ExplosionFx, transform.position, ExplosionFx.transform.rotation);
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("DeathField"))
        {
            Instantiate(ExplosionFx, transform.position, ExplosionFx.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
