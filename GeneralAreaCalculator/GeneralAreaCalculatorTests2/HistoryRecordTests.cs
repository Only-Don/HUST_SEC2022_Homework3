using Microsoft.VisualStudio.TestTools.UnitTesting;
using Record;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Record.Tests
{
    [TestClass()]
    public class HistoryRecordTests
    {
        HistoryRecord hisRecord=new HistoryRecord();

        [TestMethod()]
        public void GetRecordTest()
        {
            string output = "TestOutput";
            hisRecord.GetRecord(output);
            CollectionAssert.Contains(hisRecord.records, output);
        }

        [TestMethod()]
        public void SaveRecordTest()
        {
            //临时记录是否已清空
            string output = "TestOutput";
            hisRecord.GetRecord(output);
            hisRecord.SaveRecord();
            Assert.AreEqual(0, hisRecord.records.Count);

            //历史记录是否已读入文件
            TextBox textBox = new TextBox();
            hisRecord.ShowRecord(textBox);
            CollectionAssert.AreEqual(new List<string>() { output }, hisRecord.records);
        }

        [TestMethod()]
        public void ShowRecordTest()
        {
            //确认文本框中显示正确记录
            string output = "TestOutput";
            hisRecord.GetRecord(output);
            TextBox textBox = new TextBox();
            hisRecord.ShowRecord(textBox);
            Assert.AreEqual(textBox.Text,output);

            //确认可以从文件获取历史记录
            hisRecord.SaveRecord();
            hisRecord.ShowRecord(textBox);
            Assert.AreEqual(textBox.Text, output);
        }

        [TestMethod()]
        public void ClearRecordTest()
        {
            //确认文本框中与临时历史记录中均无数据
            string output = "TestOutput";
            hisRecord.GetRecord(output);
            TextBox textBox = new TextBox();
            hisRecord.ShowRecord(textBox);
            hisRecord.ClearRecord(textBox);
            Assert.AreEqual(hisRecord.records.Count, 0);
            Assert.AreEqual(textBox.Text, "");

            //确认文件中无数据
            hisRecord.ShowRecord(textBox);
            Assert.AreEqual(textBox.Text, "");

        }
    }
}