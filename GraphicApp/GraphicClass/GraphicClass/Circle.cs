using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
namespace GraphicClass
{
    public class Circle : Shape
    {  public int Radius { get; set; }
        public Circle()
        {

        }
        public Circle(int Radius,Point origin)
        {
            this.Radius = Radius;
            _origin = origin;

        }
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override void Draw(Graphics graphic, Pen p)
        {
            graphic.DrawEllipse(p, _origin.X - Radius, _origin.Y - Radius, Radius + Radius, Radius + Radius);   
        }

        public override void MoveTo(Point point,Graphics graphics)
        {
            _origin = point;
            graphics.DrawEllipse(p, _origin.X - Radius, _origin.Y - Radius, Radius + Radius, Radius + Radius);
        }

        public override void Resize(int Size, Graphics graphicContent)
        {
            Radius += Size;
        }
        public void Save()
        {
            string circleAsJson = JsonConvert.SerializeObject(this);
            string path = $"{ConfigurationManager.AppSettings["CirclePath"]} {this.Id}.json";
            File.WriteAllText(path, circleAsJson);
        }
        public void Load(List<Circle> circles)
        {
            string path = ConfigurationManager.AppSettings["CirclePath"];
            List<string> files = Directory.GetFiles(path).ToList();

            foreach (string file in files)
            {
                circles.Add(JsonConvert.DeserializeObject<Circle>(File.ReadAllText(file)));
            }

        }
    }
}
