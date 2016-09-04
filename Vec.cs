using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deuterium
{
    class Vec
    {
        public double x, y, z, w;

        public Vec()
        {
            x = y = z = 0.0;
        }

        public Vec(double a)
        {
            x = a;
            y = 0;
            z = 0;
        }

        public Vec(double a, double b)
        {
            x = a;
            y = b;
            z = 0;
        }

        public Vec(double a, double b, double c)
        {
            x = a;
            y = b;
            z = c;
        }

        public Vec(Vec v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }


        public static Vec operator +(Vec a, Vec b)
        {
            Vec c = new Vec();
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            c.z = a.z + b.z;
            return c;
        }

        public static Vec operator -(Vec a, Vec b)
        {
            Vec c = new Vec();
            c.x = a.x - b.x;
            c.y = a.y - b.y;
            c.z = a.z - b.z;
            return c;
        }

        public static Vec operator *(Vec a, double f)
        {
            Vec c = new Vec();
            c.x = a.x * f;
            c.y = a.y * f;
            c.z = a.z * f;
            return c;
        }

        public static Vec operator /(Vec a, double f)
        {
            Vec c = new Vec();
            c.x = a.x / f;
            c.y = a.y / f;
            c.z = a.z / f;
            return c;
        }
        public static Vec operator /(double f, Vec v)
        {
            Vec c = new Vec(); ;
            c.x = f / v.x;
            c.y = f / v.y;
            c.z = f / v.z;
            return c;
        }

        public static Vec operator *(double f, Vec v)
        {
            Vec c = new Vec();
            c.x = v.x * f;
            c.y = v.y * f;
            c.z = v.z * f;
            return c;
        }



        double Magnitude()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        double Dot(Vec b)
        {
            return x * b.x + y * b.y + z * b.z;
        }

        Vec Cross(Vec b)
        {
            Vec c = new Vec(); ;
            c.x = y * b.z - z * b.y;
            c.y = z * b.x - x * b.z;
            c.z = x * b.y - y * b.x;
            return c;
        }

        Vec Norm()
        {
            double m = Magnitude();
            Vec c = new Vec(x / m, y / m, z / m);
            return c;
        }

        Vec Normalize()
        {
            double m = Magnitude();
            x = x / m;
            y = y / m;
            z = z / m;
            return this;
        }

        Vec Normal(Vec a, Vec b)
        {
            return a.Cross(b).Norm();
        }

        Vec Normal(Vec a, Vec b, Vec c)
        {
            Vec u = (a - b);
            Vec v = (a - c);
            return Normal(u, v);
        }

        double Dot(Vec a, Vec b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        Vec Cross(Vec a, Vec b)
        {
            Vec c = new Vec(); ;
            c.x = a.y * b.z - a.z * b.y;
            c.y = a.z * b.x - a.x * b.z;
            c.z = a.x * b.y - a.y * b.x;
            return c;
        }
    }
}