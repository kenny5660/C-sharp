﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Redactor_Vector_Graph
{
    class Tool
    {
        public static Tool ActiveTool { get; set; }
        public Button toolButton;
        public List<Figure> figureArray;
        public Pen ToolPen;
        public Panel paintBox;
        protected bool flagLeftMauseClick = false;
        protected bool flagRightMauseClick = false;

        public void tool_buttonClick(object sender, EventArgs e)
        {
            ActiveTool = this;
        }
        public virtual void MouseMove(object sender, MouseEventArgs e) { }
        public virtual void MouseDown(object sender, MouseEventArgs e) { }
        public virtual void MouseUp(object sender, MouseEventArgs e) { }
    }

    class ToolReact : Tool
    {
        public ToolReact(Button button, ref List<Figure> figureArrayFrom, Pen pen, Panel paintBox_set)
        {
            paintBox = paintBox_set;
            ToolPen = pen;
            figureArray = figureArrayFrom;
            toolButton = button;
            toolButton.Click += new EventHandler(tool_buttonClick);
        }
        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (flagLeftMauseClick)
            {
                figureArray.Last().Add_Point(new Point(e.X, e.Y));
                paintBox.Invalidate();
            }
        }
        public override void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flagLeftMauseClick = true;
                figureArray.Add(new Rect(ToolPen, new Point(e.X, e.Y)));

            }
        }
        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flagLeftMauseClick = false;
            }
        }
    }

    class ToolPolyLine : Tool
    {
        public ToolPolyLine(Button button, ref List<Figure> figureArrayFrom, Pen pen, Panel paintBox_set)
        {
            paintBox = paintBox_set;
            ToolPen = pen;
            figureArray = figureArrayFrom;
            toolButton = button;
            toolButton.Click += new EventHandler(tool_buttonClick);
        }
        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (flagLeftMauseClick)
            {
                figureArray.Last().Add_Point(new Point(e.X, e.Y));
                paintBox.Invalidate();
            }
        }
        public override void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flagLeftMauseClick = true;
                figureArray.Add(new PolyLine(ToolPen, new Point(e.X, e.Y)));
                figureArray.Last().Add_Point(new Point(e.X, e.Y));

            }
        }
        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flagLeftMauseClick = false;
            }
        }

    }

    class ToolLine : Tool
    {
        public ToolLine(Button button, ref List<Figure> figureArrayFrom, Pen pen, Panel paintBox_set)
        {
            paintBox = paintBox_set;
            ToolPen = pen;
            figureArray = figureArrayFrom;
            toolButton = button;
            toolButton.Click += new EventHandler(tool_buttonClick);
        }
        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (flagLeftMauseClick)
            {
                figureArray.Last().Add_Point(new Point(e.X, e.Y));
                paintBox.Invalidate();
            }
        }
        public override void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flagLeftMauseClick = true;
                figureArray.Add(new Line(ToolPen, new Point(e.X, e.Y)));
                figureArray.Last().Add_Point(new Point(e.X, e.Y));

            }
        }
        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flagLeftMauseClick = false;
            }
        }
    }

    class ToolEllipse : Tool
    {
        public ToolEllipse(Button button, ref List<Figure> figureArrayFrom, Pen pen, Panel paintBox_set)
        {
            paintBox = paintBox_set;
            ToolPen = pen;
            figureArray = figureArrayFrom;
            toolButton = button;
            toolButton.Click += new EventHandler(tool_buttonClick);
        }
        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (flagLeftMauseClick)
            {
                figureArray.Last().Add_Point(new Point(e.X, e.Y));
                paintBox.Invalidate();
            }
        }
        public override void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flagLeftMauseClick = true;
                figureArray.Add(new Ellipse(ToolPen, new Point(e.X, e.Y)));
                figureArray.Last().Add_Point(new Point(e.X, e.Y));

            }
        }
        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flagLeftMauseClick = false;
            }
        }
    }
}