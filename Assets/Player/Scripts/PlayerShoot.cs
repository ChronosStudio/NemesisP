using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour
{
    public PlayerWeapons weapon;
    private InputManager inputManager;

    [SerializeField] public Camera cam;

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] public AudioClip[] audioClip;
    [SerializeField] public AudioClip shootSound;

    [SerializeField] private LayerMask mask;


    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = audioClip[0];
        if (cam == null)
        {
            print("Pas de camera renseign� sur le yteme de tir");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (inputManager.Player.Fire.IsPressed())
        {
            if (!audioPlayer.isPlaying)
            { 
                audioPlayer.Play(); 
            }
            Shoot();
        } else if (inputManager.Player.Fire.WasReleasedThisFrame())
        {
            audioPlayer.Stop();
        }

    }

    [Client]
    private void Shoot()
    {
        

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            if (hit.collider.tag == "player")
            {
                CmdPlayerShot(hit.collider.name, weapon.damage);
            }
        }
    }

    [Command]
    private void CmdPlayerShot(string playerId, float damage)
    {
        print(playerId + " a ete touch�.");

        Player player = GameManager.GetPlayer(playerId);
        player.RpcTakeDamage(damage);
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
