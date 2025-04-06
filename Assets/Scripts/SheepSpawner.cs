using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField]private GameObject _sheepPF;

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
                
                Instantiate(_sheepPF,startpos, Quaternion.identity);
                startpos = new Vector3(startpos.x + 5, -125, startpos.z);
            }
            startpos = new Vector3(-700, -125, startpos.z +5);
        }
    }
}
