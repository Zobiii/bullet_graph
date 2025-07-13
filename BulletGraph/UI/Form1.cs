using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BulletGraph.Core;
using BulletGraph.Rendering;

namespace BulletGraph
{
    public partial class Form1 : Form
    {
        private float startHeight = 1.6f;
        private float angleDeg = 45f;
        private float speed = 50f;

        private List<PointF> trajectory = new();
        private List<PointF> animatedTrajectory = new();
        private float maxY = 0f;
        private float hitX = 0f;
        private System.Windows.Forms.Timer? animationTimer;
        private int currentAnimationIndex = 0;

        private TextBox? inputHeight;
        private TextBox? inputAngle;
        private TextBox? inputSpeed;
        private Button? simulateButton;
        private Panel? graphPanel;

        public Form1()
        {
            InitializeComponent();

            this.Width = 1000;
            this.Height = 600;
            this.Text = "Ballistische Kurvensimulation";
            // DoubleBuffered wieder aktivieren für flüssige Animation
            this.DoubleBuffered = true;

            SetupUI();
        }

        private void SetupUI()
        {
            // Einfaches Layout ohne TableLayoutPanel - direkter Ansatz
            this.BackColor = SystemColors.Control;

            // Input-Controls direkt zur Form hinzufügen
            Label lblHeight = new() { Text = "Höhe (m):", Location = new Point(10, 15), BackColor = SystemColors.Control };
            inputHeight = new() { Location = new Point(80, 13), Width = 60, Text = startHeight.ToString("0.00") };

            Label lblAngle = new() { Text = "Winkel (°):", Location = new Point(160, 15), BackColor = SystemColors.Control };
            inputAngle = new() { Location = new Point(230, 13), Width = 60, Text = angleDeg.ToString("0.0") };

            Label lblSpeed = new() { Text = "Speed (m/s):", Location = new Point(310, 15), BackColor = SystemColors.Control };
            inputSpeed = new() { Location = new Point(400, 13), Width = 60, Text = speed.ToString("0") };

            simulateButton = new() { Text = "Simulieren", Location = new Point(480, 11), Width = 100 };
            simulateButton.Click += (_, _) => SimulateAndDraw();

            // Animation Timer erstellen
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 30; // 30ms zwischen den Frames für flüssigere Animation
            animationTimer.Tick += AnimationTimer_Tick;

            // Zeichenfläche mit explizitem Abstand von oben
            graphPanel = new Panel
            {
                Location = new Point(0, 60),
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height - 60,
                BackColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            
            // DoubleBuffering für das Panel aktivieren
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, graphPanel, new object[] { true });
                
            graphPanel.Paint += GraphPanel_Paint;

            // Input-Controls zur Form hinzufügen (hohe Z-Order)
            this.Controls.Add(lblHeight);
            this.Controls.Add(inputHeight);
            this.Controls.Add(lblAngle);
            this.Controls.Add(inputAngle);
            this.Controls.Add(lblSpeed);
            this.Controls.Add(inputSpeed);
            this.Controls.Add(simulateButton);

            // Graph-Panel zuletzt hinzufügen (niedrige Z-Order)
            this.Controls.Add(graphPanel);

            // Sicherstellen, dass Input-Controls immer im Vordergrund sind
            lblHeight.BringToFront();
            inputHeight.BringToFront();
            lblAngle.BringToFront();
            inputAngle.BringToFront();
            lblSpeed.BringToFront();
            inputSpeed.BringToFront();
            simulateButton.BringToFront();
        }

        private void SimulateAndDraw()
        {
            if (inputHeight == null || inputAngle == null || inputSpeed == null || graphPanel == null || animationTimer == null) return;

            // Animation stoppen falls sie läuft
            animationTimer.Stop();

            float.TryParse(inputHeight.Text, out startHeight);
            float.TryParse(inputAngle.Text, out angleDeg);
            float.TryParse(inputSpeed.Text, out speed);

            trajectory = TrajectoryCalculator.CalculateTrajectory(startHeight, angleDeg, speed, 0.02f, out maxY, out hitX);

            // Animation vorbereiten
            animatedTrajectory.Clear();
            currentAnimationIndex = 0;

            this.Text = $"Maximale Höhe: {maxY:0.00} m   Einschlag bei: {hitX:0.00} m";
            
            // Animation starten
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (animationTimer == null || graphPanel == null) return;

            // Mehrere Punkte pro Frame hinzufügen für flüssigere Animation
            int pointsPerFrame = Math.Max(1, trajectory.Count / 60); // Animation in etwa 2 Sekunden
            
            for (int i = 0; i < pointsPerFrame && currentAnimationIndex < trajectory.Count; i++)
            {
                animatedTrajectory.Add(trajectory[currentAnimationIndex]);
                currentAnimationIndex++;
            }

            if (currentAnimationIndex < trajectory.Count)
            {
                // Nur das Panel neu zeichnen, nicht die ganze Form
                graphPanel.Invalidate();
            }
            else
            {
                // Animation beendet
                animationTimer.Stop();
                graphPanel.Invalidate(); // Finales Neuzeichnen
            }
        }

        private void GraphPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (graphPanel == null) return;
            // Animierte Trajektorie zeichnen, aber vollständige Trajektorie für Skalierung verwenden
            GraphRenderer.DrawTrajectoryAnimated(e.Graphics, animatedTrajectory, trajectory, width: graphPanel.Width, height: graphPanel.Height);
        }
    }
}
