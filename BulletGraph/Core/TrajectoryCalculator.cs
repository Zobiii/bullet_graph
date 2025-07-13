namespace BulletGraph.Core
{
    public static class TrajectoryCalculator
    {
        public const float Gravity = 9.81f;

        public static List<PointF> CalculateTrajectory(float startHeight, float angleDeg, float speed, float timeStep, out float maxHeight, out float impactX)
        {
            List<PointF> points = new();
            float angleRad = angleDeg * (float)Math.PI / 180f;

            float vx = speed * (float)Math.Cos(angleRad);
            float vy = speed * (float)Math.Sin(angleRad);

            float t = 0;
            maxHeight = startHeight;
            impactX = 0;

            while (true)
            {
                float x = vx * t;
                float y = startHeight + vy * t - 0.5f * Gravity * t * t;

                if (y < 0)
                {
                    impactX = x;
                    break;
                }

                points.Add(new PointF(x, y));
                if (y > maxHeight) maxHeight = y;

                t += timeStep;
            }
            return points;
        }
    }
}