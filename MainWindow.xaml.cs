using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursova
{
    public partial class MainWindow : Window
    {
        List<Point> points;
        BasicFigureClass.Figure[] list; 

        public MainWindow()
        {
            InitializeComponent();
            Add_Shapes();
        }

        private void Random_data()
        {
            Random rnd = new Random();
            points = new List<Point>(){
                new Point(rnd.Next(0, 10), rnd.Next(0, 10)),
                new Point(rnd.Next(0, 10), rnd.Next(0, 10)),
                new Point(rnd.Next(0, 10), rnd.Next(0, 10)),
                new Point(rnd.Next(0, 10), rnd.Next(0, 10)),
            };
        }

        private void Add_Shapes()
        {
            Random_data();
            list = new BasicFigureClass.Figure [] { 
                new BasicFigureClass.FTriangle(points),
                new BasicFigureClass.FQuadrate(points[2].X),
                new BasicFigureClass.FRhombus(points),
                new BasicFigureClass.FRectangle(points[3].X, points[3].Y),
                new BasicFigureClass.FParallel(points, 35),
                new BasicFigureClass.FTrapezium(points),
                new BasicFigureClass.FCircle(points[3].Y),
                new BasicFigureClass.FEllipse(points[2].Y, points[1].X),
                new BasicFigureClass.FPentagon(points[2].X),
                new BasicFigureClass.FHexagon(points[3].X),
            };

            MainGrid.Children.Clear();

            int k = 0;
            for (int x = 0; x < MainGrid.RowDefinitions.Count; x++)
            {
                for (int y = 0; y < MainGrid.ColumnDefinitions.Count; y++)
                {
                    list[k].position = k;
                    var shape = list[k].Draw();
                    Grid.SetRow(shape, x);
                    Grid.SetColumn(shape, y);
                    MainGrid.Children.Add(shape);
                    k++;
                }
            }
        }

        private void BtnRefreshClick(object sender, RoutedEventArgs e)
        {
            Add_Shapes();
        }

        private void MouseOnFigure(object sender, MouseEventArgs e)
        {
            double x = e.GetPosition(MainGrid).X;
            double y = e.GetPosition(MainGrid).Y;
            double start_x = 0.0;
            double start_y = 0.0;
            int row = 0;
            int column_1 = 0;
            int column_2 = 5;

            foreach (RowDefinition ld in MainGrid.RowDefinitions)
            {
                start_y += ld.ActualHeight;
                if (y < start_y)
                {
                    break;
                }
                row++;
            }

            foreach (ColumnDefinition ld in MainGrid.ColumnDefinitions)
            {
                start_x += ld.ActualWidth;
                if (x < start_x)
                {
                    break;
                }
                if (row == 0)
                    column_1++;
                if (row == 1)
                    column_2++;
            }

            int item = 0;
            if (row == 0)
                item = column_1;
            if (row == 1)
                item = column_2;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < MainGrid.Children.Count; i++)
            {
                if (list[i].position == item)
                {
                    
                    sb.Append(list[i].position);
                    sb.Append("# ");
                    sb.Append(list[i].Name());
                    sb.AppendLine();
                    sb.Append("Square : ");
                    sb.Append(list[i].Square());
                    sb.AppendLine();
                    sb.Append("Perimeter : ");
                    sb.Append(list[i].Perimeter());
                    sb.AppendLine();
                    sb.Append("Radius : ");
                    sb.Append(list[i].Radius());
                    sb.AppendLine();
                    sb.Append("Side Length : ");
                    sb.Append(list[i].Side_Length());
                    sb.AppendLine();
                    sb.Append("Size Corners : ");
                    sb.Append(list[i].Size_Corners());
                    sb.AppendLine();
                }
                info.Text = sb.ToString();
            }
        }

        private void MouseOutFigure(object sender, MouseEventArgs e)
        {
            info.Text = "info about figure";
        }

        private static UIElement GetChildren(Grid grid, int row, int column)
        {
            foreach (UIElement child in grid.Children)
            {
                if (Grid.GetRow(child) == row
                      &&
                   Grid.GetColumn(child) == column)
                {
                    return child;
                }
            }
            return null;
        }
    }

}

