using Record;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralAreaCalculator
{
    /// <summary>
    /// 用于控制计算器的窗体，继承了<paramref name="Form"></paramref>
    /// </summary>
    public partial class Form1 : Form
    {
        HistoryRecord record = new HistoryRecord();
        /// <summary>
        /// 本构造函数对窗体进行实例化，并且显示窗体
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Graphic();
            SqaureLable.Visible = true;
        }

        /// <summary>
        /// 本构造函数用于创建图形选框的选项，并且给出<paramref name="正方形"></paramref>作为默认值
        /// </summary>
        public void Graphic()
        {
            comboBox1.Items.Add("正方形");
            comboBox1.Items.Add("圆形");
            comboBox1.Items.Add("长方形");
            comboBox1.Items.Add("三角形");
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("正方形");
        }
        /// <summary>
        /// 本构造函数用于根据选框选择图形的类别，显示相应图形的数据输入框和输入提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            clearAll();
            switch(index)
            {
                case 0:
                    SqaureLable.Visible = true;
                    break;
                case 1:
                    CircleLable.Visible = true;
                    break;
                case 2:
                    RectangleLengthLable.Visible = true;
                    RectangleWidthLable.Visible = true;
                    textBox2.Visible = true;
                    break;
                case 3:
                    TriangleBaseLable.Visible = true;
                    TriangleHeightLable.Visible = true;
                    textBox2.Visible = true;
                    break;

            }
            if(textBox2.Visible)
            {
                radioButton3.Visible = true;
                radioButton4.Visible = true;
            }
        }
        /// <summary>
        /// 这个函数用于切换图形类别时，清除之前所显示的输入框和输入提示
        /// </summary>
        public void clearAll()
        {
            textBox2.Visible = false;
            SqaureLable.Visible = false;
            RectangleLengthLable.Visible = false;
            RectangleWidthLable.Visible = false;
            CircleLable.Visible = false;
            TriangleBaseLable.Visible = false;
            TriangleHeightLable.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }
        /// <summary>
        /// 本构造函数用于清除左侧的厘米/英寸选择框的背景颜色，以便更好的融入窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
        /// <summary>
        /// 本构造函数用于清除右侧的厘米/英寸选择框的背景颜色，以便更好的融入窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
        /// <summary>
        /// 本构造函数用于在点击计算按钮的时候根据图形类别和数据输出计算结果，如结果出错则进行提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int graph = comboBox1.SelectedIndex;
            if(graph <= 1)
            {
                try
                {
                    Unit unit = new Unit(double.Parse(textBox1.Text), radioButton1.Checked);
                    Area area = new Area(unit.centimeterLeft.centimeter, unit.inchLeft.inch, graph);
                    string data = (graph == 0) ? $"{DateTime.Now}\r\n您选择的是{comboBox1.SelectedItem}\r\n输入的边长为{unit.centimeterLeft.centimeter:0.000}厘米\r\n该图形的面积为{area.cmArea:0.000}平方厘米\r\n" :
                        $"{DateTime.Now}\r\n您选择的是{comboBox1.SelectedItem}\r\n输入的直径为{unit.centimeterLeft.centimeter:0.000}厘米\r\n该图形的面积为{area.cmArea:0.000}平方厘米\r\n";
                    textBox3.Text += data + "\r\n";
                    record.GetRecord(data);
                }
                catch
                {
                    MessageBox.Show("请输入数字而不是其他类型数据！");
                }
            }
            else
            {
                try
                {
                    Unit unit = new Unit(double.Parse(textBox1.Text), double.Parse(textBox2.Text), radioButton1.Checked, radioButton3.Checked);
                    Area area = new Area(unit.centimeterLeft.centimeter, unit.inchLeft.inch, unit.centimeterRight.centimeter, unit.inchRight.inch, graph);
                    string data = (graph == 2) ? $"{DateTime.Now}\r\n您选择的是{comboBox1.SelectedItem}\r\n输入的长为{unit.centimeterLeft.centimeter:0.000}厘米，宽为{unit.centimeterRight.centimeter:0.000}厘米\r\n该图形的面积为{area.cmArea:0.000}平方厘米\r\n" :
                         $"{DateTime.Now}\r\n您选择的是{comboBox1.SelectedItem}\r\n输入的底为{unit.centimeterLeft.centimeter:0.000}厘米，高为{unit.centimeterRight.centimeter:0.000}厘米\r\n该图形的面积为{area.cmArea:0.000}平方厘米\r\n";
                    textBox3.Text += data + "\r\n";
                    record.GetRecord(data);
                }
                catch
                {
                    MessageBox.Show("请输入数字而不是其他类型数据！");
                }
            }
        }
        /// <summary>
        /// 本构造函数用于在点击显示历史记录按钮的时候调用<paramref name="ShowRecord"/>方法，加载历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadHistory_Click(object sender, EventArgs e)
        {
            record.ShowRecord(this.textBox3);
        }
        /// <summary>
        /// 本构造函数用于在点击清除历史记录按钮的时候调用<paramref name="ClearRecord"/>方法，清除历史记录，并将两个输入框的当前数据清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            record.ClearRecord(this.textBox3);
            textBox1.Text = "";
            textBox2.Text = "";
        }
        /// <summary>
        /// 本构造函数用于在退出窗体的时候调用<paramref name="SaveRecord"/>方法，保存历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            record.SaveRecord();
        }

    }
}
