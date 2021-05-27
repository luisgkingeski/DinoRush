using System.Collections.Generic;
using UnityEngine;

public class ScenarioGenerator : MonoBehaviour
{
    #region References

    public GameObject finalNPC;
    public BoxCollider2D fallGameOver;

    #endregion

    #region Variables

    public int levelSize = 100;
    public int spaceBetweenPlataforms = 5;
    private int xOffset = 0;
    private int usedSize = 0;
    private Object[] plataforms;
    private List<GameObject> plataformsList;
    private List<GameObject> finalplataformChilds;
    private GameObject currentPlataform;
    private int midObjIndex;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        plataforms = Resources.LoadAll("Prefabs/Plataforms", typeof(GameObject));
        plataformsList = new List<GameObject>();
        finalplataformChilds = new List<GameObject>();
        GenerateScenario();
        
    }


    #endregion

    #region Private Methods

    private void GenerateScenario()
    {

        for (int i = 0; i < plataforms.Length; i++)
        {
            plataformsList.Add(plataforms[i] as GameObject);
        }

        for (int i = 0; usedSize <= levelSize; i++)
        {
            int rand = Random.Range(0, plataformsList.Count);
            int plataformSize = plataformsList[rand].GetComponent<Plataform>().size;
            currentPlataform = Instantiate(plataformsList[rand], new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z), Quaternion.identity, transform);
            xOffset += spaceBetweenPlataforms + plataformSize;
            usedSize += xOffset;
        }
        currentPlataform.tag = "Final";

        foreach (Transform child in currentPlataform.transform)
        {
            finalplataformChilds.Add(child.gameObject);
        }

        midObjIndex = (finalplataformChilds.Count) / 2;

        Vector3 npcSpawnPos = new Vector3(finalplataformChilds[midObjIndex].transform.position.x, currentPlataform.transform.position.y + 5, 10);
        Instantiate(finalNPC, npcSpawnPos, Quaternion.identity);
        fallGameOver.size = new Vector2(levelSize, 1);
        ProgressBar.Instance.SetFinal(currentPlataform); // set the final plataform to progress bar
    }

    #endregion

    #region Public Methods
    #endregion
}
