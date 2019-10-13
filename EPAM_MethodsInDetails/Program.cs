using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_MethodsInDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            //вызов задачи 1):
            double num = -0.0;
            var convertee = num.ToByteString();
            Console.WriteLine($"Assignment result #1 = {convertee}");

            //вызов задачи 2):
            long s1 = GCDSearch.SearchByEuclid(100, 975);
            Console.WriteLine($"Assignment result #2 = {s1}");
            long s2 = GCDSearch.SearchByEuclid(18, -12, 24);
            Console.WriteLine($"Assignment result #2 = {s2}");
            long s3 = GCDSearch.SearchByEuclid(1000, 975, 250, -1250, 250, -625);
            Console.WriteLine($"Assignment result #2 = {s3}");
            long s4 = GCDSearch.SearchByEuclid(1000, 975, 250, -1250, 250, -625);
            Console.WriteLine($"Assignment result #2 = {s4}");

            //вызов задачи 3):
            int? a = null;
            bool isNull1 = a.getNullReference();
            Console.WriteLine($"Assignment result #3 = {isNull1}");

            string name = "Lady";
            bool isNull2 = name.getNullReference();
            Console.WriteLine($"Assignment result #3 = {isNull2}");
        }
    }

    //Расширить функциональную возможность типа System.Double, реализовав возможность
    //получения строкового представления вещественного числа в формате IEEE 754

    public static class DoubleExtensions
    {
        private const int BYTELENGTH = 8;
        private const int DOUBLEBYTELENGTH = BYTELENGTH * 8;

        public static string ToByteString(this double number)
        {
            StringBuilder byteString = new StringBuilder();
            StringBuilder temple = new StringBuilder();
            Converter converter = new Converter();
            converter.DoubleView = number;
            long pointer = converter.LongView;

            for (int i = 0; i < DOUBLEBYTELENGTH; i++, pointer >>= 1)
            {
                if ((pointer & 1) == 1)
                {
                    byteString.Insert(0, "1");
                }
                else
                {
                    byteString.Insert(0, "0");
                }
            }

            return byteString.ToString();
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 64)]
        struct Converter
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            private long longView;
            [System.Runtime.InteropServices.FieldOffset(0)]
            private double doubleView;

            public long LongView
            {
                get => this.longView;
            }

            public double DoubleView
            {
                set => this.doubleView = value;
            }
        }
    }

    //Реализовать для null-able типов, дополнительную возможность определения - является ссылка null или нет

    public static class NullExtensions
    {
        public static bool getNullReference(this Object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
