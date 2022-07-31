int userScores = 0, computerScores = 0;
while(true)
{
    var user = GetUserAnswer();
    var computer = GetComputerAnswer();
    Console.Clear();
    System.Console.WriteLine($"Игрок выбрал {user}");
    System.Console.WriteLine($"Компьютер выбрал {computer}");
    GetWinner(user, computer);
    WriteScores();

    Console.WriteLine("Для выхода нажмите ctrl + c");
}


string GetUserAnswer()
{
    while(true){
        System.Console.Write("Введите 1 для Камня, 2 для Ножниц, 3 для Бумаги: ");
        var str = Console.ReadKey().KeyChar.ToString();
        System.Console.WriteLine();
        if(Int32.TryParse(str, out int answer) && answer > 0 && answer < 4)
            return GetGameAnswer(answer);
        System.Console.WriteLine("Неверный ввод, попробуйте снова.");
    }
}

string GetComputerAnswer(){
    return GetGameAnswer(new Random().Next(1,4));
}


string GetGameAnswer(int num){
    if(num == 1) return "Камень";
    if(num == 2) return "Ножницы";
    if(num == 3) return "Бумага";
    return "Ошибка";
}

void GetWinner(string userAnswer, string computerAnswer){
    System.Console.WriteLine();
    if(userAnswer == computerAnswer){
        System.Console.WriteLine("Ничья");
        return;
    }
    if(userAnswer == "Камень" && computerAnswer == "Ножницы" 
            || userAnswer == "Ножницы" && computerAnswer == "Бумага" 
            || userAnswer == "Бумага" && computerAnswer == "Камень")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("Игрок выиграл");
        Console.ForegroundColor = ConsoleColor.Gray;
        userScores+= 1;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Компьютер выиграл");        
        Console.ForegroundColor = ConsoleColor.Gray;
        computerScores+=1;
        return;
    }
    userScores += 1;

}

void WriteScores(){
    
    System.Console.WriteLine();
    System.Console.WriteLine("Результаты:");
    
    System.Console.WriteLine($"Игрок: {userScores}");
    System.Console.WriteLine($"Компьютер: {computerScores}");
    System.Console.WriteLine();
}