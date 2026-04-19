using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileInteraction : MonoBehaviour
{
    public Tilemap AutoCollectTilemap;
    public PlayerHealth PlayerHealth;
    
    public void OnTriggerStay2D(Collider2D other)
    {
        RemoveAutoCollectTileAtPlayerPosition();
    }

    private void RemoveAutoCollectTileAtPlayerPosition()
    {
        if (AutoCollectTilemap == null)
        {
            return;
        }
        
        Vector3Int cellPosition = AutoCollectTilemap.WorldToCell(transform.position);

        if (AutoCollectTilemap.HasTile(cellPosition))
        {
            AutoCollectTilemap.SetTile(cellPosition, null);
            PlayerHealth.ChangeHealth(1);
        }
    }
}
