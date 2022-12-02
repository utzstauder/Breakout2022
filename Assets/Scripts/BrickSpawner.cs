using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickSpawner : MonoBehaviour
{
    public Brick brickPrefab;

    public int xAmount = 5;
    public int yAmount = 3;

    public float xMargin = 2f;
    public float yMargin = 0.5f;
    
    private void Start()
    {
        SpawnBricks();
    }

    private void SpawnBricks()
    {
        Vector3 offset = Vector3.zero;

        for (int y = 0; y < yAmount; y++)
        {
            for (int x = 0; x < xAmount; x++)
            {
                Brick newBrick = Instantiate(brickPrefab, transform.position + offset, Quaternion.identity);
                
                newBrick.SetSpawner(this);
                
                newBrick.transform.SetParent(transform);
                
                offset += Vector3.right * xMargin;
            }

            offset.x = 0;
            offset += Vector3.down * yMargin;
        }
    }

    public void OnBrickHit(Brick brick)
    {
        if (IsGameWon())
        {
            LoadNextScene();
        }
    }

    private bool IsGameWon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                return false;
            }
        }

        return true;
    }

    private void LoadNextScene()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        currentSceneBuildIndex++;

        if (currentSceneBuildIndex >= SceneManager.sceneCountInBuildSettings)
        {
            currentSceneBuildIndex = 0;
        }
        
        SceneManager.LoadScene(currentSceneBuildIndex);
    }
    
    private void OnDrawGizmos()
    {
        Vector3 offset = Vector3.zero;

        for (int y = 0; y < yAmount; y++)
        {
            for (int x = 0; x < xAmount; x++)
            {
                Gizmos.DrawWireCube(transform.position + offset, brickPrefab.transform.localScale);
                offset += Vector3.right * xMargin;
            }

            offset.x = 0;
            offset += Vector3.down * yMargin;
        }
    }
}