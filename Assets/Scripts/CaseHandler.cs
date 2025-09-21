using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CaseHandler : MonoBehaviour
{

    public bool isBomb;
    public int neighboringBombs;
    public bool isRevealed;
    public int matrixX;
    public int matrixY;

    public BoardManager boardManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Recherche automatique de BoardManager dans la scène
        if (boardManager == null)
        {
            boardManager = FindObjectOfType<BoardManager>();
            if (boardManager == null)
            {
                Debug.LogError("BoardManager introuvable dans la scène !");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reveal()
    {
        if (isRevealed) return;
        isRevealed = true;
        if (isBomb)
        {
            //Explosion, fin du jeu
            Debug.Log("Boom! Game Over.");
            this.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.red;
        }
        else
        {
            //Révéler la case
            this.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.gray;
            this.GetComponentInChildren<TMP_Text>().text = neighboringBombs.ToString();
            //Vérifier les cases voisines
            if (neighboringBombs == 0)
            {
                //Révéler les cases voisines
               boardManager.CheckNoNeighbors(matrixX, matrixY);
            }

        }
    }
}
