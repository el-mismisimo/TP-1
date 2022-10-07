using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private float UpForce;
    [SerializeField] private float speed = 3f;


   
    
    private Rigidbody playerRb;

    public Text score;
    public Text winText;
    public int totalItems;
    public int ItemsCollected;

    private void Start()
    {


        playerRb = GetComponent<Rigidbody>();

        totalItems = GameObject.FindGameObjectsWithTag("item").Length;
        winText.enabled = false;
        UpdateUI();

    }

    
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate( horizontalInput, 0f, verticalInput);

        Input.GetAxis("Horizontal");
        Input.GetAxis("Vertical");
        


        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * UpForce);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            Destroy(collision.gameObject);
            ItemsCollected++; // le sumo uno
            UpdateUI();

            if (ItemsCollected == totalItems)
            {

                
                winText.enabled = true;
            }
        }
    }

    private void UpdateUI()
    {
        score.text = ItemsCollected.ToString() + " / " + totalItems.ToString();
    }

}
