// Read each line of the file into a string array. Each element
// of the array is one line of the file.
string[] lines = System.IO.File.ReadAllLines(@"C:\Users\17168\Desktop\ElfsFoodList.txt");
List<(int,int)>_elfAndCaloriesList = new List<(int,int)>();
int _totalCal = 0;
AddCalories();
GetTheListOfElves();
GetTheHighestCalorieElf();
GetTheHighestCalorieElf();
GetTheHighestCalorieElf();
Console.WriteLine("THREE TOTAL: " + _totalCal);

Console.Write("Press any key to exit.");
System.Console.ReadKey();


void AddCalories()
{

    int _calorie = 0;
    int _elfID = 0;
     Elf elf = new Elf(_elfID,_calorie);
    foreach (string line in lines)
    {
        if(line == "") 
        {
            _elfAndCaloriesList.Add((_elfID+1, elf.GetCalories()));
            _elfID++;
            elf = new Elf(_calorie, _elfID); 
        }
        else elf.AddCalories(Convert.ToInt32(line));
    }
}

void GetTheHighestCalorieElf()
{
    (int, int) _highestCalorieElf = (int.MinValue, int.MinValue);
    foreach (var _elfAndCalorie in _elfAndCaloriesList)
    {
        //Console.WriteLine(_elfAndCalorie);
        if (_elfAndCalorie.Item2 > _highestCalorieElf.Item2)
        {
            _highestCalorieElf = _elfAndCalorie;
        }
    }
    Console.WriteLine("HIGHEST CALORIE ELF " + _highestCalorieElf );
    _totalCal += _highestCalorieElf.Item2;
    _elfAndCaloriesList.Remove(_highestCalorieElf);
}

void GetTheListOfElves() 
{
    foreach (var _elfAndCalorie in _elfAndCaloriesList)
    {
        Console.WriteLine("-------------");
        Console.WriteLine(_elfAndCalorie);
    }
}
        

class Elf 
{
    public int _calories;
    public int _id;

     public Elf(int calories,int id) 
    {
        _calories = calories;
        _id = id;
    }


    public void AddCalories(int incomingCalories) 
    {
        _calories += incomingCalories;
    
    }
    public int GetCalories() 
    {
        return _calories;
    }
}
