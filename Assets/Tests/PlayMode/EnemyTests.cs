using NUnit.Framework;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.Tilemaps;

public class EnemyTests
{
    [UnityTest]
    public IEnumerator EnemyWalksRightWhenTargetXGreaterThanEnemyX()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);

        var enemyGO = new GameObject("Enemy");
        var enemy = enemyGO.AddComponent<Enemy>();
        enemyGO.AddComponent<Health>();

        var plantGO = new GameObject("Plant");
        plantGO.AddComponent<Health>();
        plantGO.AddComponent<Plant>();

   

        

        yield return null; // Wait for a frame

        plantGO.transform.position = new Vector3(5, 0, 0);

        yield return null; // Wait for a frame

        enemy.DoAction();

        yield return new WaitForSeconds(1); // Adjust the delay as needed

        // Check the assertion (modify this based on your game's actual logic)
        Assert.That(enemy.transform.position.x, Is.GreaterThan(0));
    }
}
