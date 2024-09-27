using UnityEngine;
using UnityEngine.EventSystems;

public class BlockController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public HeroKnight knight;

    public void OnPointerDown(PointerEventData eventData)
    {
        knight.BlockTrue();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knight.BlockFalse();
    }
}
