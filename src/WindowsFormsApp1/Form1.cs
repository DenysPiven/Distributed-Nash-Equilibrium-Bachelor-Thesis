using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Fields
        Random rnd = new Random();
        static int a = 0, b = 10, t = 0, h = 1;
        static double y = 0;
        static int N = 10;
        List<double> xs_started = new List<double>() { };

        private void init()
        {
            xs_started.Clear();
            for (int i = 0; i < N; i++)
            {
                xs_started.Add(0.75 + 0.25 * rnd.NextDouble());
            }
        }

        private double average(List<double> xs)
        {
            y = 0;
            xs.ForEach(x => y += x);
            y /= N;
            return y;
        }

        private void button_Click(object sender, EventArgs e)
        {
            var xs = new List<double>();
            for (int i = 0; i < N; i++)
            {
                xs.Add(xs_started[i]);
            }
            var Series = this.chart.Series[0].Points;
            Series.Clear();
            for (int t = 0; t < b; t++)
            {
                y = average(xs);
                Series.AddXY(t, y);
                Alghoritm1(xs);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xs = new List<double>();
            for (int i = 0; i < N; i++)
            {
                xs.Add(xs_started[i]);
            }
            var vs = new List<double>();
            for (int i = 0; i < N; i++)
            {
                vs.Add(xs_started[i]);
            }
            for (int i = 0; i < N; i++)
            {
                W.Add(new List<double>());
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                        W[i].Add(1 - delta * d);
                    }
                    else
                    {
                        W[i].Add(delta);
                    }
                }
            }
            var Series = this.chart.Series[1].Points;
            Series.Clear();
            for (int t = 0; t < b; t++)
            {
                y = average(xs);
                Series.AddXY(t, y);
                Alghoritm2(xs, vs);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var xs = new List<double>();
            for (int i = 0; i < N; i++)
            {
                xs.Add(xs_started[i]);
            }
            var Series = this.chart.Series[2].Points;
            Series.Clear();
            for (int t = 0; t < b; t++)
            {
                y = average(xs);
                Series.AddXY(t, y);
                Alghoritm3(xs);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            init();
        }

        double sigma = 0;

        private void Alghoritm1(List<double> xs)
        {
            for (int i = 0; i < xs.Count; i++)
            {
                xs[i] = 1 / 2 * 1.5 * Math.Pow((xs[i] - (0.25 + 0.5 * rnd.NextDouble())), 2)
                    + (sigma + 0.5) * xs[i];
            }
            sigma = 0.6 * (-sigma + average(xs));
        }

        static double d = N - 1, delta = 0.5 / d;
        static List<List<double>> W = new List<List<double>>();

        private void Alghoritm2(List<double> xs, List<double> vs)
        {
            var xs_ = new List<double>();
            for (int i = 0; i < N; i++)
            {
                xs_.Add(xs[i]);
            }
            var xs_prev = new List<double>();
            for (int i = 0; i < N; i++)
            {
                xs_prev.Add(xs[i]);
            }
            var vs_ = new List<double>();
            for (int i = 0; i < N; i++)
            {
                vs_.Add(xs[i]);
            }
            for (int i = 0; i < N; i++)
            {
                vs_[i] = 0;
                for (int j = 0; j < N; j++)
                {
                    vs_[i] += W[i][j] * vs[j];
                }
                double prod = 0;
                for (int j = 0; j < N; j++)
                {
                    prod *= xs_[j] - 0.1 * (xs[i] + vs_[i]) / 2;
                }
                xs_[i] = prod;
                xs[i] = 3 * (xs[i] + 0.9 * (xs_[i] - xs[i]));
                vs[i] = vs_[i] + xs[i] - xs_prev[i];
            }
        }

        private void Alghoritm3(List<double> xs)
        {
            var xs_ = new List<double>();
            for (int i = 0; i < N; i++)
            {
                xs_.Add(xs[i]);
            }
            var xs_prev = new List<double>();
            for (int i = 0; i < N; i++)
            {
                xs_prev.Add(xs[i]);
            }
            for (int i = 0; i < N; i++)
            {
                double prod = 0;
                for (int j = 0; j < N; j++)
                {
                    prod *= xs_[j] - 0.1 * (xs[i]) / 2;
                }
                xs_[i] = prod;
                xs[i] = (xs[i] + 0.9 * (xs_[i] - xs[i]));
            }
        }
    }
}
