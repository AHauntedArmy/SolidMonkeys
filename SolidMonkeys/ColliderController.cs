using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

namespace SolidMonkeys
{
	class ColliderController : MonoBehaviour
	{
		private GameObject bodyCollider = null;
		private GameObject headCollider = null;

		private void Start()
		{
			Transform head = gameObject.transform.Find("rig/body/head/SpeakerHeadCollider");
			Transform body = gameObject.transform.Find("rig/body/BodyTrigger");

			LayerMask  toucableLayer = LayerMask.NameToLayer("Gorilla Object");

			if (head != null) {
				Debug.Log("head found, cloning head");
				headCollider = GameObject.Instantiate(head.gameObject, head.parent);

				if (headCollider != null) {
					headCollider.layer = toucableLayer;

					var headCol = head.GetComponent<SphereCollider>();
					if (headCol != null)
						headCol.isTrigger = false;
					
					headCollider.SetActive(this.enabled);
				}

			}

			if (body != null) {
				Debug.Log("body found, cloning body");
				bodyCollider = GameObject.Instantiate(body.gameObject, body.parent);

				if (bodyCollider != null) {
					bodyCollider.layer = toucableLayer;

					var bodyCol = bodyCollider.GetComponent<CapsuleCollider>();
					if (bodyCol != null)
						bodyCol.isTrigger = false;
					
					bodyCollider.SetActive(this.enabled);
				}
			}
		}

		private void OnEnable()
		{
			bodyCollider?.SetActive(true);
			headCollider?.SetActive(true);
		}

		private void OnDisable()
		{
			bodyCollider?.SetActive(false);
			headCollider?.SetActive(false);
		}
	}
}
