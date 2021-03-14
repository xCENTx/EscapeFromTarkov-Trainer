﻿using EFT.InventoryLogic;
using EFT.Trainer.Extensions;
using EFT.Trainer.UI;
using UnityEngine;

namespace EFT.Trainer.Features
{
	public class Hud : MonoBehaviour, IEnableable
	{
		public static readonly Color HudColor = Color.white;
		public bool Enabled { get; set; } = true;
		
		public void OnGUI()
		{
			if (!Enabled)
				return;

			var player = GameState.Current?.LocalPlayer;
			if (!player.IsValid())
				return;

			if (player!.HandsController == null || player.HandsController.Item is not Weapon weapon)
				return;

			var mag = weapon.GetCurrentMagazine();
			if (mag == null)
				return;

			var hud = $"{mag.Count}+{weapon.ChamberAmmoCount}/{mag.MaxCount} [{weapon.SelectedFireMode}]";
			Render.DrawString(new Vector2(512, Screen.height - 16f), hud, HudColor);
		}
	}
}
