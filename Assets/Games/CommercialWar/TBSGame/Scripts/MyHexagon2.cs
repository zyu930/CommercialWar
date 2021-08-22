using TbsFramework.Cells;
using UnityEngine;
using System;

namespace TBSGame
{
	public class MyHexagon2 : Hexagon
	{
		public enum GraphType
		{
			Base,
			Effect
		}
    	
        private Renderer hexagonRenderer;
        private Renderer outlineRenderer;

        private Vector3 dimensions = new Vector3(2.2f, 1.9f, 1.1f);

        public void Awake()
        {
            hexagonRenderer = GetComponent<Renderer>();

            var outline = transform.Find("Outline");
            outlineRenderer = outline.GetComponent<Renderer>();

            SetColor(hexagonRenderer, Color.white);
	        SetColor(outlineRenderer, Color.black);
            
	        CellClicked += OnCellClicked;
        }
        
	    public Vector2 getDistance2(MyHexagon2 _other)
	    {
	    	return GetCubeToOffsetCoords() - _other.GetCubeToOffsetCoords();
	    }
	    
		public Vector3 getDistance3(MyHexagon2 _other)
		{
			return GetCubeCoord() - _other.GetCubeCoord();
		}
	    
	    public Vector3 GetCubeCoord()
	    {
	    	return CubeCoord;
	    }
        
	    public Vector2 GetCubeToOffsetCoords()
	    {
	    	return CubeToOffsetCoords(CubeCoord);
	    }
        
		public Vector2 GetCubeToOffsetCoords(Vector3 v)
		{
			return CubeToOffsetCoords(v);
		}
        
	    void OnCellClicked(object sender, EventArgs e)
	    {
	    	Bolt.CustomEvent.Trigger(this.gameObject, "OnCellClicked");
	    }

        public override Vector3 GetCellDimensions()
        {
            return dimensions;
        }

		public void MarkAsStartPoint(Color flag)
		{
			SetColor(hexagonRenderer, flag);
		}
		public void MarkAsHighlighted2(bool highlight = true)
		{
			if(highlight)
				SetColor(outlineRenderer, Color.blue);
			else
				SetColor(outlineRenderer, Color.black);
		}
		public void MarkAsReachable2()
		{
			MarkAsReachable2(Color.yellow);
		}
		public void MarkAsReachable2(Color col)
		{
			SetColor(hexagonRenderer, col);
		}
		public void UnMark2()
		{
			SetColor(hexagonRenderer, Color.white);
			SetColor(outlineRenderer, Color.black);
		}
        public override void MarkAsReachable()
        {
	        //SetColor(hexagonRenderer, Color.yellow);
        }
        public override void MarkAsPath()
        {
	        //SetColor(hexagonRenderer, Color.green); ;
        }
        public override void MarkAsHighlighted()
        {
	        //SetColor(outlineRenderer, Color.blue);
        }
        public override void UnMark()
        {
	        //SetColor(hexagonRenderer, Color.white);
	        //SetColor(outlineRenderer, Color.black);
        }

        private void SetColor(Renderer renderer, Color color)
        {
	        renderer.material.color = color;
        }
    }
}
