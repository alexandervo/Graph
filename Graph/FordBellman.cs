using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graph
{
    public class FordBellman
    {
        readonly MyGraphic myGraphic = new MyGraphic();

        public void FordAll(ListView lv, ListView lvtable, int n, int s, out bool isPath, RichTextBox txb, List<Point> pt, List<Form1.Segment> segment, List<Form1.Segment> tmp, bool undirected)
        {
            tmp.Clear();
            txb.Clear();
            lvtable.Clear();

            lvtable.Columns.Add("k", 80);
            for (int i = 1; i < n; ++i) lvtable.Columns.Add(i.ToString(), 80);

            ListViewItem it = new ListViewItem("0");
            for (int i = 1; i < n; ++i) it.SubItems.Add("(oo, -)");

            it.SubItems[s+1].Text = "(0, " + (s + 1).ToString() + ")";

            lvtable.Items.Add(it);

            int oo = 99999999;
            List<int> length = new List<int>();
            List<int> last = new List<int>();
            isPath = true;

            for (int i = 0; i < n; ++i)
            {
                length.Add(oo);
                last.Add(-1);
            }

            length[s] = 0;
            last[s] = s;
            
            for (int t = 1; t < n; t++)
            {
                ListViewItem item = new ListViewItem(t.ToString());
                for (int iv = 1; iv < n; ++iv) item.SubItems.Add(lv.Items[t-1].SubItems[iv].Text);

                List<int> length_next = new List<int>(length);
                List<int> last_next = new List<int>(last);

                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        int w = int.Parse(checkIndexWidth(segment, j, i, undirected));
                        if (w == oo) continue;
                        if (length[j] + w < length_next[i])
                        {
                            length_next[i] = length[j] + w;
                            last_next[i] = j;
                        }
                    }
                }

                item = new ListViewItem(t.ToString());
                for (int i = 1; i < n; ++i) item.SubItems.Add("(oo, -)");
                for (int i = 0; i < n - 1; ++i)
                {
                    if (length_next[i] == oo) item.SubItems[i + 1].Text = "(oo,";
                    else item.SubItems[i + 1].Text = "(" + length_next[i].ToString() + ", ";
                    if (last_next[i] != -1) item.SubItems[i + 1].Text += (last_next[i] + 1).ToString() + ")";
                    else item.SubItems[i + 1].Text += "-)";
                }

                lvtable.Items.Add(item);
                bool flag = true;
                for (int i = 1; i < n; ++i)
                {
                    if (lvtable.Items[t-1].SubItems[i].Text != lvtable.Items[t].SubItems[i].Text)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag) break;

                length = length_next;
                last = last_next;

                if (t == n - 1) { txb.Text = "No Path!"; isPath = false; break; }
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
            if (undirected)
            {
                foreach (Form1.Segment i in segment)
                    if ((i.S == s && i.E == e) || (i.E == s && i.S == e)) return i.W;
            }
            else
            {
                foreach (Form1.Segment i in segment)
                    if (i.S == s && i.E == e) return i.W;
            }
            return "99999999";
        }
    }
}
