using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    bool _canSpawn = true;
    [SerializeField] Spawner[] _spawnerList;
    [SerializeField] float _spawnRate;
    [SerializeField] Vector3 _playerPos;
    private bool _stop;
    

    IEnumerator Spawn()
    {
       
        if (_canSpawn)
        {
            if (_stop == false)
            {
                Spawner spawners = Instantiate(_spawnerList[RandomInt(0, _spawnerList.Length)], WhereToSpawn(), new Quaternion(0, 0, RandomInt(-180, 180), 0));
                spawners._manager = this;
                _canSpawn = false;
                yield return new WaitForSeconds(_spawnRate);
                _canSpawn = true;
                StartCoroutine(Spawn()); 
            }
        }
       
    }

    private bool IsPlayerHere(Vector3 spawnPos)
    {
        _playerPos = FindFirstObjectByType<PlayerMouvement>().gameObject.transform.position;
        if (Vector3.Distance(spawnPos, _playerPos) < 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 WhereToSpawn()
    {
        Vector3 here = new Vector3(RandomInt(-8, 8), RandomInt(-4, 4), 0);
        if (IsPlayerHere(here) == true)
        {
            return WhereToSpawn();
        }
        else { return here; }
    }

    private int RandomInt(int min, int max)
    {
       int result = Random.Range(min, max);
        return result;
    }

    public void Stop()
    {
        _stop = true;
    }

    public void StarterParckProMax()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator UpSpawnRate()
    {
        if (_spawnRate >= 3f)
        {
            yield return new WaitForSeconds(15);
            _spawnRate += -0.1f;
            UpSpawnRate();
        }
    }
}
