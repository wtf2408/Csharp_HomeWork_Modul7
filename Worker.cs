using System;


namespace Csharp_HomeWork_Modul7
{
    struct Worker
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string DateBirth { get; set; }
        public string PlaceBirth { get; set; }


        public string ConvertToString()
        {
            return $"{ID}#{Date}#{FIO}#{Age}#{Height}#{DateBirth}#{PlaceBirth}";
        }
        public string Print()
        {
            return $"{ID,4} {Date,20} {FIO,26} {Age,3} {Height,4} {DateBirth,11} {PlaceBirth, 13}";
        }

    }
}
