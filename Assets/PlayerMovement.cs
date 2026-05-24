//using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
//public class PlayerMovement : MonoBehaviour
//{
//    public float speed = 8f;
//    private float originalSpeed; // Orijinal hýzý hafýzada tutmak için
//    public float jumpHeight = 2.5f;
//    public float gravity = -25f;
//    public float turnSmoothTime = 0.1f;

//    [Header("Wall Climb Ayarý")]
//    public float climbSpeed = 5f;
//    private bool isTouchingWall = false;

//    public CharacterController controller;
//    public Transform cam;

//    private float turnSmoothVelocity;
//    private Vector3 velocity;
//    private bool isGrounded;

//    // --- HAREKETLÝ PLATFORM ÝÇÝN DEÐÝÞKENLER ---
//    private Transform activePlatform;
//    private Vector3 platformLastPosition;
//    private Vector3 platformMovement;

//    void Start()
//    {
//        if (controller == null) controller = GetComponent<CharacterController>();
//        if (cam == null) cam = Camera.main.transform;

//        // Oyun baþýnda orijinal yürüme hýzýmýzý kaydediyoruz
//        originalSpeed = speed;
//    }

//    void Update()
//    {
//        isGrounded = controller.isGrounded;

//        // Zemindeyken aþaðý çekmeyi sabitle
//        if (isGrounded && velocity.y < 0)
//            velocity.y = -2f;

//        // 1. Platform Hareketi
//        if (activePlatform != null)
//        {
//            platformMovement = activePlatform.position - platformLastPosition;
//            platformLastPosition = activePlatform.position;

//            RaycastHit hit;
//            if (!Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f) || !hit.collider.CompareTag("MovingPlatform"))
//            {
//                activePlatform = null;
//                platformMovement = Vector3.zero;
//            }
//        }
//        else
//        {
//            platformMovement = Vector3.zero;
//        }

//        // 2. Oyuncu Girdileri
//        float x = Input.GetAxisRaw("Horizontal");
//        float z = Input.GetAxisRaw("Vertical");

//        Vector3 direction = new Vector3(x, 0f, z).normalized;
//        Vector3 playerMovementVector = Vector3.zero;

//        // --- DUVARA DEÐÝNCE YUKARI ÇIKMA ---
//        RaycastHit wallHit;
//        bool wallDetected = Physics.Raycast(transform.position, transform.forward, out wallHit, 1f);

//        if (wallDetected && wallHit.collider.CompareTag("Wall"))
//        {
//            velocity.y = climbSpeed;
//        }
//        else
//        {
//            velocity.y += gravity * Time.deltaTime;
//        }

//        // Normal Yürüme / Dönme
//        if (direction.magnitude >= 0.1f)
//        {
//            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
//            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

//            transform.rotation = Quaternion.Euler(0f, angle, 0f);

//            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

//            // HIZ BURADA UYGULANIYOR (Buzdaysa speed zaten 16 olacak)
//            playerMovementVector = moveDir.normalized * speed * Time.deltaTime;
//        }

//        // 3. Zýplama
//        if (Input.GetButtonDown("Jump") && isGrounded)
//        {
//            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
//            activePlatform = null;
//        }

//        // 4. Son Hareket
//        Vector3 finalMove = playerMovementVector + (velocity * Time.deltaTime) + platformMovement;
//        controller.Move(finalMove);

//        // Her kare sonunda hýzý normale çekiyoruz. 
//        // Eðer buza basmaya devam ediyorsak, alttaki OnControllerColliderHit bunu her kare tekrar 16 yapacak.
//        speed = originalSpeed;
//        isTouchingWall = false;
//    }

//    // --- Bounce ---
//    public void DisaridanZiplat(float firlatmaGucu)
//    {
//        velocity.y = firlatmaGucu;
//        activePlatform = null;
//    }

//    private void OnControllerColliderHit(ControllerColliderHit hit)
//    {
//        // 1. Hareketli Platform Kontrolü
//        if (hit.gameObject.CompareTag("MovingPlatform") && hit.normal.y > 0.5f)
//        {
//            if (activePlatform != hit.transform)
//            {
//                activePlatform = hit.transform;
//                platformLastPosition = activePlatform.position;
//            }
//        }

//        // 2. Duvar Týrmanma Kontrolü
//        if (hit.gameObject.CompareTag("Wall") && hit.normal.y < 0.1f)
//        {
//            isTouchingWall = true;
//        }

