using UnityEngine;
using UnityEngine.UI;

public class CreatePeasantButtonComponent : MonoBehaviour
{
    [SerializeField] private ResourcesManagerComponent resources;
    [SerializeField] private DeferredTimer createPeasantTimer;
    [SerializeField] private int peasantCost;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resources.WheatCount >= peasantCost)
            button.interactable = true;
        else
            button.interactable = false;
    }

    public void CreatePeasant()
    {
        Debug.Log("Start create peasant");
        createPeasantTimer.TimerStart();
    }
}
