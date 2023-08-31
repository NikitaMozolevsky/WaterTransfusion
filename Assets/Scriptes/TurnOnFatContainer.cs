using System.Collections;
using UnityEngine;

public class TurnOnFatContainer : MonoBehaviour
{
    private static Transform chosenContainer;
    private static bool isMoving;
    public float moveSpeed = 1f;
    private float rotationSpeed = 1f;

    /*private void UpAndRotateContainer()
    {
        chosen.position = Vector2.Lerp(chosen.position, chosen.position, moveSpeed * Time.deltaTime);
    }*/

    /*private Transform getFinalPosition()
    {
        /*return new Vector3()#1#
    }*/

    private void OnMouseDown()
    {
        if (chosenContainer == null && !isMoving)
        {
            chosenContainer = transform;
            SpriteRenderer childSpriteRenderer = chosenContainer.GetChild(0).GetComponent<SpriteRenderer>();
            childSpriteRenderer.enabled = true;
            
            Vector2 newposition = new Vector2(transform.position.x, transform.position.y + 3);
            StartCoroutine(MoveSmoothly(transform, newposition, moveSpeed));
        }
        
        else if (chosenContainer != null && !isMoving)
        {
            SpriteRenderer childSpriteRenderer = chosenContainer.GetChild(0).GetComponent<SpriteRenderer>();
            Vector2 newposition = new Vector2(chosenContainer.position.x, chosenContainer.position.y - 3);
            StartCoroutine(MoveSmoothly(chosenContainer, newposition, moveSpeed));
            childSpriteRenderer.enabled = false;
            chosenContainer = null;
            

            /*SpriteRenderer childSpriteRenderer = chosen.GetComponent<SpriteRenderer>();
            childSpriteRenderer.enabled = false;
            Vector2 newposition = new Vector2(transform.position.x, transform.position.y - 3);
            StartCoroutine(MoveSmoothly(transform, newposition, moveSpeed));
            chosen = null;*/
        }

        IEnumerator MoveSmoothly(Transform objectToMove, Vector2 targetPosition, float moveSpeed)
        {
            isMoving = true;
            float elapsedtime = 0;
            Vector2 startingPosition = objectToMove.position;

            while (elapsedtime < 1)
            {
                elapsedtime += Time.deltaTime * moveSpeed;
                float t = Mathf.SmoothStep(0, 1, elapsedtime); // Используем функцию SmoothStep для медленного перемещения

                objectToMove.position = Vector2.Lerp(startingPosition, targetPosition, t);
                yield return null;
            }

            isMoving = false;
        }
        
    }

}