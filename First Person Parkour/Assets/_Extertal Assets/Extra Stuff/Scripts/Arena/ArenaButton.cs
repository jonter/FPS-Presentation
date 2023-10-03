using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaButton : MonoBehaviour
{
    HintText hText;
    EnemySpawner[] spawners;

    int wave = 0;

    [SerializeField] Animator borderAnim;

    // Start is called before the first frame update
    void Start()
    {
        hText = FindObjectOfType<HintText>();
        spawners = FindObjectsOfType<EnemySpawner>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player == null) return;
        if (wave > 0) return;

        borderAnim.SetTrigger("hide");
        StartCoroutine(SpawnNewWave());
    }

    IEnumerator SpawnNewWave()
    {
        wave++;
        int enemyCount = wave * 3;
        hText.SetText("Волна "+ wave);

        for (int i = 0; i < enemyCount; i++)
        {
            int rand = Random.Range(0, spawners.Length);
            spawners[rand].SpawnNewEnemy();
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(30);
        hText.SetText("Скоро новая волна");
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnNewWave());
    }


}
