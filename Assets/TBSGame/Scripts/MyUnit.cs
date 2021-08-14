using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TbsFramework.Cells;
using TbsFramework.Pathfinding.Algorithms;

namespace TBSGame
{
	public class MyUnit : MonoBehaviour
	{
		private static DijkstraPathfinding _pathfinder = new DijkstraPathfinding();
		private static IPathfinding _fallbackPathfinder = new AStarPathfinding();
		
		Dictionary<Cell, List<Cell>> cachedPaths = null;
		/// <summary>
		/// Determines how far on the grid the unit can move.
		/// </summary>
		[SerializeField]
		private float movementPoints;
		public virtual float MovementPoints
		{
			get
			{
				return movementPoints;
			}
			protected set
			{
				movementPoints = value;
			}
		}
		/// <summary>
		/// Cell that the unit is currently occupying.
		/// </summary>
		[SerializeField]
		[HideInInspector]
		private Cell cell;
		public Cell Cell
		{
			get
			{
				return cell;
			}
			set
			{
				cell = value;
			}
		}
		/// <summary>
		/// Method returns all cells that the unit is capable of moving to.
		/// </summary>
		public HashSet<Cell> GetAvailableDestinations(List<Cell> cells)
		{
			cachedPaths = new Dictionary<Cell, List<Cell>>();

			var paths = CachePaths(cells);
			foreach (var key in paths.Keys)
			{
				if (!IsCellMovableTo(key))
				{
					continue;
				}
				var path = paths[key];

				var pathCost = path.Sum(c => c.MovementCost);
				if (pathCost <= MovementPoints)
				{
					cachedPaths.Add(key, path);
				}
			}
			return new HashSet<Cell>(cachedPaths.Keys);
		}
		private Dictionary<Cell, List<Cell>> CachePaths(List<Cell> cells)
		{
			var edges = GetGraphEdges(cells);
			var paths = _pathfinder.findAllPaths(edges, Cell);
			return paths;
		}
		/// <summary>
		/// Method returns graph representation of cell grid for pathfinding.
		/// </summary>
		protected virtual Dictionary<Cell, Dictionary<Cell, float>> GetGraphEdges(List<Cell> cells)
		{
			Dictionary<Cell, Dictionary<Cell, float>> ret = new Dictionary<Cell, Dictionary<Cell, float>>();
			foreach (var cell in cells)
			{
				if (IsCellTraversable(cell) || cell.Equals(Cell))
				{
					ret[cell] = new Dictionary<Cell, float>();
					foreach (Cell neighbour in cell.GetNeighbours(cells).FindAll(IsCellTraversable))
					{
						ret[cell][neighbour] = neighbour.MovementCost;
					}
				}
			}
			return ret;
		}
		///<summary>
		/// Method indicates if unit is capable of moving to cell given as parameter.
		/// </summary>
		public virtual bool IsCellMovableTo(Cell cell)
		{
			return !cell.IsTaken;
		}
		/// <summary>
		/// Method indicates if unit is capable of moving through cell given as parameter.
		/// </summary>
		public virtual bool IsCellTraversable(Cell cell)
		{
			return !cell.IsTaken;
		}

		public List<Cell> FindPath(List<Cell> cells, Cell destination)
		{
			if (cachedPaths != null && cachedPaths.ContainsKey(destination))
			{
				return cachedPaths[destination];
			}
			else
			{
				return _fallbackPathfinder.FindPath(GetGraphEdges(cells), Cell, destination);
			}
		}
	}
}
