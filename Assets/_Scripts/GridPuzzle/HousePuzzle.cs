using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class HousePuzzle : MonoBehaviour
{
    GameManager gManage;
    public puzzlePIece[,] grid=new puzzlePIece[3,3];
    private List<puzzlePIece> selectedPieces = new List<puzzlePIece>();
    PlayerCont playerCont;
    bool HousePuzzleIsActive = false;
    bool correctSwap = false;
    bool hasBeenSwapped = false;
    private bool isSwapping = false;

    void Start()
{
    playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCont>();
    gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        foreach (Transform child in transform)
        {
            puzzlePIece piece = child.GetComponent<puzzlePIece>();
            if (piece != null)
            {
                grid[piece.gridX, piece.gridY] = piece;
                piece.onClick.AddListener(OnPieceClicked);
            }

        }
        
    }
private void Update() {
    if (HousePuzzleIsActive && Input.GetKeyDown(KeyCode.Escape))
    {
        ClosePuzzleGame();
    }
    //swap specific pieces on certain days for player to solve
    if (gManage.currentDay == 1&&hasBeenSwapped==false)
    {
        puzzlePIece a = grid[0, 0];
        puzzlePIece b = grid[1, 0];
        
        int tempX = a.gridX;
        int tempY = a.gridY;

        a.gridX = b.gridX;
        a.gridY = b.gridY;

        b.gridX = tempX;
        b.gridY = tempY;

        // Update grid array
        grid[a.gridX, a.gridY] = a;
        grid[b.gridX, b.gridY] = b;
        Vector3 tempPos = grid[0, 0].transform.position;
        grid[0, 0].transform.position = grid[1, 0].transform.position;
        grid[1, 0].transform.position = tempPos;
        hasBeenSwapped = true;



        }
    if (gManage.currentDay == 2 && hasBeenSwapped == false)
    {
        puzzlePIece a = grid[2, 2];
        puzzlePIece b = grid[2, 1];

        int tempX = a.gridX;
        int tempY = a.gridY;

        a.gridX = b.gridX;
        a.gridY = b.gridY;

        b.gridX = tempX;
        b.gridY = tempY;

        // Update grid array
        grid[a.gridX, a.gridY] = a;
        grid[b.gridX, b.gridY] = b;
        //swap pieces 2,2 and 2,1
        Vector3 tempPos = grid[2, 2].transform.position;
        grid[2, 2].transform.position = grid[2, 1].transform.position;
        grid[2, 1].transform.position = tempPos;
        hasBeenSwapped = true;
    }
    if (gManage.currentDay == 3 && hasBeenSwapped == false)
    {
        puzzlePIece a = grid[1, 1];
        puzzlePIece b = grid[1, 2];

        int tempX = a.gridX;
        int tempY = a.gridY;

        a.gridX = b.gridX;
        a.gridY = b.gridY;

        b.gridX = tempX;
        b.gridY = tempY;

        // Update grid array
        grid[a.gridX, a.gridY] = a;
        grid[b.gridX, b.gridY] = b;
        //swap pieces 1,1 and 1,2
        Vector3 tempPos = grid[1, 1].transform.position;
        grid[1, 1].transform.position = grid[1, 2].transform.position;
        grid[1, 2].transform.position = tempPos;
        hasBeenSwapped = true;
    }
    if (selectedPieces.Count >= 3)
    {
        selectedPieces.Clear();
    }
    }
public void ClosePuzzleGame()
{
    playerCont.playerCanMove = true;
    Cursor.lockState = CursorLockMode.Locked;
    //washingMachineUI[gManage.currentDay - 1].SetActive(false);
    //gManage.washingMachineStarted = true;
    //if (gManage.currentDay == 3)
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //}
}
// Start is called before the first frame update
public void StartPuzzle()
    {

        HousePuzzleIsActive = true;
        playerCont.playerCanMove = false;
        Cursor.lockState = CursorLockMode.Confined;
        
        

    }
    public void OnPieceClicked(GameObject pieceClicked)
    {
        if (isSwapping) return;
        puzzlePIece piece=pieceClicked.GetComponent<puzzlePIece>();

        /*if (curDay!=gManage.currentDay&&selectedPieces.Count>=1)
        {
            selectedPieces.Clear();
        }*/
        if (selectedPieces.Count > 2)
        {
            selectedPieces.Clear();
        }
        

        if (selectedPieces.Contains(piece)||piece==null){
            //selectedPieces.Remove(piece);
            return;
        }
        
        selectedPieces.Add(piece);
        
        if (selectedPieces.Count==2){//if two pieces are selected, swap
            Debug.Log("Hello! swapping pieces");
            if(isAdjacent(selectedPieces[0], selectedPieces[1]))
            {
                
                isSwapping = true; 
                puzzlePIece a = selectedPieces[0];
                puzzlePIece b= selectedPieces[1];
                // Swap their logical positions
                int tempX = a.gridX;
                int tempY = a.gridY;

                a.gridX = b.gridX;
                a.gridY = b.gridY;

                b.gridX = tempX;
                b.gridY = tempY;

                // Update grid array
                grid[a.gridX, a.gridY] = a;
                grid[b.gridX, b.gridY] = b;

                // Start smooth animation
                StartCoroutine(AnimateSwap(a, b));
                /*Vector3 tempPos = selectedPieces[0].transform.position; <<old swap method DONT DELETE
                
                selectedPieces[0].transform.position =  selectedPieces[1].transform.position;
                selectedPieces[1].transform.position = tempPos;*/

                if (gManage.currentDay == 1)//check for correct swap according to day
                {

                }
                selectedPieces.Clear();
                if (selectedPieces.Any())
                {
                    foreach (puzzlePIece selectedPiece in selectedPieces)
                    {
                        Debug.Log("Selected pieces in list: " + selectedPiece.name);
                    }
                }
                
            }
                
            
            //if (isAdjacent(selectedPieces[0]) && isAdjacent(selectedPieces[1]))
            //{
            //    Vector3 tempPos = selectedPieces[0].transform.position;
            //    selectedPieces[0].transform.position = selectedPieces[1].transform.position;
            //    selectedPieces[1].transform.position = tempPos;
            //}
            selectedPieces.Clear();
        }


    }
    private IEnumerator AnimateSwap(puzzlePIece a, puzzlePIece b, float duration = 0.25f)
    {//coroutine to animate the swap of two pieces with a suspension for the duration of the animation
        Vector3 aStart = a.transform.position;
        Vector3 bStart = b.transform.position;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            a.transform.position = Vector3.Lerp(aStart, bStart, t);
            b.transform.position = Vector3.Lerp(bStart, aStart, t);
            yield return null;
        }

        // Final snap to clean up rounding errors
        a.transform.position = bStart;
        b.transform.position = aStart;
        yield return new WaitForSeconds(duration);
        isSwapping = false;
    }
    bool isAdjacent(puzzlePIece piece1,puzzlePIece piece2)
    {
        //check if piece is adjacent to any selected piece
        Debug.Log("In isAdjacent function");
        int dx = Mathf.Abs(piece1.gridX - piece2.gridX);
        int dy = Mathf.Abs(piece1.gridY - piece2.gridY);
        return (dx + dy) == 1;
    }
}

