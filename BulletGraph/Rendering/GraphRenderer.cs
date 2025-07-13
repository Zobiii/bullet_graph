namespace BulletGraph.Rendering
{
    public static class GraphRenderer
    {
        private static Pen? ghostPen;
        private static Pen? curvePen;
        private static Pen? axisPen;
        private static Brush? bulletBrush;
        private static Brush? glowBrush;

        static GraphRenderer()
        {
            // Pens und Brushes einmalig erstellen für bessere Performance
            ghostPen = new Pen(Color.LightGray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            curvePen = new Pen(Color.Red, 3);
            axisPen = new Pen(Color.Black, 2);
            bulletBrush = new SolidBrush(Color.DarkBlue);
            glowBrush = new SolidBrush(Color.FromArgb(100, Color.Yellow));
        }

        public static void DrawTrajectory(Graphics g, List<PointF> points, float width, int height)
        {
            if (points.Count == 0 || axisPen == null || curvePen == null || bulletBrush == null) return;

            float maxX = 0;
            float maxY = 0;

            foreach (var p in points)
            {
                if (p.X > maxX) maxX = p.X;
                if (p.Y > maxY) maxY = p.Y;
            }

            float scaleX = (width - 100) / Math.Max(maxX, 1);   // Platz nach rechts
            float scaleY = (height - 100) / Math.Max(maxY, 1);  // Platz nach oben

            float scale = Math.Min(scaleX, scaleY);

            // Achsen zeichnen
            g.DrawLine(axisPen, 50, height - 50, width - 20, height - 50);
            g.DrawLine(axisPen, 50, height - 50, 50, 20);

            g.DrawString("Entfernung (m)", SystemFonts.DefaultFont, Brushes.Black, width - 120, height - 40);
            g.DrawString("Höhe (m)", SystemFonts.DefaultFont, Brushes.Black, 10, 20);

            if (points.Count < 2) return;

            // Trajektorie zeichnen
            for (int i = 1; i < points.Count; i++)
            {
                PointF p1 = WorldToScreen(points[i - 1], scale, height);
                PointF p2 = WorldToScreen(points[i], scale, height);
                g.DrawLine(curvePen, p1, p2);
            }

            // Bullet an der aktuellen Position zeichnen
            if (points.Count > 0)
            {
                PointF bulletPos = WorldToScreen(points[points.Count - 1], scale, height);
                g.FillEllipse(bulletBrush, bulletPos.X - 4, bulletPos.Y - 4, 8, 8);
            }
        }

        public static void DrawTrajectoryAnimated(Graphics g, List<PointF> animatedPoints, List<PointF> fullTrajectory, float width, int height)
        {
            if (fullTrajectory.Count == 0 || ghostPen == null || curvePen == null || axisPen == null || bulletBrush == null || glowBrush == null) return;

            // Skalierung basierend auf der vollständigen Trajektorie berechnen
            float maxX = 0;
            float maxY = 0;

            foreach (var p in fullTrajectory)
            {
                if (p.X > maxX) maxX = p.X;
                if (p.Y > maxY) maxY = p.Y;
            }

            float scaleX = (width - 100) / Math.Max(maxX, 1);
            float scaleY = (height - 100) / Math.Max(maxY, 1);
            float scale = Math.Min(scaleX, scaleY);

            // Achsen zeichnen
            g.DrawLine(axisPen, 50, height - 50, width - 20, height - 50);
            g.DrawLine(axisPen, 50, height - 50, 50, 20);

            g.DrawString("Entfernung (m)", SystemFonts.DefaultFont, Brushes.Black, width - 120, height - 40);
            g.DrawString("Höhe (m)", SystemFonts.DefaultFont, Brushes.Black, 10, 20);

            // Vollständige Trajektorie als graue gestrichelte Linie zeichnen
            if (fullTrajectory.Count >= 2)
            {
                for (int i = 1; i < fullTrajectory.Count; i++)
                {
                    PointF p1 = WorldToScreen(fullTrajectory[i - 1], scale, height);
                    PointF p2 = WorldToScreen(fullTrajectory[i], scale, height);
                    g.DrawLine(ghostPen, p1, p2);
                }
            }

            // Animierte Trajektorie als rote Linie zeichnen
            if (animatedPoints.Count >= 2)
            {
                for (int i = 1; i < animatedPoints.Count; i++)
                {
                    PointF p1 = WorldToScreen(animatedPoints[i - 1], scale, height);
                    PointF p2 = WorldToScreen(animatedPoints[i], scale, height);
                    g.DrawLine(curvePen, p1, p2);
                }
            }

            // Bullet an der aktuellen Position zeichnen
            if (animatedPoints.Count > 0)
            {
                PointF bulletPos = WorldToScreen(animatedPoints[animatedPoints.Count - 1], scale, height);
                
                // Glow-Effekt
                g.FillEllipse(glowBrush, bulletPos.X - 6, bulletPos.Y - 6, 12, 12);
                // Bullet
                g.FillEllipse(bulletBrush, bulletPos.X - 3, bulletPos.Y - 3, 6, 6);
            }
        }

        private static PointF WorldToScreen(PointF p, float scale, int height)
        {
            float x = 50 + p.X * scale;
            float y = height - 50 - p.Y * scale;
            return new PointF(x, y);
        }
    }
}