using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController characterController;
    public Transform cam;
    public float lookSensivity;
    public float maxXRot;
    public float minXRot;
    private float curXRot;
    public LayerMask layer;
    public float maxTimeOnGround = 10f;
    private float timeOnGround = 0f;
    private TimerUI timerUI;
    public int sahneNumarasi;
    public Sahne sahne;
    public Saysay level;

    public static PlayerController Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        timerUI = FindObjectOfType<TimerUI>();
        //Sahne.Instance.currentScene=SceneManager.GetActiveScene().buildIndex;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();

        if (IsGrounded())
        {
            timeOnGround += Time.deltaTime; // Zemindeyken geçen süreyi güncelle
            if (timeOnGround > maxTimeOnGround)
            {
                // Oyunu bitir
                GameOver();
            }
            else
            {
                timerUI.UpdateTimer(maxTimeOnGround - timeOnGround); // Geri sayýmý güncelle
            }
        }
        else
        {
            timeOnGround = 0f; // Zeminde deðilse süreyi sýfýrla
        }

    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;
        characterController.Move(dir);


    }
    void Look()
    {
        float x = Input.GetAxis("Mouse X") * lookSensivity;
        float y = Input.GetAxis("Mouse Y") * lookSensivity;

        transform.eulerAngles += Vector3.up * x;

        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);
        cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f);

    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f, layer);
    }

    void GameOver()
    {
        Debug.Log("Oyun bitti!");
        Sahne.Instance.counter++;
        Debug.Log(Sahne.Instance.counter);

        SceneManager.LoadScene(3);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Die();
        }
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Oyun bitti!");
            if (PlayerPrefs.GetInt("MaxLevel") < SceneManager.GetActiveScene().buildIndex+1)
            {
                PlayerPrefs.SetInt("MaxLevel", SceneManager.GetActiveScene().buildIndex+1);
            }

            if (PlayerPrefs.GetInt("DeadCount" + SceneManager.GetActiveScene().buildIndex, 10000) > Sahne.Instance.counter)
            {
                PlayerPrefs.SetInt("DeadCount" + SceneManager.GetActiveScene().buildIndex, Sahne.Instance.counter);
            }
           
            SceneManager.LoadScene(4); 
        }
        
    }

    void Die()
    {
        Debug.Log("Öldünüz!");
        Sahne.Instance.counter++;
        Debug.Log(Sahne.Instance.counter);
        Debug.Log("hahahah!");
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
        
    }
}