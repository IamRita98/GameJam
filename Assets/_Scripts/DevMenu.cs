/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevMenu : MonoBehaviour
{
    public bool uiIsActive;
    public GameObject buttonGridLayout;

    public Button completeBtn;
    public Button uncompleteBtn;
    public Button day1Btn;
    public Button day2Btn;
    public Button day3Btn;
    public Button bedroomTPBtn;
    public Button studyTPBtn;
    public Button kitchenTPBtn;
    public Button LaundryTPBtn;
    public Button muteMusic;

    GameManager gManage;

    public Transform bedroomTPLocation;
    public Transform studyTPLocation;
    public Transform kitchenTPLocation;
    public Transform laundryTPLocation;
    Transform playerTransform;

    public AudioSource musicPlayer;
    bool musicIsMuted = false;
    private void Start()
    {
        completeBtn.onClick.AddListener(CompleteAllGames);
        uncompleteBtn.onClick.AddListener(UncompleteAllGames);
        day1Btn.onClick.AddListener(SetToDay1);
        day2Btn.onClick.AddListener(SetToDay2);
        day3Btn.onClick.AddListener(SetToDay3);
        bedroomTPBtn.onClick.AddListener(MoveToBedroom);
        studyTPBtn.onClick.AddListener(MoveToStudy);
        kitchenTPBtn.onClick.AddListener(MoveToKitchen);
        LaundryTPBtn.onClick.AddListener(MoveToLaundry);
        muteMusic.onClick.AddListener(MuteMusic);

        gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (buttonGridLayout.activeInHierarchy)
        {
            uiIsActive = true;
        }
        else
        {
            uiIsActive = false;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            if (uiIsActive)
            {
                Cursor.lockState = CursorLockMode.Locked;
                buttonGridLayout.SetActive(false);
            }
            else if (!uiIsActive)
            {
                
                buttonGridLayout.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void CompleteAllGames()
    {
        gManage.sandwichMade = true;
        gManage.washingMachineStarted = true;
        gManage.slidingPuzzleSolved = true;
    }
    void UncompleteAllGames()
    {
        gManage.sandwichMade = false;
        gManage.washingMachineStarted = false;
        gManage.slidingPuzzleSolved = false;
    }
    void SetToDay1()
    {
        gManage.currentDay = 1;
    }
    void SetToDay2()
    {
        gManage.currentDay = 2;
    }
    void SetToDay3()
    {
        gManage.currentDay = 3;
    }
    void MoveToBedroom()
    {
        playerTransform.position = bedroomTPLocation.position;
    }
    void MoveToStudy()
    {
        playerTransform.position = studyTPLocation.position;
    }
    void MoveToKitchen()
    {
        playerTransform.position = kitchenTPLocation.position;
    }
    void MoveToLaundry()
    {
        playerTransform.position = laundryTPLocation.position;
    }
    void MuteMusic()
    {
        if (!musicIsMuted)
        {
            musicPlayer.volume = 0;
            musicIsMuted = true;
        }
        else if (musicIsMuted)
        {
            musicPlayer.volume = .3f;
            musicIsMuted = false;
        }
    }
}
*/