﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elysium.Tilemaps
{
    public class BuildingVisualTilemap : MonoBehaviour, IVisualTilemap<BuildingTileObject>
    {
        public BuildingTilemap SmartTilemap => smartTilemap as BuildingTilemap;
        public SmartTilemap<BuildingTileObject> smartTilemap { get; set; }

        public void CreateVisuals(Vector3Int _position)
        {
            BuildingTileObject ctx = SmartTilemap.GetBuilding(_position);
            if (ctx == null) { return; }
            ctx.gameObject = new GameObject(ctx.building.name);
            ctx.gameObject.transform.position = smartTilemap.Tilemap.GetCellCenterWorld(_position);
            ctx.gameObject.transform.rotation = Quaternion.identity;
            ctx.gameObject.AddComponent<SpriteRenderer>().sprite = ctx.building.sprite;
        }

        public void UpdateVisuals(Vector3Int _position)
        {
            BuildingTileObject ctx = SmartTilemap.GetBuilding(_position);
            if (ctx == null) { return; }
            if (ctx.functional) { ctx.gameObject.GetComponent<SpriteRenderer>().color = Color.green; }
            else { ctx.gameObject.GetComponent<SpriteRenderer>().color = Color.red; }
        }

        public void RemoveVisuals(Vector3Int _position)
        {
            BuildingTileObject ctx = SmartTilemap.GetBuilding(_position);
            if (ctx == null) { return; }
            Destroy(ctx.gameObject);
        }
    }
}