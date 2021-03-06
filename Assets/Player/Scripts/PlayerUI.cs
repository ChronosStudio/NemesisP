using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private RectTransform thrusterFuellFill;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private RectTransform healthbarFill;

    private Player player;
    private PlayerController controller;
    //private WeaponManager weaponManager;

    [SerializeField] private Text ammoText;

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject scoreboard;


    public void SetPlayer(Player _player)
    {
        player = _player;
        controller = player.GetComponent<PlayerController>();
        //weaponManager = player.GetComponent<WeaponManager>();
    }

    private void Start()
    {
        PauseMenu.isOn = false;
    }

    private void Update()
    {
        //SetFuelAmount(controller.GetThrusterFuelAmount());
        //SetHealthAmount(player.GetHealthPct());
        //SetAmmoAmount(weaponManager.currentMagazineSize);

        if (inputManager.Player.Pause.triggered)
        {
            print("triggered");
            TogglePauseMenu();
        }

        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    scoreboard.SetActive(true);
        //}else if(Input.GetKeyUp(KeyCode.Tab))
        //{
        //    scoreboard.SetActive(false);
        //}
    }

    public void TogglePauseMenu()
    {
        print(pauseMenu.activeSelf);
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.isOn = pauseMenu.activeSelf;
    }

    void SetFuelAmount(float _amount)
    {
        thrusterFuellFill.localScale = new Vector3(1f, _amount, 1f);
    }

    void SetHealthAmount(float _amount)
    {
        healthbarFill.localScale = new Vector3(1f, _amount, 1f);
    }

    void SetAmmoAmount(int _amount)
    {
        ammoText.text = _amount.ToString();
    }
    private void Awake()
    {
        inputManager = new InputManager();
    }
    private void OnEnable()
    {
        inputManager.Player.Enable();
    }
    private void OnDisable()
    {
        inputManager.Player.Disable();
    }

}