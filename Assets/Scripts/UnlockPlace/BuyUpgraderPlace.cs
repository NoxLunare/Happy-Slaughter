using UnityEngine;

public class BuyUpgraderPlace : MonoBehaviour
{
    public static BuyUpgraderPlace Instance;

    public GameObject placeUpgrader;

    public GameObject upgraderText;
    public GameObject closeUpgrader;
    public GameObject buttonUpgrade;
    private int priceUpgrader = 30;
    
    public int buyUpgrader;

    public bool canUpgrader = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        placeUpgrader.SetActive(false);
       
        upgraderText.SetActive(false);
        closeUpgrader.SetActive(true);
    }
    private void FixedUpdate()
    {
        BuyPlaceUpgrader();
    }

    public void BuyPlaceUpgrader( )
    {
        if (Input.GetKey(KeyCode.E) && canUpgrader && MoneyController.Instance.addMoney >= priceUpgrader)
        {
            MoneyController.Instance.addMoney -= priceUpgrader;
            placeUpgrader.SetActive(true);
            upgraderText.SetActive(true);
            closeUpgrader.SetActive(false);
            buyUpgrader = 1;
            SaveManager.Instance.SavePlayerStats();
        }

        if (buyUpgrader == 1)
        {
            buttonUpgrade.SetActive(false);
        }

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canUpgrader = true;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUpgrader = false;
        }
    }

    private void OnGUI()
    {
        if (canUpgrader)
        {
            GUI.TextField(new Rect(1000, 1000, 250, 40), "Click E To Buy Upgrader Player For 30 $");
        }
    }

}
