using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graph
{
    public class Dijkstra
    {
        MyGraphic myGraphic = new MyGraphic();

        public void DijkstraSimple(ListView lv, ListView lvtable, int n, int s, int e, out bool isPath, RichTextBox txb, List<Point> pt, List<Form1.Segment> segment, List<Form1.Segment> tmp, List<int> _segment, List<List<Form1.Segment>> Segment_Review, bool undirected)
        {
            tmp.Clear();
            txb.Clear();
            lvtable.Clear();
            Segment_Review.Clear();
            _segment.Clear();

            ListViewItem it = new ListViewItem("(oo, -)");

            for (int i = 1; i < n; ++i) lvtable.Columns.Add(i.ToString(), 80);

            for (int i = 1; i < n; ++i) it.SubItems.Add("(oo, -)");

            it.SubItems[s].Text = "(0, " + (s + 1).ToString() + ")*";

            lvtable.Items.Add(it);

            int oo = 99999999;
            List<int> length = new List<int>();
            List<int> last = new List<int>();
            List<int> roads = new List<int>();
            List<bool> visited = new List<bool>();
            isPath = true;

            for (int i = 0; i < n; ++i)
            {
                length.Add(oo);
                last.Add(-1);
                visited.Add(true);
            }

            length[s] = 0;
            visited[s] = false;
            last[s] = s;
            int b = 1;           

            int v = s;
            while (visited[e])
            {
                _segment.Add(v);
                int dem = 0;

                ListViewItem item = new ListViewItem("(oo, -)");
                for (int iv = 1; iv < n; ++iv) item.SubItems.Add("(oo, -)");

                item.SubItems[v].Text = "-";

                List<Form1.Segment> segment_load = new List<Form1.Segment>();

                for (int i = 0; i < n - 1; ++i)
                {
                    int num = int.Parse(lv.Items[v].SubItems[i + 1].Text);
                    int temp = length[i];

                    if (lv.Items[v].SubItems[i + 1].Text == "0") ++dem;

                    if (!visited[i]) item.SubItems[i].Text = "-";
                    else if (length[i] == temp && b != 1) item.SubItems[i].Text = lvtable.Items[b - 1].SubItems[i].Text;

                    if (lv.Items[v].SubItems[i + 1].Text != "0" && visited[i] && (length[i] == oo || length[i] >= length[v] + num))
                    {
                        length[i] = length[v] + num;
                        last[i] = v;
                        item.SubItems[i].Text = "(" + length[i].ToString() + ", " + (last[i] + 1).ToString() + ")";
                    }
                }

                if (dem == n - 1) { txb.Text = "No Path!"; isPath = false; break; }

                int Mins = oo;

                for (int i = 0; i < n; ++i)
                {
                    if (visited[i] && length[i] != oo)
                    {
                        if (Mins > length[i])
                        {
                            v = i;
                            Mins = length[i];
                        }
                    }
                }

                Segment_Review.Add(segment_load);
                
                item.SubItems[v].Text += "*";
                lvtable.Items.Add(item);

                visited[v] = false;
                
                ++b;
            }

            if (isPath)
            {
                _segment.Add(e);

                int k = e;
                while (k != s)
                {
                    roads.Add(k);
                    k = last[k];
                }

                roads.Add(s);

                txb.Text += "Shortest Path [" + (s + 1).ToString() + "->" + (e + 1).ToString() + "] : ";
                for (int i = roads.Count - 1; i > 0; --i)
                {
                    tmp.Add(new Form1.Segment(roads[i], roads[i - 1], checkIndexWidth(segment, roads[i], roads[i - 1], undirected)));
                    txb.Text += (roads[i] + 1).ToString() + " --> ";
                }
                txb.Text += (roads[0] + 1).ToString() + "\n Cost: " + length[e].ToString();
            }
        }

        public void DijkstraAll(ListView lv, ListView lvtable, int n, int s, out bool isPath, RichTextBox txb, List<Point> pt, List<Form1.Segment> segment, List<Form1.Segment> tmp, bool undirected)
        {
            tmp.Clear();
            txb.Clear();
            lvtable.Clear();            

            ListViewItem it = new ListViewItem("(oo, -)");

            for (int i = 1; i < n; ++i) lvtable.Columns.Add(i.ToString(), 80);

            for (int i = 1; i < n; ++i) it.SubItems.Add("(oo, -)");

            it.SubItems[s].Text = "(0, " + (s + 1).ToString() + ")*";

            lvtable.Items.Add(it);

            int oo = 99999999;
            List<int> length = new List<int>();
            List<int> last = new List<int>();
            List<bool> visited = new List<bool>();
            isPath = true;

            for (int i = 0; i < n; ++i)
            {
                length.Add(oo);
                last.Add(-1);
                visited.Add(true);
            }

            length[s] = 0;
            visited[s] = false;
            last[s] = s;
            int b = 1;

            int v = s;
            int t = n - 1;
            
            while (t != 1)
            {
                int dem = 0;

                ListViewItem item = new ListViewItem("(oo, -)");
                for (int iv = 1; iv < n; ++iv) item.SubItems.Add("(oo, -)");

                item.SubItems[v].Text = "-";

                for (int i = 0; i < n - 1; ++i)
                {
                    int num = int.Parse(lv.Items[v].SubItems[i + 1].Text);
                    int temp = length[i];

                    if (lv.Items[v].SubItems[i + 1].Text == "0") ++dem;

                    if (!visited[i]) item.SubItems[i].Text = "-";
                    else if (length[i] == temp && b != 1) item.SubItems[i].Text = lvtable.Items[b - 1].SubItems[i].Text;

                    if (lv.Items[v].SubItems[i + 1].Text != "0" && visited[i] && (length[i] == oo || length[i] >= length[v] + num))
                    {
                        length[i] = length[v] + num;
                        last[i] = v;
                        item.SubItems[i].Text = "(" + length[i].ToString() + ", " + (last[i] + 1).ToString() + ")";
                    }                
                }

                if (dem == n - 1) { txb.Text = "No Path!"; isPath = false; break; }

                int Mins = oo;

                for (int i = 0; i < n; ++i)
                {
                    if (visited[i] && length[i] != oo)
                    {
                        if (Mins > length[i])
                        {
                            v = i;
                            Mins = length[i];
                        }
                    }
                }

                if(item.SubItems[v].Text != "-") item.SubItems[v].Text += "*";
                lvtable.Items.Add(item);

                visited[v] = false;

                ++b; --t;
            }
            if (isPath)
            {
                for (int i = 0; i < n - 1; ++i)
                {
                    if (i != s)
                    {
                        try
                        {
                            List<int> roads = new List<int>();
                            int k = i;
                            while (k != s)
                            {
                                roads.Add(k);
                                k = last[k];
                            }

                            roads.Add(s);

                            txb.Text += "Shortest Path [" + (s + 1).ToString() + "->" + (i + 1).ToString() + "] : ";
                            for (int j = roads.Count - 1; j > 0; --j)
                            {
                                tmp.Add(new Form1.Segment(roads[j], roads[j - 1], checkIndexWidth(segment, roads[j], roads[j - 1], undirected)));
                                txb.Text += (roads[j] + 1).ToString() + " --> ";
                            }
                            txb.Text += (roads[0] + 1).ToString() + "\n Cost: " + length[i].ToString() + "\n";
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                }
            }
        }
        
        public string checkIndexWidth(List<Form1.Segment> segment, int s, int e, bool undirected)
        {
            if(undirected)
            {
                foreach (Form1.Segment i in segment)
                    if ((i.S == s && i.E == e) || (i.E == s && i.S == e)) return i.W;
            }
            else
            {
                foreach (Form1.Segment i in segment)
                    if (i.S == s && i.E == e) return i.W;
            }
            
            return "0";
        }
    }
}
