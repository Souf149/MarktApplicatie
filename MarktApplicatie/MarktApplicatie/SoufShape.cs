using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MarktApplicatie {
    class SoufShape : Shape {
        public Shape shape;
        public static Canvas canvas;
        double xSpeed = 1, ySpeed = 0;

        public SoufShape(Shape s) {

            shape = s;
            canvas.Children.Add(s);
        }

        public void Update() {
            double[] pos = GetLocation();
            SetLocation(pos[0] + xSpeed, pos[1] + ySpeed);
        }

        

        public void SetLocation(double x, double y) {
            Canvas.SetLeft(shape, x);
            Canvas.SetTop(shape, y);
        }

        // returns array with location.
        public double[] GetLocation() {
            return new double[]{
                Canvas.GetLeft(shape),
                Canvas.GetTop(shape)
            };
        }

        public void Rotate(double angle) {
            shape.RenderTransform = new RotateTransform(angle);
        }

        protected override Geometry DefiningGeometry => throw new NotImplementedException();

        
    }
}
