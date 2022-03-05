using HarmonyLib;

namespace SolidMonkeys.Patches
{
	[HarmonyPatch(typeof(VRRig))]
	[HarmonyPatch("Start", MethodType.Normal)]
	internal class VRRigColliderPatch
	{
		public static bool ModEnabled { get; set; }

		private static void Postfix(VRRig __instance)
		{
			if (__instance.isOfflineVRRig)
				return;

			Photon.Pun.PhotonView photView = __instance.photonView;
			if (photView != null && photView.IsMine)
				return;

			var cc = __instance.gameObject.AddComponent<ColliderController>();
			cc.enabled = ModEnabled;

			// Debug.Log("adding collider component");
		}
	}
}
