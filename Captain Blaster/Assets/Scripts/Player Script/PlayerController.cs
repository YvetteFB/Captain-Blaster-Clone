using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float minY, maxY;
    public AudioSource[] AudioClips = null;
    

    private Animator anim;

    [SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private Transform attack_point;

    public float attack_Timer = 0.35f;
    private float current_attack_Timer;
    private bool canAttack;

     void Awake() {
      
        anim = GetComponent <Animator>();
        
    }


    void Start()
    {
        current_attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer()
    {
       if (Input.GetAxisRaw("Vertical") > 0f)
           {
              Vector3 temp = transform.position;
              temp.y += speed * Time.deltaTime;

              if (temp.y > maxY)
                 temp.y = maxY;

              transform.position = temp;

           } else if(Input.GetAxisRaw("Vertical")< 0f){
               Vector3 temp = transform.position;
               temp.y -= speed * Time.deltaTime;

                if (temp.y < minY)
                   temp.y = minY;

               transform.position = temp;   
           }
        }

            void Attack(){
            attack_Timer += Time.deltaTime;
            if (attack_Timer > current_attack_Timer)
            {
                canAttack = true;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (canAttack)
                {
                    canAttack = false;
                    attack_Timer = 0f;

                    Instantiate(player_Bullet, attack_point.position, Quaternion.identity);
                    
                    AudioClips[0].Play();
                }

            }
    }
     void TurnOffGameObject(){
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Bullet"||target.tag == "Enemy")
        {
        
            Invoke("TurnOffGameObject", 2f);
          
            AudioClips[1].Play();
            anim.Play("destroy");
            
            FindObjectOfType<Game_Manager>().EndGame();
        }
        
    }
}
