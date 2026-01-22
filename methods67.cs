using System;

namespace lab67
{

    //создаём класс отрезок,
    public class LineSegment
    {
        // Поля
        private double x;
        private double y;

        
        // Свойства
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // Конструктор
        public LineSegment()
        {
            x = 0;
            y = 1;
        }

        //конструктор с параметрами принимает коорд х у,создаёт объект
        public LineSegment(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        //ToString()
        public override string ToString()
        {
            return "[" + x + "; " + y + "]";
        }

        //попало ли в отрезок
        public bool Contains(double value)
        {
            double min = x < y ? x : y;
            double max = x > y ? x : y;

            return value >= min && value <= max;
        }
        
        //ПЕРЕГРУЗКИ операторов
        //тернарные операторы
        // ! — длина отрезка,если х больше у то x-y иначе y-x
        public static double operator !(LineSegment seg)
        {
            return seg.x > seg.y ? seg.x - seg.y : seg.y - seg.x;
        }

        //++обе координаты на 1
        public static LineSegment operator ++(LineSegment seg)
        {
            seg.x = seg.x + 1;
            seg.y = seg.y + 1;
            return seg;
        }

        //целая часть X
        public static explicit operator int(LineSegment seg)
        {
            return (int)seg.x;
        }

        //координата Y
        public static implicit operator double(LineSegment seg)
        {
            return seg.y;
        }

        //отрезок + d
        public static LineSegment operator +(LineSegment seg, int d)
        {
            return new LineSegment(seg.x + d, seg.y + d);
        }

        // d + отрезок
        public static LineSegment operator +(int d, LineSegment seg)
        {
            return new LineSegment(seg.x + d, seg.y + d);
        }

        //попадает ли число в отрезок
        public static bool operator <(LineSegment seg, int value)
        {
            return seg.Contains(value);
        }

        //не попало в отрезок
        public static bool operator >(LineSegment seg, int value)
        {
            return !seg.Contains(value);
        }
    }
}
