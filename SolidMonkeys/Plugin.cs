using BepInEx;
using System;
using System.ComponentModel;
using UnityEngine;
using Utilla;

namespace SolidMonkeys
{
	[ModdedGamemode]
	[Description("HauntedModMenu")]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class SolidMonkeysPlugin : BaseUnityPlugin
	{
		bool inRoom;
		CollisionHandler colScript = null;
		void OnEnable()
		{
			if (!inRoom)
				return;

			Patches.VRRigColliderPatch.ModEnabled = true;
			ToggleColliders(true);
		}

		void OnDisable()
		{
			Patches.VRRigColliderPatch.ModEnabled = false;
			ToggleColliders(false);
		}

		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			Patches.HarmonyPatches.ApplyHarmonyPatches();
			Patches.VRRigColliderPatch.ModEnabled = this.enabled;

			colScript = GorillaLocomotion.Player.Instance.gameObject.AddComponent<CollisionHandler>();
			colScript.enabled = this.enabled;

			inRoom = true;
		}

		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			Patches.HarmonyPatches.RemoveHarmonyPatches();
			GameObject.Destroy(colScript);

			inRoom = false;
		}

		private void ToggleColliders(bool toEnable)
		{
			var myCols = Resources.FindObjectsOfTypeAll<ColliderController>();
			if (myCols == null)
				return;

			foreach (var cc in myCols)
				cc.enabled = toEnable;

			if (colScript != null)
				colScript.enabled = toEnable;
		}
	}
}
