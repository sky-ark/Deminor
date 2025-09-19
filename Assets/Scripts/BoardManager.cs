using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public GameObject CasePrefab;
    public GameObject NeigborCasePrefab;
    public GameObject CaseWithBombPrefab;
    public Transform GridParent;
    public int MaxColumns = 5;
    public int MaxRows = 9;
    
    public int[,] Board;
    public bool[,] Revealed;
    
    private bool isBomb;

    
    private void Awake()
    {
        Board = new int[MaxColumns, MaxRows];
    }

    void Start()
    {
        // Setup grid
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                // Add a bomb on the cell
                if (Random.Range(0, 10) <= 0)
                {
                    PlaceBomb(i, j);
                }
            }
        }
        
        
        // Display grid
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                if (Board[i, j] == 0)  Instantiate(CasePrefab, GridParent);
                if (Board[i, j] == -1) Instantiate(CaseWithBombPrefab, GridParent);
                if (Board[i, j] > 0)
                {
                   GameObject neighborCase = Instantiate(NeigborCasePrefab, GridParent);
                   //neighborCase.GetComponentInChildren<TMP_Text>().text = $"i:{i}, j:{j}";
                   neighborCase.GetComponentInChildren<TMP_Text>().text = Board[i, j].ToString();
                }
            }
        }
    }

    private void PlaceBomb(int i, int j)
    {
        Board[i, j] = -1;

        Debug.Log($"Bomb at i:{i}, j:{j}");
        
        // Access Neighbors
        for (int k = i - 1; k <= i + 1; k++)
        {
            for (int l = j - 1; l <= j + 1; l++)
            {
                Debug.Log($"Check neighbors at k:{k}, l:{l}");
                if (k == i && l == j) continue;
                
                if (IsAccessible(k,l) && !HasBombInside(k,l)) Board[k, l] += 1;
                if (IsAccessible(k, l))
                {
                    Debug.Log("IsAccessible");
                    if (HasBombInside(k, l)) Debug.Log("HasBombInside");
                }
            }
        }
    }

    //Check if there's a bomb inside the case
    private bool HasBombInside(int i, int j)
    {
        return Board[i, j] == -1;
    }
    
    /// <summary>
    /// Check if a case is accessible (not outside the board) on Board
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    private bool IsAccessible(int i, int j)
    {
        // Check if coord outside board
        if (j < 0 || i < 0) return false;
        if (i >= Board.GetLength(0) || j >= Board.GetLength(1)) return false;

        return true;
    } 
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
