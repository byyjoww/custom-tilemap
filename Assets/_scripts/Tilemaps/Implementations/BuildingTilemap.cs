﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elysium.Tilemaps
{
    public class BuildingTilemap : SmartTilemap<BuildingTileObject>
    {
        public BuildingTileObject GetBuilding(Vector2 _position)
        {
            Vector3Int gridPosition = Tilemap.WorldToCell(_position);
            Properties.GetValue(gridPosition, out BuildingTileObject building);
            return building;
        }

        public BuildingTileObject GetBuilding(Vector3Int _position)
        {
            Properties.GetValue(_position, out BuildingTileObject building);
            return building;
        }

        public bool ConstructBuilding(Vector2 _position, TestBuildingObject _building)
        {
            var tilePosition = Tilemap.WorldToCell(_position);
            BuildingTileObject buildingObject = new BuildingTileObject(tilePosition, Properties.TriggerOnValueChanged, _building);

            Vector3Int gridPosition = Tilemap.WorldToCell(_position);
            return Properties.CreateValue(gridPosition, buildingObject);
        }

        public bool ConstructBuilding(Vector3Int _position, TestBuildingObject _building)
        {
            BuildingTileObject buildingObject = new BuildingTileObject(_position, Properties.TriggerOnValueChanged, _building);

            Vector3Int gridPosition = Tilemap.WorldToCell(_position);
            return Properties.CreateValue(gridPosition, buildingObject);
        }

        public bool UpdateBuilding(Vector2 _position, BuildingTileObject _building)
        {
            Vector3Int gridPosition = Tilemap.WorldToCell(_position);
            return Properties.ChangeValue(gridPosition, _building);
        }

        public bool DemolishBuilding(Vector2 _position)
        {
            Vector3Int gridPosition = Tilemap.WorldToCell(_position);
            return Properties.RemoveValue(gridPosition);
        }
    }
}