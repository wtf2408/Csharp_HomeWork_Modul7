using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Csharp_HomeWork_Modul7
{
    class Repozitory
    {
        private string path = @"D:\Workers";

        public List<Worker> GetAllWorkers()
        {
            var file = File.ReadAllLines(path);
            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < file.Length; i++)
            {
                var temp = file[i].Split('#');
                workers.Add(new Worker()
                {
                    ID = int.Parse(temp[0]),
                    Date = Convert.ToDateTime(temp[1]),
                    FIO = temp[2],
                    Age = int.Parse(temp[3]),
                    Height = int.Parse(temp[4]),
                    DateBirth = temp[5],
                    PlaceBirth = temp[6]
                }) ;
            }
            return workers;
        }
        public Worker GetWorkerById(int id)
        {
            var workers = GetAllWorkers();
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].ID == id) 
                {
                    return workers[i];
                }
            }
            return workers[0];
        }
        public void DeleteWorker(int id)
        {
            var workers = GetAllWorkers();
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].ID == id)
                {
                    workers.Remove(workers[i]);
                }
            }
            PushToFile(workers);
        }
        public void AddWorker(string worker)
        {
            var workers = GetAllWorkers();
            int id = MaxIndex(workers);
            var temp = worker.Split('#');

            workers.Add(new Worker()
            {
                ID = id + 1,
                Date = DateTime.Now,
                FIO = temp[0],
                Age = int.Parse(temp[1]),
                Height = int.Parse(temp[2]),
                DateBirth = temp[3],
                PlaceBirth = temp[4]
            });

            PushToFile(workers);
        }


        int MaxIndex(List<Worker> workers)
        {
            if (workers.Count != 0)
            {
                int max = 0;
                foreach (var item in workers)
                {
                    if (item.ID > max) max = item.ID;
                }
                return max;
            }
            else return 0;
        }
        void PushToFile(List<Worker> workers)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < workers.Count; i++)
            {
                temp.Add(workers[i].ConvertToString());
            }
            File.WriteAllLines(path, temp);
        }
        public List<Worker> GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            var workers = GetAllWorkers();
            var workersBetweenTwoDates = new List<Worker>();
            int indexFrom = 0, indexTo = 0;
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].Date == dateFrom) indexFrom = i;
                else if (workers[i].Date == dateTo) indexTo = i;
            }
            while ( indexFrom <= indexTo)
            {
                workersBetweenTwoDates.Add(workers[indexFrom]);
                indexFrom++;
            }
            return workersBetweenTwoDates;
        }
    }
}