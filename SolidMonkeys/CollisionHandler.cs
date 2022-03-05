using UnityEngine;

namespace SolidMonkeys
{
	class CollisionHandler : MonoBehaviour
	{
		private Rigidbody rigidbody = null;

		private void Awake() => rigidbody = this.gameObject.GetComponent<Rigidbody>();

		private void OnCollisionEnter(Collision col)
		{
			if (rigidbody == null)
				return;

			var velocityTracker = col.collider.gameObject.GetComponent<VelocityTracker>();
			if (velocityTracker != null)
				rigidbody.velocity = velocityTracker.Velocity * 0.5f;
		}
	}
}
