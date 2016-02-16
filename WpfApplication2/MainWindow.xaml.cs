/*using System;
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

namespace WpfApplication2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Line a = new Line();
            a.X1 = 10;
            a.X2 = 500;
            a.Y1 = 100;
            a.Y2 = 100;
            a.StrokeThickness = 50;
            a.Stroke = Brushes.BlueViolet;
            //a.Visibility = Visibility.Visible;



            canvas.Children.Add(a);
            Rectangle rec = new Rectangle();
            rec.RadiusX = 50;
            rec.RadiusY = 50;
            Ellipse el = new Ellipse();
            el.Margin = new Thickness(200, 200, el.Margin.Right, el.Margin.Bottom);
            el.Width = el.Height = 100;
            el.Fill = Brushes.Goldenrod;
            canvas.Background = Brushes.Black;

            canvas.Children.Add(el);

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Line a = new Line();
            a.X1 = 10;
            a.X2 = 500;
            a.Y1 = 100;
            a.Y2 = 100;
            a.StrokeThickness = 50;
            a.Stroke = Brushes.BlueViolet;
            //a.Visibility = Visibility.Visible;



            canvas.Children.Add(a);
            Rectangle rec = new Rectangle();
            rec.RadiusX = 50;
            rec.RadiusY = 50;
            Ellipse el = new Ellipse();
            el.Margin = new Thickness(200, 200, el.Margin.Right, el.Margin.Bottom);
            el.Width = el.Height = 100;
            el.Fill = Brushes.Goldenrod;
            canvas.Background = Brushes.Black;

            canvas.Children.Add(el);

        }
    }
}

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication2
{
    /// <summary> 
    /// Interaction logic for MainWindow.xaml 
    /// </summary> 
    /// 

    public partial class MainWindow : Window
    {
        BasePlanet planet;

        //class Coord
        //{
        //    public static Coord operator+(Coord c1,Coord c2)
        //    {
        //        return new Coord(c1.x + c2.x, c1.y + c2.y);

        //    }
        //    public static Coord operator *(double c1, Coord c2)
        //    {
        //        return new Coord(c1 * c2.x, c1 * c2.y);

        //    }
        //    public static Coord operator *(Coord c1,double c2)
        //    {
        //        return new Coord(c2 * c1.x, c2 * c1.y);

        //    }
        //    public static Coord operator /(Coord c1, double c2)
        //    {
        //        return new Coord(c1.x / c2, c1.y / c2);

        //    }
        //    public Coord()
        //    {
        //        x = y = 0;//z
        //    }
        //    public Coord(double x, double y)
        //    {
        //        this.x = x;
        //        this.y = y;
        //    }
        //    public double x { get; private set; }
        //    public double y { get; private set; }
        //    //z 
        //    public double getMod() {
        //        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        //    }
        //}
        class BasePlanet
        {
            public bool delStatus { get; private set;}
            public double radius { get; set; }
            public Ellipse ellipse { get; set; }
            Vector _speed { get; set; }
            public Vector coord {get;set;}
            Vector _acc;
            public Vector _strength { get; set; }
            public long weight;
            DateTime time;
            Brush color;


            int stop;

            //public BasePlanet(Coord coord,Coord sheed, Coord acc)
            //{
            //    ellipse = new Ellipse();
            //    weight = 50;
            //    _strength = new Coord();
            //    _acc = new Coord();
            //    _speed = new Coord();
            //}
            public static BasePlanet operator+ (BasePlanet first, BasePlanet second)
            {
                double m1 = first.weight;
                double m2 = second.weight;

                first.radius = Math.Sqrt(Math.Pow(first.radius, 2) + Math.Pow(second.radius, 2));
                first.weight += second.weight;
                first._speed = (m1*first._speed+m2*second._speed) / (m1+m2);
                


                return first;
            }

            public void merger(BasePlanet planet)
            {
                double m1 = planet.weight;
                double m2 = weight;

                radius = Math.Sqrt(Math.Pow(planet.radius, 2) + Math.Pow(radius, 2));
                weight += planet.weight;
                _speed = (m1 * planet._speed + m2 * _speed) / (m1 + m2);
            }
            public BasePlanet(Vector coord)
            {
                this.color = Brushes.Goldenrod;
                this.coord = coord;
                radius = 5;
                weight = 5000000;
                ellipse = new Ellipse();
                _strength = new Vector();
                _acc = new Vector();
                _speed = new Vector();
                time = DateTime.Now;
                stop =0;
                delStatus = false;
            }

        public BasePlanet(Vector coord, Vector speed , Brush color) : this(coord)
            {
                this.color = color;
                _speed = speed;
                //this.radius = v;
            }

            public BasePlanet(Vector coord,Vector speed, Brush color, long weight, double radius):this(coord)
            {
                this.weight = weight;
                this.radius = radius;
                this.color = color;
                _speed = speed;
                //this.radius = v;
            }

            public BasePlanet(BasePlanet planet1, BasePlanet planet2):this(planet1.coord,planet1._speed+planet2._speed,Brushes.Blue,planet1.weight+planet2.weight,(planet2.radius+planet1.radius)*0.8)
            {
                _strength = planet1._strength + planet2._strength;
            }

            internal double getCordY()
            {
                return coord.Y;
            }

            internal double getCordX()
            {
                return coord.X;
            }

            internal void Update()
            {
                UpdateAcceliration();
                stop++;
                ellipse.Width = ellipse.Height = radius * 2;
                ellipse.Fill = color;
                Thickness Thick = new Thickness(getCordX(), getCordY(), ellipse.Margin.Right, ellipse.Margin.Bottom);
                ellipse.Margin = Thick;
            }

            private void UpdateAcceliration()
            {
                //
                _acc = _strength / (double)weight;
                double t = (double)(DateTime.Now - time).Ticks / (double)100000000000; 
                //double t = 0.01;

                Vector tmpCoord = new Vector();
                //if (coord.x < 0)
                //{
                //    _speed = new Coord(_speed.x * (-1), _speed.y);
                //}
                //if (coord.y < 0)
                //{
                //    _speed = new Coord(_speed.x, _speed.y * (-1));
                //}
                //if (coord.x > 1920)
                //{
                //    _speed = new Coord(_speed.x * (-1), _speed.y);
                //}
                //if (coord.y > 1000)
                //{
                //    _speed = new Coord(_speed.x, _speed.y * (-1));
                //}

                coord +=(_speed * t + (_acc * t * t) / 2);
                
                _speed += _acc * t;
                


                
            }

            internal double distance(BasePlanet tp)
            {
                return Math.Sqrt(Math.Pow((this.coord.X-tp.coord.X),2) + Math.Pow((this.coord.Y - tp.coord.Y), 2));
            }

            internal void del()
            {
                delStatus = true;
            }
        }



        class Painter
        {
            Canvas _canvas;
            public List<Ellipse> elList;
            public List<Ellipse> elDelList;

            public void setEllipseLists(ref List<Ellipse> elList, ref List<Ellipse> elDelList)
            {
                this.elDelList = elDelList;
                this.elList = elList;
            }


    public Painter(Canvas canvas)
            {
                //elList = new List<Ellipse>();
                //elDelList = new List<Ellipse>();
                _canvas = canvas;

            }

            public void RePaint() {

            foreach(var el in elDelList)
            {
                    _canvas.Children.Remove(el);
                    
            }
                foreach(var el in elList)
                {
                    try
                    {
                        _canvas.UpdateLayout();
                        _canvas.Children.Add(el);

                    }
                    catch
                    {

                    }
                }
            }

            public void Refresh()
            {

            }

            internal void delEllipse(Ellipse ellipse)
            {
                _canvas.Children.Remove(ellipse);
            }
        }
        class ManagerPlanet
        {
            double g = 100000;
            HashSet<BasePlanet> planets;
            List<Ellipse> ellipses;
            List<Ellipse> delEllipses;
            Painter paint;
            private List<BasePlanet> delPlanets;

            public ManagerPlanet(Painter paint)
            {
                delPlanets = new List<BasePlanet>();
                this.paint = paint;
                planets = new HashSet<BasePlanet>();
                ellipses =  new List<Ellipse>();
                delEllipses =  new List<Ellipse>();
                paint.setEllipseLists(ref ellipses, ref delEllipses);
            }
            public void AddPlanet(BasePlanet planet)
            {
                planets.Add(planet);
                ellipses.Add(planet.ellipse);
            }
            public void UpdatePlanets()
            {


                foreach(var p in planets) // Calculating strenght
                {
                    if (p.delStatus)
                    {
                        continue;
                    }
                    Vector tmpStrength = new Vector();
                    foreach (var tp in planets)
                    {

                        if (!p.Equals(tp))
                        {
                            if (tp.delStatus)
                            {
                                continue;
                            }
                            if (p.distance(tp) > (p.radius + tp.radius)*0.6)
                            {

                                double strengthMod = g * tp.weight * p.weight / Math.Pow(p.distance(tp), 2);
                                double k = Math.Sqrt(Math.Pow(tp.coord.X - p.coord.X, 2) + Math.Pow(tp.coord.Y - p.coord.Y, 2));

                                Vector tmpStr = new Vector((tp.coord.X - p.coord.X) / k, (tp.coord.Y - p.coord.Y) / k);
                                tmpStrength += strengthMod * tmpStr;
                            }
                            else
                            {
                                //p.merger(tp);
                                //tp.del();
                                //paint.elList.Remove(tp.ellipse);
                                
                                //delPlanets.Add(tp);
                            }
                                    

                         }
                    }
                    p._strength = tmpStrength;
                }

                foreach(var p in delPlanets)
                {
                    paint.delEllipse(p.ellipse);
                    //delEllipses.Add(p.ellipse);
                    ellipses.Remove(p.ellipse);
                    planets.Remove(p);
                }
                delPlanets.Clear();


                foreach(var p in planets) // Calculating acceleration
                {
                   


                }


                foreach(var p in planets) // Update All planets.
                {
                    p.Update();
                }
            }
            public void DisplayPlanets()
            {
                paint.RePaint();
            }


        }
        ManagerPlanet manager;
        public MainWindow()
        {

            InitializeComponent();
            this.Background = Brushes.Black;
            //canvas.Background = Brushes.Black;
            Painter painter = new Painter(canvas);
            manager = new ManagerPlanet(painter);
            Vector startCord = new Vector(canvas.Width / 2, canvas.Height / 2);
            planet = new BasePlanet(startCord);
            //manager.AddPlanet(planet);
            //manager.AddPlanet(new BasePlanet(new Coord(150, 980), new Coord(3050, 0), Brushes.Red, 2, 7));
            //manager.AddPlanet(new BasePlanet(new Coord(700, 400), new Coord(0, 1500), Brushes.Blue, 1, 5));
            //manager.AddPlanet(new BasePlanet(new Coord(1000, 400), new Coord(0, 0), Brushes.Gold, 100000, 25));
            //manager.AddPlanet(new BasePlanet(new Coord(850, 500), new Coord(-50, 30), Brushes.SteelBlue, 100, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(50, 800), new Coord(100, 40), Brushes.White, 1, 4));
            //manager.AddPlanet(new BasePlanet(new Coord(350, 100), new Coord(-30, 300), Brushes.Silver, 3, 1));

            //manager.AddPlanet(new BasePlanet(new Coord(600, 600), new Coord(100, 100), Brushes.Red, 10, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(1200, 600), new Coord(200, -100), Brushes.Yellow, 10, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(900, 300), new Coord(310, 0), Brushes.Violet, 300, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(900, 900), new Coord(410, 0), Brushes.MintCream, 10, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(900, 600), new Coord(300, 0), Brushes.MintCream, 300, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(150, 980), new Coord(500, 0), Brushes.Red, 2, 7));
            //manager.AddPlanet(new BasePlanet(new Coord(400, 400), new Coord(300, 0), Brushes.Blue, 1, 5));
            //manager.AddPlanet(new BasePlanet(new Coord(1000, 400), new Coord(0, 0), Brushes.Gold, 100000, 25));
            //manager.AddPlanet(new BasePlanet(new Coord(850, 500), new Coord(900, 0), Brushes.SteelBlue, 100, 10));
            Random rand = new Random();
            rand.Next();
            for (int i = 0; i < 100; i++)
            {
                manager.AddPlanet(new BasePlanet(new Vector(rand.Next(0, 700), rand.Next(0, 400)), new Vector(rand.Next(2000, 5000), rand.Next(2000, 5000)), Brushes.Red, rand.Next(10, 10), 3));
            }
            manager.AddPlanet(new BasePlanet(new Vector(350, 200), new Vector(0, 0), Brushes.Yellow, -1000, 10));
            manager.AddPlanet(new BasePlanet(new Vector(450, 200), new Vector(0, 0), Brushes.Yellow, 10000, 10));

            //manager.AddPlanet(new BasePlanet(new Coord(600, 600), new Coord(0, 3500), Brushes.Red, 10, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(1200, 600), new Coord(0, -3500), Brushes.Yellow, 10, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(900, 300), new Coord(-3500, 0), Brushes.Violet, 10, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(900, 900), new Coord(3500, 0), Brushes.MintCream, 10, 10));
            //manager.AddPlanet(new BasePlanet(new Coord(900, 600), new Coord(0, 0), Brushes.Blue, 3000, 15));
            manager.UpdatePlanets();
            manager.DisplayPlanets();




        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            dispatcherTimer.Interval = new TimeSpan(10000);
            dispatcherTimer.Start();


        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            manager.UpdatePlanets();
            
        }
    }
}