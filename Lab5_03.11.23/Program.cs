 abstract class Parent  /////геом тiла
{
    public abstract string Info();
    public abstract double Metod1();
    public abstract double Metod2();
}

class Paralelepiped : Parent ////пряи паралеле
{
    double pole1, pole2, pole3;

    public Paralelepiped(double pole1, double pole2, double pole3)
    {
        this.pole1 = pole1; this.pole2 = pole2; this.pole3 = pole3;
    }
    public override string Info()
    {
        return $"Прямокутний паралелепiпед зi сторонами: {pole1}, {pole2}, {pole3}";
    }
    public override double Metod1()
    {
        return 2 * (pole1 * pole2 + pole2 * pole3 + pole3 * pole1); ////2*(ab+bc+ac) площа повн поверхн прям паралеп
    }
    public override double Metod2()
    {
        return pole1 * pole2 * pole3; ////обьем пара
    }
}
class Konus : Parent
{
    double pole4, pole5;
    public Konus(double pole4, double pole5)
    {
        this.pole4 = pole4;this.pole5 = pole5;
    }
    public override string Info()
    {
        return $"Радiус основи конуса {pole4} , висота  конуса{pole5}";
    }
    public override double Metod1()
    {
        double l = Math.Sqrt(pole4 * pole4 + pole5 * pole5); ////piR(I*R)
        return Math.PI * pole4 * (pole4 + l);/////площа поверхн конуса
    }

    public override double Metod2()
    {
        return (Math.PI * pole4 * pole4 * pole5) / 3; /////обьем конуса
    }
}
class Kulya : Parent
{
    double pole6;
    public Kulya (double pole6)
    {
        this.pole6 = pole6;
    }
    public override string Info()
    {
        return $"Радiус кулi {pole6}";
    }
    public override double Metod1()
    {
        return 4 * Math.PI * pole6 * pole6; ////площа поверхнi кулi 4pi * d
    }

    public override double Metod2()
    {
        return (4.0 / 3.0) * Math.PI * pole6 * pole6 * pole6; /////обьем кулi 4\3 pi r^3
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("|     Тип об'єкта     |  Площа повної поверхнi |        Об'єм         |");
        Console.WriteLine("-----------------------------------------------------------------------");

        Parent obj = null; /////об'єкт абстрактного класу
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            int clsobj = random.Next(3);
            switch (clsobj)
            {
                case 0:
                    double pole1 = random.Next(1, 15);
                    double pole2 = random.Next(1, 15);
                    double pole3 = random.Next(1, 15);
                    obj = new Paralelepiped(pole1, pole2, pole3);
                    break;
                case 1:
                    double pole4 = random.Next(1, 15);
                    double pole5 = random.Next(1, 15);
                    obj = new Konus(pole4, pole5);
                    break;
                case 2:
                    double pole6 = random.Next(1, 15);
                    obj = new Kulya(pole6);
                    break;
            }
            string name = obj.GetType().Name;
            Console.WriteLine($"| {name,-19} | {obj.Metod1(),22:F2} | {obj.Metod2(),20:F2} |");
        }
        Console.WriteLine("-----------------------------------------------------------------------");
    }

}
