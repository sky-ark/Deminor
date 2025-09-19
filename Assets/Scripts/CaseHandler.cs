using UnityEngine;

public class CaseHandler : MonoBehaviour
{

    public bool isBomb;

    public bool isRevealed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reveal()
    {
        if (isBomb)
        {
            //Explosion, fin du jeu
        }
        else
        {
            // S'il n'y a pas de bombe voisine, révéler les cases environnantes
        }
    }
}
