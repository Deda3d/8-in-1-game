int[] games = new int[7];
int nowchoosed = 0;
Console.CursorVisible= false;
void Gamess()
{
    Console.Clear();
    if (nowchoosed == 0) Console.ForegroundColor = ConsoleColor.DarkGray;
    else Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Minesweeper");

    if (nowchoosed == 1) Console.ForegroundColor = ConsoleColor.DarkGray;
    else Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 1);
    Console.WriteLine("Arkanoid");

    if (nowchoosed == 2) Console.ForegroundColor = ConsoleColor.DarkGray;
    else Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 2);
    Console.WriteLine("Memory-training-cards");

    if (nowchoosed == 3) Console.ForegroundColor = ConsoleColor.DarkGray;
    else Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 3);
    Console.WriteLine("Hangman");

    if (nowchoosed == 4) Console.ForegroundColor = ConsoleColor.DarkGray;
    else Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 4);
    Console.WriteLine("Maze-game");

    if (nowchoosed == 5) Console.ForegroundColor = ConsoleColor.DarkGray;
    else Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 5);
    Console.WriteLine("Match-three");

    if (nowchoosed == 6) Console.ForegroundColor = ConsoleColor.DarkGray;
    else Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 6);
    Console.WriteLine("Chess-horse-game");

    if (nowchoosed == 7) Console.ForegroundColor = ConsoleColor.DarkGray;
    else Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 7);
    Console.WriteLine("Tic-tac-toe");
}
bool gamechoosed = false;
while (gamechoosed == false)
{
    Gamess();
    var x = Console.ReadKey(true).Key; // считываем первое нажатие
    switch (x)
    {
        case ConsoleKey.DownArrow: nowchoosed++; break;
        case ConsoleKey.UpArrow: nowchoosed--; break;
        case ConsoleKey.Enter: gamechoosed = true; break;
    }
}
if(nowchoosed == 0)
{
    Console.Clear();
    int xfield = 9; // розмір поля Х
    int yfield = 9; // розмір поля У
    int nmines = 10; // кількість мін
    int xmine; // координата міни по Х
    int ymine; // координата міни по Y
    int xplayer = 3;
    int yplayer = 1;

    //

    //


    int[,] field = new int[yfield + 2, xfield + 2]; // поле
    bool[,] openempty = new bool[yfield + 2, xfield + 2];
    bool[,] cellisopen = new bool[yfield + 2, xfield + 2];
    bool[,] flag = new bool[yfield + 2, xfield + 2];

    for (int i = 0; i < yfield + 2; i++) field[i, 0] = -1;
    for (int i = 0; i < yfield + 2; i++) field[i, xfield + 1] = -1;
    for (int i = 0; i < xfield + 2; i++) field[0, i] = -1;
    for (int i = 0; i < xfield + 2; i++) field[yfield + 1, i] = -1;

    Random rnd = new Random();
    while (nmines > 0)
    {
        xmine = rnd.Next(1, xfield + 1);
        ymine = rnd.Next(1, yfield + 1);
        if (field[ymine, xmine] != 9)
        {
            field[ymine, xmine] = 9;
            nmines--;
        }
    }

    for (int i = 1; i < yfield + 1; i++)
    {
        for (int j = 1; j < xfield + 1; j++)
        {
            if (field[i, j] != 9)
            {
                int c = 0;
                if (field[i + 1, j] == 9) c++;
                if (field[i + -1, j] == 9) c++;
                if (field[i, j + 1] == 9) c++;
                if (field[i, j - 1] == 9) c++;
                if (field[i + 1, j + 1] == 9) c++;
                if (field[i - 1, j - 1] == 9) c++;
                if (field[i + 1, j - 1] == 9) c++;
                if (field[i - 1, j + 1] == 9) c++;
                field[i, j] = c;
            }
        }
    }


    void Color()
    {
        if (field[yplayer, (xplayer - 1) / 2] == -1) Console.ForegroundColor = ConsoleColor.White;
        else if (field[yplayer, (xplayer - 1) / 2] == 0) Console.ForegroundColor = ConsoleColor.Black;
        else if (field[yplayer, (xplayer - 1) / 2] == 1) Console.ForegroundColor = ConsoleColor.Blue;
        else if (field[yplayer, (xplayer - 1) / 2] == 2) Console.ForegroundColor = ConsoleColor.Green;
        else if (field[yplayer, (xplayer - 1) / 2] == 3) Console.ForegroundColor = ConsoleColor.Red;
        else if (field[yplayer, (xplayer - 1) / 2] == 4) Console.ForegroundColor = ConsoleColor.Magenta;
        else if (field[yplayer, (xplayer - 1) / 2] == 5) Console.ForegroundColor = ConsoleColor.DarkYellow;
        else if (field[yplayer, (xplayer - 1) / 2] == 6) Console.ForegroundColor = ConsoleColor.Cyan;
        else if (field[yplayer, (xplayer - 1) / 2] == 7) Console.ForegroundColor = ConsoleColor.DarkMagenta;
        else if (field[yplayer, (xplayer - 1) / 2] == 8) Console.ForegroundColor = ConsoleColor.DarkGray;
    }


    for (int i = 0; i < yfield + 2; i++)
    {
        for (int j = 0; j < xfield + 2; j++)
        {
            if (field[i, j] == -1) Console.ForegroundColor = ConsoleColor.White;
            else if (field[i, j] == 0) Console.ForegroundColor = ConsoleColor.Black;
            else if (field[i, j] == 1) Console.ForegroundColor = ConsoleColor.Blue;
            else if (field[i, j] == 2) Console.ForegroundColor = ConsoleColor.Green;
            else if (field[i, j] == 3) Console.ForegroundColor = ConsoleColor.Red;
            else if (field[i, j] == 4) Console.ForegroundColor = ConsoleColor.Magenta;
            else if (field[i, j] == 5) Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (field[i, j] == 6) Console.ForegroundColor = ConsoleColor.Cyan;
            else if (field[i, j] == 7) Console.ForegroundColor = ConsoleColor.DarkMagenta;
            else if (field[i, j] == 8) Console.ForegroundColor = ConsoleColor.DarkGray;
            if (cellisopen[i, j] == false && field[i, j] != -1)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("██");
            }

            else
            {
                if (field[i, j] == -1) Console.Write("██");
                else if (field[i, j] == 9) Console.Write("()");
                else Console.Write($" {field[i, j]}");
            }
        }
        Console.WriteLine();
    }

    Console.SetCursorPosition(xplayer, yplayer);

    bool gameactive = true;
    bool win = false;
    bool loose = false;

    while (gameactive == true)
    {
        var x = Console.ReadKey(true).Key;
        switch (x)
        {
            case ConsoleKey.D: if (field[yplayer, (xplayer + 2) / 2] != -1) xplayer += 2; break;
            case ConsoleKey.A: if (field[yplayer, (xplayer - 2) / 2] != -1) xplayer -= 2; break;
            case ConsoleKey.S: if (field[yplayer + 1, xplayer / 2] != -1) yplayer++; break;
            case ConsoleKey.W: if (field[yplayer - 1, xplayer / 2] != -1) yplayer--; break;
            case ConsoleKey.F:
                if (flag[yplayer - 1, xplayer / 2] == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    flag[yplayer - 1, xplayer / 2] = true;
                }
                else if (flag[yplayer - 1, xplayer / 2] == true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    flag[yplayer - 1, xplayer / 2] = false;
                }
                Console.SetCursorPosition(xplayer - 1, yplayer);
                Console.Write("██");
                Console.SetCursorPosition(xplayer, yplayer);
                break;
            case ConsoleKey.E:
                if (field[yplayer, (xplayer - 1) / 2] != 9)
                {
                    Color();
                    Console.SetCursorPosition(xplayer - 1, yplayer);
                    Console.Write(" ");
                    Console.SetCursorPosition(xplayer, yplayer);
                    Console.Write(field[yplayer, (xplayer - 1) / 2]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(xplayer - 1, yplayer);
                    Console.Write(" *");
                    Console.SetCursorPosition(xplayer, yplayer);
                    gameactive = false;
                    loose = true;
                }
                //

                //
                break;
        }
        Console.SetCursorPosition(xplayer, yplayer);
        if (gameactive == false)
        {
            Console.SetCursorPosition(0, yfield + 1);
            if (win == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You win!!!");
            }
            if (loose == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lose!!!");
            }
        }
    }
}
if (nowchoosed == 1)
{
    Console.Clear();

    int xball = 50;
    int yball = 1;
    int xballlast;
    int yballlast;
    int xplayer = 50;
    int yplayer = 30;
    int balldir = 9;
    int speed = 50;
    int rplatform = 2;
    int r;



    Random rn = new Random();
    Console.SetWindowSize(100, 40);
    Console.SetBufferSize(100, 40);
    int[,] blocks = new int[30, 96];
    //for(int i = 0; i < 30; i++)
    //{
    //    for (int j = 0; j < 96; j++) blocks[i, j] = 0;
    //}
    //for (int i = 0; i < 30; i++)
    //{
    //    for (int j = 2; j < 96; j++) Console.Write(blocks[i, j]);
    //    Console.WriteLine();
    //}
    for (int i = 0; i < 100; i++)
    {
        Console.SetCursorPosition(i, 0);
        Console.Write("█");
    }
    for (int i = 0; i < 40; i++)
    {
        Console.SetCursorPosition(0, i);
        Console.Write("██");
    }
    for (int i = 0; i < 40; i++)
    {
        Console.SetCursorPosition(98, i);
        Console.Write("██");
    }
    void PlatformUpdate()
    {
        Console.SetCursorPosition(xplayer, yplayer);
        for (int i = 0; i < rplatform; i++)
        {
            Console.SetCursorPosition(xplayer + i, yplayer);
            Console.Write("_");
            Console.SetCursorPosition(xplayer - i, yplayer);
            Console.Write("_");
        }

        Console.SetCursorPosition(xplayer + rplatform, yplayer);
        Console.Write(" ");
        Console.SetCursorPosition(xplayer - rplatform, yplayer);
        Console.Write(" ");
        if (xplayer + rplatform + 2 <= 96 && xplayer - rplatform - 2 >= 3)
        {
            Console.SetCursorPosition(xplayer + rplatform + 1, yplayer);
            Console.Write(" ");
            Console.SetCursorPosition(xplayer - rplatform - 1, yplayer);
            Console.Write(" ");
        }
    }
    PlatformUpdate();

    Console.CursorVisible = false;
    while (true)
    {
        void Ball()
        {
            while (true)
            {
                xballlast = xball;
                yballlast = yball;

                if (xball < 4 && balldir == 14) balldir = 4;
                if (xball < 4 && balldir == 15) balldir = 3;
                if (xball < 4 && balldir == 16) balldir = 2;
                if (xball < 4 && balldir == 12) balldir = 6;
                if (xball < 4 && balldir == 11) balldir = 7;
                if (xball < 4 && balldir == 10) balldir = 8;

                if (xball > 95 && balldir == 4) balldir = 14;
                if (xball > 95 && balldir == 3) balldir = 15;
                if (xball > 95 && balldir == 2) balldir = 16;
                if (xball > 95 && balldir == 6) balldir = 12;
                if (xball > 95 && balldir == 7) balldir = 11;
                if (xball > 95 && balldir == 8) balldir = 10;

                if (yball < 3 && balldir == 1) balldir = 9;
                if (yball < 3 && balldir == 2) balldir = 8;
                if (yball < 3 && balldir == 3) balldir = 7;
                if (yball < 3 && balldir == 4) balldir = 6;
                if (yball < 3 && balldir == 16) balldir = 10;
                if (yball < 3 && balldir == 15) balldir = 11;
                if (yball < 3 && balldir == 14) balldir = 12;

                if (yball > 35 && balldir == 9) balldir = 1;
                if (yball > 35 && balldir == 8) balldir = 2;
                if (yball > 35 && balldir == 7) balldir = 3;
                if (yball > 35 && balldir == 6) balldir = 4;
                if (yball > 35 && balldir == 10) balldir = 16;
                if (yball > 35 && balldir == 11) balldir = 15;
                if (yball > 35 && balldir == 12) balldir = 14;


                if (balldir == 1) yball--;
                if (balldir == 9) yball++;
                //
                if (balldir == 3)
                {
                    yball--;
                    xball++;
                }
                if (balldir == 15)
                {
                    yball--;
                    xball--;
                }
                if (balldir == 7)
                {
                    yball++;
                    xball++;
                }
                if (balldir == 11)
                {
                    yball++;
                    xball--;
                }
                //
                if (balldir == 2)
                {
                    yball -= 2;
                    xball++;
                }
                if (balldir == 4)
                {
                    yball--;
                    xball += 2;
                }
                if (balldir == 6)
                {
                    yball++;
                    xball += 2;
                }
                if (balldir == 8)
                {
                    yball += 2;
                    xball++;
                }
                if (balldir == 10)
                {
                    yball += 2;
                    xball--;
                }
                if (balldir == 12)
                {
                    yball++;
                    xball -= 2;
                }
                if (balldir == 14)
                {
                    yball--;
                    xball -= 2;
                }
                if (balldir == 16)
                {
                    yball -= 2;
                    xball--;
                }



                PlatformUpdate();
                Console.SetCursorPosition(xballlast, yballlast);
                Console.Write(" ");
                Console.SetCursorPosition(xball, yball);
                Console.WriteLine("o");
                if (balldir == 1 || balldir == 9) Thread.Sleep(Convert.ToInt32(speed / Math.Sqrt(5)));
                if (balldir == 15 || balldir == 3) Thread.Sleep(Convert.ToInt32(speed / Math.Sqrt(2)));
                else Thread.Sleep(speed);


                if (rplatform == 2)
                {
                    if (yball == yplayer && xball == xplayer)
                    {
                        r = rn.Next(0, 3);
                        if (r == 0) balldir = 16;
                        if (r == 1) balldir = 1;
                        if (r == 2) balldir = 2;
                    }
                    if (yball == yplayer && xball == xplayer + 1)
                    {
                        r = rn.Next(0, 2);
                        if (r == 0) balldir = 3;
                        if (r == 1) balldir = 4;
                    }
                    if (yball == yplayer && xball == xplayer - 1)
                    {
                        r = rn.Next(0, 2);
                        if (r == 0) balldir = 14;
                        if (r == 1) balldir = 15;
                    }
                }

            }
        }
        Task.Run(() => Ball());
        while (true)
        {
            var x = Console.ReadKey(true).Key;
            switch (x)
            {
                case ConsoleKey.A: if (xplayer - rplatform >= 3) xplayer--; break;
                case ConsoleKey.D: if (xplayer + rplatform <= 96) xplayer++; break;
            }
        }
    }
}
if (nowchoosed == 2)
{
    Console.CursorVisible= true;
    Console.Clear();
    int LengthField = 0; // довжина та ширина поля, переед тип, як ми впишемо - вона = 0
    while (LengthField != 4 && LengthField != 8 && LengthField != 6) // цикл не завершиться до тих пір, поки ми не введемо правильне значення: 4,6 або 8
    {
        Console.Clear(); // кожного разу стираємо консоль, щоб текст не дублювався 
        Console.Write("Введiть значення довжини та ширини поля (4,6 або 8): ");
        LengthField = Convert.ToInt32(Console.ReadLine()); // зчитуємо значення
    }
    Console.Clear(); // ще раз чистимо консоль, щоб пропав текст "Введіть значення..."

    Console.CursorVisible = false; // вимикаємо курсор, щоб його не було видно
    int[,] Field = new int[LengthField + 2, LengthField + 2];  // робимо ігрове поле. воно більше, ніж те, що ми вписали на 2 тому, що ще будуть стіни
    bool[,] CardInfo = new bool[LengthField + 2, LengthField + 2]; // массив булів для того, щоб стежити за станом карти ( відкрита чи закрита )
    int NCards = LengthField * LengthField / 2;  // кількість різних карт у полі
    Random rnd = new Random();
    int c = 0; // просто лічильник
    bool game = false; // запам'ятовуємо, що гра ще не почалась

    int time; // змінна, у якій зберігається інформація про те, скільки в нас часу є на розв'язок задачі
    int starttime; // змінна, у якій зберігається інформація про те, скільки в нас часу є для того, щоб запам'ятати картки
    if (LengthField == 4) // при різних значеннях складності поля буде даватися різний час
    {
        time = 30;
        starttime = 15;
    }
    else if (LengthField == 6)
    {
        time = 60;
        starttime = 30;
    }
    else if (LengthField == 8)
    {
        time = 90;
        starttime = 45;
    }
    else
    {
        time = 0;
        starttime = 0;
    }

    int timebeforeclosecard = 1000;  // час, через який відкриті карти будуть закриватися, якщо ми не вгадали
    int personx = 1;  // координати ігрока. спочатку ігрок стоїть у верхньому лівому куту
    int persony = 1;

    for (int i = 0; i < LengthField + 2; i++) Field[i, 0] = -1;  // заповнюємо по краям стінками. стінка - це (-1)
    for (int i = 0; i < LengthField + 2; i++) Field[0, i] = -1;
    for (int i = 0; i < LengthField + 2; i++) Field[i, LengthField + 1] = -1;
    for (int i = 0; i < LengthField + 2; i++) Field[LengthField + 1, i] = -1;

    int cardsput = 0; // кількість карт, які сгенерувалися при створенні лабіринту
    while (cardsput != LengthField * LengthField)  // цикл буде виконуватися до тих пір, поки все поле не буде в картках
    {
        for (int i = 1; i < LengthField + 1; i++)  // проходимо по полю
        {
            for (int j = 1; j < LengthField + 1; j++)
            {
                int card = rnd.Next(1, NCards + 1); // беремо випадкову картку
                c = 0;
                foreach (int x in Field) if (x == card) c++; // рахуємо, скільки таких карт вже є у полі
                if (c < 2 && Field[i, j] == 0) // якщо поле пусте, та таких карт було не більше однієї
                {
                    Field[i, j] = card; // записуємо цю картку в поле
                    cardsput++; // кількість розміщених карт стає більшою
                }
                c = 0;
            }
        }
    }
    void WriteCard(int ii, int jj) // метод для малювання комірки в полі, у який подаються її координати
    {
        if (CardInfo[ii, jj] == true || game == false) // якщо карта відкрита АБО гра ще не почалась ( для того, щоб ми бачили всі відкриті, поки запам'ятовуємо )
        {
            if (Field[ii, jj] % 10 == 1) Console.ForegroundColor = ConsoleColor.Red; // змінюємо колір в залежності від одиничної частини числа
            if (Field[ii, jj] % 10 == 2) Console.ForegroundColor = ConsoleColor.Green;
            if (Field[ii, jj] % 10 == 3) Console.ForegroundColor = ConsoleColor.Blue;
            if (Field[ii, jj] % 10 == 4) Console.ForegroundColor = ConsoleColor.Yellow;
            if (Field[ii, jj] % 10 == 5) Console.ForegroundColor = ConsoleColor.White;
            if (Field[ii, jj] % 10 == 6) Console.ForegroundColor = ConsoleColor.Cyan;
            if (Field[ii, jj] % 10 == 7) Console.ForegroundColor = ConsoleColor.DarkGray;
            if (Field[ii, jj] % 10 == 8) Console.ForegroundColor = ConsoleColor.Magenta;
            if (Field[ii, jj] % 10 == 9) Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (Field[ii, jj] % 10 == 0) Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (Field[ii, jj] / 10 == 0) Console.Write(Convert.ToChar(3)); // виводимо символ в залежності від десяткової частини числа
            if (Field[ii, jj] / 10 == 1) Console.Write(Convert.ToChar(4));
            if (Field[ii, jj] / 10 == 2) Console.Write(Convert.ToChar(5));
            if (Field[ii, jj] / 10 == 3) Console.Write(Convert.ToChar(6));
        }
        else // якщо комірка повинна бути закрита
        {
            Console.ForegroundColor = ConsoleColor.Gray;  // малюємо замість картки сірий прямокутник
            Console.Write('█');
        }
    }

    Console.WriteLine("Натисніть будь-яку кнопку, щоб почати гру");
    Console.ReadKey(); // чекаємо, доки ігрок не буде готовий, щоб почати гру. після того, як рідкей зловить якесь натискання - код буде йти далі
    Console.Clear();

    void PrintField()  // метод для того, щоб намалювати поле
    {
        for (int i = 0; i < LengthField + 2; i++)
        {
            for (int j = 0; j < LengthField + 2; j++)
            {
                if (Field[i, j] == -1) // якщо стіна (-1) - виводимо стіну
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("█");
                }
                else WriteCard(i, j); // інакше - малюємо карту, або якщо гра почалась та ми не відкрили ще цю карту - малюється сірий прямокутник
            }
            Console.WriteLine();
        }
    }
    PrintField();  // малюємо поле, щоб гравець під час відліку міг дивитися на нього

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("   секунд залишилося, щоб запам'ятати картки"); // пишемо під полем інформацію про стан часу. замість пропуску далі буде таймер
    for (int i = starttime; i >= 0; i--)  // виконуємо цикл стільки разів, скільки в нас дається часу для того, щоб запам'ятати поле
    {
        Console.SetCursorPosition(0, LengthField + 3); // ставимо курсор поруч з текстом, який ми виводили у 119 рядку
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{i} ");  // пишемо, скільки секунд залишилось
        Thread.Sleep(1000); // виконання коду зупиняється на 1 секунду
    }


    void TimeLeft() // метод для того, щоб коли гра почалась, ми змогли писати скільки в нас залишилося часу
    {
        while (game != false)  // цикл, який буде виконуватися нескінченно до тих пір, поки гра активна ( гравець ще не виграв та час ще не вийшов )
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(3, LengthField + 3);
            Console.WriteLine("секунд залишилося до кінця гри");
            for (int t = time; t >= 0; t--)  // виконуємо цикл стільки разів, скільки в нас дається часу для того, щоб пройти поле
            {
                Console.CursorVisible = false;  // вимикаємо курсор
                Console.SetCursorPosition(0, LengthField + 3);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{t} "); // виводить скільки залишилося секунд
                Console.CursorVisible = true;
                Console.SetCursorPosition(personx, persony); // вертаємо курсор на позицію гравця
                Thread.Sleep(1000);
                if (t == 0) // якщо час вийшов
                {
                    game = false; // зупиняємо гру
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ви програли!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }

    void CloseOpened(int xop, int yop, int xop2, int yop2) // метод, який приймає координати двох комірок та закриває їх, якщо гравець не вгадав
    {

        CardInfo[yop, xop] = false; // закриваємо ці комірки
        CardInfo[yop2, xop2] = false;
        Thread.Sleep(timebeforeclosecard); // затримка, щоб гравець не зміг дуже швидко всі комірки відкривати
        Console.CursorVisible = false;
        Console.SetCursorPosition(xop, yop);  // ставимо курсор в першу комірку
        WriteCard(yop, xop);  // оновлюємо ії, тільки після цієї команди вона візуально зміниться
        Console.SetCursorPosition(xop2, yop2);// ставимо курсор в другу комірку
        WriteCard(yop2, xop2);
        Console.CursorVisible = false;
        Console.SetCursorPosition(personx, persony); // вертаємо курсор на позицію гравця
    }

    game = true; // починаємо гру, відлік закінчився
    Console.Clear();
    PrintField(); // малюємо нове поле. теперь воно буде закритим, бо гра почалася 
    Task.Run(() => TimeLeft()); // запускаєио асинхронне виконання метода з таймером, щоб він не тормозив код

    while (game == true) // цикл виконується, поки гра не завершена 
    {
        Thread.Sleep(10); // маленька затримка для того, щоб таймери не збігалися, бо через це гра може запрацювати некоректно
        var x = Console.ReadKey(true).Key; // зчитуємо кнопку, яку ми натиснули
        switch (x)
        {
            case ConsoleKey.RightArrow: if (Field[persony, personx + 1] != -1) personx++; Console.SetCursorPosition(personx, persony); break;  // якщо це стрілка вправо, так справа немає стінки
            case ConsoleKey.LeftArrow: if (Field[persony, personx - 1] != -1) personx--; Console.SetCursorPosition(personx, persony); break;
            case ConsoleKey.UpArrow: if (Field[persony - 1, personx] != -1) persony--; Console.SetCursorPosition(personx, persony); break;
            case ConsoleKey.DownArrow: if (Field[persony + 1, personx] != -1) persony++; Console.SetCursorPosition(personx, persony); break;
            case ConsoleKey.Spacebar:  // пробіл - відкриття комірки
                if (CardInfo[persony, personx] == false)  // якщо ми не намагаємося відкрити відкриту комірку
                {
                    int xopen = personx; // запам'ятовуємо координати цієї відкритої комірки, щоб далі її порівняти з іншою
                    int yopen = persony;
                    CardInfo[persony, personx] = true; // відкриваємо комірку
                    WriteCard(persony, personx); // оновлюємо її, щоб побачити це візуально
                    Thread.Sleep(100);  // маленька затримка для коректної роботи програми
                    bool second = false;  // статус другої комірки ( натиснута чи не натиснута )
                    while (second == false)  // виконуємо цикл до тих пір, поки друга карта не відкрита ( це потрібно для того, щоб можна було спокійно переміщатися по полю в цей час )
                    {
                        var xx = Console.ReadKey(true).Key; // зчитуємо друге натискання
                        switch (xx)
                        {
                            case ConsoleKey.RightArrow: if (Field[persony, personx + 1] != -1) personx++; Console.SetCursorPosition(personx, persony); break; // даємо змогу переміщатися
                            case ConsoleKey.LeftArrow: if (Field[persony, personx - 1] != -1) personx--; Console.SetCursorPosition(personx, persony); break;
                            case ConsoleKey.UpArrow: if (Field[persony - 1, personx] != -1) persony--; Console.SetCursorPosition(personx, persony); break;
                            case ConsoleKey.DownArrow: if (Field[persony + 1, personx] != -1) persony++; Console.SetCursorPosition(personx, persony); break;
                            case ConsoleKey.Spacebar:  // друге натискання пробілу
                                if (CardInfo[persony, personx] == false) // перевіряємо, чи не відкрита вже друга карта
                                {
                                    CardInfo[persony, personx] = true; // відкриваємо її
                                    WriteCard(persony, personx); // оновлюємо візуально
                                    Thread.Sleep(100);
                                    if (Field[persony, personx] != Field[yopen, xopen]) CloseOpened(xopen, yopen, personx, persony); // якщо дві карти не совпали - виконуємо метод із закриття ціх комірок.
                                    second = true; // запам'ятовуємо, що ми відкрили другу карту
                                }
                                break;
                        }
                    }
                }
                break;
        }
        c = 0;
        for (int i = 1; i < LengthField + 1; i++)  // рахуємо кількість відкритих карт
        {
            for (int j = 1; j < LengthField + 1; j++) if (CardInfo[i, j] == true) c++;
        }
        if (c == LengthField * LengthField) // якщо всі карти відкриті - ми виграли
        {
            game = false; // зупиняємо гру
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ви виграли!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
if (nowchoosed == 3)
{
    Console.Clear();
    int lives_left = 6;
    int n_sovp = 0;
    bool win = false;
    bool lose = false;
    string[] words = new string[] { "элемент", "командир", "удар", "лестница", "способ", "состояние", "золото", "президент", "нарушение", "должность", "оплата", "самолет", "сознание", "семья", "сумма" };
    Random rnd = new Random();
    int word_number = rnd.Next(0, words.Length + 1);
    string word = words[word_number];
    char[] word_hide = new char[word.Length];
    for (int i = 0; i < word.Length; i++) word_hide[i] = '_';
    void Update()
    {
        Console.Clear();
        if (lives_left != 7) Console.WriteLine($"осталось {lives_left} жизней");
        switch (lives_left)
        {
            case 6:
                Console.WriteLine(" ______ ");
                Console.WriteLine(" |     | ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                break;
            case 5:
                Console.WriteLine(" ______ ");
                Console.WriteLine(" |     | ");
                Console.WriteLine(" |     0 ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                break;
            case 4:
                Console.WriteLine(" ______ ");
                Console.WriteLine(" |     | ");
                Console.WriteLine(" |     0 ");
                Console.WriteLine(" |     | ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                break;
            case 3:
                Console.WriteLine(" ______ ");
                Console.WriteLine(" |     | ");
                Console.WriteLine(" |     0 ");
                Console.WriteLine(" |    /| ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                break;
            case 2:
                Console.WriteLine(" ______ ");
                Console.WriteLine(" |     | ");
                Console.WriteLine(" |     0 ");
                Console.WriteLine(" |    /|\\ ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                break;
            case 1:
                Console.WriteLine(" ______ ");
                Console.WriteLine(" |     | ");
                Console.WriteLine(" |     0 ");
                Console.WriteLine(" |    /|\\ ");
                Console.WriteLine(" |    /  ");
                Console.WriteLine(" |      ");
                break;
            case 0:
                Console.WriteLine(" ______ ");
                Console.WriteLine(" |     | ");
                Console.WriteLine(" |     0 ");
                Console.WriteLine(" |    /|\\ ");
                Console.WriteLine(" |    / \\");
                Console.WriteLine(" |      ");
                break;
            case 7:
                Console.WriteLine(" ______ ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |      ");
                Console.WriteLine(" |     0 ");
                Console.WriteLine(" |    /|\\ ");
                Console.WriteLine(" |    / \\");
                break;
        }
        for (int i = 0; i < word.Length; i++) Console.Write($"{word_hide[i]} ");
        Console.WriteLine();
        if (win == true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вы выиграли!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        if (lose == true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы проиграли!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    Update();
    bool game = true;
    while (game == true)
    {
        Console.WriteLine();
        char pressed_key = Convert.ToChar(Console.ReadLine());
        for (int i = 0; i < word.Length; i++) if (word[i] == pressed_key)
            {
                n_sovp++;
                word_hide[i] = pressed_key;

            }
        if (n_sovp == 0) lives_left--;
        n_sovp = 0;
        Console.WriteLine(pressed_key);
        if (lives_left == 0)
        {
            game = false;
            lose = true;
        }
        for (int i = 0; i < word.Length; i++) if (word_hide[i] == '_') n_sovp++;
        if (n_sovp == 0)
        {
            game = false;
            win = true;
            lives_left = 7;
        }
        n_sovp = 0;
        Update();
    }
}
if (nowchoosed == 4)
{
    Console.Clear();
    int x = 27; //размеры лабиринта по Х
    int y = 27; //размеры лабиринта по У
    Console.CursorVisible = false;

    int[] xused = new int[x * y]; //координаты Х точек, через которые лежат проходы (количество ячеек х*у потому что там очень много ходов, и нужно много места )
    int[] yused = new int[x * y]; //координаты У точек, через которые лежат проходы (количество ячеек х*у потому что там очень много ходов, и нужно много места )
    xused[0] = 2; //записываем координату Х начальной точки
    yused[0] = 2; //записываем координату У начальной точки
    int numused = 1; //счетчик для того, чтобы запоминать следующие точки
    int randomused = 0; //количество переходов к случайной точке лабиринта после того, как возможность двигаться пропадает

    int[,] lab = new int[y, x]; //сам лабиринт
    int[,] used = new int[y, x]; //пустой массив, который будет заполняться единицами. 1 = мы уже были в этой точке

    used[2, 2] = 1; //записываем начальную точку как использованную

    int xp = 2; //координаты игрока по Х
    int yp = 2; //координаты игрока по У

    for (int i = 0; i < y; i++)
    {
        for (int j = 0; j < x; j++) lab[i, j] = 1;
    }//заполняем лабиринт стенами (1)
    for (int i = 1; i < y - 1; i++)
    {
        for (int j = 1; j < x - 1; j++) lab[i, j] = 0;
    }//заполняем его внутри пустым пространством (0)
    for (int i = 1; i < y - 1; i++)
    {
        for (int j = 0; j < x - 1; j++) if (i % 2 == 1 || j % 2 == 1) lab[i, j] = 1;
    }//делаем "сетку" чтобы нули были через 1 стену

    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < x; j++) lab[i, j] = 2;
    }//обозначаем верхнюю границу (2)
    for (int i = y - 2; i < y; i++)
    {
        for (int j = 0; j < x; j++) lab[i, j] = 2;
    }//обозначаем нижнюю границу (2)
    for (int j = 0; j < 2; j++)
    {
        for (int i = 0; i < y; i++) lab[i, j] = 2;
    }//обозначаем левую границу (2)
    for (int j = x - 2; j < x; j++)
    {
        for (int i = 0; i < y; i++) lab[i, j] = 2;
    }//обозначаем правую границу (2)


    Random rnd = new Random();
    bool CanMove = true; //если "змейка" может дальше строить ход, то true, иначе false
    while (CanMove == true)
    {
        int nap = rnd.Next(1, 5); //генерируем случайное направление. 1 - вправо, 2 - вверх, 3 - влево, 4 - вниз

        if ((nap == 1) && (lab[yp, xp + 2] == 0) && (used[yp, xp + 2] != 1)) //если направление вправо И в правой клетке пустое пространство И "змейка" там еще не была, то
        {
            lab[yp, xp + 1] = 0; //"ломаем" стену справа
            xp += 2; //переходим в свободную клетку справа
            used[yp, xp] = 1; //находясь в новой клетке запоминаем, что мы в ней были, чтобы не попадать в неё снова
            xused[numused] = xp; //запоминаем координату Х этой точки, чтобы потом к ней можно было вернуться
            yused[numused] = yp; //запоминаем координату У этой точки, чтобы потом к ней можно было вернуться
            numused++; //переходим к следующей точке, но заполняться она уже будет не тут, просто выходим из прошлой, так как мы уже получили её Х и У
        }
        if ((nap == 4) && (lab[yp + 2, xp] == 0) && (used[yp + 2, xp] != 1)) //то же самое, что и для направления вправо(1) только теперь вниз(4)
        {
            lab[yp + 1, xp] = 0;
            yp += 2;
            used[yp, xp] = 1;
            xused[numused] = xp;
            yused[numused] = yp;
            numused++;
        }
        if ((nap == 3) && (lab[yp, xp - 2] == 0) && (used[yp, xp - 2] != 1)) //то же самое, что и для направления вправо(1) только теперь влево(3)
        {
            lab[yp, xp - 1] = 0;
            xp -= 2;
            used[yp, xp] = 1;
            xused[numused] = xp;
            yused[numused] = yp;
            numused++;
        }
        if ((nap == 2) && (lab[yp - 2, xp] == 0) && (used[yp - 2, xp] != 1)) //то же самое, что и для направления вправо(1) только теперь вверх(2)
        {
            lab[yp - 1, xp] = 0;
            yp -= 2;
            used[yp, xp] = 1;
            xused[numused] = xp;
            yused[numused] = yp;
            numused++;
        }

        if ((lab[yp + 2, xp] == 2 || used[yp + 2, xp] == 1) && (lab[yp - 2, xp] == 2 || used[yp - 2, xp] == 1) && (lab[yp, xp + 2] == 2 || used[yp, xp + 2] == 1) && (lab[yp, xp - 2] == 2 || used[yp, xp - 2] == 1))
        //если (снизу граница(2) ИЛИ снизу стена(1)) И (сверху граница(2) ИЛИ сверху стена(1)) И (справа граница(2) ИЛИ справа стена(1)) И (слева граница(2) ИЛИ слева стена(1)) ТО МЫ НЕ МОЖЕМ ДВИГАТЬСЯ, тогда:
        {
            int r = rnd.Next(1, numused); //берем случайную точку лабиринта
            xp = xused[r]; //переходим в неё, меняя кординату игрока по Х
            yp = yused[r]; //переходим в неё, меняя кординату игрока по У
            randomused++; //увеличиваем счетчик переходов к случайным точкам на 1;
                          //таким образом после всего вышеперечисленного мы начинаем строить новую "змейку" со случайной точки, чтобы построить новые ходы в лабиринте
        }
        if (randomused == x * y) CanMove = false; //если мы уже достаточно много раз строили "змейку" в случайных точках, то, скорее всего, лабиринт уже построен. на самом деле тут можно точно посчитать нужно количество переходов, но так как лабиринт строится мгновенно, то можно взять просто площадь лабиринта как ограничение по переходам.
    }


    int[,] labprov = new int[y, x];
    for (int i = 0; i < y; i++)
    {
        for (int j = 0; j < x; j++)
        {
            labprov[i, j] = lab[i, j];
        }
    }

    xp = x - 3;
    yp = y - 3;


    bool prov = true;
    while (prov == true)
    {
        int nap = rnd.Next(1, 5);
        if (nap == 1 && labprov[yp, xp + 1] == 0)
        {
            labprov[yp, xp] = -1;
            xp++;
        }
        else if (nap == 3 && labprov[yp, xp - 1] == 0)
        {
            labprov[yp, xp] = -1;
            xp--;
        }
        else if (nap == 2 && labprov[yp - 1, xp] == 0)
        {
            labprov[yp, xp] = -1;
            yp--;
        }
        else if (nap == 4 && labprov[yp + 1, xp] == 0)
        {
            labprov[yp, xp] = -1;
            yp++;
        }
        if (xp == 2 && yp == 2)
        {
            labprov[yp, xp] = -1;
            prov = false;
        }
        else if (labprov[yp + 1, xp] != 0 && labprov[yp - 1, xp] != 0 && labprov[yp, xp + 1] != 0 && labprov[yp, xp - 1] != 0)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    labprov[i, j] = lab[i, j];
                }
            }
            xp = x - 3;
            yp = y - 3;
        }

    }

    int nmin = Convert.ToInt32(Math.Sqrt(x * y));
    while (nmin > 0)
    {
        int minx = rnd.Next(2, x - 2);
        int miny = rnd.Next(2, x - 2);
        if (labprov[miny, minx] == 0)
        {
            lab[miny, minx] = -2;
            nmin--;
        }
    }

    lab[2, 2] = 6;
    lab[y - 3, x - 3] = 9;
    for (int i = 0; i < y; i++) //выводим лабиринт на экран
    {
        for (int j = 0; j < x; j++)
        {
            if (lab[i, j] == 1) Console.ForegroundColor = ConsoleColor.Black; //черный цвет в случае, если это стена
            if (lab[i, j] == 0) Console.ForegroundColor = ConsoleColor.White; //белый цвет в случае, если это проход
            if (lab[i, j] == 2) Console.ForegroundColor = ConsoleColor.DarkGray; //серый цвет в случае, если это граница
            if (lab[i, j] == -1) Console.ForegroundColor = ConsoleColor.Green;
            if (lab[i, j] == -2) Console.ForegroundColor = ConsoleColor.Red;
            if (lab[i, j] == 6) Console.ForegroundColor = ConsoleColor.Blue;
            if (lab[i, j] == 9) Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("██");
            //Console.Write(labprov[i, j]); //в случае вывода чисел вместо цветных пикселей
            //Console.Write(' '); //в случае вывода чисел вместо цветных пикселей

        }
        Console.WriteLine();
    }

    xp = 2;
    yp = 2;
    int kursy = 2;
    int kursx = 4;
    bool winorloose = false;
    while (winorloose == false)
    {
        var ch = Console.ReadKey(true).Key;
        switch (ch)
        {
            case ConsoleKey.D:
                if (lab[yp, xp + 1] == 0)
                {
                    lab[yp, xp] = 0;
                    xp++;
                    lab[yp, xp] = 6;
                    Console.SetCursorPosition(kursx, kursy);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("██");
                    kursx += 2;
                    Console.SetCursorPosition(kursx, kursy);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("██");
                }
                else if (lab[yp, xp + 1] == -2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lose");
                    winorloose = true;
                }
                else if (lab[yp, xp + 1] == 9)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You win");
                    winorloose = true;
                }
                break;
            case ConsoleKey.A:
                if (lab[yp, xp - 1] == 0)
                {
                    lab[yp, xp] = 0;
                    xp--;
                    lab[yp, xp] = 6;
                    Console.SetCursorPosition(kursx, kursy);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("██");
                    kursx -= 2;
                    Console.SetCursorPosition(kursx, kursy);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("██");
                }
                else if (lab[yp, xp - 1] == -2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lose");
                    winorloose = true;
                }
                else if (lab[yp, xp - 1] == 9)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You win");
                    winorloose = true;
                }
                break;
            case ConsoleKey.W:
                if (lab[yp - 1, xp] == 0)
                {
                    lab[yp, xp] = 0;
                    yp--;
                    lab[yp, xp] = 6;
                    Console.SetCursorPosition(kursx, kursy);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("██");
                    kursy--;
                    Console.SetCursorPosition(kursx, kursy);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("██");
                }
                else if (lab[yp - 1, xp] == -2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lose");
                    winorloose = true;
                }
                else if (lab[yp - 1, xp] == 9)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You win");
                    winorloose = true;
                }
                break;
            case ConsoleKey.S:
                if (lab[yp + 1, xp] == 0)
                {
                    lab[yp, xp] = 0;
                    yp++;
                    lab[yp, xp] = 6;
                    Console.SetCursorPosition(kursx, kursy);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("██");
                    kursy++;
                    Console.SetCursorPosition(kursx, kursy);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("██");
                }
                else if (lab[yp + 1, xp] == -2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lose");
                    winorloose = true;
                }
                else if (lab[yp + 1, xp] == 9)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You win");
                    winorloose = true;
                }
                break;
        }
    }
}
if (nowchoosed == 5)
{
    Console.Clear();
    Console.CursorVisible = false; //убираем курсор

    int xfield = 10; // размер поля по X с учетом границ
    int yfield = 10; // размер поля по Y с учетом границ
    int gamespeed = 200; // длительность задержки в мс
    bool FieldReady = false; // проверка на то, сгенерировалось ли наше поле
    int playerx = 1; // координаты игрока ( курсора ) по Х
    int playery = 1; // координаты игрока ( курсора ) по У
    int c = 0; // просто счетчик


    bool[,] destroy = new bool[yfield + 1, xfield + 1];

    int[,] field = new int[yfield + 1, xfield + 1]; // объявляем поле
    for (int i = 0; i < yfield; i++) field[i, xfield - 1] = -1; // делаем границы. в графической части это будет серый квадрат, а на самом деле это будут -1
    for (int i = 0; i < xfield; i++) field[yfield - 1, i] = -1;
    for (int i = 0; i < yfield; i++) field[i, 0] = -1;
    for (int i = 0; i < xfield; i++) field[0, i] = -1;
    Random rnd = new Random();

    int col; // переменная, в которой будет храниться цвет шарика
    void Colour() // при вызове этого метода, наш цвет будет меняться на тот, на какую клетку мы попали. ( например при прохождении массива field[i,j] = 2, значит запоминаем этот цвет col = field[i,j]; Colour(). после использования этого метода можно выводить и саму ячейку, и она будет нужного цвета
    {
        if (col == 0) Console.ForegroundColor = ConsoleColor.Black;
        if (col == 1) Console.ForegroundColor = ConsoleColor.Yellow;
        if (col == 2) Console.ForegroundColor = ConsoleColor.Blue;
        if (col == 3) Console.ForegroundColor = ConsoleColor.Red;
        if (col == 4) Console.ForegroundColor = ConsoleColor.Green;
        if (col == 5) Console.ForegroundColor = ConsoleColor.Magenta;
        if (col == 6) Console.ForegroundColor = ConsoleColor.Cyan;
    }
    for (int i = 1; i < yfield - 1; i++) // заполняем всё наше пространство случайными числами, которые на самом деле выступают цветами ( игнорируя границы!! )
    {
        for (int j = 1; j < xfield - 1; j++) field[i, j] = rnd.Next(1, 6);
    }


    for (int i = 0; i < yfield; i++) // выводим наше поле вместе с границами
    {
        for (int j = 0; j < xfield; j++) if (field[i, j] == -1) // если граница - выводим █
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("█");
            }
            else // иначе - ноль того цвета, номер которого в поле
            {
                col = field[i, j];
                Colour();
                Console.Write('0');
            }
        Console.WriteLine();

    }
    void Fall() // метод для "приземления" нулей
    {
        for (int j = 1; j < xfield - 1; j++)
        {
            for (int u = 0; u < 100; u++) // повторяем 100 раз, чтобы наверняка все нули упали
            {
                for (int i = yfield - 2; i > 0; i--)
                {
                    if (field[i + 1, j] == 0) // если под числом есть пустое пространство ( 0 ) - опускаем его на 1 вниз
                    {
                        field[i + 1, j] = field[i, j];
                        Draw(i + 1, j); // этот метод описан немного ниже. он просто обновляет в поле ячейку, которую мы вписали в метод
                        field[i, j] = 0;
                        Draw(i, j);
                    }
                }
            }
        }
    }
    void Draw(int ii, int jj) // этот метод обновляет в поле ячейку, которую мы вписали в метод
    {
        Console.SetCursorPosition(jj, ii); // ставим туда курсор
        col = field[ii, jj]; // меняем цвет
        Colour();
        Console.Write('0'); // рисуем ноль такого цвета
    }


    while (FieldReady == false) // повторяем следующие действия до тех пор, пока поле не будет готово для игры ( не будет 2+ одинаковых цветов в ряд, строку и т.д )
    {
        for (int i = 1; i < yfield - 1; i++)
        {
            for (int j = 1; j < xfield - 1; j++)
            {
                if (field[i, j] != 0)
                {
                    if (field[i, j] == field[i, j + 1] && field[i, j] == field[i, j - 1]) // проверяем 3 в ряд
                    {
                        field[i, j] = 0; // уничтожаем центральное число ( превращаем в 0 ), потом боковые. и рисуем их, чтобы увидеть их уничтожение
                        Draw(i, j);
                        field[i, j + 1] = 0;
                        Draw(i, j + 1);
                        field[i, j - 1] = 0;
                        Draw(i, j - 1);
                        Fall(); // "приземляем" поле, чтобы пустые ячейки заполнились теми, что выше


                    }
                    if (field[i, j] == field[i + 1, j] && field[i, j] == field[i - 1, j]) // проверяем 3 в столбик, алгоритм тот же, что и в строку
                    {
                        field[i, j] = 0;
                        Draw(i, j);
                        field[i + 1, j] = 0;
                        Draw(i + 1, j);
                        field[i - 1, j] = 0;
                        Draw(i - 1, j);
                        Fall();
                    }
                }
            }
        }


        for (int i = 1; i < yfield - 1; i++) // тут мы проверяем, готово ли наше поле к игре ( нет ли у нас пустого пространства. все 3 в ряд и в столбик уничтожаются выше, поэтому проверять не нужно )
        {
            for (int j = 1; j < xfield - 1; j++)
            {
                if (field[i, j] == 0) c++;
            }
        }
        if (c == 0) FieldReady = true;
        c = 0;



        for (int i = 1; i < yfield - 1; i++) // заполняем образовавшиеся сверху пустые пространства новыми случайными числами и рисуем их. внутри поля они не сгенерируется, так как перед этим мы "приземлили" всё
        {
            for (int j = 1; j < xfield - 1; j++)
            {
                if (field[i, j] == 0) field[i, j] = rnd.Next(1, 6);
                Draw(i, j);
            }
        }
    }

    bool game = true;

    // ВСЁ ЧТО БЫЛО ВЫШЕ, ЭТО ПРОСТО ГЕНЕРАЦИЯ УРОВНЯ. ТАЙМЕР И ОЧКИ ЗАПУСТЯТСЯ ТОЛЬКО ПОСЛЕ ЭТОЙ СТРОКИ

    while (game == true)
    {

        bool move = false;


        for (int o = 0; o < 100; o++)
        {
            for (int i = 1; i < yfield - 1; i++)
            {
                for (int j = 1; j < xfield - 1; j++)
                {
                    if (field[i, j] != 0)
                    {
                        if (field[i, j] == field[i, j + 1] && field[i, j] == field[i, j - 1])
                        {
                            destroy[i, j] = true;
                            destroy[i, j + 1] = true;
                            destroy[i, j - 1] = true;
                        }
                        if (field[i, j] == field[i + 1, j] && field[i, j] == field[i - 1, j])
                        {
                            destroy[i, j] = true;
                            destroy[i + 1, j] = true;
                            destroy[i - 1, j] = true;
                        }
                    }
                }
            }
            for (int i = 1; i < yfield - 1; i++)
            {
                for (int j = 0; j < xfield - 1; j++) if (destroy[i, j] == true)
                    {
                        field[i, j] = 0;
                        Draw(i, j);
                        Thread.Sleep(gamespeed);
                        destroy[i, j] = false;
                    }
            }
            Fall();

            for (int i = 1; i < yfield - 1; i++) // тем же алгоритмом заполняем пустые ячейки, которые образовались в последствии "приземления"
            {
                for (int j = 1; j < xfield - 1; j++)
                {
                    if (field[i, j] == 0)
                    {
                        field[i, j] = rnd.Next(1, 6);
                    }
                    Draw(i, j);
                }
            }
        }


        while (move == false && game == true) // цикл выполняется до тех пор, пока мы не походим
        {
            Console.SetCursorPosition(playerx, playery); // переходим в последнее место на поле, где был игрок
            Console.CursorVisible = true; // включаем курсор, чтобы было видно, где мы сейчас
            var x = Console.ReadKey(true).Key; // считываем первое нажатие
            switch (x)
            {
                case ConsoleKey.A: if (playerx - 1 > 0) playerx--; break; // A,D,W,S нужны просто для перемещения по полю
                case ConsoleKey.D: if (playerx + 1 < xfield - 1) playerx++; break;
                case ConsoleKey.W: if (playery - 1 > 0) playery--; break;
                case ConsoleKey.S: if (playery + 1 < yfield - 1) playery++; break;
                case ConsoleKey.K: // нажатие К значит, что сейчас мы попытаемся поменять число, на котором мы стоим с другим
                    var xx = Console.ReadKey(true).Key; // считываем второе нажатие
                    switch (xx)
                    {
                        case ConsoleKey.A: // хотим поменять с числом слева
                            if (playerx - 1 > 0) // проверяяем, не выходит ли за границы
                            {
                                int q = field[playery, playerx]; // запоминаем число, на котором мы стоим чтобы его не потерять
                                field[playery, playerx] = field[playery, playerx - 1]; // меняем наше поле на то, что было слева
                                Draw(playery, playerx); // выводим его
                                field[playery, playerx - 1] = q; // меняем поле слева на наше, которое мы запомнили в переменной q
                                Draw(playery, playerx - 1); // выводим
                                move = true; // запоминаем, что мы сделали шаг, чтобы выйти из режима хода
                                Console.CursorVisible = false; // выключаем курсор
                            }
                            break;
                        case ConsoleKey.D:
                            if (playerx + 1 < xfield - 1)
                            {
                                int q = field[playery, playerx];
                                field[playery, playerx] = field[playery, playerx + 1];
                                Draw(playery, playerx);
                                field[playery, playerx + 1] = q;
                                Draw(playery, playerx + 1);
                                move = true;
                                Console.CursorVisible = false;
                            }
                            break;
                        case ConsoleKey.S:
                            if (playery + 1 < yfield - 1)
                            {
                                int q = field[playery, playerx];
                                field[playery, playerx] = field[playery + 1, playerx];
                                Draw(playery, playerx);
                                field[playery + 1, playerx] = q;
                                Draw(playery + 1, playerx);
                                move = true;
                                Console.CursorVisible = false;
                            }
                            break;
                        case ConsoleKey.W:
                            if (playery - 1 > 0)
                            {
                                int q = field[playery, playerx];
                                field[playery, playerx] = field[playery - 1, playerx];
                                Draw(playery, playerx);
                                field[playery - 1, playerx] = q;
                                Draw(playery - 1, playerx);
                                move = true;
                                Console.CursorVisible = false;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
if (nowchoosed == 6)
{
    Console.Clear();
    Console.SetWindowSize(30, 15);
    Console.SetBufferSize(30, 15);

    //робимо поле 12 на 12, у якому 0 - пустий простір, 9 - бортики, 1 - місця, на яких побував кінь. сам кінь - 9 
    int[,] GameField = new int[12, 12];

    for (int i = 0; i < 12; i++)
    {
        for (int j = 0; j < 12; j++) GameField[i, j] = 9;
    }
    for (int i = 2; i < 10; i++)
    {
        for (int j = 2; j < 10; j++) GameField[i, j] = 0;
    }
    GameField[2, 9] = 1; // одразу заповнюємо, бо тут кінь стоїть за замовчуванням
                         //

    int xhorse = 9;
    int yhorse = 2;
    int score = 1;
    int maxscore = 1;

    bool wpressed = false; // змінна для того, щоб запам'ятати статус кнопки
    bool apressed = false;
    bool spressed = false;
    bool dpressed = false;


    void FieldPrint() // оновлення поля гри, щоб після зміни даних у ньому їх можна було побачити
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Use w,a,s,d to move");
        Console.WriteLine();
        for (int i = 2; i < 10; i++)
        {
            for (int j = 2; j < 10; j++)
            {
                if (i == yhorse && j == xhorse) Console.ForegroundColor = ConsoleColor.DarkGreen;
                else if (GameField[i, j] == 1 && i % 2 == j % 2) Console.ForegroundColor = ConsoleColor.DarkRed;
                else if (GameField[i, j] == 1 && i % 2 != j % 2) Console.ForegroundColor = ConsoleColor.Red;
                else if (i % 2 == j % 2) Console.ForegroundColor = ConsoleColor.DarkGray;
                else Console.ForegroundColor = ConsoleColor.White;
                if ((i == yhorse + 2 && j == xhorse && (spressed == true)) || // для того, щоб було видно напрямок, коли натискаємо w/a/s/d
                    (i == yhorse - 2 && j == xhorse && (wpressed == true)) ||
                    (i == yhorse && j == xhorse - 2 && (apressed == true)) ||
                    (i == yhorse && j == xhorse + 2 && (dpressed == true)))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("┼┼");
                }
                else Console.Write("██");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"{64 - score} left");
        Console.WriteLine($"Your max score is {maxscore}");
    }
    FieldPrint();


    bool game = true;
    while (game == true)
    {
        Console.CursorVisible = false; // відключаємо курсор у консолі
        var key1 = Console.ReadKey(true).Key; // зчитуємо перше натискання кнопки на клавіатурі
        if (key1 == ConsoleKey.S)
        {
            spressed = true;
            FieldPrint(); // оновлюємо, щоб на полі було видно, що ми нажали цю кнопку
            var key2 = Console.ReadKey(true).Key; // зчитуємо друге натискання кнопки на клавіатурі
            if (key2 == ConsoleKey.A)
            {
                if (GameField[yhorse + 2, xhorse - 1] != 9 && GameField[yhorse + 2, xhorse - 1] != 1) // якщо ми не виходимо за поле (9) та якщо тут ще не стояв кінь (1)
                {
                    Task.Run(() => Console.Beep(600, 200)); // програвання звуку при пересуванні
                    yhorse += 2; // координати коня змінюються
                    xhorse--;
                    GameField[yhorse, xhorse] = 1; // додаємо інформацію на поле про те, що тут вже стояв кінь
                    score++; // збільшуємо статистику наших пересувань на 1
                    FieldPrint();
                }
                else Task.Run(() => Console.Beep(400, 200)); // якщо виходимо за поле або тут був кінь, програється інший звук
            }
            if (key2 == ConsoleKey.D)
            {
                if (GameField[yhorse + 2, xhorse + 1] != 9 && GameField[yhorse + 2, xhorse + 1] != 1)
                {
                    Task.Run(() => Console.Beep(600, 200));
                    yhorse += 2;
                    xhorse++;
                    GameField[yhorse, xhorse] = 1;
                    score++;
                    FieldPrint();
                }
                else Task.Run(() => Console.Beep(400, 200));
            }
            spressed = false; // очищуємо статус кнопки та оновлюємо поле
            FieldPrint();
        }

        if (key1 == ConsoleKey.A)
        {
            apressed = true;
            FieldPrint();
            var key2 = Console.ReadKey(true).Key;
            if (key2 == ConsoleKey.S)
            {
                if (GameField[yhorse + 1, xhorse - 2] != 9 && GameField[yhorse + 1, xhorse - 2] != 1)
                {
                    Task.Run(() => Console.Beep(600, 200));
                    yhorse++;
                    xhorse -= 2;
                    GameField[yhorse, xhorse] = 1;
                    score++;
                    FieldPrint();
                }
                else Task.Run(() => Console.Beep(400, 200));
            }
            if (key2 == ConsoleKey.W)
            {
                if (GameField[yhorse - 1, xhorse - 2] != 9 && GameField[yhorse - 1, xhorse - 2] != 1)
                {
                    Task.Run(() => Console.Beep(600, 200));
                    yhorse--;
                    xhorse -= 2;
                    GameField[yhorse, xhorse] = 1;
                    score++;
                    FieldPrint();
                }
                else Task.Run(() => Console.Beep(400, 200));
            }
            apressed = false;
            FieldPrint();
        }
        if (key1 == ConsoleKey.W)
        {
            wpressed = true;
            FieldPrint();
            var key2 = Console.ReadKey(true).Key;
            if (key2 == ConsoleKey.A)
            {
                if (GameField[yhorse - 2, xhorse - 1] != 9 && GameField[yhorse - 2, xhorse - 1] != 1)
                {
                    Task.Run(() => Console.Beep(600, 200));
                    yhorse -= 2;
                    xhorse--;
                    GameField[yhorse, xhorse] = 1;
                    score++;
                    FieldPrint();
                }
                else Task.Run(() => Console.Beep(400, 200));
            }
            if (key2 == ConsoleKey.D)
            {
                if (GameField[yhorse - 2, xhorse + 1] != 9 && GameField[yhorse - 2, xhorse + 1] != 1)
                {
                    Task.Run(() => Console.Beep(600, 200));
                    yhorse -= 2;
                    xhorse++;
                    GameField[yhorse, xhorse] = 1;
                    score++;
                    FieldPrint();
                }
                else Task.Run(() => Console.Beep(400, 200));
            }
            wpressed = false;
            FieldPrint();
        }
        if (key1 == ConsoleKey.D)
        {
            dpressed = true;
            FieldPrint();
            var key2 = Console.ReadKey(true).Key;
            if (key2 == ConsoleKey.W)
            {
                if (GameField[yhorse - 1, xhorse + 2] != 9 && GameField[yhorse - 1, xhorse + 2] != 1)
                {
                    Task.Run(() => Console.Beep(600, 200));
                    yhorse--;
                    xhorse += 2;
                    GameField[yhorse, xhorse] = 1;
                    score++;
                    FieldPrint();
                }
                else Task.Run(() => Console.Beep(400, 200));
            }
            if (key2 == ConsoleKey.S)
            {
                if (GameField[yhorse + 1, xhorse + 2] != 9 && GameField[yhorse + 1, xhorse + 2] != 1)
                {
                    Task.Run(() => Console.Beep(600, 200));
                    yhorse++;
                    xhorse += 2;
                    GameField[yhorse, xhorse] = 1;
                    score++;
                    FieldPrint();
                }
                else Task.Run(() => Console.Beep(400, 200));
            }
            dpressed = false;
            FieldPrint();
        }
        // перевіряємо, чи може наш кінь пересуватись, чи на його шляху є тільки (9) або (1). якщо ні - поразка
        if ((GameField[yhorse + 2, xhorse + 1] == 1 || GameField[yhorse + 2, xhorse + 1] == 9) &&
            (GameField[yhorse + 2, xhorse - 1] == 1 || GameField[yhorse + 2, xhorse - 1] == 9) &&
            (GameField[yhorse - 2, xhorse - 1] == 1 || GameField[yhorse - 2, xhorse - 1] == 9) &&
            (GameField[yhorse - 2, xhorse + 1] == 1 || GameField[yhorse - 2, xhorse + 1] == 9) &&

            (GameField[yhorse - 1, xhorse + 2] == 1 || GameField[yhorse - 1, xhorse + 2] == 9) &&
            (GameField[yhorse - 1, xhorse - 2] == 1 || GameField[yhorse - 1, xhorse - 2] == 9) &&
            (GameField[yhorse + 1, xhorse - 2] == 1 || GameField[yhorse + 1, xhorse - 2] == 9) &&
            (GameField[yhorse + 1, xhorse + 2] == 1 || GameField[yhorse + 1, xhorse + 2] == 9))
        {
            FieldPrint();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("YOU LOSE!!!!!!!!!!");
            Console.Beep(1319, 50);
            Console.Beep(1244, 50);
            Console.Beep(1175, 50);

            Console.ForegroundColor = ConsoleColor.White;
            game = false;
            if (score > maxscore) maxscore = score; // якщо це рекорд - записуємо

            Console.WriteLine();
            Console.Write("Try again?(yes/no): ");
            Console.CursorVisible = true; // включаємо курсор, щоб ми змогли вписати відповідь на запитання
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                game = true; // відміняємо закінчення гри, щоб while було true
                for (int i = 2; i < 10; i++) // обнуляємо старе поле
                {
                    for (int j = 2; j < 10; j++) GameField[i, j] = 0;
                }
                xhorse = 9; // знову відправляємо на початкові координати
                yhorse = 2;
                GameField[yhorse, xhorse] = 1;
                score = 1; // оновлюємо наш рахунок
                FieldPrint();

            }

        }
        //

        // якщо ми зробили 63 кроки, то це означає, що ми змогли пройти все поле, тому це перемога
        if (score == 64)
        {
            FieldPrint();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("YOU WIN!!!!!!!!!!");
            Console.Beep(1047, 100);
            Console.Beep(1318, 100);
            Console.Beep(1568, 100);
            Console.ForegroundColor = ConsoleColor.White;
            game = false;
            if (score > maxscore) maxscore = score;


            Console.WriteLine();
            Console.Write("Try again?(yes/no): ");
            Console.CursorVisible = true;
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                game = true;
                for (int i = 2; i < 10; i++)
                {
                    for (int j = 2; j < 10; j++) GameField[i, j] = 0;
                }
                xhorse = 9;
                yhorse = 2;
                GameField[yhorse, xhorse] = 1;
                score = 1;
                FieldPrint();

            }
        }
    }
}
if (nowchoosed == 7)
{
    Console.Clear();
    bool[,] field_is_used = new bool[3, 3]; // масив 3*3 у якому зберігається інформація про те, використане поле чи воно пусте
    for (int i = 0; i < 3; i++) // заповнюємо цей масив інформацією про те, що ніяка комірка не була використана
    {
        for (int j = 0; j < 3; j++) field_is_used[i, j] = false;
    }
    int[,] field = new int[3, 3]; // основне поле, у якому проходить гра. (-1) - ще не заповнене, 1 - походив гравець, 0 - походив бот
    for (int i = 0; i < 3; i++) // за замовчуванням поле пусте, заповнюэмо
    {
        for (int j = 0; j < 3; j++) field[i, j] = -1;
    }

    int x_player_position = 0; // позиція гравця за Х
    int y_player_position = 0; // позиція гравця за У
    int x_bot_position = 0; // позиція бота за Х
    int y_bot_position = 0; // позиція бота за У

    int k = 0; // лічильник, який буде рахувати кількість хрестиків та ноликів для того, щоб бот зміг зробити правильний хід
    int k2dif = 0;

    bool player_made_step = false; // інформація про те, чи зробив гравець хід
    bool bot_made_step = false; // інформація про те, чи зробив бот хід

    bool win = false; // флаг для того, щоб зберегти інформацію про те, що гравець переміг
    bool lose = false; // флаг для того, щоб зберегти інформацію про те, що гравець програв
    bool draw = false;
    bool warning = false; // флаг для того, щоб зберегти інформацію про те, що гравець намагається поставити хрестик на зайняте поле


    void FieldPrint() // метод, який ми будемо кожного разу визивати для того, щоб оновити поле
    {
        Console.Clear(); // стираємо все, що було в консолі, щоб воно не дублювалося
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Щоб пересуватися, використовуйте W,A,S,D");
        Console.WriteLine("Щоб зробити хiд натиснiть P");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        for (int i = 0; i < 3; i++) // перевіряємо кожну комірку поля
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == y_player_position && j == x_player_position && field[i, j] == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"+ "); // виводимо "+" щоб показати поточне місцезнаходження курсору нашого гравця
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (field[i, j] == -1) Console.Write("- "); // якщо поле пусте, то виводимо "-"
                else if (i == y_player_position && j == x_player_position && field[i, j] != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (field[i, j] == 1) Console.Write("x ");
                    if (field[i, j] == 0) Console.Write("o ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    if (field[i, j] == 1) Console.Write("x ");
                    if (field[i, j] == 0) Console.Write("o ");
                } // якщо гравець чи бот вже ходили, то тут буде виводитися 1 та 0
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        if (warning == true) // разом з полем нам на екран виведе попередження, якщо ми будемо намагатися поставити хрестик на зайняте місце
        {
            Console.ForegroundColor = ConsoleColor.Red; // змінюємо колір тексту, щоб надпис був червоний
            Console.WriteLine("Ця клiтинка вже використана!");
            Console.ForegroundColor = ConsoleColor.White; // вертаємо білий колір
        }
        if (win == true) // разом з полем нам на екран виведе повідомлення про перемогу, якщо ми переможемо
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ви виграли!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        if (lose == true) // разом з полем нам на екран виведе повідомлення про поразку, якщо ми програємо
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ви програли!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        if (draw == true && win == false && lose == false) // разом з полем нам на екран виведе повідомлення про поразку, якщо ми програємо
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Нiчия!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    bool gameactive = true; // флаг для того, щоб по закінченню гри вона зупинялась ( не спрацював наступний while )

    int level_difficulty = -1; // складність бота, спочатку вона не визначена (-1)
    while (level_difficulty != 1 && level_difficulty != 2 && level_difficulty != 3) // цикл буде повторюватися до тих пір, поки гравець не вибере складність
    {
        Console.Write("Виберiть рiвень складностi бота (1 - легко, 2 - нормально, 3 - важко): ");
        level_difficulty = Convert.ToInt32(Console.ReadLine());
        if (level_difficulty != 1 && level_difficulty != 2 && level_difficulty != 3)
        {
            Console.Clear();
            Console.WriteLine("Помилка!");
        }
    }
    Console.CursorVisible = false; // прибираємо курсор, щоб не заважав
    FieldPrint(); // виводимо поле, яке в нас зараз є
    while (gameactive == true)
    {
        while (player_made_step == false && win == false && lose == false && draw == false) // якщо гравець досі не походив та гра не закінчена
        {
            var move = Console.ReadKey(true).Key; // зчитуємо натискання клавіші на клавіатурі
            switch (move) // перевіряємо, яка клавіша була натиснута
            {
                case ConsoleKey.D: // якщо це Д, то ми пересуваємо наш курсор вправо, для цього виконуємо наступні дії
                    if (x_player_position + 1 <= 2) x_player_position++; // if потрібен для того, щоб не вийти за рамки поля курсором
                    FieldPrint(); // знову оновлюємо поле, щоб побачити зміни ( ми побачимо пересування курсору, тобто "+"
                    break;
                case ConsoleKey.A: // для кожної клавіші повторюємо те саме
                    if (x_player_position - 1 >= 0) x_player_position--;
                    FieldPrint();
                    break;
                case ConsoleKey.W:
                    if (y_player_position - 1 >= 0) y_player_position--;
                    FieldPrint();
                    break;
                case ConsoleKey.S:
                    if (y_player_position + 1 <= 2) y_player_position++;
                    FieldPrint();
                    break;
                case ConsoleKey.P: // при натисканні цієї клавіші ми ставимо хрестик на місце курсора
                    if (field[y_player_position, x_player_position] != 0 && field[y_player_position, x_player_position] != 1) // якщо поле ще не зайняте
                    {
                        field[y_player_position, x_player_position] = 1; // ставимо хрестик
                        field_is_used[y_player_position, x_player_position] = true; // запам'ятовуємо, що ця комірка вже зайнята хрестиком, щоб бот не зміг туди ставити
                        player_made_step = true; // гравець зробив хід, теперь while зупиниться, та буде хід бота
                    }
                    else warning = true; // якщо ми нажали Р и при цьому стояли на зайнятій комірці, то ми фіксуємо це, щоб зробити попередження
                    FieldPrint(); // оновлюємо поле, щоб побачити попередження ( воно прописане всередині методу )
                    warning = false; // відключаємо попередження щоб воно не заважало
                    break;
            }
        }// хід ігрока
        { // перевірка на перемогу
            for (int i = 0; i < 3; i++) // перевіряємо, чи виграли ми ( 3 варіанти по горизонталі )
            {
                if (field[i, 0] == 1 && field[i, 1] == 1 && field[i, 2] == 1) // якщо всі хрестики, тобто одинички
                {
                    win = true; // фіксуємо перемогу
                    gameactive = false; // закінчуємо гру
                    x_player_position = -1; // прибираємо гравця з поля, щоб можна було побачити всі хрестики та нолики ( інакше замість якогось буде стояти "+")
                    y_player_position = -1;
                    FieldPrint(); // оновлюємо поле, щоб побачити результат
                }
            }
            for (int j = 0; j < 3; j++) // перевіряємо, чи виграли ми ( 3 варіанти по вертикалі )
            {
                if (field[0, j] == 1 && field[1, j] == 1 && field[2, j] == 1)
                {
                    win = true;
                    gameactive = false;
                    x_player_position = -1;
                    y_player_position = -1;
                    FieldPrint();
                }
            }
            if ((field[0, 0] == 1 && field[1, 1] == 1 && field[2, 2] == 1) || (field[0, 2] == 1 && field[1, 1] == 1 && field[2, 0] == 1)) // перевіряємо, чи виграли ми ( залишилися тільки діагоналі )
            {
                win = true;
                gameactive = false;
                x_player_position = -1;
                y_player_position = -1;
                FieldPrint();
            }
        }// перевірка на перемогу
        { // перевірка на нічию
            int nused = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) if (field_is_used[i, j] == true) nused++;
            }
            if (nused == 9)
            {
                draw = true;
                gameactive = false;
                x_player_position = -1;
                y_player_position = -1;
                FieldPrint();
            }
        } // перевірка на нічию
        player_made_step = false; // це для того, щоб після того, як походить бот, нам дозволили знову зробити хід ( запрацював while )
        while (bot_made_step == false && win == false && lose == false && draw == false) // доки бот не походить, цикл буде повторюватися
        {
            if (level_difficulty == 3 || (level_difficulty == 2 && k2dif == 0)) // якщо 2, то завдяки k2dif бот буде думати через раз, а в іншому випадку буде ставити не рандом
            {

                // перевірки для того, щоб бот походив "по-умному"
                for (int i = 0; i < 3; i++) // два нуля по горизонтали
                {
                    if (bot_made_step == false)
                    {
                        k = 0;
                        for (int j = 0; j < 3; j++) if (field[i, j] == 0) k++;
                        if (k == 2)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (field_is_used[i, j] == false)
                                {
                                    field[i, j] = 0;
                                    field_is_used[i, j] = true;
                                    bot_made_step = true;
                                    FieldPrint();
                                }
                            }
                        }
                    }
                } // два нуля по горизонтали

                for (int j = 0; j < 3; j++) // два нуля по вертикали
                {
                    if (bot_made_step == false)
                    {
                        k = 0;
                        for (int i = 0; i < 3; i++) if (field[i, j] == 0) k++;
                        if (k == 2)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (field_is_used[i, j] == false)
                                {
                                    field[i, j] = 0;
                                    field_is_used[i, j] = true;
                                    bot_made_step = true;
                                    FieldPrint();
                                }
                            }
                        }
                    }
                } // два нуля по вертикали
                if (bot_made_step == false) // два нуля на головній діагоналі
                {
                    k = 0;
                    if (field[0, 0] == 0) k++;
                    if (field[1, 1] == 0) k++;
                    if (field[2, 2] == 0) k++;
                    if (k == 2)
                    {
                        if (field_is_used[0, 0] == false)
                        {
                            field[0, 0] = 0;
                            field_is_used[0, 0] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                        if (field_is_used[1, 1] == false)
                        {
                            field[1, 1] = 0;
                            field_is_used[1, 1] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                        if (field_is_used[2, 2] == false)
                        {
                            field[2, 2] = 0;
                            field_is_used[2, 2] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                    }
                } // два нуля на головній діагоналі

                if (bot_made_step == false) // два нуля на побічній діагоналі
                {
                    k = 0;
                    if (field[0, 2] == 0) k++;
                    if (field[1, 1] == 0) k++;
                    if (field[2, 0] == 0) k++;
                    if (k == 2)
                    {
                        if (field_is_used[0, 2] == false)
                        {
                            field[0, 2] = 0;
                            field_is_used[0, 2] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                        if (field_is_used[1, 1] == false)
                        {
                            field[1, 1] = 0;
                            field_is_used[1, 1] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                        if (field_is_used[2, 0] == false)
                        {
                            field[2, 0] = 0;
                            field_is_used[2, 0] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                    }
                } // два нуля на побічній діагоналі


                for (int i = 0; i < 3; i++) // дві одиниці по горизонтали
                {
                    if (bot_made_step == false)
                    {
                        k = 0;
                        for (int j = 0; j < 3; j++) if (field[i, j] == 1) k++;
                        if (k == 2)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (field_is_used[i, j] == false)
                                {
                                    field[i, j] = 0;
                                    field_is_used[i, j] = true;
                                    bot_made_step = true;
                                    FieldPrint();
                                }
                            }
                        }
                    }
                } // дві одиниці по горизонтали

                for (int j = 0; j < 3; j++) // дві одиниці по вертикали
                {
                    if (bot_made_step == false)
                    {
                        k = 0;
                        for (int i = 0; i < 3; i++) if (field[i, j] == 1) k++;
                        if (k == 2)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (field_is_used[i, j] == false)
                                {
                                    field[i, j] = 0;
                                    field_is_used[i, j] = true;
                                    bot_made_step = true;
                                    FieldPrint();
                                }
                            }
                        }
                    }
                } // дві одиниці по вертикали
                if (bot_made_step == false) // дві одиниці на головній діагоналі
                {
                    k = 0;
                    if (field[0, 0] == 1) k++;
                    if (field[1, 1] == 1) k++;
                    if (field[2, 2] == 1) k++;
                    if (k == 2)
                    {
                        if (field_is_used[0, 0] == false)
                        {
                            field[0, 0] = 0;
                            field_is_used[0, 0] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                        if (field_is_used[1, 1] == false)
                        {
                            field[1, 1] = 0;
                            field_is_used[1, 1] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                        if (field_is_used[2, 2] == false)
                        {
                            field[2, 2] = 0;
                            field_is_used[2, 2] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                    }
                } // дві одиниці на головній діагоналі

                if (bot_made_step == false) // дві одиниці на побічній діагоналі
                {
                    k = 0;
                    if (field[0, 2] == 1) k++;
                    if (field[1, 1] == 1) k++;
                    if (field[2, 0] == 1) k++;
                    if (k == 2)
                    {
                        if (field_is_used[0, 2] == false)
                        {
                            field[0, 2] = 0;
                            field_is_used[0, 2] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                        if (field_is_used[1, 1] == false)
                        {
                            field[1, 1] = 0;
                            field_is_used[1, 1] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                        if (field_is_used[2, 0] == false)
                        {
                            field[2, 0] = 0;
                            field_is_used[2, 0] = true;
                            FieldPrint();
                            bot_made_step = true;
                        }
                    }
                } // дві одиниці на побічній діагоналі




                k2dif++; // для того щоб бот в наступний раз не думав, а ходив на рандом

            }
            if (bot_made_step == false)
            {
                Random rnd = new Random();
                x_bot_position = rnd.Next(0, 3); // беремо випадкву комірку в полі по Х та У
                y_bot_position = rnd.Next(0, 3);
                if (field_is_used[y_bot_position, x_bot_position] == false) // при умові, що вона не зайнята
                {
                    field[y_bot_position, x_bot_position] = 0; // бот ставить нолик
                    field_is_used[y_bot_position, x_bot_position] = true; // фіксуємо, що комірка зайнята
                    bot_made_step = true; // запам'ятовуємо, що бот зробив крок
                    FieldPrint(); // оновлюємо поле
                }
                if (k2dif == 1) k2dif--;
            }
        }// хід бота
        bot_made_step = false; // це для того, щоб після того, як походить гравець знову походить, бот зміг знову зробити хід ( запрацював while )
        { // перевірка на програш
            for (int i = 0; i < 3; i++) // перевіряємо, чи ми програли після того, як походив бот ( та сама перевірка, що для перемоги, але тут нулі )
            {
                if (field[i, 0] == 0 && field[i, 1] == 0 && field[i, 2] == 0)
                {
                    lose = true;
                    gameactive = false;
                    x_player_position = -1;
                    y_player_position = -1;
                    FieldPrint();
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (field[0, j] == 0 && field[1, j] == 0 && field[2, j] == 0)
                {
                    lose = true;
                    gameactive = false;
                    x_player_position = -1;
                    y_player_position = -1;
                    FieldPrint();
                }
            }
            if ((field[0, 0] == 0 && field[1, 1] == 0 && field[2, 2] == 0) || (field[0, 2] == 0 && field[1, 1] == 0 && field[2, 0] == 0))
            {
                lose = true;
                gameactive = false;
                x_player_position = -1;
                y_player_position = -1;
                FieldPrint();
            }
        }// перевірка на програш


    }
}