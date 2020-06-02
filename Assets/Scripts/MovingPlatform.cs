using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;


public class MovingPlatform : MonoBehaviour
{
    const float ConstSpeed = 0.02f;
    public static float speed= ConstSpeed;
    private static float speedBackup=speed;
    private float distance;
    private bool lowest;
    public int PeriodToSpeedUp;

    public Transform FloorPoint;
    public Transform EndPoint;
    public GameObject LeftPlatform;
    public GameObject RightPlatform;
    public GameObject CrossPlat;
    private static int nextUpdate;

    void Start()
    {
        nextUpdate = Mathf.FloorToInt(Time.time)/ PeriodToSpeedUp;
        distance = 2.5f;
        float LocalScale = 12f;
        lowest = true;
        Vector3 LeftPlatLen = Vector3.right * Random.Range(1.0f, 7.5f) + Vector3.up + Vector3.forward;
        LeftPlatform.transform.localScale = LeftPlatLen;
        float startX = (LocalScale / 2 - LocalScale) + LeftPlatLen.x / 2;
        LeftPlatform.transform.localPosition= new Vector3(startX, LeftPlatform.transform.localPosition.y, LeftPlatform.transform.localPosition.z);

        float CroosBorder = startX + LeftPlatLen.x / 2 + distance / 2;
        CrossPlat.transform.localPosition = new Vector3(CroosBorder, LeftPlatform.transform.localPosition.y, LeftPlatform.transform.localPosition.z);

        Vector3 RightPlatLen = Vector3.right * (LocalScale-distance- LeftPlatLen.x) + Vector3.up + Vector3.forward;
        RightPlatform.transform.localScale = RightPlatLen;
        startX = (LocalScale / 2 - LocalScale) + LeftPlatLen.x+1.8f+ RightPlatLen.x/2;
        RightPlatform.transform.localPosition = new Vector3(startX, RightPlatform.transform.localPosition.y, RightPlatform.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= EndPoint.position.y)
            Destroy(gameObject);
        
        transform.position += Vector3.up * speed;
        
        if (lowest == false)
            return;

        if (Mathf.Abs(transform.position.y - FloorPoint.transform.position.y) >= distance)
        {
            lowest = false;
            Vector3 temp = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
            Instantiate(gameObject, temp, transform.rotation);
        }
        if ((Mathf.FloorToInt(Time.time) / PeriodToSpeedUp) > nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) / PeriodToSpeedUp;
            speed += 0.01f;
            Debug.Log("speed: " + (speed-0.02f));
        }
    }
    public void resetSpeed()
    {
        speed = ConstSpeed;
    }
    public void resetTime()
    {
        nextUpdate = 0;
    }
    public void MakePause()
    {
        speedBackup = speed;
        speed = 0;
    }
    public void MakeResume()
    {
        speed=speedBackup;
    }
}