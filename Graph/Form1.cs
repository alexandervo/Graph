using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using ComponentFactory.Krypton.Ribbon;
using ComponentFactory.Krypton.Toolkit;
using System.Linq;
using System.Text.RegularExpressions;

namespace Graph
{
    public partial class Form1 : KryptonForm
    {
        #region Variables

        const int oo = Int32.MaxValue;
        const int EMPTY = 0;
        const int OBST = 1;
        const int ROBOT = 2;
        const int TARGET = 3;
        const int RUNNING = 4;
        const int CLOSED = 5;
        const int PATH = 6;
        int[] dx = { 0, 1, 0, -1, -1, -1, 1, 1 };
        int[] dy = { -1, 0, 1, 0, -1, 1, 1, -1 };
        int rows = 21;
        int columns = 21;
        int squareSize = 25;

        List<Cell> openSet = new List<Cell>();
        List<Cell> closedSet = new List<Cell>();

        Cell Start;
        Cell Target;

        int[,] grid;
        Point[,] par;
        Point[,] centers;
        bool realTime = false;
        bool found = false;
        bool searching = false;
        bool endOfSearch = false;
        bool animation = false;
        int delay;

        bool mouse_down = false;
        int cur_row, cur_col, cur_val;

        MyGraphic myGraphic = new MyGraphic();
        MyGraph myGraph = new MyGraph();
        Dijkstra dijkstra = new Dijkstra();
        FordBellman fordbellman = new FordBellman();

        private int i_th = 1;
        private int grid_gap = 30;
        private int radius = 12;
        private bool isPoint = false;
        private bool isDrawing = false;
        private bool dijkstra_step = true;
        private bool isPaths = true;
        private bool isColor = false;
        private bool isCut = false;
        private bool weightNeg = false;

        Point p = new Point(0, 0);
        List<Point> Pt = new List<Point>();
        List<PointColor> PtColor = new List<PointColor>();
        List<Segment> segment = new List<Segment>();
        List<Segment> segment_dijkstra = new List<Segment>();
        List<int> segment_dijkstra_save = new List<int>();
        List<int> segment_dijkstra_save_tmp = new List<int>();
        List<List<Segment>> segment_dijkstra_Review_tmp = new List<List<Segment>>();
        List<List<Segment>> segment_dijkstra_Review = new List<List<Segment>>();

        ListView lv = new ListView();


        public class Cell
        {
            public int row;
            public int col;
            public double d;
            public int level;
            public Cell prev;

            public Cell(int x, int y, int d = oo, int l = 0)
            {
                this.row = x;
                this.col = y;
                this.d = d;
                this.level = l;
            }
        }

        public class Segment
        {
            public int S { get; set; }
            public int E { get; set; }
            public string W { get; set; }

            public Segment(int s, int e, string w)
            {
                this.S = s;
                this.E = e;
                this.W = w;
            }
        }

        private class PointColor
        {
            public int _index { get; set; }
            public Color _color { get; set; }

            public PointColor(int _index, Color _color)
            {
                this._index = _index;
                this._color = _color;
            }
        }
        #endregion

