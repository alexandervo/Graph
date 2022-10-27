using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon;

namespace Graph
{
    public class MyGraph
    {
        public void SaveGraph(List<Point> pt, List<Form1.Segment> segment, bool directed, string path)
        {
            string graph = "";
            for(int i = 0; i < pt.Count; ++i)
                graph += pt[i].X.ToString() + " " + pt[i].Y.ToString() + "\n";
            for (int i = 0; i < segment.Count; ++i)
                graph += segment[i].S.ToString() + " " + segment[i].E.ToString() + " " + segment[i].W + "\n";
            if (directed) graph += "Direct";
            else graph += "UnDirect";
            File.WriteAllText(path, graph);
        }

        public void ReadGraph(List<Point> pt, List<Form1.Segment> segment, ListView lv, Color color, KryptonRibbonGroupRadioButton rbtn1, KryptonRibbonGroupRadioButton rbtn2, KryptonRibbonGroupComboBox cbs, KryptonRibbonGroupComboBox cbe, out int i, string path)
        {
            pt.Clear();
            lv.Clear();
            lv.Columns.Add("", 35);
            segment.Clear();
            cbs.Items.Clear();
            cbs.SelectedIndex = -1;
            cbs.SelectedItem = null;
            cbs.SelectedText = "";
            cbs.SelectedValue = null;
            cbs.Text = "";
            cbe.Items.Clear();
            cbe.SelectedIndex = -1;
            cbe.SelectedItem = null;
            cbe.SelectedText = "";
            cbe.SelectedValue = null;
            cbe.Text = "";
            cbe.Items.Add("All");
            i = 1;

            using (StreamReader fs = new StreamReader(path))
            {
                while(true)
                {
                    string tmp = fs.ReadLine();
                    if (tmp == "Direct") { rbtn1.Checked = true; break; }
                    if (tmp == "UnDirect") { rbtn2.Checked = true; break; }
                    string[] _tmp = tmp.Split(' ');
                    if (_tmp.Length == 2)
                    {
                        int x = int.Parse(_tmp[0]);
                        int y = int.Parse(_tmp[1]);
                        pt.Add(new Point(x, y));
                        MatrixCreate(lv, i, color);
                        cbs.Items.Add(i);
                        cbe.Items.Add(i);
                        ++i;
                    }
                    else
                    {
                        int a = int.Parse(_tmp[0]);
                        int b = int.Parse(_tmp[1]);
                        segment.Add(new Form1.Segment(a, b, _tmp[2]));
                        MatrixAdd(lv, a, b, rbtn2.Checked, _tmp[2]);
                    }

                }
            }
        }

        public void MatrixCreate(ListView lv, int num, Color color)
        {
            lv.Clear();
            lv.Columns.Add("", 35);
            lv.GridLines = true;
            for (int i = 1; i <= num; i++)
                lv.Columns.Add(i.ToString(), 35);

            for (int i = 1; i <= num; i++)
            {
                ListViewItem item = new ListViewItem();
                lv.Items.Add(item);
            }

            int k = 1;
            foreach (ListViewItem it in lv.Items)
            {
                it.SubItems.Clear();
                it.Text = k.ToString();
                if (k % 2 != 0) it.BackColor = color;
                for (int i = 0; i <= num; ++i)
                    it.SubItems.Add("0");
                ++k;
            }
        }

        public void MatrixAdd(ListView lv, int i, int j, bool undirect, string value)
        {
            lv.Items[i].SubItems[j + 1].Text = value;
            if (undirect) lv.Items[j].SubItems[i + 1].Text = value;
        }
             

        public void SaveMatrix(ListView lv, int n)
        {
            string matrix = n.ToString() + "\n";
            foreach (ListViewItem i in lv.Items)
            {
                for(int j = 1; j < i.SubItems.Count - 1; ++j)
                    matrix += i.SubItems[j].Text + " ";
                matrix += "\n";
            }
            Clipboard.SetText(matrix);
        }

        public void TableView(ListView lv, Color color)
        {
            lv.GridLines = true;            
            int i = 1;
            foreach (ListViewItem item in lv.Items)
            {
                if (i % 2 != 0) item.BackColor = color;
                ++i;
            }
        }
    }
}
