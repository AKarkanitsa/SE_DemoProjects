using _07_LINQ;

TestSet set = new TestSet();

//фильтрация данных
var filteredSet = set.Where(s => s > 75);
foreach (int i in filteredSet) Console.WriteLine(i);

//преобразование данных
var resultingSet = set.Select(s => '*' + s.ToString() + '*');
foreach (string i in resultingSet) Console.WriteLine(i);

//последовательное использование методов
resultingSet = set.Where(s => s > 75).Select(s => '*' + s.ToString() + '*');
foreach (string i in resultingSet) Console.WriteLine(i);

//выбор первого, удовлетворяющего условию
var result = set.First(s => s % 2 == 0);
Console.WriteLine(result);

//Выбор единственного, удовлетворяющего условию
//В строке ниже возникнет исключение, так как честное число не единственное в исходно наборе данных
//result = set.Single(s => s % 2 == 0);
//Console.WriteLine(result);

//Агрегация данных (свертка)
result = set.Aggregate(0, (acc, i) => acc + i);
Console.WriteLine(result);

//Фильтрация и свертка (факториал 5)
result = set.Where(i => i <= 5).Aggregate(1, (acc, i) => acc * i);

//Сортировка по некоторому свойству
var sortedSet = set.Select(i => new { Number = i, isEven = i % 2 == 0 }).OrderBy(r => r.isEven);
//сначала выведутся все нечетные, потом все четные
foreach (var i in sortedSet) Console.WriteLine(i);

//Переборы в наборе данных. Сколько?
var subSet = set.Where(i => i % 2 == 0).Select(i => '*' + i.ToString() + '*').Where(i => i.Length == 4);
foreach (var i in subSet) Console.WriteLine(i);

//Операторы запросов LINQ
string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
// создаем новый список для результатов
var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
                     where p.ToUpper().StartsWith("T") //фильтрация по критерию
                     orderby p  // упорядочиваем по возрастанию
                     select p; // выбираем объект в создаваемую коллекцию
foreach (string person in selectedPeople) Console.WriteLine(person);


//или так в одну строку
//var selectedPeople = from p in people where p.ToUpper().StartsWith("T") orderby p select p;
//foreach (string person in selectedPeople)  Console.WriteLine(person);

// То же самое с помощью методов расширений
//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
//var selectedPeople = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);
//foreach (string person in selectedPeople)
//    Console.WriteLine(person);
