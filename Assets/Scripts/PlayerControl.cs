using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        rb = GetComponent <Rigidbody>(); 
        SetCountText();
        winTextObject.SetActive(false);
        
    }
    void OnMove(InputValue movementValue)
    {
        Vector3 movementV = movementValue.Get<Vector2>();
        movementX = movementV.x;
        movementY = movementV.y;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
       {
           winTextObject.SetActive(true);
       }
    }
    // Update is called once per frame
    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
}
