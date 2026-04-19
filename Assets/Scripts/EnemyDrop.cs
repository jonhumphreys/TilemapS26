using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyDrop : MonoBehaviour
{
    public TileBase TileToPlace;
    private Tilemap interactTilemap;
    
    public void Awake()
    {
        interactTilemap = GameObject.Find("Grid/AutoPickup").GetComponent<Tilemap>();
    }

    public void SpawnTileOnEnemyDeath()
    {
        Vector3Int cellPosition = interactTilemap.WorldToCell(transform.position);
        interactTilemap.SetTile(cellPosition, TileToPlace);
    }
}
