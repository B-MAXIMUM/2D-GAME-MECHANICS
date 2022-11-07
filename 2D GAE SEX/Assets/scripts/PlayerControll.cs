using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControll : MonoBehaviour
{
    public float Speed = 10;
    public GameObject PowerUpTime;
    public bool IsPoweredUp = false;
    public GameObject ExplosionFx;
    private Rigidbody2D _playerRb;
    private SpriteRenderer _PlayerSr;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _PlayerSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float veticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalInput, veticalInput);
        _playerRb.AddForce(direction * Speed);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("die bitch"))
        {
            StartCoroutine(DEDMOMEN());
        }

        if(other.gameObject.CompareTag("power"))
        { 
            Destroy(other.gameObject);
            PowerUpTime.gameObject.SetActive(true);
            IsPoweredUp = true;
            StartCoroutine(PowerupCountDownRoutine());
        } 
        
        if( other.gameObject.CompareTag("Enemy") && IsPoweredUp )
        {
            Destroy(other.gameObject);
            IsPoweredUp = false;
            PowerUpTime.gameObject.SetActive(false);
        }
    } 
    IEnumerator PowerupCountDownRoutine() 
    { 
        yield return new WaitForSeconds(10);
        PowerUpTime.gameObject.SetActive(false);
        IsPoweredUp = false; 
    }
    IEnumerator DEDMOMEN()
    {
        
        Instantiate(ExplosionFx, transform.position, ExplosionFx.transform.rotation);
        IsPoweredUp = false;
        PowerUpTime.gameObject.SetActive(false);
        _PlayerSr.enabled = false;
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(0);
    }
}
