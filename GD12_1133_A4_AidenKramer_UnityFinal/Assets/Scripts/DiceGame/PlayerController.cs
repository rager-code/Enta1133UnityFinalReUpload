using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject GreatSword;
    public GameObject LongSword;
    public GameObject ShortSword;
    public GameObject Axe;
    public GameObject HealthPotion;

    

    public Dictionary<Direction, int> _rotationByDirection = new()
    { 
    
        // ask about where the enum is in code
        { Direction.North, 0 }, // also 360
        { Direction.East, 90 },
        { Direction.South, 180 },
        { Direction.West, 270 }

    };

    public bool GreatSwordInHand = false;
    public bool LongSwordInHand = false;
    public bool ShortSwordInHand = false;
    public bool AxeInHand = false;
    public bool HealthPotionInHand = false;



    private CharacterController controller;
    //private float playerSpeed = 4.0f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;

    private bool isWalking = false;
    //private float walkSpeed = 20f;
    private float walkTime = 0.5f;
    private float walkTimer = 0f;
    private Vector3 previousPosition;
    private float walkingdistance = 5f;

    public float speed = 1f;
    private float MoveForward;

    private Direction _facingDirection;
    private bool _isRotating = false;

    [SerializeField] private float RotationTime = 0.5f;
    private float _rotationTimer = 0.0f;
    private Quaternion _previousRotation;


    public void Setup()
    {
        // Simple array of all directions
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
        //roll a random direction
        _facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
        // Update the transform
        SetFacingDirection();
    }

    private void SetFacingDirection()
    {
        // Note: transform.rotation is type "Quaternion", we hate working with these, and i mean straight up despise
        // Get the transorm's rotation, use eulerAnglers for easier math (Vector3)
        Vector3 facing = transform.rotation.eulerAngles;
        // Set the y value
        facing.y = _rotationByDirection[_facingDirection];
        // Save the rotation back, converting it to a Quaternion first
        transform.rotation = Quaternion.Euler(facing);
    }

    // Update is called once per frame

    public void TurnLeft()
    {
        switch (_facingDirection)
        {
            case Direction.North:
                _facingDirection = Direction.West;
                break;
            case Direction.South:
                _facingDirection = Direction.East;
                break;
            case Direction.East:
                _facingDirection = Direction.North;
                break;
            case Direction.West:
                _facingDirection = Direction.South;
                break;

        }
        StartRotating();

    }
    public void TurnRight()
    {
        switch (_facingDirection)
        {
            case Direction.North:
                _facingDirection = Direction.East;
                break;
            case Direction.South:
                _facingDirection = Direction.West;
                break;
            case Direction.East:
                _facingDirection = Direction.South;
                break;
            case Direction.West:
                _facingDirection = Direction.North;
                break;

        }
        StartRotating();

    }
    private void StartRotating()
    {
        _previousRotation = transform.rotation;
        _isRotating = true;

    }

    public void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

        GreatSword.SetActive(false);
    }
    public void Update()
    {
        if (_isRotating)
        {

            Quaternion currentRotation = Quaternion.Slerp(
            _previousRotation,
            Quaternion.Euler(new Vector3(0, _rotationByDirection[_facingDirection])),
            _rotationTimer / RotationTime);

            transform.rotation = currentRotation;

            _rotationTimer += Time.deltaTime;

            if (_rotationTimer > RotationTime)
            {
                _isRotating = false;
                _rotationTimer = 0.0f;
                SetFacingDirection();

            }

        }
        else if (isWalking)
        {
            Vector3 endPosition = walkingdistance * transform.forward + previousPosition;
            Vector3 currentPosition = Vector3.Lerp(previousPosition, endPosition,
                walkTimer / walkTime);
            transform.localPosition = currentPosition;
            walkTimer += Time.deltaTime;
            if (walkTimer > walkTime)
            {
                isWalking = false;
                walkTimer = 0f;
                transform.localPosition = endPosition;

            }


        }
        else
        {

            bool rotateLeft = Input.GetKeyDown(KeyCode.A);
            bool rotateRight = Input.GetKeyDown(KeyCode.D);

            if (Input.GetKeyDown(KeyCode.W))
            {
                StartWalking();


            }
            if (rotateLeft && !rotateRight)
            {

                TurnLeft();

            }
            else if (!rotateLeft && rotateRight)
            {
                TurnRight();
            }


















            AxeOnActiveTakeOut();
            ShortSwordOnActiveTakeOut();
            LongSwordOnActiveTakeOut(); //new code
            GreatSwordSwordOnActiveTakeOut();
            HealthPotionSwordSwordOnActiveTakeOut();
        }

    }
    private void StartWalking()
    {
        previousPosition = transform.localPosition;
        isWalking = true;


    }

    public void GreatSwordOnActive()
    {


        GreatSword.SetActive(!GreatSwordInHand);
        GreatSwordInHand = !GreatSwordInHand;

        if (GreatSwordInHand == true)
        {
            Axe.SetActive(false);
            ShortSword.SetActive(false);
            LongSword.SetActive(false);
            HealthPotion.SetActive(false);
        }
        else
        {

            GreatSword.SetActive(false);

        }
    }
    public void AxeOnActive()
    {


        Axe.SetActive(!AxeInHand);
        AxeInHand = !AxeInHand;

        if (AxeInHand == true)
        {
            GreatSword.SetActive(false);
            ShortSword.SetActive(false);
            LongSword.SetActive(false);
            HealthPotion.SetActive(false);

        }
        else
        {

            Axe.SetActive(false);

        }
    }
    public void ShortSwordOnActive()
    {


        ShortSword.SetActive(!ShortSwordInHand);
        ShortSwordInHand = !ShortSwordInHand;

        if (ShortSwordInHand == true)
        {
            GreatSword.SetActive(false);
            Axe.SetActive(false);
            LongSword.SetActive(false);
            HealthPotion.SetActive(false);


        }
        else
        {

            ShortSword.SetActive(false);

        }
    }
    public void LongSwordOnActive()
    {


        LongSword.SetActive(!LongSwordInHand);
        LongSwordInHand = !LongSwordInHand;

        if (LongSwordInHand == true)
        {
            GreatSword.SetActive(false);
            ShortSword.SetActive(false);
            Axe.SetActive(false);
            HealthPotion.SetActive(false);


        }
        else
        {

            LongSword.SetActive(false);

        }
    }
    public void HealthPotionOnActive()
    {


        HealthPotion.SetActive(!HealthPotionInHand);
        HealthPotionInHand = !HealthPotionInHand;

        if (HealthPotionInHand == true)
        {
            GreatSword.SetActive(false);
            ShortSword.SetActive(false);
            Axe.SetActive(false);
            LongSword.SetActive(false);

                
        }
        else
        {

            HealthPotion.SetActive(false);

        }





    }






    public void AxeOnActiveTakeOut()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           Axe.SetActive(true);
           AxeInHand = true;

            if (AxeInHand == true)
            {
                GreatSword.SetActive(false);
                ShortSword.SetActive(false);
                LongSword.SetActive(false);
                HealthPotion.SetActive(false);

            }
            else
            {

                Axe.SetActive(false);

            }
        }

    }
    public void ShortSwordOnActiveTakeOut()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShortSword.SetActive(true);
            ShortSwordInHand = true;

            if (ShortSwordInHand == true)
            {
                GreatSword.SetActive(false);
                Axe.SetActive(false);
                LongSword.SetActive(false);
                HealthPotion.SetActive(false);


            }
            else
            {

                ShortSword.SetActive(false);

            }
        }

    }

    public void LongSwordOnActiveTakeOut()
    {
       if (Input.GetKeyDown(KeyCode.Alpha3))
       {
            LongSword.SetActive(true);
            LongSwordInHand = true;

            if (LongSwordInHand == true)
            {
                GreatSword.SetActive(false);
                ShortSword.SetActive(false);
                Axe.SetActive(false);
                HealthPotion.SetActive(false);


            }
            else
            {

                LongSword.SetActive(false);

            }
        }

    }
    public void GreatSwordSwordOnActiveTakeOut()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GreatSword.SetActive(true);
            GreatSwordInHand = true;

            if (GreatSwordInHand == true)
            {
                Axe.SetActive(false);
                ShortSword.SetActive(false);
                LongSword.SetActive(false);
                HealthPotion.SetActive(false);
            }
            else
            {

                GreatSword.SetActive(false);

            }

        }
    }
    public void HealthPotionSwordSwordOnActiveTakeOut()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            HealthPotion.SetActive(true);//(!HealthPotionInHand);
            HealthPotionInHand = true;// = !HealthPotionInHand;

            if (HealthPotionInHand == true)
            {
                GreatSword.SetActive(false);
                ShortSword.SetActive(false);
                Axe.SetActive(false);
                LongSword.SetActive(false);


            }
            else
            {

                HealthPotion.SetActive(false);

            }
        }

    }

    //public List<GameObject> button_List = new List<GameObject>();
    //GameObject newButton = new GameObject();
    //newButton.name = ;
    //void TakeDamage(int damage)
    //{
    //currentHealth -= damage;

    //healthBar.SetHealth(currentHealth);
    //}

}


