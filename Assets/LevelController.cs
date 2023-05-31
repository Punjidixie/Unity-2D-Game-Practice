using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelController : MonoBehaviour
{
    public Boss bossScript;
    public Reference reference;
    public UIManager uiManager;
    public string playerName;
    public GameObject lampyPrefab;
    public GameObject catcherPrefab;
    public GameObject leonardoPrefab;
    public GameObject warperPrefab;
    public GameObject playerObject;
    public Player playerScript;

    public GameObject enemyPrefab;
    public GameObject unpredictablePrefab;
    public GameObject spinningEnemyPrefab;
    public GameObject walkingEnemyPrefab;
    public GameObject poisonEnemyPrefab;

    public GameObject potionPrefab;
    

    public float enemySpawnPeriod;
    public float potionSpawnPeriod;
    public float cycleTime;
    public float potionCycleTime;
    public bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        enemySpawnPeriod = 5;
        potionSpawnPeriod = 5;
        gameStarted = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        cycleTime += Time.deltaTime;
        potionCycleTime += Time.deltaTime;
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        if (gameStarted && playerScript.hp <= 0)
        {
            uiManager.Lose();
        }
        else if (enemyArray.Length == 0) //boss died, everything else died
        {
            uiManager.Win();
        }
        else if (bossScript.hp == 0) //boss died, something survives
        {
            uiManager.AlmostWin();
        }
        else if (gameStarted) //normal
        {
            
            if (cycleTime >= enemySpawnPeriod)
            {
                cycleTime = 0;
                SpawnEnemyRandomly();
                enemySpawnPeriod = 4f + enemyArray.Length * Random.Range(0.5f, 1.5f);
            }

            if (potionCycleTime >= potionSpawnPeriod)
            {
                potionCycleTime = 0;
                SpawnPotionRandomly();
                potionSpawnPeriod = Random.Range(12, 15);
            }
        }

    }

    //activated by select character screen
    public void SetPlayerName(string name)
    {
        playerName = name;
        switch (playerName)
        {
            case "Lampy":
                playerObject = Instantiate(lampyPrefab);
                break;
            case "Catcher":
                playerObject = Instantiate(catcherPrefab);
                break;
            case "Leonardo":
                playerObject = Instantiate(leonardoPrefab);
                break;
            case "Warper":
                playerObject = Instantiate(warperPrefab);
                break;
            default:
                break;
        }
        playerObject.transform.position = new Vector3(0, -2, 0);
        reference.player = playerObject.GetComponent<Player>();
        playerObject.GetComponent<Player>().reference = reference;
        playerScript = playerObject.GetComponent<Player>();
        playerScript.hp = 100; //first frame it'll be 0 if this line is not here, causing defeat instantly
        gameStarted = true;
        cycleTime = 0;
        StartCoroutine(HorizontalEnemyCoroutine());
    }
    IEnumerator HorizontalEnemyCoroutine()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(-4 + 1.5f * (i  - 1), 3.25f);
            newEnemy.GetComponent<Enemy>().reference = reference;
            yield return new WaitForSecondsRealtime(0.25f);
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(4 + 1.5f * (i - 1), 3.25f);
            newEnemy.GetComponent<Enemy>().reference = reference;
            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
    public void SpawnEnemyRandomly()
    {
        string name = "Enemy";
        float random = Random.value;
        if (random <= 1f / 5f)
        {
            name = "Enemy";
        }
        else if (random <= 2f / 5f)
        {
            name = "SpinningEnemy";
        }
        else if (random <= 3f / 5f)
        {
            name = "Unpredictable";
        }
        else if (random <= 4f / 5f)
        {
            name = "WalkingEnemy";
        }
        else if (random <= 5f / 5f)
        {
            name = "PoisonEnemy";
        }
        GameObject newEnemy;
        switch (name)
        {
            case "Enemy":
                newEnemy = Instantiate(enemyPrefab);
                break;
            case "SpinningEnemy":
                newEnemy = Instantiate(spinningEnemyPrefab);
                break;
            case "Unpredictable":
                newEnemy = Instantiate(unpredictablePrefab);
                break;
            case "WalkingEnemy":
                newEnemy = Instantiate(walkingEnemyPrefab);
                break;
            case "PoisonEnemy":
                newEnemy = Instantiate(poisonEnemyPrefab);
                break;
            default:
                newEnemy = Instantiate(enemyPrefab);
                break;
        }
        newEnemy.GetComponent<Enemy>().reference = reference;

        //making sure enemy doesnt spawn inside boss
        newEnemy.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(-1, 4));
        while (Mathf.Abs(newEnemy.transform.position.x) <= 2 && Mathf.Abs(newEnemy.transform.position.y - 3.25f) <= 2)
        {
            newEnemy.transform.position = new Vector3(Random.Range(-7, 7), Random.Range(0, 4));
        }
    }

    public void SpawnPotionRandomly()
    {
        GameObject potion = Instantiate(potionPrefab);
        potion.transform.position = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4));
        while (Mathf.Abs(potion.transform.position.x) <= 2 && Mathf.Abs(potion.transform.position.y - 3.25f) <= 2)
        {
            potion.transform.position = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4));
        }
    }
}
