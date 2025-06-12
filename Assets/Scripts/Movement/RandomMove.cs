using RS.Extensions;
using System.Collections;
using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Move the object randomly
    /// </summary>
    public class RandomMove : MonoBehaviour
    {
        // public field

        public float Speed = 1;
        public float MaxOffset = 10;

        public float DirectionMoverTime = 1f;

        public Vector3 AxeMultiplier = Vector3.one;

        public bool RandomizeOnStart;

        // Positions

        private Vector3 _basePosition;

        private Vector3 _offset;
        private Vector3 _direction;

        private Vector3 _offsetTarget;

        //

        private Coroutine _directionMover = null;
        private float _limiter = 1f;

        private float _minMovementSqr;

        #region Unity Events
        private void Awake()
        {
            float moveRatio = MaxOffset / Speed;
            float minMovement = DirectionMoverTime / moveRatio;
            minMovement *= 1.33f;

            minMovement = Mathf.Min(0.75f, minMovement);
            _minMovementSqr = minMovement * minMovement;

            _basePosition = transform.localPosition;

            RandomizeStart();
        }

        private void Update()
        {
            if (_directionMover == null)
            {
                _directionMover = StartCoroutine(MoveDirectionCo());
            }

            UpdateOffset();

            transform.localPosition = _basePosition + GetFinalOffset();
        }

        private void OnDisable()
        {
            _directionMover = null;
        }
        #endregion

        private void UpdateOffset()
        {
            Vector3 oldOffset = _offset;
            _offset += _direction * Speed * Time.deltaTime;

            if (_offset.sqrMagnitude > MaxOffset * MaxOffset)
            {
                _offset = oldOffset;
            }
        }

        /// <summary>
        /// Movement coroutine
        /// </summary>
        private IEnumerator MoveDirectionCo()
        {
            _offsetTarget = GenerateNewDirectionTarget();

            float t = 0;

            float step = 1 / DirectionMoverTime;

            Vector3 start = _direction;
            Vector3 targetDirection = _offsetTarget - _offset;

            while (t < 1)
            {
                yield return new WaitForFixedUpdate();

                t += Time.fixedDeltaTime * step;

                _direction = Vector3.Lerp(start, targetDirection, CurveType.SmoothLinear.Get(t));
            }

            _directionMover = null;
        }


        /// <summary>
        /// Generate a new target direction
        /// </summary>
        /// <returns>New target direction</returns>
        private Vector3 GenerateNewDirectionTarget()
        {
            Vector3 target;

            while (true)
            {
                target = Random.insideUnitSphere;

                if ((target - _offsetTarget).sqrMagnitude > _minMovementSqr)
                {
                    break;
                }
            }

            return target;
        }

        /// <summary>
        /// Randomize the offset if RandomizeOnStart is enabled
        /// </summary>
        private void RandomizeStart()
        {
            if (!RandomizeOnStart)
            {
                return;
            }

            _offset = Random.insideUnitSphere * MaxOffset;
        }


        /// <summary>
        /// Get the final offset
        /// </summary>
        /// <returns>Final Offset</returns>
        private Vector3 GetFinalOffset()
        {
            return Vector3.Scale(_offset, AxeMultiplier) * _limiter;
        }


        // TODO: What is limiter, why change it
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public void SetLimiter(float t)
        {
            _limiter = Mathf.Clamp01(t);
        }
    } 
}
