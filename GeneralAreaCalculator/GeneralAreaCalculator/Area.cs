using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralAreaCalculator
{
    /// <summary>
    /// the main <c>Area</c>
    /// Calculate Area
    /// <list type="bullet">
    /// <item>
    /// <term>Area</term>
    /// <description>接收传递的参数，进行正方形和圆形的面积计算</description>
    ///</item>
    ///<item>
    ///<term>Area</term>
    ///<description>接收传递的参数，进行长方形和三角形的面积</description>
    /// </item>
    /// </list>
    /// </summary>
    public class Area
    {
        /// <summary>
        /// 厘米为单位的面积
        /// </summary>
        public double cmArea { get; set; }
        /// <summary>
        /// 英尺为单位的面积
        /// </summary>
        public double inArea { get; set; }

        /// <summary>
        /// 接收正方形和圆形的数据，分别是<paramref name="cmLeft"/>和<paramref name="inLeft"/>，另外，还有识别计算图形的编号<paramref name="Gragh"/>
        /// </summary>
        /// <param name="cmLeft">单位为厘米时的数据</param>
        /// <param name="inLeft">单位为英尺时的数据</param>
        /// <param name="Gragh">识别正方形(<paramref name="Gragh"/>=0)和圆形(<paramref name="Gragh"/>=1)的编号</param>
        public Area(double cmLeft, double inLeft, int Gragh)
        {
            if (Gragh == 0)
            {
                cmArea = cmLeft * cmLeft;
                inArea = inLeft * inLeft;
            }
            else if (Gragh == 1)
            {
                cmArea = cmLeft * cmLeft * 3.1415926 / 4;
                inArea = inLeft * inLeft * 3.1415926 / 4;
            }
        }

        /// <summary>
        /// 接收长方形和三角形的两组数据（厘米英尺），分别是厘米的<paramref name="cmLeft"/>和<paramref name="cmRight"/>与英尺的<paramref name="inLeft"/>和<paramref name="inRight"/>，还有识别计算图形的编号<paramref name="Gragh"/>
        /// </summary>
        /// <param name="cmLeft">单位为厘米时左边的数据</param>
        /// <param name="inLeft">单位为厘米时左边的数据</param>
        /// <param name="cmRight">单位为厘米时左边的数据</param>
        /// <param name="inRight">单位为厘米时左边的数据</param>
        /// <param name="Gragh">识别长方形（<paramref name="Gragh"/>=2）和三角形（<paramref name="Gragh"/>=3）的参数</param>
        public Area(double cmLeft, double inLeft, double cmRight, double inRight, int Gragh)
        {
            if (Gragh == 2)
            {
                cmArea = cmLeft * cmRight;
                inArea = inLeft * inRight;
            }
            else if (Gragh == 3)
            {
                cmArea = cmLeft * cmRight * 0.5;
                inArea = inLeft * inRight * 0.5;
            }
        }
    }
}
