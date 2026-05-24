using UnityEngine;

public class PistonBlock : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.right; // Hangi yöne gidecek?
    public float moveDistance = 2f; // Ne kadar uzaða gidecek?
    public float speed = 2f; // Ne kadar hýzlý?
    public float waitTime = 1f; // Uç noktada ne kadar bekleyecek?

    private Vector3 startPos;
    private Vector3 endPos;
    private bool isMovingToEnd = true;
    private float timer = 0f;

    void Awake()
    {
        startPos = transform.position;
        endPos = startPos + (moveDirection.normalized * moveDistance);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isMovingToEnd)
        {
            // Ýleri git
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            // Uca vardýysa bekle ve geri dön
            if (transform.position == endPos && timer >= waitTime)
            {
                isMovingToEnd = false;
                timer = 0f;
            }
        }
        else
        {
            // Geri gel
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            // Baþa vardýysa bekle ve ileri git
            if (transform.position == startPos && timer >= waitTime)
            {
                isMovingToEnd = true;
                timer = 0f;
            }
        }
    }
}