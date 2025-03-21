using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using System.Windows.Media;

namespace PR2
{
    public partial class MainWindow : Window
    {
        private RotateTransform3D cubeRotation, pyramidRotation;
        private AxisAngleRotation3D cubeAxis, pyramidAxis;
        private DispatcherTimer timer;
        private double cubeAngle = 0;
        private double pyramidAngle = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cubeRotation = new RotateTransform3D();
            cubeAxis = new AxisAngleRotation3D { Axis = new Vector3D(0, 1, 0), Angle = 0 };
            cubeRotation.Rotation = cubeAxis;

            Transform3DGroup cubeTransform = new Transform3DGroup();
            cubeTransform.Children.Add(cubeRotation);
            cubeTransform.Children.Add(new TranslateTransform3D(-1.5, 0, 0));
            CubeModel.Transform = cubeTransform;

            
            pyramidRotation = new RotateTransform3D();
            pyramidAxis = new AxisAngleRotation3D { Axis = new Vector3D(0, 1, 0), Angle = 0 };
            pyramidRotation.Rotation = pyramidAxis;

            Transform3DGroup pyramidTransform = new Transform3DGroup();
            pyramidTransform.Children.Add(pyramidRotation);
            pyramidTransform.Children.Add(new TranslateTransform3D(1.5, 0, 0));
            PyramidModel.Transform = pyramidTransform;

            timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(25) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            cubeAngle += 10;      
            pyramidAngle -= 10;   

            cubeAxis.Angle = cubeAngle;
            pyramidAxis.Angle = pyramidAngle;
        }
    }
}