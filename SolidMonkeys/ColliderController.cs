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
			GameObject head = gameObject.transform.Find("rig/body/head/SpeakerHeadCollider")?.gameObject;
			GameObject body = gameObject.transform.Find("rig/body/BodyTrigger")?.gameObject;

			LayerMask  toucableLayer = LayerMask.NameToLayer("Gorilla Object");

			if (head != null) {
				Debug.Log("head found, cloning head");
				headCollider = GameObject.Instantiate(head, head.transform);

				if (headCollider != null) {
					headCollider.SetActive(this.enabled);
					headCollider.layer = toucableLayer;

					var headCol = head.GetComponent<SphereCollider>();
					if (headCol != null)
						headCol.isTrigger = false;
				}
			}

			if (body != null) {
				Debug.Log("body found, cloning body");
				bodyCollider = GameObject.Instantiate(body, body.transform);

				if (bodyCollider != null) {
					bodyCollider.SetActive(this.enabled);
					bodyCollider.layer = toucableLayer;

					var bodyCol = bodyCollider.GetComponent<CapsuleCollider>();
					if (bodyCol != null)
						bodyCol.isTrigger = false;
				}
			}
		}

		private void OnEnable()
		{
			if (bodyCollider != null)
				bodyCollider.SetActive(true);

			if (headCollider != null)
				headCollider.SetActive(true);
		}

		private void OnDisable()
		{
			if (bodyCollider != null)
				bodyCollider.SetActive(false);

			if (headCollider != null)
				headCollider.SetActive(false);
		}
	}
}
