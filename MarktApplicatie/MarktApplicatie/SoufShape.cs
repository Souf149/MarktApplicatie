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
        private static Random rng = new Random(DateTime.Now.Millisecond);
        double xSpeed, ySpeed;
        double speed = 10;

        public SoufShape(Shape s) {

            shape = s;
            canvas.Children.Add(s);

            

            // top-right, bot-right, bot-left, top-left
            switch (rng.Next(1, 4)) {
                case 1:
                    xSpeed = speed; ySpeed = -speed;
                    break;
                case 2:
                    xSpeed = speed; ySpeed = speed;
                    break;
                case 3:
                    xSpeed = -speed; ySpeed = speed;
                    break;
                case 4:
                    xSpeed = -speed; ySpeed = -speed;
                    break;
                default:
                    xSpeed = 6;
                    break;
            }



        }

        public void Update() {
            double[] pos = GetLocation();
            double x = pos[0] + xSpeed;
            double y = pos[1] + ySpeed;
            SetLocation(x, y);
            
            if(x <= 0 || x + shape.Width >= canvas.ActualWidth) {
                xSpeed *= -1;
            }

            if(y <= 0 || y + shape.Height >= canvas.ActualHeight) {
                ySpeed *= -1;
            }

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
        
        public double GetWidth() {
            return shape.Width;
        }

        public void Rotate(double angle) {
            shape.RenderTransform = new RotateTransform(angle);
        }

        protected override Geometry DefiningGeometry => throw new NotImplementedException();

        
    }
}
