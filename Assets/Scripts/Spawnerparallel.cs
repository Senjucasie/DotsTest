using System.Collections.Generic;
using UnityEngine;

public class Spawnerparallel : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField]private GameObject _sheepPF;
    private List<GameObject> _sheeps = new();


    private void Start()
    {
        InstantiateSheep();
    }

    private void InstantiateSheep()
    {
        Vector3 startpos = new Vector3(-700, -125, -409);
        for (int y = 0; y < 120; y++)
        {
            for (int x = 0; x < 160; x++)
            {
                _sheeps.Add(Instantiate(_sheepPF,startpos, Quaternion.identity));
                startpos = new Vector3(startpos.x + 5, -125, startpos.z);
            }
            startpos = new Vector3(-700, -125, startpos.z +5);
        }
    }
    private void Update()
    {
        foreach (GameObject sheep in _sheeps)
        {
            sheep.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            if (sheep.transform.position.z > 192)
            {
                sheep.transform.position = new Vector3(sheep.transform.position.x, sheep.transform.position.y, -409f);
            }
        }
    }
}
