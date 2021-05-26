using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : SingletonMonobehaviour<MeteorSpawn>
{
    #region References

    public GameObject meteor;
    public Transform meteorParent;
    #endregion

    #region Variables

    public float meteorSpeed;
    private float spawnRate;
    private GameObject currentMeteor;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        spawnRate = Random.Range(2f, 4f);
        StartCoroutine(Spawn());
    }

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods
    #endregion

    #region Coroutines

    IEnumerator Spawn()
    {
        int signal = Random.Range(0,2);

        if (signal == 0)
        {
            signal = -1;
        }
        else signal = 1;

        transform.position = new Vector3(Player.Instance.transform.position.x + 40, transform.position.y, transform.position.z);
        transform.position = new Vector3((transform.position.x + (Random.Range(0f, 4f)) * signal), transform.position.y, 10);
        yield return new WaitForSeconds(spawnRate);
        spawnRate = Random.Range(2f, 5f);
        currentMeteor = Instantiate(meteor, transform.position, Quaternion.identity, transform);
        currentMeteor.transform.parent = meteorParent;

        StartCoroutine(Spawn());
    }


    #endregion

}
