using StandardAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

public enum CardType
{
    Giant,
    Army,
    Cannoneer,
    Log,
    Shield,
    Explosives,
    Archers,
    Heal
}

[System.Serializable]
public class CardInfos
{
    public RectTransform cardTranform;
    public CardType type;
}

public class Cards : MonoBehaviour
{
    private Queue<int> nextCardIndex = new Queue<int>();
    public CardInfos[] cards;
    public int nextCard = 4;
    public GameObject[] nextCardsIcons;
    public ProceduralImage nextCardTimer;

    private void Awake()
    {
        nextCardsIcons[nextCard].SetActive(true);
        for (int i = 4; i < cards.Length; i++)
        {
            nextCardIndex.Enqueue(i);
        }
    }
    public void DisableCard(CardType card)
    {

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].type == card)
            {
                nextCardIndex.Enqueue(i);
                cards[i].cardTranform.gameObject.SetActive(false);
                MoveNextCard(cards[i].cardTranform.localPosition);
                return;
            }
        }
    }

    private void MoveNextCard(Vector3 localPos)
    {
        IEnumerator ie = CardMover(localPos);
        StartCoroutine(ie);
    }

    private IEnumerator CardMover(Vector3 localPos)
    {
        int nextCard = nextCardIndex.Dequeue();
        float t = 0.2f;
        while (t > 0.001f)
        {
            t -= Time.deltaTime;
            yield return null;
        }
        cards[nextCard].cardTranform.localPosition = localPos;
        cards[nextCard].cardTranform.gameObject.SetActive(true);
        nextCardsIcons[nextCard].SetActive(false);
        nextCardsIcons[nextCardIndex.Peek()].SetActive(true);
    }
}
