using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileInteraction : MonoBehaviour
{
    public Tilemap AutoCollectTilemap;
    public Tilemap InteractTilemap;
    public PlayerHealth PlayerHealth;
    public TileBase TileToPlace;

    public void OnPickup()
    {
        PickupTile();
    }

    private void PickupTile()
    {
        if (InteractTilemap == null)
        {
            return;
        }

        Vector3Int cellPosition = InteractTilemap.WorldToCell(transform.position);
        InteractTilemap.SetTile(cellPosition, null);
    }

    public void OnDrop()
    {
        DropTile();
    }

    private void DropTile()
    {
        if (InteractTilemap == null)
        {
            return;
        }
        if (TileToPlace == null)
        {
            return;
        }
        
        Vector3Int cellPosition = InteractTilemap.WorldToCell(transform.position);
        if (IsCellEmpty(cellPosition))
        {
            InteractTilemap.SetTile(cellPosition, TileToPlace);
        }
    }

    private bool IsCellEmpty(Vector3Int cellPosition)
    {
        if (InteractTilemap.GetTile(cellPosition) == null)
            return true;
        return false;
    }

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
