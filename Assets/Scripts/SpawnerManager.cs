using System.Collections;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    bool _canSpawn = true;
    [SerializeField] Spawner[] _spawnerList;
    [SerializeField] float _spawnRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
    }
    
    IEnumerator Spawn()
    {
       
        if (_canSpawn)
        {
            Spawner spawners = Instantiate(_spawnerList[RandomInt(0,_spawnerList.Length)],new Vector3(RandomInt(-8,8),RandomInt(-4,4),0),new Quaternion(0,0,RandomInt(-180,180),0));
            _canSpawn = false;
            yield return new WaitForSeconds(_spawnRate);
            _canSpawn = true;
            StartCoroutine(Spawn());
        }
       
    }

    private int RandomInt(int min, int max)
    {
       int result = Random.Range(min, max);
        return result;
    }
}