        public Form1()
        {

            InitializeComponent();
            NewGrid();
            panelControl.Visible = true;
            MakeBackgroundGrid();
            rbtnUnDirected.Checked = true;
            SPADijkstra.Checked = true;
            dfs.Checked = true;
            rbDijkstra.Checked = true;
            this.Enabled = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private Cell findRowCol(int cur_Y, int cur_X)
        {
            int row = 0, col = 0;
            row = (cur_Y - 160) / squareSize;
            col = (cur_X - 250) / squareSize;
            return new Cell(row, col);
        }

        private Point getPoint(Cell X)
        {
            Point Y = new Point();
            Y.X = X.row;
            Y.Y = X.col;
            return Y;
        }

        private Point[] CalcSquare(int r, int c)
        {
            Point[] polygon = {
                new Point((int)(251 +     c*squareSize + 0), (int)(161 +     r*squareSize + 0)),
                new Point((int)(251 + (c+1)*squareSize - 1), (int)(161 +     r*squareSize + 0)),
                new Point((int)(251 + (c+1)*squareSize - 1), (int)(161 + (r+1)*squareSize - 1)),
                new Point((int)(251 +     c*squareSize + 0), (int)(161 + (r+1)*squareSize - 1))
            };
            return polygon;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Brush brush;
            brush = new SolidBrush(Color.DarkGray);

            g.FillRectangle(brush, new Rectangle(250, 160, columns * squareSize + 1, rows * squareSize + 1));

            brush.Dispose();

            grid[Start.row, Start.col] = ROBOT;
            grid[Target.row, Target.col] = TARGET;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                {
                    if (grid[r, c] == EMPTY)
                        brush = new SolidBrush(Color.White);
                    else if (grid[r, c] == ROBOT)
                        brush = new SolidBrush(Color.Red);
                    else if (grid[r, c] == TARGET)
                        brush = new SolidBrush(Color.Green);
                    else if (grid[r, c] == OBST)
                        brush = new SolidBrush(Color.Black);
                    else if (grid[r, c] == RUNNING)
                        brush = new SolidBrush(Color.BlueViolet);
                    else if (grid[r, c] == CLOSED)
                        brush = new SolidBrush(Color.Cyan);
                    else if (grid[r, c] == PATH)
                        brush = new SolidBrush(Color.Yellow);

                    g.FillPolygon(brush, CalcSquare(r, c));

                    brush.Dispose();
                }
            if (arrow.Checked)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        if (par[i, j].X == -1 || par[i, j].Y == -1) continue;
                        Pen P = new Pen(Color.Black, 2);
                        P.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                        P.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 8, true);
                        Point startPoint = centers[i, j];
                        Point endPoint = new Point(centers[par[i, j].X, par[i, j].Y].X, centers[par[i, j].X, par[i, j].Y].Y);
                        g.DrawLine(P, startPoint, endPoint);
                        brush.Dispose();
                    }
            }

        }

        private void FillGrid()
        {
            if (searching || endOfSearch || realTime)
            {
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < columns; c++)
                    {
                        if (grid[r, c] == RUNNING || grid[r, c] == CLOSED || grid[r, c] == PATH)
                            grid[r, c] = EMPTY;
                        if (grid[r, c] == ROBOT)
                            Start = new Cell(r, c);
                        if (grid[r, c] == TARGET)
                            Target = new Cell(r, c);
                    }
            }
            else
            {
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < columns; c++)
                        grid[r, c] = EMPTY;
                Start = new Cell(rows - 2, 1);
                Target = new Cell(1, columns - 2);
            }

            found = false;
            searching = realTime;
            endOfSearch = false;

            if (!realTime)
            {
                grid[Target.row, Target.col] = TARGET;
                grid[Start.row, Start.col] = ROBOT;
            }

            openSet.Clear();

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                {
                    par[r, c] = new Point(-1, -1);
                    if (grid[r, c] != OBST)
                    {
                        if (r == Start.row && c == Start.col)
                            openSet.Add(new Cell(r, c, 0, 0));
                        else openSet.Add(new Cell(r, c, oo, oo));
                    }
                }

            closedSet.Clear();


            Invalidate();
        }

        private void NewGrid()
        {
            panelControl.Visible = false;
            realTime = false;
            found = false;
            searching = false;
            endOfSearch = false;
            animation = false;

            grid = new int[rows, columns];
            centers = new Point[rows, columns];
            par = new Point[rows, columns];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                {
                    centers[r, c] = new Point(250 + c * squareSize + squareSize / 2, 160 + r * squareSize + squareSize / 2);
                    par[r, c] = new Point(-1, -1);
                }


            FillGrid();

            Invalidate();
        }

        private void CreateMaze()
        {
            panelControl.Visible = false;
            realTime = false;
            found = false;
            searching = false;
            endOfSearch = false;
            animation = false;

            grid = new int[rows, columns];
            centers = new Point[rows, columns];
            par = new Point[rows, columns];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                {
                    centers[r, c] = new Point(250 + c * squareSize + squareSize / 2, 160 + r * squareSize + squareSize / 2);
                    par[r, c] = new Point(-1, -1);
                }

            FillGrid();

            var maze = new Maze(rows / 2, columns / 2);
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                    if (Regex.IsMatch(maze.maze_str.Substring(r * columns + c, 1), "[+-|]"))
                        grid[r, c] = OBST;

            Invalidate();
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;

            Cell cur_cell = findRowCol(e.Y, e.X);

            int row = cur_cell.row;
            int col = cur_cell.col;


            if (row >= 0 && row < rows && col >= 0 && col < columns)
            {
                if (realTime ? true : !found && !searching)
                {
                    if (realTime)
                        FillGrid();
                    cur_row = row;
                    cur_col = col;
                    cur_val = grid[row, col];
                    if (cur_val == EMPTY) grid[row, col] = OBST;
                    if (cur_val == OBST) grid[row, col] = EMPTY;
                }
            }

            if (realTime) RealTime_Action();

            Invalidate();

        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouse_down)
                return;

            Cell cur_cell = findRowCol(e.Y, e.X);
            int row = cur_cell.row;
            int col = cur_cell.col;

            if (row == cur_row && col == cur_col) return;

            if (row >= 0 && row < rows && col >= 0 && col < columns)
            {
                if (realTime ? true : !found && !searching)
                {
                    if (realTime)
                        FillGrid();

                    if (cur_val == ROBOT || cur_val == TARGET)
                    {
                        int new_val = grid[row, col];
                        if (new_val == EMPTY)
                        {
                            grid[row, col] = cur_val;
                            grid[cur_row, cur_col] = EMPTY;
                            cur_row = row;
                            cur_col = col;
                            if (cur_val == ROBOT)
                            {
                                for (int i = 0; i < openSet.Count; i++)
                                {
                                    if (openSet[i].row == Start.row && openSet[i].col == Start.col) openSet[i].d = oo;
                                    if (openSet[i].row == row && openSet[i].col == col) openSet[i].d = 0;
                                }

                                Start.col = col;
                                Start.row = row;
                            }
                            if (cur_val == TARGET)
                            {

                                Target.col = col;
                                Target.row = row;
                            }
                        }
                    }
                    else if (grid[row, col] != ROBOT && grid[row, col] != TARGET)
                        grid[row, col] = OBST;
                }


                if (realTime)
                    RealTime_Action();

                Invalidate();

            }
        }


        private void EnableRadiosAndChecks()
        {
            slider.Enabled = true;
            dfs.Enabled = true;
            bfs.Enabled = true;
            rbDijkstra.Enabled = true;
            diagonal.Enabled = true;
            arrow.Enabled = true;

        }

        private void DisableRadiosAndChecks()
        {
            slider.Enabled = false;
            dfs.Enabled = false;
            bfs.Enabled = false;
            rbDijkstra.Enabled = false;
            diagonal.Enabled = false;
            arrow.Enabled = false;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            clearBtn.Checked = false;
            Mazebtn.Checked = false;
            realtimeBtn.Checked = false;
            stepBtn.Checked = false;
            animationBtn.Checked = false;

            animation = false;
            realTime = false;
            realtimeBtn.Enabled = true;
            animationBtn.Enabled = true;
            stepBtn.Enabled = true;
            EnableRadiosAndChecks();
            NewGrid();
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearBtn.Checked = true;
            Mazebtn.Checked = false;
            realtimeBtn.Checked = false;
            stepBtn.Checked = false;
            animationBtn.Checked = false;

            animation = false;
            realTime = false;
            realtimeBtn.Enabled = true;
            stepBtn.Enabled = true;
            animationBtn.Enabled = true;
            EnableRadiosAndChecks();

            FillGrid();

            Invalidate();
        }


        private void MazeButton_Click(object sender, EventArgs e)
        {
            clearBtn.Checked = false;
            Mazebtn.Checked = true;
            realtimeBtn.Checked = false;
            stepBtn.Checked = false;
            animationBtn.Checked = false;

            animation = false;
            realTime = false;
            panelControl.Visible = false;
            realTime = false;
            found = false;
            searching = false;
            endOfSearch = false;
            EnableRadiosAndChecks();
            CreateMaze();
        }

        private void RealTime_Action()
        {
            do
                SearchAndCheck();
            while (!endOfSearch);
        }

        private void realtimeBtn_Click(object sender, EventArgs e)
        {
            clearBtn.Checked = false;
            Mazebtn.Checked = false;
            realtimeBtn.Checked = true;
            stepBtn.Checked = false;
            animationBtn.Checked = false;

            if (realTime) return;

            realTime = true;
            searching = true;
            DisableRadiosAndChecks();
            stepBtn.Enabled = false;
            animationBtn.Enabled = false;
            timer.Stop();

            RealTime_Action();
        }

        private void stepBtn_Click(object sender, EventArgs e)
        {
            clearBtn.Checked = false;
            Mazebtn.Checked = false;
            realtimeBtn.Checked = false;
            stepBtn.Checked = true;
            animationBtn.Checked = false;

            animation = false;
            timer.Stop();
            if (found || endOfSearch) return;
            searching = true;

            DisableRadiosAndChecks();
            slider.Enabled = true;

            SearchAndCheck();
            Invalidate();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Animation_action();
        }

        private void Animation_action()
        {
            if (animation)
            {
                SearchAndCheck();
                Invalidate();
                if (endOfSearch)
                {
                    animation = false;
                    timer.Stop();
                }
            }
        }


        private void animationBtn_Click(object sender, EventArgs e)
        {
            clearBtn.Checked = false;
            Mazebtn.Checked = false;
            realtimeBtn.Checked = false;
            stepBtn.Checked = false;
            animationBtn.Checked = true;

            animation = true;
            searching = true;
            DisableRadiosAndChecks();
            slider.Enabled = true;


            delay = slider.Value;
            timer.Stop();
            timer.Interval = delay;
            timer.Start();

            Animation_action();
        }

        private void SearchAndCheck()
        {
            if (openSet.Count == 0 || endOfSearch)
            {
                Invalidate();
            }
            else
            {
                ExpandNode();
                if (found)
                {
                    endOfSearch = true;
                    Path();
                    Invalidate();
                }
            }
        }

        private void ExpandNode()
        {
            if (rbDijkstra.Checked) dijkstraAlgorithm();
            if (bfs.Checked) bfsAlgorithm();
            if (dfs.Checked) dfsAlgorithm();
        }


        private bool checkCell(Cell a)
        {
            if (a.row >= 0 && a.row < rows && a.col >= 0 && a.col < columns && grid[a.row, a.col] != OBST) return true;
            return false;
        }

        private double calDist(Cell a, Cell b)
        {
            double x = centers[a.row, a.col].X - centers[b.row, b.col].X;
            double y = centers[a.row, a.col].Y - centers[b.row, b.col].Y;
            if (diagonal.Checked) return Math.Sqrt(x * x + y * y);
            else return Math.Abs(x) + Math.Abs(y);
        }

        private bool checkInOP(Cell a)
        {
            foreach (Cell i in openSet)
            {
                if (a.col == i.col && a.row == i.row) return true;
            }
            return false;
        }

        private bool checkInCL(Cell a)
        {
            foreach (Cell i in closedSet)
            {
                if (a.col == i.col && a.row == i.row) return true;
            }
            return false;
        }

        private void dijkstraAlgorithm()
        {
            if (openSet.Count == 0)
            {
                endOfSearch = true;
                return;
            }

            openSet.Sort((x, y) =>
            {
                int result = x.d.CompareTo(y.d);
                if (result == 0)
                    result = x.level.CompareTo(y.level);
                return result;
            });

            Cell u = openSet[0];
            openSet.RemoveAt(0);

            if (u.d == oo)
            {
                endOfSearch = true;
                return;
            }

            grid[u.row, u.col] = CLOSED;

            closedSet.Add(u);

            if (u.row == Target.row && u.col == Target.col)
            {
                found = true;
                endOfSearch = true;
                grid[u.row, u.col] = TARGET;
                return;
            }

            int count = diagonal.Checked == true ? 8 : 4;

            for (int i = 0; i < count; i++)

                for (int k = 0; k < openSet.Count; k++)
                {
                    if (!((u.row + dx[i]) == openSet[k].row && (u.col + dy[i]) == openSet[k].col) || !checkCell(openSet[k])) continue;

                    double tmp = u.d + calDist(u, openSet[k]);
                    if (tmp < openSet[k].d)
                    {
                        openSet[k].d = tmp;
                        openSet[k].prev = u;
                        par[openSet[k].row, openSet[k].col] = new Point(u.row, u.col);
                        grid[openSet[k].row, openSet[k].col] = RUNNING;
                    }
                }
        }

        private void bfsAlgorithm()
        {
            if (closedSet.Count == 0)
            {
                openSet.Clear();
                openSet.Add(new Cell(Start.row, Start.col));
            }

            if (openSet.Count == 0)
            {
                endOfSearch = true;
                return;
            }

            Cell u = openSet[0];
            openSet.RemoveAt(0);

            grid[u.row, u.col] = CLOSED;

            closedSet.Add(u);

            if (u.row == Target.row && u.col == Target.col)
            {
                found = true;
                endOfSearch = true;
                grid[u.row, u.col] = TARGET;
                return;
            }

            int count = diagonal.Checked == true ? 8 : 4;

            for (int i = 0; i < count; i++)
            {
                Cell cur = new Cell(u.row + dx[i], u.col + dy[i]);
                if (checkInOP(cur) || checkInCL(cur) || !checkCell(cur)) continue;
                else
                {
                    openSet.Add(cur);
                    par[cur.row, cur.col] = new Point(u.row, u.col);
                    grid[cur.row, cur.col] = RUNNING;
                }
            }
        }

        private void dfsAlgorithm()
        {
            if (closedSet.Count == 0)
            {
                openSet.Clear();
                openSet.Add(new Cell(Start.row, Start.col));
            }

            while (openSet.Count > 0 && checkInCL(openSet[0])) openSet.RemoveAt(0);

            if (openSet.Count == 0)
            {
                endOfSearch = true;
                return;
            }

            Cell u = openSet[0];
            openSet.RemoveAt(0);

            grid[u.row, u.col] = CLOSED;

            closedSet.Add(u);

            if (u.row == Target.row && u.col == Target.col)
            {
                found = true;
                endOfSearch = true;
                grid[u.row, u.col] = TARGET;
                return;
            }

            int count = diagonal.Checked == true ? 8 : 4;

            for (int i = 0; i < count; i++)
            {
                Cell cur = new Cell(u.row + dx[i], u.col + dy[i]);
                if (checkInCL(cur) || !checkCell(cur)) continue;
                else
                {
                    openSet.Insert(0, cur);
                    par[cur.row, cur.col] = new Point(u.row, u.col);
                    grid[cur.row, cur.col] = RUNNING;
                }
            }
        }

        private void Path()
        {
            if (!found) return;
            Point Cur = new Point(Target.row, Target.col);
            while (Cur.X != -1 && Cur.Y != -1)
            {
                grid[Cur.X, Cur.Y] = PATH;
                Cur = par[Cur.X, Cur.Y];
            }
            grid[Target.row, Target.col] = TARGET;

        }

        #region Menustrip
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void about_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void guide_Click(object sender, EventArgs e)
        {
            Guide f = new Guide();
            f.ShowDialog();
        }


        #endregion

        #region GridLine
        private void MakeBackgroundGrid()
        {
            if (GridLine.Checked)
            {
                Bitmap bm = new Bitmap(picGraphView.ClientSize.Width, picGraphView.ClientSize.Height);
                var g = Graphics.FromImage(bm);
                Pen pen = new Pen(ChangeColorBrightness(Color.LightGray, 0.5F), 1);

                for (int i = grid_gap; i < picGraphView.ClientSize.Width; i += grid_gap)
                {
                    g.DrawLine(pen, i, 0, i, picGraphView.ClientSize.Height);
                }

                for (int j = grid_gap; j < picGraphView.ClientSize.Height; j += grid_gap)
                {
                    g.DrawLine(pen, 0, j, picGraphView.ClientSize.Width, j);
                }

                picGraphView.BackgroundImage = bm;
            }
            else picGraphView.BackgroundImage = null;
        }

        private void GridLine_CheckedChanged(object sender, EventArgs e)
        {
            MakeBackgroundGrid();
        }

        private void picGraphView_Resize(object sender, EventArgs e)
        {
            MakeBackgroundGrid();
        }
        #endregion

        #region Graph
        private int FindDistanceToPointSquared(Point a, Point b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return dx * dx + dy * dy;
        }

        private bool MouseIsOverEndPoint(Point mouse_pt, out int segment_number, out Point hit_pt)
        {
            int over_squared = radius * radius;
            for (int i = 0; i < Pt.Count; ++i)
            {
                if (FindDistanceToPointSquared(mouse_pt, Pt[i]) <= over_squared)
                {
                    segment_number = i;
                    hit_pt = Pt[i];
                    return true;
                }
            }

            segment_number = -1;
            hit_pt = new Point(0, 0);
            return false;
        }

        private bool MouseIsNearEdge(Point mouse_pt, out int segment_number1, out int segment_number2)
        {
            int over_dis = 2;
            for (int i = 0; i < segment.Count; ++i)
            {
                int x = FindDistanceToPointSquared(mouse_pt, Pt[segment[i].S]);
                int y = FindDistanceToPointSquared(mouse_pt, Pt[segment[i].E]);
                int z = FindDistanceToPointSquared(Pt[segment[i].S], Pt[segment[i].E]);
                if (x + y <= z + over_dis)
                {
                    segment_number1 = segment[i].S;
                    segment_number2 = segment[i].E;
                    return true;
                }
            }
            segment_number1 = -1;
            segment_number2 = -1;
            return false;
        }

        private void picGraphView_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isPoint)
            {
                Cursor my_cursor = Cursors.Default;
                Point hit_point;
                int segment_num;
                if (MouseIsOverEndPoint(e.Location, out segment_num, out hit_point)) my_cursor = Cursors.Hand;
                if (picGraphView.Cursor != my_cursor) picGraphView.Cursor = my_cursor;
            }
        }

        private void picGraphView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isPoint)
                {
                    Pt.Add(e.Location);
                    myGraph.MatrixCreate(lvMatrixView, i_th, ChangeColorBrightness(Color.LightGreen, 0.6F));
                    cbStartPoint.Items.Add(i_th.ToString());
                    cbEndPoint.Items.Add(i_th.ToString());
                    txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Point " + i_th.ToString() + " (" + e.X.ToString() + ", " + e.Y.ToString() + ")" + " add!\n";
                    ++i_th;
                }
                else
                {
                    Point hit_pt;
                    int segment_number;
                    int segment_number1, segment_number2;
                    if (isCut && MouseIsNearEdge(e.Location, out segment_number1, out segment_number2))
                    {
                        for (int i = 0; i < segment.Count; i++)
                        {
                            bool flag = false;
                            if (segment_number1 == segment[i].S && segment_number2 == segment[i].E) flag = true;
                            if (rbtnUnDirected.Checked && segment_number1 == segment[i].E && segment_number2 == segment[i].S) flag = true;
                            if (!flag) continue;
                            else
                            {
                                if (rbtnDirected.Checked)
                                    myGraph.MatrixAdd(lvMatrixView, segment_number1, segment_number2, true, "0");
                                else
                                {
                                    myGraph.MatrixAdd(lvMatrixView, segment_number1, segment_number2, true, "0");
                                    myGraph.MatrixAdd(lvMatrixView, segment_number2, segment_number1, true, "0");
                                }
                                txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Erase path from Point " + (segment_number1 + 1).ToString() + " to Point " + (segment_number2 + 1).ToString() + "!\n";
                                List<Segment> tmp = new List<Segment>();
                                for (int j = 0; j < segment.Count; j++)
                                {
                                    if (j == i) continue;
                                    tmp.Add(segment[j]);
                                }
                                segment = tmp;
                            }
                        }
                    }
                    else if (MouseIsOverEndPoint(e.Location, out segment_number, out hit_pt))
                    {
                        if (isDrawing)
                        {
                            picGraphView.MouseMove -= picGraphView_MouseMove;
                            picGraphView.MouseMove += picGraphView_MouseMove_Drawing;
                            picGraphView.MouseUp += picGraphView_MouseUp_Drawing;
                        }
                        else if (isColor)
                        {
                            PtColor.Add(new PointColor(segment_number, MyColorDialog.Color));
                            txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Color Point " + (segment_number + 1).ToString() + " changed!\n";
                        }
                        else
                        {
                            picGraphView.MouseMove -= picGraphView_MouseMove;
                            picGraphView.MouseMove += picGraphView_MouseMove_Point;
                            picGraphView.MouseUp += picGraphView_MouseUp_Point;
                        }

                        moving_segment = segment_number;
                    }
                }
            }

            picGraphView.Invalidate();
        }

        #region MovingPoint
        private int moving_segment = -1;

        private void picGraphView_MouseMove_Point(object sender, MouseEventArgs e)
        {
            Pt[moving_segment] = e.Location;
            picGraphView.Invalidate();
        }

        private void picGraphView_MouseUp_Point(object sender, MouseEventArgs e)
        {
            txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Point " + (moving_segment + 1).ToString() + " new location (" + Pt[moving_segment].X.ToString() + ", " + Pt[moving_segment].Y.ToString() + ") updated!\n";
            picGraphView.MouseMove -= picGraphView_MouseMove_Point;
            picGraphView.MouseMove += picGraphView_MouseMove;
            picGraphView.MouseUp -= picGraphView_MouseUp_Point;
            picGraphView.Invalidate();
        }
        #endregion

        #region DrawingMove
        private void picGraphView_MouseMove_Drawing(object sender, MouseEventArgs e)
        {
            int over_squared = radius * radius;
            p = e.Location;

            Point hit_pt = new Point();
            hit_pt = Pt[moving_segment];
            int segment_num;
            if (FindDistanceToPointSquared(e.Location, hit_pt) > over_squared && MouseIsOverEndPoint(e.Location, out segment_num, out hit_pt))
            {
            start:
                string value = "";
                if (InputGraph.InputBox("Input", "Enter Input", ref value) == DialogResult.OK)
                {
                    if (int.TryParse(value, out int tmp))
                    {
                        if (tmp < 0) weightNeg = true;
                        int temp;
                        if (!checkindexSimpleDirect(moving_segment, segment_num, out temp)) segment[temp].W = value;
                        else segment.Add(new Segment(moving_segment, segment_num, value));
                        txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Point " + (moving_segment + 1).ToString() + " to Point " + (segment_num + 1).ToString() + " is " + value + "\n";
                    }
                    else
                    {
                        MessageBox.Show("Input isn't correct", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto start;
                    }
                }
                picGraphView_MouseUp_Drawing(sender, e);
            }
            picGraphView.Invalidate();
        }

        private void picGraphView_MouseUp_Drawing(object sender, MouseEventArgs e)
        {
            picGraphView.MouseMove += picGraphView_MouseMove;
            picGraphView.MouseMove -= picGraphView_MouseMove_Drawing;
            picGraphView.MouseUp -= picGraphView_MouseUp_Drawing;
            p = new Point(0, 0);
            picGraphView.Invalidate();
        }
        #endregion

        private bool checkindexSimpleDirect(int s, int e, out int tmp)
        {
            if (segment.Count == 0) { tmp = -1; return true; }
            int temp = segment.Count;
            for (int i = 0; i < segment.Count / 2 + 1; ++i)
            {
                if (segment[i].S == s && segment[i].E == e) { tmp = i; return false; }

                if (segment[temp - i - 1].S == s && segment[temp - i - 1].E == e) { tmp = temp - i - 1; return false; }
            }
            tmp = -1;
            return true;
        }

        private void picGraphView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (p.X != 0) myGraphic.DrawLineNoInputGraph(e.Graphics, Pt[moving_segment], p, Brushes.DarkGray, 3, rbtnDirected.Checked);

            for (int i = 0; i < segment.Count; ++i)
            {
                int temp;
                if (rbtnDirected.Checked && !checkindexSimpleDirect(segment[i].E, segment[i].S, out temp) && !checkindexSimpleDirect(segment[i].S, segment[i].E, out temp)) myGraphic.DrawCurve(e.Graphics, Pt[segment[i].S], Pt[segment[i].E], segment[i].W, this.Font, Brushes.Black, 3, rbtnDirected.Checked);
                else myGraphic.DrawLine(e.Graphics, Pt[segment[i].S], Pt[segment[i].E], segment[i].W, this.Font, Brushes.Black, 3, rbtnDirected.Checked);
                myGraph.MatrixAdd(lvMatrixView, segment[i].S, segment[i].E, rbtnUnDirected.Checked, segment[i].W);
            }

            for (int i = 0; i < Pt.Count; ++i)
                myGraphic.DrawPoint(e.Graphics, Pt[i], (i + 1).ToString(), 4, Brushes.LightYellow, this.Font);

            if (PtColor.Count != 0)
            {
                foreach (PointColor i in PtColor)
                    myGraphic.DrawPoint(e.Graphics, Pt[i._index], (i._index + 1).ToString(), 5, new SolidBrush(i._color), this.Font);
            }

            if (segment_dijkstra_Review.Count != 0)
            {
                int temp;
                foreach (List<Segment> i in segment_dijkstra_Review)
                    foreach (Segment j in i)
                        if (!checkindexSimpleDirect(j.E, j.S, out temp) && !checkindexSimpleDirect(j.S, j.E, out temp)) myGraphic.DrawCurve(e.Graphics, Pt[j.S], Pt[j.E], j.W, this.Font, Brushes.Blue, 4, rbtnDirected.Checked);
                        else myGraphic.DrawLine(e.Graphics, Pt[j.S], Pt[j.E], j.W, this.Font, Brushes.Blue, 4, rbtnDirected.Checked);
            }

            if (segment_dijkstra_save.Count != 0)
            {
                foreach (int i in segment_dijkstra_save)
                    myGraphic.DrawPoint(e.Graphics, Pt[i], (i + 1).ToString(), 5, Brushes.Yellow, this.Font);
            }

            if (segment_dijkstra_save_tmp.Count == 0)
            {
                if (segment_dijkstra.Count != 0)
                {
                    int temp;
                    foreach (Segment i in segment_dijkstra)
                        if (!checkindexSimpleDirect(i.E, i.S, out temp) && !checkindexSimpleDirect(i.S, i.E, out temp)) myGraphic.DrawCurve(e.Graphics, Pt[i.S], Pt[i.E], i.W, this.Font, Brushes.Red, 4, rbtnDirected.Checked);
                        else myGraphic.DrawLine(e.Graphics, Pt[i.S], Pt[i.E], i.W, this.Font, Brushes.Red, 4, rbtnDirected.Checked);

                    foreach (Segment i in segment_dijkstra)
                    {
                        myGraphic.DrawPoint(e.Graphics, Pt[i.S], (i.S + 1).ToString(), 5, Brushes.Yellow, this.Font);
                        myGraphic.DrawPoint(e.Graphics, Pt[i.E], (i.E + 1).ToString(), 5, Brushes.Yellow, this.Font);
                    }
                }
            }

        }
        #endregion

        #region TurnOnOffEditGraph
        private void btnDrawPoint_Click(object sender, EventArgs e)
        {
            RibbonBtnNew.Checked = false;
            RibbonAddVertex.Checked = true;
            RibbonAddEdge.Checked = false;
            RibbonBtnMove.Checked = false;
            BtnErase.Checked = false;
            RibbonBtnColor.Checked = false;
            btnRefresh.Checked = false;

            if (!isPoint) { isPoint = true; }
            else { isPoint = false; }
            isDrawing = false;
            isColor = false;
            isCut = false;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            RibbonBtnNew.Checked = false;
            RibbonAddVertex.Checked = false;
            RibbonAddEdge.Checked = false;
            RibbonBtnMove.Checked = true;
            BtnErase.Checked = false;
            RibbonBtnColor.Checked = false;
            btnRefresh.Checked = false;

            isPoint = false;
            isDrawing = false;
            isColor = false;
            isCut = false;
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            RibbonBtnNew.Checked = false;
            RibbonAddVertex.Checked = false;
            RibbonAddEdge.Checked = true;
            RibbonBtnMove.Checked = false;
            BtnErase.Checked = false;
            RibbonBtnColor.Checked = false;
            btnRefresh.Checked = false;

            if (!isDrawing) { isDrawing = true; }
            else { isDrawing = false; }
            isPoint = false;
            isColor = false;
            isCut = false;
        }

        private void btnCutLine_Click(object sender, EventArgs e)
        {
            RibbonBtnNew.Checked = false;
            RibbonAddVertex.Checked = false;
            RibbonAddEdge.Checked = false;
            RibbonBtnMove.Checked = false;
            BtnErase.Checked = true;
            RibbonBtnColor.Checked = false;
            btnRefresh.Checked = false;

            if (!isCut) isCut = true; else isCut = false;
            isPoint = false;
            isColor = false;
            isDrawing = false;
            picGraphView.Invalidate();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            RibbonBtnNew.Checked = false;
            RibbonAddVertex.Checked = false;
            RibbonAddEdge.Checked = false;
            RibbonBtnMove.Checked = false;
            BtnErase.Checked = false;
            RibbonBtnColor.Checked = true;
            btnRefresh.Checked = false;

            if (!isColor) { isColor = true; }
            else { isColor = false; }
            isPoint = false;
            isDrawing = false;
            isCut = false;
            if (MyColorDialog.ShowDialog() != DialogResult.OK) { isColor = false; }
            else { isColor = true; }
        }
        #endregion

        private void RestNew()
        {
            this.Cursor = Cursors.WaitCursor;
            panelControl.Visible = true;
            isPoint = false;
            isDrawing = false;
            isPaths = true;
            isColor = false;
            isCut = false;
            p = new Point(0, 0);
            dijkstra_step = true;
            Pt.Clear();
            PtColor.Clear();
            segment.Clear();
            segment_dijkstra.Clear();
            segment_dijkstra_Review.Clear();
            segment_dijkstra_Review_tmp.Clear();
            segment_dijkstra_save.Clear();
            segment_dijkstra_save_tmp.Clear();
            PtColor.Clear();
            picGraphView.Invalidate();
            txbLogs.Clear();
            txbLogDijkstra.Clear();
            lvMatrixView.GridLines = false;
            lvMatrixView.Clear();
            lvMatrixView.Columns.Add("", 35);
            lvTableView.GridLines = false;
            lvTableView.Clear();
            cbStartPoint.Items.Clear();
            cbStartPoint.SelectedIndex = -1;
            cbStartPoint.SelectedItem = null;
            cbStartPoint.SelectedValue = null;
            cbStartPoint.SelectedText = "";
            cbStartPoint.Text = "";
            cbEndPoint.Items.Clear();
            cbEndPoint.SelectedIndex = -1;
            cbEndPoint.SelectedItem = null;
            cbEndPoint.SelectedValue = null;
            cbEndPoint.SelectedText = "";
            cbEndPoint.Text = "";
            cbEndPoint.Items.Add("All");
            i_th = 1;

            this.Cursor = Cursors.Default;
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestNew();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            RibbonBtnNew.Checked = true;
            RibbonAddVertex.Checked = false;
            RibbonAddEdge.Checked = false;
            RibbonBtnMove.Checked = false;
            BtnErase.Checked = false;
            RibbonBtnColor.Checked = false;
            btnRefresh.Checked = false;

            RestNew();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RestNew();
        }

        private void TabDemo_Click(object sender, EventArgs e)
        {
            panelControl.Visible = false;
        }

        #region OpenSave
        private void Save()
        {
            if (MySaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                myGraph.SaveGraph(Pt, segment, rbtnDirected.Checked, MySaveFileDialog.FileName);
                txbLogDijkstra.Clear();
                txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Graph save!\n";
            }
        }

        private void btnSaveGraph_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Open()
        {
            picGraphView.Invalidate();
            if (MyOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                myGraph.ReadGraph(Pt, segment, lvMatrixView, ChangeColorBrightness(Color.LightGreen, 0.6F), rbtnDirected, rbtnUnDirected, cbStartPoint, cbEndPoint, out i_th, MyOpenFileDialog.FileName);
                txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Graph open!\n";
                lvTableView.Clear();
                segment_dijkstra.Clear();
            }
            picGraphView.Invalidate();
        }

        private void btnOpenGraph_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Updates()
        {
            segment_dijkstra.Clear();
            segment_dijkstra_Review.Clear();
            segment_dijkstra_Review_tmp.Clear();
            segment_dijkstra_save.Clear();
            segment_dijkstra_save_tmp.Clear();
            picGraphView.Invalidate();
            lvTableView.GridLines = false;
            lvTableView.Clear();
            PtColor.Clear();
            myGraph.MatrixCreate(lvMatrixView, i_th - 1, ChangeColorBrightness(Color.LightGreen, 0.6F));
            txbLogDijkstra.Clear();
            txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Graph updated!\n";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RibbonBtnNew.Checked = false;
            RibbonAddVertex.Checked = false;
            RibbonAddEdge.Checked = false;
            RibbonBtnMove.Checked = false;
            BtnErase.Checked = false;
            RibbonBtnColor.Checked = false;
            btnRefresh.Checked = true;

            Updates();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updates();
        }

        Bitmap SaveImage()
        {
            Bitmap bm = new Bitmap(picGraphView.Width, picGraphView.Height);
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(bm.Width, bm.Height));
            picGraphView.DrawToBitmap(bm, rect);
            return bm;
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                SaveImage().Save(SaveFileDialogImage.FileName, System.Drawing.Imaging.ImageFormat.Png);
                txbLogs.Text += "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] Graph save image!\n";
            }
        }

        private void copyGraphImageInClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(SaveImage());
        }

        private void copyMatrixToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMatrixView.Items.Count == 0) MessageBox.Show("Nothing to Copy!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else myGraph.SaveMatrix(lvMatrixView, i_th - 1);
        }
        #endregion

        #region DijkstraSolve

        private void btnRunAll_Click(object sender, EventArgs e)
        {
            SPAPath.Checked = true;
            SPAStep.Checked = false;
            if (cbStartPoint.SelectedIndex != -1 && cbEndPoint.SelectedIndex != -1)
            {
                if (weightNeg && SPADijkstra.Checked)
                {
                    MessageBox.Show("Error!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    try
                    {
                        if (cbEndPoint.SelectedIndex == 0) dijkstra.DijkstraAll(lvMatrixView, lvTableView, i_th, cbStartPoint.SelectedIndex, out isPaths, txbLogDijkstra, Pt, segment, segment_dijkstra, rbtnUnDirected.Checked);
                        else dijkstra.DijkstraSimple(lvMatrixView, lvTableView, i_th, cbStartPoint.SelectedIndex, cbEndPoint.SelectedIndex - 1, out isPaths, txbLogDijkstra, Pt, segment, segment_dijkstra, segment_dijkstra_save_tmp, segment_dijkstra_Review_tmp, rbtnUnDirected.Checked);
                        myGraph.TableView(lvTableView, ChangeColorBrightness(Color.LightSkyBlue, 0.7F));

                        if (isPaths)
                        {
                            segment_dijkstra_Review_tmp.Clear();
                            segment_dijkstra_save_tmp.Clear();
                            segment_dijkstra_Review.Clear();
                            segment_dijkstra_save.Clear();
                            picGraphView.Invalidate();
                        }
                        else MessageBox.Show("Error!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (SPAFordBellman.Checked)
                        {
                            fordbellman.FordAll(lvMatrixView, lvTableView, i_th, cbStartPoint.SelectedIndex, out isPaths, txbLogDijkstra, Pt, segment, segment_dijkstra, rbtnUnDirected.Checked);
                            myGraph.TableView(lvTableView, ChangeColorBrightness(Color.LightSkyBlue, 0.7F));
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else MessageBox.Show("Start point or End point isn't choose!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DijkstraStep()
        {
            picGraphView.Invalidate();
            if (dijkstra_step)
            {
                segment_dijkstra.Clear();
                lvTableView.Clear();
                segment_dijkstra_Review.Clear();
                segment_dijkstra_save.Clear();
                dijkstra.DijkstraSimple(lvMatrixView, lv, i_th, cbStartPoint.SelectedIndex, cbEndPoint.SelectedIndex - 1, out isPaths, txbLogDijkstra, Pt, segment, segment_dijkstra, segment_dijkstra_save_tmp, segment_dijkstra_Review_tmp, rbtnUnDirected.Checked);
                for (int i = 1; i < i_th; ++i) lvTableView.Columns.Add(i.ToString(), 80);
            }

            if (lv.Items.Count != 0)
            {
                ListViewItem item = lv.Items[0];
                lv.Items.RemoveAt(0);
                lvTableView.Items.Add(item);
            }

            if (isPaths)
            {
                if (!dijkstra_step)
                {
                    if (segment_dijkstra_Review_tmp.Count != 0)
                    {
                        segment_dijkstra_Review.Clear();
                        segment_dijkstra_Review.Add(segment_dijkstra_Review_tmp[0]);
                        segment_dijkstra_Review_tmp.RemoveAt(0);
                    }
                }

                dijkstra_step = false;

                if (segment_dijkstra_save_tmp.Count != 0)
                {
                    segment_dijkstra_save.Add(segment_dijkstra_save_tmp[0]);
                    segment_dijkstra_save_tmp.RemoveAt(0);
                    picGraphView.Invalidate();
                }

                if (segment_dijkstra_save_tmp.Count == 0)
                {
                    segment_dijkstra_save.Clear();
                    segment_dijkstra_Review.Clear();
                    picGraphView.Invalidate();
                    MessageBox.Show("Done!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dijkstra_step = true;
                }
            }
            else
            {
                MessageBox.Show("Error!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                segment_dijkstra_save.Clear();
                segment_dijkstra_Review.Clear();
                picGraphView.Invalidate();
                dijkstra_step = true;
            }

            myGraph.TableView(lvTableView, ChangeColorBrightness(Color.LightSkyBlue, 0.7F));
        }

        private void btnRunStep_Click(object sender, EventArgs e)
        {
            SPAPath.Checked = false;
            SPAStep.Checked = true;
            if (weightNeg && SPADijkstra.Checked)
            {
                MessageBox.Show("Error!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SPAFordBellman.Checked)
            {
                MessageBox.Show("Run step aren't available for Ford-Bellman Algorithms", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbStartPoint.SelectedIndex != -1 && cbEndPoint.SelectedIndex != -1)
            {
                try
                {
                    if (cbEndPoint.SelectedIndex == 0) MessageBox.Show("Run step aren't available for Point to All", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (isPaths) DijkstraStep();
                    else MessageBox.Show("Error!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Start point or End point isn't choose!", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

    }



    /// <summary>
    /// The following code creates a random, perfect (without cycles) maze
    /// 
    /// From http://rosettacode.org/wiki/Maze_generation
    /// </summary>
    public static class Extensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            var e = source.ToArray();
            for (var i = e.Length - 1; i >= 0; i--)
            {
                var swapIndex = rng.Next(i + 1);
                yield return e[swapIndex];
                e[swapIndex] = e[i];
            }
        }

        public static CellState OppositeWall(this CellState orig)
        {
            return (CellState)(((int)orig >> 2) | ((int)orig << 2)) & CellState.Initial;
        }

        public static bool HasFlag(this CellState cs, CellState flag)
        {
            return ((int)cs & (int)flag) != 0;
        }
    }

    [Flags]
    public enum CellState
    {
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8,
        Visited = 128,
        Initial = Top | Right | Bottom | Left,
    }

    public struct RemoveWallAction
    {
        public Point Neighbour;
        public CellState Wall;
    }

    public class Maze
    {
        private readonly CellState[,] _cells;
        private readonly int _width;
        private readonly int _height;
        private readonly Random _rng;
        public String maze_str = "";

        public Maze(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new CellState[width, height];
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    _cells[x, y] = CellState.Initial;
            _rng = new Random();
            VisitCell(_rng.Next(width), _rng.Next(height));
            make_string();
        }

        public CellState this[int x, int y]
        {
            get { return _cells[x, y]; }
            set { _cells[x, y] = value; }
        }

        public IEnumerable<RemoveWallAction> GetNeighbours(Point p)
        {
            if (p.X > 0) yield return new RemoveWallAction { Neighbour = new Point(p.X - 1, p.Y), Wall = CellState.Left };
            if (p.Y > 0) yield return new RemoveWallAction { Neighbour = new Point(p.X, p.Y - 1), Wall = CellState.Top };
            if (p.X < _width - 1) yield return new RemoveWallAction { Neighbour = new Point(p.X + 1, p.Y), Wall = CellState.Right };
            if (p.Y < _height - 1) yield return new RemoveWallAction { Neighbour = new Point(p.X, p.Y + 1), Wall = CellState.Bottom };
        }

        public void VisitCell(int x, int y)
        {
            this[x, y] |= CellState.Visited;
            foreach (var p in GetNeighbours(new Point(x, y)).Shuffle(_rng).Where(z => !(this[z.Neighbour.X, z.Neighbour.Y].HasFlag(CellState.Visited))))
            {
                this[x, y] -= p.Wall;
                this[p.Neighbour.X, p.Neighbour.Y] -= p.Wall.OppositeWall();
                VisitCell(p.Neighbour.X, p.Neighbour.Y);
            }
        }

        public void make_string()
        {
            var firstLine = string.Empty;
            for (var y = 0; y < _height; y++)
            {
                var sbTop = new StringBuilder();
                var sbMid = new StringBuilder();
                for (var x = 0; x < _width; x++)
                {
                    sbTop.Append(this[x, y].HasFlag(CellState.Top) ? "+-" : "+ ");
                    sbMid.Append(this[x, y].HasFlag(CellState.Left) ? "| " : "  ");
                }
                if (firstLine == string.Empty)
                    firstLine = sbTop.ToString();
                maze_str = maze_str + sbTop + "+";
                maze_str = maze_str + sbMid + "|";
            }
            maze_str = maze_str + firstLine + "+";
        }
    }
}
