using UnityEngine;

namespace SolidMonkeys
{
	class VelocityTracker : MonoBehaviour
	{
		private Vector3 lastPosition;
		private Vector3 currentPosition;
		private Vector3 velocity = Vector3.zero;

		public Vector3 Velocity => velocity;

		private void Awake() => lastPosition = this.transform.position;
		private void OnDisable() => velocity = Vector3.zero;

		private void OnEnable()
		{
			lastPosition = this.transform.position;
			currentPosition = this.transform.position;
		}

		private void LateUpdate()
		{
			currentPosition = this.transform.position;
			velocity = (currentPosition - lastPosition) / Time.deltaTime;
			lastPosition = currentPosition;
		}
	}
}
