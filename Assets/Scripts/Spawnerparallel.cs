using System;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Jobs;


public class Spawnerparallel : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField]private GameObject _sheepPF;
    private List<GameObject> _sheeps = new();

    private JobHandle _moveHandler;
    private TransformAccessArray _transformAccessArray;

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

        SetTranformArray();

    }
    private void SetTranformArray()
    {
        Transform[] dummy = new Transform[_sheeps.Count];
        
        for(int i = 0;i<_sheeps.Count;i++)
        {
            dummy[i] =_sheeps[i].transform;
        }
        _transformAccessArray = new TransformAccessArray(dummy);
    }
    private void Update()
    {
        MoveJob movejob = new MoveJob(_speed,Time.deltaTime);
        _moveHandler = movejob.Schedule(_transformAccessArray);

    }
    private void LateUpdate()
    {
       _moveHandler.Complete();
    }

    struct MoveJob : IJobParallelForTransform
    {
         private float _speed;
        private float _deltaTime;
        public MoveJob(float speed,float deltatime)
        {
            _deltaTime = deltatime;
            _speed = speed;
        }
       
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += (Vector3.forward* _speed*_deltaTime);
            if(transform.position.z >192)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -409f);
            }
        }
    }

    private void OnDestroy()
    {
        _transformAccessArray.Dispose();
    }
}
