using System.Collections.Generic;
using UnityEngine;

public class ScenarioGenerator : MonoBehaviour
{
    #region References
    #endregion

    #region Variables

    public int levelSize = 100;
    public int spaceBetweenPlataforms = 5;
    private int xOffset = 0;
    private int usedSize = 0;
    private Object[] plataforms;
    private List<GameObject> plataformsList;
    private GameObject currentPlataform;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        plataforms = Resources.LoadAll("Prefabs/Plataforms", typeof(GameObject));
        plataformsList = new List<GameObject>();
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
        ProgressBar.Instance.SetFinal(currentPlataform); // set the final plataform to progress bar

    }

    #endregion

    #region Public Methods
    #endregion
}
