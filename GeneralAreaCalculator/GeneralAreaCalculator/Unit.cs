using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralAreaCalculator
{
    /// <summary>
    /// <c>Unit</c>类用于转换cm和inch两种单位，每个<c>Unit</c>类的实例有四个属性，
    /// 分别是<c>Centimeter</c>类的两个实例和<c>Inch</c>类的两个实例，用于储存用户输入的数据，
    /// 并将其转换为厘米单位。
    /// </summary>
    public class Unit
    {
        public Centimeter centimeterLeft { get; set; }
        public Centimeter centimeterRight { get; set; }
        public Inch inchLeft { get; set; }
        public Inch inchRight { get; set; }

        /// <summary>
        /// 本构造函数用于对<c>Unit</c>类中的四个属性进行构造，用于构造长方形和三角形的<c>Unit</c>实例，
        /// 传入的<paramref name="dataLeft"/>和<paramref name="dataRight"/>参数为具体的用于转换的数据，
        /// 而传入的<paramref name="judgeLeft"/>和<paramref name="judgeRight"/>用于判断传入的数据是厘米还是英寸。
        /// </summary>
        /// <param name="dataLeft">左侧文本框输入的数据。</param>
        /// <param name="dataRight">右侧文本框输入的数据。</param>
        /// <param name="judgeLeft">判断左侧文本框输入的数据的类型，true为厘米，false为英寸。</param>
        /// <param name="judgeRight">判断右侧文本框输入的数据的类型，true为厘米，false为英寸。</param>
        /// <example>
        /// 当在GUI面板上用户选择的图形类型为长方形或三角形，
        /// 左侧文本框输入的数据为15厘米，右侧文本框输入的数据为20英寸，
        /// 则创造<c>Unit</c>类时的代码如下所示:
        /// <code>
        /// Unit unit = new Unit(15, 20, true, false);
        /// </code>
        /// </example>
        public Unit(double dataLeft, double dataRight, bool judgeLeft, bool judgeRight)
        {
            centimeterLeft = new Centimeter(dataLeft, judgeLeft);
            inchLeft = new Inch(dataLeft, judgeLeft);
            centimeterRight = new Centimeter(dataRight, judgeRight);
            inchRight = new Inch(dataRight, judgeRight);
        }
        /// <summary>
        /// 本构造函数是对具有四个参数的构造函数的重构，用于对正方形和圆形构造<c>Unit</c>实例，
        /// 传入的<paramref name="data"/>和<paramref name="judge"/>的功能与<c>Unit(double dataLeft, double dataRight, bool judgeLeft, bool judgeRight)</c>一致。
        /// </summary>
        /// <param name="data">文本框中输入的数据</param>
        /// <param name="judge"></param>
        public Unit(double data, bool judge)
        {
            centimeterLeft = new Centimeter(data, judge);
            inchLeft = new Inch(data, judge);
            centimeterRight = null;
            inchRight = null;
        }
    }
    /// <summary>
    /// <c>Centimeter</c>类用于存储一个具有以厘米为单位的数据centimeter的类，当构造Centimeter实例的时候，程序将自动判断并将输入的数据依单位转换为厘米格式。
    /// </summary>
    public class Centimeter
    {
        public double centimeter { get; set; }
        /// <summary>
        /// <c>Centimeter</c>构造方法通过<paramref name="judge"/>判断传入数据<paramref name="data"/>的单位，并将其转换为以厘米为单位的数据。
        /// </summary>
        /// <param name="data">传入的文本框数据。</param>
        /// <param name="judge">对传入的数据的单位进行判断，true为厘米，false为英寸。</param>
        /// <example>
        /// 当输入的数为12，单位为英寸时，代码如下所示：
        /// <code>
        /// Centimeter centimeter = new Centimeter(12, false);
        /// </code>
        /// 此时centimeter实例中的属性centimeter = 12 * 2.54。
        /// </example>
        public Centimeter(double data, bool judge)
        {
            if (judge)
                centimeter = data;
            else
                centimeter = data * 2.54;
        }
    }
    /// <summary>
    /// <c>Inch</c>类用于存储一个具有以英寸为单位的数据inch的类，当构造Inch实例的时候，程序将自动判断并将输入的数据依单位转换为英寸格式。
    /// </summary>
    public class Inch
    {
        public double inch { get; set; }
        /// <summary>
        /// <c>Inch</c>构造方法通过<paramref name="judge"/>判断传入数据<paramref name="data"/>的单位，并将其转换为以英寸为单位的数据。
        /// </summary>
        /// <param name="data">传入的文本框数据。</param>
        /// <param name="judge">对传入的数据的单位进行判断，true为厘米，false为英寸。</param>
        /// <example>
        /// 当输入的数为12，单位为英寸时，代码如下所示：
        /// <code>
        /// Inch inch = new Inch(12, false);
        /// </code>
        /// 此时inch实例中的属性inch = 12。
        /// </example>
        public Inch(double data, bool judge)
        {
            if (!judge)
                inch = data;
            else
                inch = data / 2.54;
        }
    }
}
