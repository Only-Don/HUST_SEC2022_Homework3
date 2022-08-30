using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Record
{
    /// <summary>
    /// 记录历史操作
    /// </summary>
    public class HistoryRecord
    {
        /// <summary>
        /// 记录临时历史记录
        /// </summary>
        public List<string> records { get; } = new List<string>();

        /// <summary>
        /// 将输出加入临时历史记录中
        /// </summary>
        /// <param name="output"></param>
        public void GetRecord(string output)
        {
                records.Add($"{output}");
        }

        /// <summary>
        /// 将临时历史记录存入文件，并删除临时历史记录
        /// </summary>
        public void SaveRecord()
        {
            FileStream recordFile = new FileStream("records.txt",FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(recordFile);

            foreach (var record in records)
            {
                streamWriter.WriteLine(record);
            }
            streamWriter.Close();

            records.Clear();
        }

        /// <summary>
        /// 将文件中历史记录存入临时历史记录，在文本框中显示，并删除文件中历史记录
        /// </summary>
        /// <param name="recordTextBox">显示历史记录的文本框</param>
        public void ShowRecord(TextBox recordTextBox)
        {
            FileStream recordFile = new FileStream("records.txt", FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(recordFile);
            while (streamReader.Peek() >= 0)
            {
                records.Add(streamReader.ReadLine());
            }
            streamReader.Close();
            File.Delete("records.txt");
            recordTextBox.Text = string.Join("\r\n", records);
        }

        /// <summary>
        /// 清除临时，文件中的历史记录与文本框中文字
        /// </summary>
        /// <param name="recordTextBox">显示历史记录的文本框</param>
        public void ClearRecord(TextBox recordTextBox)
        {
            records.Clear();
            File.Delete("records.txt");
            recordTextBox.Text = "";
        }
    }
}

