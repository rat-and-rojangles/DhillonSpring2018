using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCategoryResources : ScriptableObject {
	public class HealthCategoryData {
		public HealthCategoryData (Sprite icon, Color color) {
			this.icon = icon;
			this.color = color;
		}
		public Sprite icon;
		public Color color;
	}

	public HealthCategoryData GetDataFromCategory (HealthCategory healthCategory) {
		switch (healthCategory) {
			case HealthCategory.Diet:
				return new HealthCategoryData (dietIcon, dietColor);
			case HealthCategory.Social:
				return new HealthCategoryData (socialIcon, socialColor);
			case HealthCategory.Exercise:
				return new HealthCategoryData (exerciseIcon, exerciseColor);
			case HealthCategory.Uncategorized:
				return new HealthCategoryData (null, Color.white);
			default:    //silent
				return new HealthCategoryData (null, Color.clear);
		}
	}


	public Sprite dietIcon;
	public Color dietColor;
	public Sprite socialIcon;
	public Color socialColor;
	public Sprite exerciseIcon;
	public Color exerciseColor;
}
