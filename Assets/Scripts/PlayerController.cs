using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sp;
    [Header("Capas")]
    public LayerMask layerMask;
    [Header("Estadisticas")]
    public int speed = 10;
    private Rigidbody2D rb;
    float forceJump = 10f;
    public Vector2 direction;
    [Header("Booleanos")]
    public bool puedeMover = true;

    // Start is called before the first frame update
    void Start()
    {
        Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
    }
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
       
    }
    void Move(){
      float x = Input.GetAxis("Horizontal");
      float y = Input.GetAxis("Vertical");
      direction =  new Vector2(x,y);
      Walk();
      PlusJump();
      if(Input.GetKeyDown(KeyCode.Space)){
        Jump();
      }
    }
    void Walk(){
        if(puedeMover){
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
            // if(direction != Vector2.zero){
            //     if(direction.x < 0 && this.transform.localScale.x > 0){
            //         this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            //     }else if(direction.x > 0 && this.transform.localScale.x < 0){
            //         this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //     }
            // }
        }
    }
    private void Jump(){
       rb.velocity = new Vector2(rb.velocity.x, 0);
       rb.velocity += Vector2.up * forceJump;
    }
    private void PlusJump(){
        if(rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.0f - 1) * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "c1"){
            // other.gameObject.sp.color = Color.red;
        }
    }
}
