using UnityEngine;

namespace SolidMonkeys
{
	class ColliderController : MonoBehaviour
	{
		private GameObject bodyCollider = null;
		private GameObject headCollider = null;
		private GameObject lHandCollider = null;
		private GameObject rHandCollider = null;

		private void Start()
		{
			Transform head = gameObject.transform.Find("rig/body/head/SpeakerHeadCollider");
			Transform body = gameObject.transform.Find("rig/body/BodyTrigger");
			Transform lhand = this.gameObject.transform.Find("rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L");
			Transform rHand = this.gameObject.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R");

			LayerMask  touchableLayer = LayerMask.NameToLayer("Gorilla Object");

			if (head != null) {
				// Debug.Log("head found, cloning head");
				headCollider = GameObject.Instantiate(head.gameObject, head.parent);

				if (headCollider != null) {
					headCollider.layer = touchableLayer;

					var headCol = head.GetComponent<SphereCollider>();
					if (headCol != null)
						headCol.isTrigger = false;

					headCollider.AddComponent<VelocityTracker>();
					headCollider.SetActive(this.enabled);
				}

			}

			if (body != null) {
				// Debug.Log("body found, cloning body");
				bodyCollider = GameObject.Instantiate(body.gameObject, body.parent);

				if (bodyCollider != null) {
					bodyCollider.layer = touchableLayer;

					var bodyCol = bodyCollider.GetComponent<CapsuleCollider>();
					if (bodyCol != null)
						bodyCol.isTrigger = false;

					bodyCollider.AddComponent<VelocityTracker>();
					bodyCollider.SetActive(this.enabled);
				}
			}

			Vector3 localScale = new Vector3(0.12f, 0.12f, 0.12f);
			Vector3 localPosition = new Vector3(-0.016f, 0.043f, 0f);

			if(lhand != null) {
				lHandCollider = GameObject.CreatePrimitive(PrimitiveType.Sphere);

				if (lHandCollider != null) {
					GameObject.Destroy(lHandCollider.GetComponent<MeshFilter>());
					GameObject.Destroy(lHandCollider.GetComponent<MeshRenderer>());

					lHandCollider.layer = touchableLayer;
					lHandCollider.transform.SetParent(lhand);
					lHandCollider.transform.localScale = localScale;
					lHandCollider.transform.localPosition = localPosition;
					lHandCollider.AddComponent<VelocityTracker>();
					lHandCollider.SetActive(this.enabled);
				}
			}

			localPosition.x *= -1f;

			if(rHand != null) {
				rHandCollider = GameObject.CreatePrimitive(PrimitiveType.Sphere);

				if (rHandCollider != null) {
					GameObject.Destroy(rHandCollider.GetComponent<MeshFilter>());
					GameObject.Destroy(rHandCollider.GetComponent<MeshRenderer>());

					rHandCollider.layer = touchableLayer;
					rHandCollider.transform.SetParent(rHand);
					rHandCollider.transform.localScale = localScale;
					rHandCollider.transform.localPosition = localPosition;
					rHandCollider.AddComponent<VelocityTracker>();
					rHandCollider.SetActive(this.enabled);
				}
			}

			// lastPosition = this.gameObject.transform.position;
		}

		private void OnEnable()
		{
			bodyCollider?.SetActive(true);
			headCollider?.SetActive(true);
			lHandCollider?.SetActive(true);
			rHandCollider?.SetActive(true);
		}

		private void OnDisable()
		{
			bodyCollider?.SetActive(false);
			headCollider?.SetActive(false);
			lHandCollider?.SetActive(false);
			rHandCollider?.SetActive(false);
		}
	}
}
