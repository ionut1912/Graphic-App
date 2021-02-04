using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace GraphicClass
{
    public class GraphicTool
    {
        public Graphics graphicContent;
        public Pen p;
        public List<Shape> _shapeList { get; set; }
        public GraphicTool(Graphics graphicContent, Pen p)
        {
            this._shapeList = new List<Shape>()
            {
               new Rectanglee(),new Circle(),new Square()
            };
            this.graphicContent = graphicContent;
            this.p = p;
        }

        public void DrawAll()
        {

            foreach (Shape shape in _shapeList)
            {
                shape.Draw(graphicContent, p);
            }
        }

        public void Load()
        {
            string pathSquare = ConfigurationManager.AppSettings["SquarePath"];
            string pathCircle = ConfigurationManager.AppSettings["CirclePath"];
            string pathRectangle = ConfigurationManager.AppSettings["RectanglePath"];

            List<string> squares = Directory.GetFiles(pathSquare).ToList();

            foreach (string file in squares)
            {
                _shapeList.Add(JsonConvert.DeserializeObject<Square>(File.ReadAllText(file)));
            }

            List<string> circles = Directory.GetFiles(pathCircle).ToList();

            foreach (string file in circles)
            {
                _shapeList.Add(JsonConvert.DeserializeObject<Circle>(File.ReadAllText(file)));
            }

            List<string> rectangles = Directory.GetFiles(pathRectangle).ToList();

            foreach (string file in rectangles)
            {
                _shapeList.Add(JsonConvert.DeserializeObject<Rectanglee>(File.ReadAllText(file)));
            }

        }
    }
}
