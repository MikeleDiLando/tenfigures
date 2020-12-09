using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace kursova
{
    public class BasicFigureClass
    {
        public abstract class Figure
        {
            public int position;
            abstract public string Name();
            abstract public string Square();
            abstract public string Perimeter();
            abstract public string Radius();
            abstract public string Side_Length();
            abstract public string Size_Corners();
            abstract public Shape Draw();
        }
        public class FTriangle : Figure
        {
            double a, b, c;
            PointCollection myPointCollection;

            public FTriangle(List<Point> points)
            {
                this.a = side_length(points[0], points[1]);
                this.b = side_length(points[1], points[2]);
                this.c = side_length(points[0], points[2]);

                myPointCollection = new PointCollection();
                myPointCollection.Add(points[0]);
                myPointCollection.Add(points[1]);
                myPointCollection.Add(points[2]);
            }
            public override string Name()
            {
                return "Triangle";
            }
            public override string Square()
            {
                double p = (a + b + c) / 2;
                return string.Format("{0:0.##}", Math.Sqrt(p * (p - a) * (p - b) * (p - c))).ToString();
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (a + b + c)).ToString();
            }
            public override string Radius()
            {
                double p = (a + b + c) / 2;
                return string.Format("{0:0.##}", ((a * b * c) / (4 * Math.Sqrt(p * (p - a) * (p - b) * (p - c))))).ToString();
            }
            public override string Side_Length()
            {
                return ("\nSide a = " + string.Format("{0:0.##}", this.a) + "\nSide b = " + string.Format("{0:0.##}", this.b) + "\nSide c = " + string.Format("{0:0.##}", this.c));
            }
            public override string Size_Corners()
            {
                double alpha = (Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)) * 180) / Math.PI;
                double beta = (Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)) * 180) / Math.PI;
                double gamma = (Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)) * 180) / Math.PI;
                return ("\nAlpha = " + string.Format("{0:0.##}", alpha) + " 'C\nBeta = " + string.Format("{0:0.##}", beta) + " 'C\nGamma = " + string.Format("{0:0.##}", gamma) + " 'C");
            }
            public override Shape Draw()
            {
                return draw_poligon(this.myPointCollection);
            }
        }

        public class FQuadrate : Figure
        {
            double a;
            public FQuadrate(double a)
            {
                this.a = a;
            }
            public override string Name()
            {
                return "Quadrate";
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", (a * a)).ToString();
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (4 * a)).ToString();
            }
            public override string Radius()
            {
                return string.Format("{0:0.##}", (a / Math.Sqrt(2))).ToString();
            }
            public override string Side_Length()
            {
                return ("\nSide a, b, c, d = " + this.a);
            }
            public override string Size_Corners()
            {
                return ("\nAll have 90 'C");
            }
            public override Shape Draw()
            {
                return draw_rectangle(this.a, this.a);
            }
        }

        public class FRhombus : Figure
        {
            double a, diagonal;
            PointCollection myPointCollection;
            public FRhombus(List<Point> points)
            {
                this.a = side_length(points[0], new Point(-points[0].Y, points[0].X));
                this.diagonal = side_length(points[0], new Point(-points[0].X, -points[0].Y));

                myPointCollection = new PointCollection();
                myPointCollection.Add(new Point(points[0].X, points[0].Y));
                myPointCollection.Add(new Point(-points[0].Y, points[0].X));
                myPointCollection.Add(new Point(-points[0].X, -points[0].Y));
                myPointCollection.Add(new Point(points[0].Y, -points[0].X));
            }
            public override string Name()
            {
                return "Rhombus";
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", (diagonal * diagonal / 2)).ToString();
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (4 * a)).ToString();
            }
            public override string Radius()
            {
                return string.Format("{0:0.##}", (a / Math.Sqrt(2))).ToString();
            }
            public override string Side_Length()
            {
                return ("\nSide a, b, c, d = " + string.Format("{0:0.##}", this.a) + "\nDiagonal 1, 2 = " + string.Format("{0:0.##}", this.diagonal));
            }
            public override string Size_Corners()
            {
                double alpha = (Math.Acos(1 - (Math.Pow(diagonal, 2) / (2 * Math.Pow(a, 2)))) * 180) / Math.PI;
                double beta = (Math.Acos((Math.Pow(diagonal, 2) / (2 * Math.Pow(a, 2))) - 1) * 180) / Math.PI;
                return ("\nAlpha = " + string.Format("{0:0.##}", alpha) + " 'C\nBeta = " + string.Format("{0:0.##}", beta) + " 'C");
            }
            public override Shape Draw()
            {
                return draw_poligon(this.myPointCollection);
            }
        }

        public class FRectangle : Figure
        {
            double a, b;
            public FRectangle(double a, double b)
            {
                this.a = a;
                this.b = b;
            }
            public override string Name()
            {
                return "Rectangle";
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", (a * b)).ToString();
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", ((a + b) * 2)).ToString();
            }
            public override string Radius()
            {
                return string.Format("{0:0.##}", (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) / 2)).ToString();
            }
            public override string Side_Length()
            {
                return ("\nSide a, c = " + string.Format("{0:0.##}", this.a) + "\nSide b, d = " + string.Format("{0:0.##}", this.b));
            }
            public override string Size_Corners()
            {
                return ("\nAll have 90 'C");
            }
            public override Shape Draw()
            {
                return draw_rectangle(this.a, this.b);
            }
        }

        public class FParallel : Figure
        {
            double a, b, diagonal, h;
            PointCollection myPointCollection;
            public FParallel(List<Point> points, double h)
            {
                this.a = side_length(points[0], points[1]);
                this.b = side_length(points[1], new Point(-points[0].X, -points[0].Y));
                this.diagonal = side_length(points[1], new Point(-points[1].X, -points[1].Y));
                double сos_alpha = (Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(diagonal, 2)) / (2 * a * b);
                double sin_alpha = Math.Sqrt(1 - Math.Pow(сos_alpha, 2));
                this.h = a * sin_alpha;

                myPointCollection = new PointCollection();
                myPointCollection.Add(points[0]);
                myPointCollection.Add(points[1]);
                myPointCollection.Add(new Point(-points[0].X, -points[0].Y));
                myPointCollection.Add(new Point(-points[1].X, -points[1].Y));
            }
            public override string Name()
            {
                return "Parallel";
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (2 * (a + b))).ToString();
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", (a * h)).ToString();
            }
            public override string Radius()
            {
                return ("has no circle around");
            }
            public override string Side_Length()
            {
                return ("\nSide a, c = " + string.Format("{0:0.##}", this.a) + "\nSide b, d = " + string.Format("{0:0.##}", this.b) + "\nDiagonal 1 = " + string.Format("{0:0.##}", this.diagonal) + "\nH = " + string.Format("{0:0.##}", this.h));
            }
            public override string Size_Corners()
            {
                double alpha = (Math.Acos((Math.Pow(a, 2) + Math.Pow(diagonal, 2) - Math.Pow(b, 2)) / (2 * a * diagonal)) * 180) / Math.PI;
                double beta = 180 - alpha;
                return ("\nAlpha = " + string.Format("{0:0.##}", alpha) + " 'C\nBeta = " + string.Format("{0:0.##}", beta) + " 'C");
            }
            public override Shape Draw()
            {
                return draw_poligon(this.myPointCollection);
            }
        }

        public class FTrapezium : Figure
        {
            double a, b, d, diagonal, h;
            PointCollection myPointCollection;
            public FTrapezium(List<Point> points)
            {
                this.a = side_length(points[0], points[1]);
                this.b = side_length(points[1], new Point(-points[1].X, points[1].Y));
                this.diagonal = side_length(points[0], new Point(-points[0].X, points[0].Y));
                this.d = (Math.Pow(diagonal, 2) - Math.Pow(a, 2)) / b;
                double сos_alpha = (Math.Pow(a, 2) + Math.Pow(d, 2) - Math.Pow(diagonal, 2)) / (2 * a * d);
                double sin_alpha = Math.Sqrt(1 - Math.Pow(сos_alpha, 2));
                this.h = a * sin_alpha;

                myPointCollection = new PointCollection();
                myPointCollection.Add(new Point(points[0].X, points[0].Y));
                myPointCollection.Add(new Point(points[1].X, points[1].Y));
                myPointCollection.Add(new Point(-points[1].X, points[1].Y));
                myPointCollection.Add(new Point(-points[0].X, points[0].Y));
            }
            public override string Name()
            {
                return "Trapezium";
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", (((b + d) / 2) * h)).ToString();
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (a + b + a + d)).ToString();
            }
            public override string Radius()
            {
                double p = (a + diagonal + d) / 2;
                return string.Format("{0:0.##}", ( (a * diagonal * d) / (4 * Math.Sqrt(p * (p - a) * (p - diagonal) * (p - d))))).ToString();
            }
            public override string Side_Length()
            {
                return ("\nSide a, c = " + string.Format("{0:0.##}", this.a) + "\nSide b = " + string.Format("{0:0.##}", this.b) + "\nSide d = " + string.Format("{0:0.##}", this.d) + "\nDiagonal = " + string.Format("{0:0.##}", this.diagonal) + "\nH = " + string.Format("{0:0.##}", this.h));
            }
            public override string Size_Corners()
            {
                double alpha = (Math.Acos((Math.Pow(a, 2) + Math.Pow(d, 2) - Math.Pow(diagonal, 2)) / (2 * a * d)) * 180) / Math.PI;
                double beta = (Math.Acos((Math.Pow(b, 2) + Math.Pow(a, 2) - Math.Pow(diagonal, 2)) / (2 * a * b)) * 180) / Math.PI;
                return ("\nAlpha = " + string.Format("{0:0.##}", alpha) + " 'C\nBeta = " + string.Format("{0:0.##}", beta) + " 'C");
            }
            public override Shape Draw()
            {
                return draw_poligon(this.myPointCollection);
            }
        }

        public class FCircle : Figure
        {
            double r;
            public FCircle(double r)
            {
                this.r = r;
            }
            public override string Name()
            {
                return "Circle";
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", (Math.PI * Math.Pow(r, 2))).ToString();
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (2 * Math.PI * r)).ToString();
            }
            public override string Radius()
            {
                return string.Format("{0:0.##}", r).ToString();
            }
            public override string Side_Length()
            {
                return ("\nСircumference = Perimeter = " + string.Format("{0:0.##}", Perimeter()));
            }
            public override string Size_Corners()
            {
                return ("\nDidn't have a corners");
            }
            public override Shape Draw()
            {
                return draw_ellipse(this.r, this.r);
            }
        }

        public class FEllipse : Figure
        {
            double a, b;
            public FEllipse(double a, double b)
            {
                this.a = a;
                this.b = b;
            }
            public override string Name()
            {
                return "Ellipse";
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", (Math.PI * a * b)).ToString();
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (2 * Math.PI * Math.Sqrt((Math.Pow(a,2) + Math.Pow(b,2))/8))).ToString();
            }
            public override string Radius()
            {
                return string.Format("{0:0.##}", (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) / 2)).ToString();
            }
            public override string Side_Length()
            {
                return ("\nСircumference = Perimeter = " + string.Format("{0:0.##}", Perimeter()));
            }
            public override string Size_Corners()
            {
                return ("\nDidn't have a corners");
            }
            public override Shape Draw()
            {
                return draw_ellipse(this.a, this.b);
            }
        }

        public class FPentagon : Figure
        {
            double side;
            PointCollection myPointCollection;
            public FPentagon(double rotate)
            {
                this.side = side_length(new Point((float)Math.Cos(1 * 72 * Math.PI / 180f), (float)Math.Sin(1 * 72 * Math.PI / 180f)), new Point((float)Math.Cos(2 * 72 * Math.PI / 180f), (float)Math.Sin(2 * 72 * Math.PI / 180f)));

                myPointCollection = new PointCollection();
                for (int a = 0; a < 5; a++)
                {
                    myPointCollection.Add(new Point((float)Math.Cos(rotate + a * 72 * Math.PI / 180f), (float)Math.Sin(rotate + a * 72 * Math.PI / 180f)));
                }
            }
            public override string Name()
            {
                return "Pentagon";
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", ((Math.Sqrt(25 + 10 * Math.Sqrt(5)) / 4) * Math.Pow(side, 2))).ToString();
            }
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (5 * side)).ToString();
            }
            public override string Radius()
            {
                return string.Format("{0:0.##}", ((Math.Sqrt(50 + 10 * Math.Sqrt(5)) / 10) * side)).ToString();
            }
            public override string Side_Length()
            {
                return ("\nAll Sides = " + string.Format("{0:0.##}", this.side));
            }
            public override string Size_Corners()
            {
                return ("\nAll have 108 'C");
            }
            public override Shape Draw()
            {
                return draw_poligon(this.myPointCollection);
            }
        }

        public class FHexagon : Figure
        {
            double side;
            PointCollection myPointCollection;

            public FHexagon(double rotate)
            {
                this.side = side_length(new Point((float)Math.Cos(1 * 60 * Math.PI / 180f), (float)Math.Sin(1 * 60 * Math.PI / 180f)), new Point((float)Math.Cos(2 * 60 * Math.PI / 180f), (float)Math.Sin(2 * 60 * Math.PI / 180f)));

                myPointCollection = new PointCollection();
                for (int a = 0; a < 6; a++)
                {
                    myPointCollection.Add(new Point((float)Math.Cos(rotate + a * 60 * Math.PI / 180f), (float)Math.Sin(rotate + a * 60 * Math.PI / 180f)));
                }
            }
            public override string Name()
            {
                return "Hexagon";
            }
            public override string Square()
            {
                return string.Format("{0:0.##}", (((3 * Math.Sqrt(3)) / 2) * Math.Pow(side, 2))).ToString();
            } 
            public override string Perimeter()
            {
                return string.Format("{0:0.##}", (6 * side)).ToString();
            }
            public override string Radius()
            {
                return ("\nRadius = Side = " + string.Format("{0:0.##}", this.side));
            }
            public override string Side_Length()
            {
                return ("\nAll Sides = " + string.Format("{0:0.##}", this.side));
            }
            public override string Size_Corners()
            {
                return ("\nAll have 120 'C");
            }
            public override Shape Draw()
            {
                return draw_poligon(this.myPointCollection);
            }
        }


        //////////////////////////////////



        public static double side_length(Point point1, Point point2)
        {
            double side;
            side = Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
            return side;
        }

        public static Polygon draw_poligon(PointCollection pointCollection)
        {
            Polygon polygon = new Polygon();
            polygon.Points = pointCollection;
            polygon.Width = 100;
            polygon.Height = 100;
            polygon.Fill = random_color();
            polygon.Stretch = Stretch.Fill;
            polygon.StrokeThickness = 2;
            polygon.Stroke = random_color(); 
            return polygon;
        }

        public static Ellipse draw_ellipse(double x, double y)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = x * 15;
            ellipse.Height = y * 15;
            ellipse.Fill = random_color();
            ellipse.Stretch = Stretch.Fill;
            ellipse.StrokeThickness = 2;
            ellipse.Stroke = random_color();
            return ellipse;
        }

        public static Rectangle draw_rectangle(double x, double y)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = x*15;
            rectangle.Height = y*15;
            rectangle.Fill = random_color();
            rectangle.Stretch = Stretch.Fill;
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = random_color();
            return rectangle;
        }

        public static SolidColorBrush random_color()
        {
            Random rnd = new Random();
            SolidColorBrush solidColorBrush = new SolidColorBrush();
            solidColorBrush.Color = Color.FromArgb((byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256));
            return solidColorBrush;
        }
    }
}
