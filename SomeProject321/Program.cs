Console.Write("Введите номер машины >>");
string number = Console.ReadLine();
Console.Write("Введите количество топлива >> ");
int volume = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите объём бака >> ");
int maxV = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите потребление топлива на 100 километров >> ");
int expend = Convert.ToInt32(Console.ReadLine());

Auto Car1 = new Auto(number, volume, maxV, expend);

bool responce = true;
do 
{
    Console.Write("Введите дистанцию(в км) до места назначения(или введите q чтобы закончить) >> ");
    string resp = Console.ReadLine();
    if (resp == "q")
    {
        Console.Write($"\nПробег автомобиля: {Car1.mileage} км.\nЗавершаем работу прграммы...");
        responce = false;
        break;
    }
    else 
    {
        int destination = Convert.ToInt32(resp);
        Car1.Destination(destination);
    }
} 
while (responce == true);

class Auto 
{
    public string number;
    public double volume;
    public int maxV;
    public double expend;
    public int mileage = 0;
    public Auto() { number = "AB123C"; volume = 150; maxV = 300; expend = 100; }
    public Auto(double i) { volume = i; }
    public Auto(double i, int j) { volume = i; maxV = j; }
    public Auto(double i, int j, double k) { volume = i; maxV = j; expend = k; }
    public Auto(string a, double i, int j, double k) { number = a; volume = i; maxV = j; expend = k; }
    public void Destination(int distance)
    {
        bool responce = false;
        bool checkExit = false;
        int count = 0;
        int refuelCount = 0;

        do
        {
            while (volume >= expend)
            {
                if (distance == 0) break;
                else if (distance >= 100)
                {
                    volume -= expend;
                    distance -= 100;
                    count += 100;
                    Console.WriteLine(distance + " " + volume);
                }
                else if (distance >= 10)
                {
                    volume -= expend / 10;
                    distance -= 10;
                    count += 10;
                    Console.WriteLine(distance + " " + volume);
                }
                else if (distance >= 1)
                {
                    volume -= expend / 100;
                    distance -= 1;
                    count += 1;
                    Console.WriteLine(distance + " " + volume);
                }
            }
            if (distance != 0)
            {
                string refueling;
                int res = 0;
                Console.Write($"\nНе хватает топлива!\nВ баке осталось {volume} литров!\nАвтомобиль проехал {count} км из {distance + count} км!\nВведите дозаправку(или введите q чтобы выйти)>> ");
                while (volume < expend)
                {
                    refueling = Console.ReadLine();
                    if (refueling == "q")
                    {
                        responce = true;
                        checkExit = true;
                        break;
                    }
                    else
                    {
                        res = Convert.ToInt32(refueling);
                        if (res + volume > maxV) Console.Write($"\nСтолько в бак не поместится! Максимальня ёмкость автомобиля -- {maxV}!\nВведите дозаправку(или введите q чтобы выйти)>> ");
                        else
                        {
                            Console.WriteLine($"\nТопливо было залито!");
                            volume += res;
                            refuelCount++;
                            if (volume < expend) Console.Write($"Необходимо ещё {expend - volume} топлива!\nВведите дозаправку(или введите q чтобы выйти)>> ");
                        }
                    }
                }
            }
            else responce = true;
        }
        while (responce == false);
        mileage += count;
        if (checkExit != true) 
        {
            if (refuelCount == 0) Console.WriteLine($"Автомобиль проехал {count} км без дозаправки!");
            else if (refuelCount == 1) Console.WriteLine($"Автомобиль проехал {count} км с одной дозаправокой.");
            else Console.WriteLine($"Автомобиль проехал {count} км с дозаправками. Количество дозаправок: {refuelCount}.");
        }
        else Console.WriteLine("Прекращение дозаправки...");
    }
}