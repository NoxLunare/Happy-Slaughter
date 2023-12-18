using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static BulletController Instance;
    [SerializeField] float velocity;
    [SerializeField] new Rigidbody rigidbody;
    public int damage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       

        rigidbody.velocity=transform.forward*velocity;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Enemy")
        {
            AIStatistics  aIStatistics = other.GetComponent<AIStatistics>();
            aIStatistics.health -=damage;
            Destroy(gameObject);
        }
    }
}
