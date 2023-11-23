using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] int damage;

    private void Awake(){
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
