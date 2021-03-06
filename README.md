# Pacmen

1.Објаснување на апликацијата 

Апликацијата е во стил на познатата игра Pac-Man.Се игра со двајца играчи кои се обидуваат да ги избришат кружниците од нивниот дел на екранот така што ќе поминат над  нив со фигурата Pac-Man,притоа избегнувајќи да допрат било која од двете црни линии кои постојано се движат.Црвениот Pac-Man може да се движи само во границите на големиот син квадрат,додека  синиот Pac-Man е ограничен со црвениот квадрат.Ако фигурата Pac-Man ја премине неговата лева граница се појавува од неговата десна граница(од спротивната страна) и обратно.Истото важи и за горната и долната граница. На Слика 1 е прикажано едно почетно сценарио за изгледот на играта.Се гледа дека црвениот квадрат е поделен на 2 дела од хоризонталната црна линија,па ако сака синиот Pac-Man да премине на другата страна од црната линија треба да ја премине неговата горна граница. 
![image](https://user-images.githubusercontent.com/108064435/175291359-683e0102-b11d-43e9-9d70-326ad165f031.png)

Слика 1 – Почетно сценарио


Штом се притисне на Start и двете фигури Pac-Man почнуваат да се движат,а корисникот може ако сака да им ја смени насоката на движење со притискање на стрелките на тастатурата(за синиот Pac-Man) и копчињата W(нагоре), S(надолу), A(налево) и  D(надесно) за црвениот Pac-Man.Играта се паузира со притискање на Stop.Доколку не му се допаѓа на корисникот почетната позиција на двете црни линии тоа може да го смени со притискање на копчето Nova igra со што се генерира ново почетно сценарио.
Играта завршува доколку било кој Pac-Man се судри со црна линија -што значи тој што не се судрил со црна линија победува или некој од двата квадрати (синиот или црвениот) се испразни од кружници-што значи дека фигурата Pac-Man во празниот квадрат е победник или ако времето е истечено.На слика 2 е прикажано завршно сценарио каде што синиот Pac-Man изгубил бидејќи прв се судрил со црна линија.
![image](https://user-images.githubusercontent.com/108064435/175291810-d3d1506f-d052-4804-9e39-6864d129bd5a.png)

Слика 2-Завршно сценарио на играта каде црвениот Pac-Man е победник

2.Имплементација

Фигурата Pac-Man е претставена со една класа каде што се чуваат границите на нејзиното поле,насоката,информација дали устата е отворена,центарот,радиусот и четка за боење. Важни методи тука се Move() -ја придвижува фигурата Pac-Man на секој настан timer1_Tick() и Draw(Graphics g)-гледа во која насока устата е отворена и соодветно ја исцртува фигурата Pac-Man.

    public class PacMan
    {
        public enum DIRECTION { left,right, up, down };
        public Point position{ get; set; }//the center of the pacman
        public DIRECTION  direction { get; set; }

        public static int  radius  = 20;
        public bool isOpenMouth { get; set; }
        public Brush brush { get; set; }
        public int leftLimit { get; set; }//the left limit of the field where the pacman may walk
        public int rightLimit { get; set; }//the right limit of the field where the pacman may walk
        public int bottomLimit { get; set; }//the bottom limit of the field where the pacman may walk
                                            //the top limit is always 0
        public PacMan(int left,int right,int bottom,Point position,Color color)
        {
            direction=DIRECTION.right;//Initially the head is directed to the right
            isOpenMouth = true;//Initially the mouth is open
            //...
        }

        public void Move()
        {
           //...
        }

        public void Draw(Graphics g)
        {
          //...  
        } 
    } 


За двете црни линии има посебна класа Positioner.Таму се чува нивната пресечна точка (Center) ширина и висина на делот од екранот над кој што се простираат, Random објект за одредување на центарот и за тоа кај кој Pac-Man ќе се падне центарот,два објекти од тип Rectangle наречени horizontal и vertical (со кои ќе се претставуваат црните линии,тука класата Rectangle е искористена затоа што нуди метод intersectsWith() кој е искористен за да се види дали црните линии имаат заеднички точки со правоаголникот во кој е фигурата Pac-Man), брзината на движење (Velocity),аголот под кој ќе почне да се движи(Angle),брзината по X оската(velocity) и брзината по Y оската(velocityY).


Во класата Form1 се чува статички променливи TIMER_INTERVAL(на секои TIMER_INTERVAL милисекунди се повикува timer1_Tick() настанот каде што се бришат кружниците (храната) кои се доволно блиску до некој Pac-Man,се поместуваат движечките фигури,се проверува дали е крај на играта и целата сцена се исцртува од почеток), WORLD_WIDTH(означува колку кружници ќе има еден Pac-Man во еден ред), WORLD_HEIGHT(колку кружници ќе има еден Pac-Man во една колона).Тука се чуваат и границите на двата играчи како променливи од тип Rectangle,листи за чување на храната,трите движечки фигури(pacman1, pacman2 и positioner) и времето кое го имаат играчите за да победат(timeInSeconds).



Детален опис на функцијата Move() од класата PacMan

Во зависност од насоката на главата на PacMan тој се движи за 15 единици десно(на X координатата на неговиот центар се додава value=15),лево(на Х координатата на неговиот центар се одзема value=15),нагоре (на Y координатата на неговиот центар се одзема value=15) и надолу(на Y координатата на неговиот центар се додава value=15).Центарот во програмата се вика position.Притоа се внимава ако ново пресметаната X вредност е поголема од десната граница тогаш се поставува на левата граница(така фигурата PacMan се враќа на почеток) и ако излева од левата граница се поставува на десната граница.Логиката е слична и за координатата Y,горната и долната граница. На крај се менува информацијата за состојбата на устата (ако била отворена се затвора и обратно).

           public void Move()
          {            int value = 15;
            if (direction == DIRECTION.right)
            {
                int newX = position.X + value;
                if (newX > rightLimit) newX = leftLimit;//if it exceeds the right limit of the field put him on the left limit
                position = new Point(newX, position.Y);
            }else if (direction == DIRECTION.left)
            {
                int newX = position.X - value;
                if (newX <leftLimit) newX = rightLimit;
                position = new Point(newX, position.Y);

            }else if (direction == DIRECTION.up)
            {
                int newY = position.Y - value;
                if (newY <0) newY = bottomLimit;
                position = new Point(position.X, newY);
            }
            else
            {
                int newY = position.Y + value;
                if (newY > bottomLimit) newY = 0;
                position = new Point(position.X, newY);
            }
            isOpenMouth = !isOpenMouth;
        }


