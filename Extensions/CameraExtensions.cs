﻿using UnityEngine;

namespace EFT.Trainer.Extensions
{
	public static class CameraExtensions
	{
		public static Vector3 WorldPointToScreenPoint(this Camera camera, Vector3 worldPoint)
		{
			var screenPoint = camera.WorldToScreenPoint(worldPoint);
			screenPoint.y = Screen.height - screenPoint.y;
			return screenPoint;
		}

		public static bool IsWorldPointVisible(this Camera camera, Vector3 worldPoint)
		{
			return IsScreenPointVisible(camera, WorldPointToScreenPoint(camera, worldPoint));
		}

		public static bool IsScreenPointVisible(this Camera camera, Vector3 screenPoint)
		{
			return screenPoint.z > 0.01f && screenPoint.x > -5f && screenPoint.y > -5f && screenPoint.x < Screen.width && screenPoint.y < Screen.height;
		}

		public static bool IsWithinDistance(this Camera camera, Transform transform, float distance)
		{
			return Vector3.Distance(camera.transform.position, transform.position) <= distance;
		}
	}
}