//        // 3. YENÝ: BUZ PÝSTÝ KONTROLÜ
//        // Eðer bastýðýmýz nesnenin tag'i "Ice" ise karakteri uçur!
//        if (hit.gameObject.CompareTag("Ice") && hit.normal.y > 0.5f)
//        {
//            speed = originalSpeed * 2.2f; // Hýzý yaklaþýk 17.6f yapar, acayip hýzlanýr!
//        }
//    }
//}
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float jumpHeight = 2.5f;
    public float gravity = -25f;
    public float turnSmoothTime = 0.1f;

    [Header("Wall Climb Ayarý")]
    public float climbSpeed = 5f;

    [Header("Minecraft Buz Ayarlarý")]
    public float iceSpeedMultiplier = 2f;    // Buz üstündeki maksimum hýz çarpaný
    public float iceInertia = 3f;           // Buzun kayganlýðý (Ne kadar büyükse o kadar çok savrulur ve geç durur)

    public CharacterController controller;
    public Transform cam;

    private float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isGrounded;

    // Kayma mekaniði için akýþkan hýz vektörü
    private Vector3 currentInputVelocity;

    // --- HAREKETLÝ PLATFORM ÝÇÝN DEÐÝÞKENLER ---
    private Transform activePlatform;
    private Vector3 platformLastPosition;
    private Vector3 platformMovement;

    void Start()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
        if (cam == null) cam = Camera.main.transform;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        // Zemindeyken aþaðý çekmeyi sabitle
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // 1. Platform Hareketi
        if (activePlatform != null)
        {
            platformMovement = activePlatform.position - platformLastPosition;
            platformLastPosition = activePlatform.position;

            RaycastHit hit;
            if (!Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f) || !hit.collider.CompareTag("MovingPlatform"))
            {
                activePlatform = null;
                platformMovement = Vector3.zero;
            }
        }
        else
        {
            platformMovement = Vector3.zero;
        }

        // 2. Oyuncu Girdileri
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;
        Vector3 targetMoveVelocity = Vector3.zero;

        // --- DUVARA DEÐÝNCE YUKARI ÇIKMA ---
        RaycastHit wallHit;
        bool wallDetected = Physics.Raycast(transform.position, transform.forward, out wallHit, 1f);

        if (wallDetected && wallHit.collider.CompareTag("Wall"))
        {
            velocity.y = climbSpeed;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // --- MINECRAFT BUZDA KAYMA VE HAREKET HESABI ---
        // Karakterin altýnda buz var mý kontrolü (Aþaðýya kýsa bir ýþýn atýyoruz)
        RaycastHit groundHit;
        bool isOnIce = false;
        if (Physics.Raycast(transform.position, Vector3.down, out groundHit, 1.2f))
        {
            if (groundHit.collider.CompareTag("Ice"))
            {
                isOnIce = true;
            }
        }

        // Hedef hýzý zemin türüne göre belirliyoruz
        float currentMaxSpeed = isOnIce ? (speed * iceSpeedMultiplier) : speed;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            targetMoveVelocity = moveDir.normalized * currentMaxSpeed;
        }

        // Eðer buzdaysak hýzý yavaþça (Lerp ile) deðiþtirerek Minecraft hissiyatý yaratýyoruz
        if (isOnIce)
        {
            // iceInertia ne kadar düþükse o kadar hýzlý ivmelenir/durur. 
            // Zamanla yumuþatarak kayma efektini veriyoruz.
            currentInputVelocity = Vector3.Lerp(currentInputVelocity, targetMoveVelocity, Time.deltaTime * iceInertia);
        }
        else
        {
            // Normal zemindeyken anýnda dur ve anýnda hýzlan (Eski pürüzsüz mekanik)
            currentInputVelocity = targetMoveVelocity;
        }

        // 3. Zýplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            activePlatform = null;
        }

        // 4. Son Hareket Birleþtirmesi
        // Oyuncunun kayma/yürüme hýzý + Yerçekimi dikey hýzý + Platform hareketi
        Vector3 playerMovementVector = currentInputVelocity * Time.deltaTime;
        Vector3 finalMove = playerMovementVector + (velocity * Time.deltaTime) + platformMovement;

        controller.Move(finalMove);
    }

    // --- Bounce ---
    public void DisaridanZiplat(float firlatmaGucu)
    {
        velocity.y = firlatmaGucu;
        activePlatform = null;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("MovingPlatform") && hit.normal.y > 0.5f)
        {
            if (activePlatform != hit.transform)
            {
                activePlatform = hit.transform;
                platformLastPosition = activePlatform.position;
            }
        }
    }
}