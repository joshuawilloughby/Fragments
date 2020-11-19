using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    #region Public Variables
    public GameObject arrowHandler;
    public GameObject newPoints;
    public Sprite arrows;
    public Sprite pointSprite;

    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public Transform shotPoint2;
    public Transform shotPoint3;

    public GameObject point;
    public GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;

    public int ammo;
    public Text ammoDisplay;

    public Abilities abilities;
    public int arrowDamage;
    public int numOfArrows = 3;
    public bool unlimitedArrowsCheck;
    #endregion

    #region Private Variables
    private bool timerOn;
    private int timer = 0;

    private bool shotTimerOn;
    private int shotTimer = 0;

    public Initialise_UI initialise;

    public bool canShoot;
    #endregion

    Vector2 direction;

    void Awake()
    {
        abilities.tripleShot = false;
        abilities.unlimitedArrows = false;
        timer = 0;
        timerOn = false;
        shotTimer = 0;
        shotTimerOn = false;
        canShoot = true;
    }

    void Start()
    {
        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
            newPoints = points[i];

            Sprite newPointSprite = pointSprite;

            newPoints.transform.SetParent(arrowHandler.transform);

            newPoints.GetComponent<SpriteRenderer>().sprite = newPointSprite;
        }
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            canShoot = false;
        }

        if (Time.timeScale == 1)
        {
            canShoot = true;
        }

        if (initialise.gamePaused)
        {
            return;
        }

        if (!initialise.gamePaused)
        {
            Vector2 bowPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - bowPosition;
            transform.right = direction;

            if (abilities.unlimitedArrows && timerOn == false)
            {
                ammoDisplay.text = "∞";

                timerOn = false;
                canShoot = true;
                timer = 0;
            }

            if (shotTimerOn)
            {
                canShoot = false;
                shotTimer += 1;

                if (shotTimer > 200)
                {
                    shotTimerOn = false;
                    canShoot = true;
                    shotTimer = 0;
                }
            }

            if (abilities.tripleShot && timerOn == false)
            {
                ammoDisplay.text = ammo.ToString() + "/10";

                timerOn = false;
                canShoot = true;
                timer = 0;
            }

            if (abilities.tripleShot && timerOn)
            {
                timer += 1;
                if (timer > 200)
                {
                    ammoDisplay.text = ammo.ToString() + "/10";

                    timerOn = false;
                    canShoot = true;
                    timer = 0;
                }
            }

            if (!abilities.tripleShot && timerOn)
            {
                timer += 1;
                if (timer > 200)
                {
                    ammoDisplay.text = ammo.ToString() + "/10";
                    timerOn = false;
                    canShoot = true;
                    timer = 0;
                }
            }

            if (timerOn == false && !abilities.tripleShot && !abilities.unlimitedArrows)
            {
                ammoDisplay.text = ammo.ToString() + "/10";
                timerOn = false;
                canShoot = true;
                timer = 0;
            }

            if (Input.GetMouseButtonDown(0) && ammo > 0 && canShoot && !shotTimerOn && !abilities.unlimitedArrows)
            {
                Shoot();
                shotTimerOn = true;
            }

            if (Input.GetMouseButtonDown(0) && ammo > 0 && canShoot && !shotTimerOn && abilities.unlimitedArrows)
            {
                Shoot();
                shotTimerOn = false;
            }

            if (Input.GetMouseButtonDown(0) && !canShoot)
            {
                return;
            }

            Reload();

            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }
        } 
    }

    void Shoot()
    {
        if (abilities.unlimitedArrows)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);

            Sprite newArrowSprite = arrows;

            newArrow.transform.SetParent(arrowHandler.transform);

            newArrow.GetComponent<SpriteRenderer>().sprite = newArrowSprite;

            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }

        if (!abilities.unlimitedArrows && !abilities.tripleShot)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);

            ammo -= 1;

            Sprite newArrowSprite = arrows;

            newArrow.transform.SetParent(arrowHandler.transform);

            newArrow.GetComponent<SpriteRenderer>().sprite = newArrowSprite;

            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }

        if (abilities.tripleShot)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);

            ammo -= 1;

            Sprite newArrowSprite = arrows;

            #region Arrow1
            newArrow.transform.SetParent(arrowHandler.transform);

            newArrow.GetComponent<SpriteRenderer>().sprite = newArrowSprite;

            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            #endregion
        }

        if (abilities.tripleShot && ammo >= 3)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            GameObject newArrow2 = Instantiate(arrow, shotPoint2.position, shotPoint2.rotation);
            GameObject newArrow3 = Instantiate(arrow, shotPoint3.position, shotPoint3.rotation);

            ammo -= 2;

            Sprite newArrowSprite = arrows;

            #region Arrow1
            newArrow.transform.SetParent(arrowHandler.transform);

            newArrow.GetComponent<SpriteRenderer>().sprite = newArrowSprite;

            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            #endregion

            #region Arrow2
            newArrow2.transform.SetParent(arrowHandler.transform);

            newArrow2.GetComponent<SpriteRenderer>().sprite = newArrowSprite;

            newArrow2.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            #endregion

            #region Arrow3
            newArrow3.transform.SetParent(arrowHandler.transform);

            newArrow3.GetComponent<SpriteRenderer>().sprite = newArrowSprite;

            newArrow3.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            #endregion
        }

        if (abilities.tripleShot && ammo == 2)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            GameObject newArrow2 = Instantiate(arrow, shotPoint2.position, shotPoint2.rotation);

            ammo -= 1;

            Sprite newArrowSprite = arrows;

            #region Arrow1
            newArrow.transform.SetParent(arrowHandler.transform);

            newArrow.GetComponent<SpriteRenderer>().sprite = newArrowSprite;

            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            #endregion

            #region Arrow2
            newArrow2.transform.SetParent(arrowHandler.transform);

            newArrow2.GetComponent<SpriteRenderer>().sprite = newArrowSprite;

            newArrow2.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            #endregion
        }  
    }

    void Reload ()
    {
        if (ammo == 0)
        {
            canShoot = false;
            ammoDisplay.text = "Reloading";
            timerOn = true;
            ammo = 10;
        }
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t*t);
        return position;
    }
}
