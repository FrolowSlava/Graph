using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp4
{
    public class Graph
    {
        public Dictionary<string, Dictionary<string, double>> MainGraph = new Dictionary<string, Dictionary<string, double>>();
        public List<string> Verts = new List<string>();
        public string type;
        public Dictionary<string, int> nov = new Dictionary<string, int>();

        // Конструктор пустой
        public Graph() { }

        // Конструктор только типа графа
        public Graph(string type) { this.type = type; }

        // Конструктор для работы с файлом
        public Graph(string Path, string type)
        {
            using (StreamReader file = new StreamReader(Path))
            {
                try
                {
                    this.type = type;
                    if (type == "t1")
                    {
                        while (!file.EndOfStream)
                        {
                            string Vertex = file.ReadLine();
                            Dictionary<string, double> Link = new Dictionary<string, double>();
                            string LinkString = file.ReadLine();
                            if (String.IsNullOrEmpty(LinkString))
                            {
                                MainGraph.Add(Vertex, Link);

                            }
                            else
                            {
                                char[] c = { ' ' };
                                List<string> Vertexes = LinkString.Split(c, StringSplitOptions.RemoveEmptyEntries).ToList();
                                for (int i = 0; i < Vertexes.Count; i++)
                                {
                                    Link.Add(Vertexes[i], 1);
                                }
                                MainGraph.Add(Vertex, Link);

                            }
                        }
                    }
                    if (type == "t2")
                    {
                        while (!file.EndOfStream)
                        {
                            string Vertex = file.ReadLine();
                            Dictionary<string, double> Link = new Dictionary<string, double>();
                            string LinkString = file.ReadLine();
                            if (String.IsNullOrEmpty(LinkString))
                            {
                                MainGraph.Add(Vertex, Link);

                            }
                            else
                            {
                                char[] c = { ' ' };
                                List<string> VertexesAndWeights = LinkString.Split(c, StringSplitOptions.RemoveEmptyEntries).ToList();
                                for (int i = 0; i < VertexesAndWeights.Count; i += 2)
                                {
                                    Link.Add(VertexesAndWeights[i], double.Parse(VertexesAndWeights[i + 1]));
                                }
                                MainGraph.Add(Vertex, Link);

                            }
                        }
                    }
                    if (type == "t3")
                    {
                        while (!file.EndOfStream)
                        {
                            string Vertex = file.ReadLine();
                            Dictionary<string, double> Link = new Dictionary<string, double>();
                            string LinkString = file.ReadLine();
                            if (String.IsNullOrEmpty(LinkString))
                            {
                                MainGraph.Add(Vertex, Link);

                            }
                            else
                            {
                                char[] c = { ' ' };
                                List<string> Vertexes = LinkString.Split(c, StringSplitOptions.RemoveEmptyEntries).ToList();
                                for (int i = 0; i < Vertexes.Count; i++)
                                {
                                    Link.Add(Vertexes[i], 1);
                                }
                                MainGraph.Add(Vertex, Link);

                            }
                        }
                    }
                    if (type == "t4")
                    {
                        while (!file.EndOfStream)
                        {
                            string Vertex = file.ReadLine();
                            Dictionary<string, double> Link = new Dictionary<string, double>();
                            string LinkString = file.ReadLine();
                            if (String.IsNullOrEmpty(LinkString))
                            {
                                MainGraph.Add(Vertex, Link);

                            }
                            else
                            {
                                char[] c = { ' ' };
                                List<string> VertexesAndWeights = LinkString.Split(c, StringSplitOptions.RemoveEmptyEntries).ToList();
                                for (int i = 0; i < VertexesAndWeights.Count; i += 2)
                                {
                                    Link.Add(VertexesAndWeights[i], double.Parse(VertexesAndWeights[i + 1]));
                                }
                                MainGraph.Add(Vertex, Link);

                            }
                        }
                    }
                }
                catch { }
            }
            Console.WriteLine("Граф успешно создан");
        }

        // Констурктор копирования
        public Graph(Graph graph)
        {
            foreach (var Vertex in graph.MainGraph)
            {
                Dictionary<string, double> Link = new Dictionary<string, double>();
                foreach (var Vertexes in Vertex.Value)
                {
                    Link.Add(Vertexes.Key, Vertexes.Value);
                }
                MainGraph.Add(Vertex.Key, Link);
                this.type = graph.type;

            }

           // Console.WriteLine("Копия графа успешно создана");
        }


        // Вывод графа на консоль
        public void ShowMainGraph()
        {
            foreach (var Vertex in MainGraph)
            {
                Console.Write("{0}: ", Vertex.Key);
                foreach (var Vertexes in Vertex.Value)
                {
                    if (Vertexes.Value == 0)
                    {
                        Console.Write("{0}", Vertexes.Key);
                    }
                    else
                    {
                        Console.Write("{0} ({1}) ", Vertexes.Key, Vertexes.Value);
                    }

                }
                Console.WriteLine();
            }
        }

        // Добавление вершины
        public void AddVertex(string Vertex)
        {
            Dictionary<string, double> Link = new Dictionary<string, double>();
            if (MainGraph.ContainsKey(Vertex))
            {
                Console.WriteLine("Ошибка: Такая вершина уже существует");
            }
            else
            {
                MainGraph.Add(Vertex, Link);
               Console.WriteLine("Новая вершина добавлена успешно");
            }
        }

        // Добавление пути между вершинами
        public void AddWayFromVertexes(string Vertex1, string Vertex2, double Weight)
        {
            if (this.type == "t2")
            {
                if (MainGraph.ContainsKey(Vertex1) && MainGraph.ContainsKey(Vertex2))
                {
                    MainGraph[Vertex1].Add(Vertex2, Weight);
                    MainGraph[Vertex2].Add(Vertex1, Weight);
                   // Console.WriteLine("Ребро успешно создано");
                }
                else
                {
                    Console.WriteLine("Ошибка: нарушено одно из условий:");
                    Console.WriteLine("обе вершины должны быть в графе");
                }
            }
            if (this.type == "t4")
            {
                if (MainGraph.ContainsKey(Vertex1) && MainGraph.ContainsKey(Vertex2))
                {
                    MainGraph[Vertex1].Add(Vertex2, Weight);
                   // Console.WriteLine("Ребро успешно создано");
                }
                else
                {
                    Console.WriteLine("Ошибка: нарушено одно из условий:");
                    Console.WriteLine("обе вершины должны быть в графе");
                }
            }
        }

        public void AddWayFromVertexes(string Vertex1, string Vertex2)
        {
            if (this.type == "t1")
            {
                if (MainGraph.ContainsKey(Vertex1) && MainGraph.ContainsKey(Vertex2))
                {
                    MainGraph[Vertex1].Add(Vertex2, 1);
                    MainGraph[Vertex2].Add(Vertex1, 1);
                    Console.WriteLine("Ребро успешно создано");
                }
                else
                {
                    Console.WriteLine("Ошибка: нарушено одно из условий:");
                    Console.WriteLine(" обе вершины должны быть в графе");
                }
            }
            if (this.type == "t3")
            {
                if (MainGraph.ContainsKey(Vertex1) && MainGraph.ContainsKey(Vertex2))
                {
                    MainGraph[Vertex1].Add(Vertex2, 1);
                    Console.WriteLine("Ребро успешно создано");
                }
                else
                {
                    Console.WriteLine("Ошибка: нарушено одно из условий:");
                    Console.WriteLine(" обе вершины должны быть в графе");
                }
            }
        }

        // Удаление вершины
        public void DeleteVertex(string Vertex)
        {
            Dictionary<string, double> Link = new Dictionary<string, double>();
            if (!MainGraph.ContainsKey(Vertex))
            {
                Console.WriteLine("Ошибка: Такая вершина отсутствует");
            }
            else
            {
                MainGraph.Remove(Vertex);
                foreach (string Vertexes in MainGraph.Keys)
                {
                    if (MainGraph[Vertexes].ContainsKey(Vertex))
                    {
                        MainGraph[Vertexes].Remove(Vertex);
                    }
                }
                Console.WriteLine("Вершина удалена успешно");
            }
        }

        // Удаление пути между вершинами
        public void DeleteWayFromVertexes(string Vertex1, string Vertex2)
        {
            if (this.type == "t1" || this.type == "t2")
            {
                if (MainGraph.ContainsKey(Vertex1) && MainGraph.ContainsKey(Vertex2) && MainGraph[Vertex1].ContainsKey(Vertex2) && MainGraph[Vertex2].ContainsKey(Vertex1))
                {
                    if (MainGraph[Vertex1].ContainsKey(Vertex2) && MainGraph[Vertex2].ContainsKey(Vertex1))
                    {
                        MainGraph[Vertex1].Remove(Vertex2);
                        MainGraph[Vertex2].Remove(Vertex1);
                        Console.WriteLine("Ребро удалено успешно");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: нарушено одно из условий:");
                    Console.WriteLine(" обе вершины должны быть в графе или такого ребра не существует");
                }
            }
            if (this.type == "t3" || this.type == "t4")
            {
                if (MainGraph.ContainsKey(Vertex1) && MainGraph.ContainsKey(Vertex2) && (MainGraph[Vertex1].ContainsKey(Vertex2) || MainGraph[Vertex2].ContainsKey(Vertex1)))
                {
                    if (MainGraph[Vertex1].ContainsKey(Vertex2) && MainGraph[Vertex2].ContainsKey(Vertex1))
                    {
                        MainGraph[Vertex1].Remove(Vertex2);
                        MainGraph[Vertex2].Remove(Vertex1);
                        Console.WriteLine("Ребро удалено успешно");
                    }
                    else if (!MainGraph[Vertex1].ContainsKey(Vertex2) && MainGraph[Vertex2].ContainsKey(Vertex1))
                    {
                        MainGraph[Vertex2].Remove(Vertex1);
                        Console.WriteLine("Ребро удалено успешно");
                    }
                    else if (MainGraph[Vertex1].ContainsKey(Vertex2) && !MainGraph[Vertex2].ContainsKey(Vertex1))
                    {
                        MainGraph[Vertex1].Remove(Vertex2);
                        Console.WriteLine("Ребро удалено успешно");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: нарушено одно из условий:");
                    Console.WriteLine(" обе вершины должны быть в графе или такого ребра не существует");
                }
            }
        }


        // Запись в файл
        public void WrtiteToFile(string Path)
        {
            using (StreamWriter file = new StreamWriter(Path))
            {
                foreach (var Vertex in MainGraph)
                {
                    file.Write("{0}: ", Vertex.Key);
                    if (Vertex.Value.Count == 0)
                    {
                        file.Write("");
                    }
                    else
                    {
                        foreach (var Vertexes in Vertex.Value)
                        {
                            file.Write("{0} ({1}) ", Vertexes.Key, Vertexes.Value);
                        }
                    }
                    file.WriteLine();
                }
            }
            Console.WriteLine("Данные успешно записаны в файл");
        }
        public string DegOfVertex()   // степень вершины 
        {
            string res = "";
            foreach (var vertex1 in MainGraph)
            {
                int deg = 0;
                deg += vertex1.Value.Count();    // степень исхода
                foreach (var vertex2 in MainGraph)
                {
                    if (vertex2.Value.ContainsKey(vertex1.Key) && (vertex2.Key != vertex1.Key))
                    {
                        deg++;     // cтепень захода 
                    }
                }
                res += vertex1.Key + ":" + deg.ToString() + "\n";
            }
            return res;

        }
        public bool DFS_Visit_three_colors(Dictionary<string,string>PI, Dictionary<string,int>color,string vertex)
        {
            color[vertex] = 1;//gray
            foreach (var u in MainGraph[vertex].Keys)
            {
                if (!u.Equals(vertex))   // для петель
                {
                    if (color[u] == 0)
                    {
                        PI[u] = vertex;
                        if (DFS_Visit_three_colors(PI, color, u))
                            return true;
                    }
                    else if (color[u] == 1)
                    {
                        return true;
                    }

                }
            }
            color[vertex] = 2;
            return false;

        }
        public void IsAcyclic()
        {
            Dictionary<string, int> color = new Dictionary<string, int>();
            Dictionary<string, string> PI = new Dictionary<string, string>();
            foreach(var element in MainGraph.Keys)
            {
                color.Add(element, 0);//все белым
                PI.Add(element, element);//предок вершины = сама вершина
            }
            foreach(var element in MainGraph.Keys)
            {
                if (DFS_Visit_three_colors(PI, color, element))
                {
                    Console.WriteLine(false);
                    return;
                }
            }
            Console.WriteLine(true);

        }



        public void Shortest_Distance_by_number_of_edges(List<string> set_of_vertexes)
        {
            foreach (string vertex in MainGraph.Keys)
            {
                Dictionary<string, int> nov = new Dictionary<string, int>();
                foreach (string v in MainGraph.Keys)
                {
                    nov.Add(v, 0);
                }
                int k = 1;
                BFS(vertex, set_of_vertexes, k, nov);
            }

        }


        public void BFS(string v, List<string> set_of_vertexes, int k, Dictionary<string, int> nov)
        {
            if (MainGraph.ContainsKey(v))
            {
                string cur_v = v;
                Queue<string> queue = new Queue<string>();
                queue.Enqueue(v);
                nov[v] = 1;
                while (queue.Count != 0)
                {
                    v = queue.Dequeue();
                    foreach (var Points in MainGraph[v])
                    {
                        if (Points.Value != 0 && nov[Points.Key] == 0 && set_of_vertexes.Contains(Points.Key))
                        {
                            Console.WriteLine("{0}: {1} {2}", cur_v, Points.Key, k);
                            return;
                        }
                        else if (Points.Value != 0 && nov[Points.Key] == 0)
                        {
                            queue.Enqueue(Points.Key);
                            nov[Points.Key] = 1;
                        }
                    }
                    k++;
                }
                Console.WriteLine("{0}: Недостижима из заданного множества вершин", cur_v);
            }
            else
            {
                Console.WriteLine("Такой точки нет в графе");
            }
        }


        public void Set_Nov ()
        {
            foreach (string v in MainGraph.Keys)
            {
                nov.Add(v,0);
            }
        }

        public void ClearNov()
        {
            foreach (string v in MainGraph.Keys)
            {
                nov[v]= 0;
            }

        }
        public void BFS(string v)
        {
            if (MainGraph.ContainsKey(v))
            {
                Queue<string> queue = new Queue<string>();
                queue.Enqueue(v);
                nov[v] = 1;
                while (queue.Count != 0)
                {
                    v = queue.Dequeue();
                    foreach (var Points in MainGraph[v])
                    {
                        
                         if (Points.Value != 0 && nov[Points.Key] == 0)
                        {
                            queue.Enqueue(Points.Key);
                            nov[Points.Key] = 1;
                        }
                    }
                }
            }
        }

        public void Prim(string v)
        {
            this.BFS(this.MainGraph.Keys.First());  
            bool flag = true;
            foreach (var temp in this.nov)
            {
                if (temp.Value == 0)
                {
                    flag = false;
                    break;
                }
            }
            this.ClearNov();
            if (flag)
            {
                Graph Copy = new Graph();
                Copy.type = "t2";
                List<string> Selected = new List<string>();
                List<string> Unselected = new List<string>();
                foreach (string key in this.MainGraph.Keys)
                {
                    Copy.AddVertex(key);
                    Unselected.Add(key);
                }
                string p = v;
                Selected.Add(v);
                Unselected.Remove(v);
                while (Unselected.Count != 0)
                {
                    double minv = double.MaxValue;
                    string mink = "";
                    foreach (string key in Selected)
                    {
                        foreach (var Vertexes in MainGraph[key])
                        {
                            if (Vertexes.Value < minv && !Selected.Contains(Vertexes.Key))
                            {
                                minv = Vertexes.Value;
                                mink = Vertexes.Key;
                                p = key;
                            }
                        }
                    }
                    Copy.AddWayFromVertexes(p, mink, minv);
                    Selected.Add(mink);
                    Unselected.Remove(mink);
                }
                Copy.ShowMainGraph();
            }
            else
            {
                Console.WriteLine("Граф не связный");
            }
        }
        public Dictionary<string, int> Dijkstra(string v)
        {
            if (MainGraph.ContainsKey(v))
            {
                Dictionary<string, int> D = new Dictionary<string, int>();
                Dictionary<string, bool> Used = new Dictionary<string, bool>();
                foreach (var keys in MainGraph.Keys)
                {
                    D.Add(keys, int.MaxValue);
                    Used.Add(keys, false);
                }
                D[v] = 0;
                for (int i = 0; i < MainGraph.Keys.Count; i++)
                {
                    foreach (KeyValuePair<string, int> item in D.OrderBy(key => key.Value))
                    {
                        if (!Used[item.Key])
                        {
                            v = item.Key;
                            Used[v] = true;
                            break;
                        }
                    }
                    foreach (var to in MainGraph[v].Keys)
                    {
                        if (MainGraph[v][to] < 0)
                        {
                            Console.WriteLine("Граф содержит ребра с отрицительными весами");
                            return null;
                        }
                        else
                        {

                            if (D[v] != int.MaxValue)
                                D[to] = Math.Min(D[to], D[v] + (int)MainGraph[v][to]);
                        }
                    }

                }
                return D;
            }
            else
            {
                Console.WriteLine("Такая вершина отсутствует в графе");
                return null;
            }
        }

        public string Min_sum_of_shortest_path_lengths()
        {
            int min = int.MaxValue;
            string name_of_vertex = " ";
            foreach (string vertex in MainGraph.Keys)
            {
                int sum = 0;
                Dictionary<string, int> dict = Dijkstra(vertex);
                foreach (var key in dict.Keys)
                {
                    sum += dict[key];
                }
                if (sum < min)
                   {
                      min = sum;
                      name_of_vertex = vertex;
                   }
            }
            return name_of_vertex;
        }

        public Dictionary<string, double> FordBellman(string v)
        {
            if (!MainGraph.ContainsKey(v))
            {
                Console.WriteLine("Ошибка: вершина не существует");
            }
            else
            {
                Dictionary<string, double> distance = new Dictionary<string, double>();
                foreach (var item in MainGraph.Keys)
                {
                    distance[item] = int.MaxValue;
                }

                distance[v] = 0;

                for (int i = 0; i < MainGraph.Count - 1; i++)
                {
                    foreach (var item in MainGraph)
                    {
                        foreach (var item2 in item.Value)
                        {
                            if (distance[item.Key] + item2.Value < distance[item2.Key])
                            {
                                distance[item2.Key] = distance[item.Key] + item2.Value;
                            }
                        }
                    }
                }
                // Проверка наличия отрицательного цикла
                foreach (var item in MainGraph)
                {
                    foreach (var item2 in item.Value)
                    {
                        if (distance[item.Key] + item2.Value < distance[item2.Key])
                        {
                            Console.WriteLine("Граф содержит отрицательный цикл");
                            return null;
                        }
                    }
                }
                return distance;
            }
            return null;
        }

        public void Is_vertex_in_graph_min_costs(double n)
        {
            foreach (string vertex in MainGraph.Keys)
            {
                bool flag = true;
                Dictionary<string, double> dict = FordBellman(vertex);
                if (dict == null)
                    return;
                else
                {
                    foreach (var item in dict)
                    {
                        if (item.Value > n)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("В графе есть вершина, каждая из минимальных стоимостей пути от которой до остальных не превосходит N");
                        Console.WriteLine(vertex);
                        return;
                    }
                }
            }
            Console.WriteLine("В графе нет вершины, каждая из минимальных стоимостей пути от которой до остальных не превосходит N");
        }



        public Dictionary<string, Dictionary<string, double>> Floyd_Warshall(Dictionary<string, Dictionary<string, string>> PI)
        {
            Dictionary<string, Dictionary<string, double>> D = new Dictionary<string, Dictionary<string, double>>();

            foreach (var element in MainGraph.Keys)
            {
                PI.Add(element, new Dictionary<string, string>());
                foreach (var second_element in MainGraph.Keys)
                {
                    if (MainGraph[element].ContainsKey(second_element))
                    {
                        PI[element].Add(second_element, second_element);
                    }
                    else
                    {
                        PI[element].Add(second_element, null);
                    }
                }

            }
            foreach (var first in MainGraph.Keys)
            {
                D.Add(first, new Dictionary<string, double>());
                foreach (var second in MainGraph.Keys)
                {
                    if (MainGraph[first].ContainsKey(second))
                    {
                        D[first].Add(second, MainGraph[first][second]);
                    }
                    else if (first == second)
                    {
                        D[first].Add(second, 0);
                    }
                    else
                    {
                        D[first].Add(second, int.MaxValue);
                    }
                }


            }

            foreach (var first in MainGraph.Keys)
            {
                foreach (var second in MainGraph.Keys)
                {
                    foreach (var third in MainGraph.Keys)
                    {
                        if (D[second][first] != int.MaxValue && D[first][third] != int.MaxValue && D[second][third] > D[second][first] + D[first][third])
                        {
                            D[second][third] = D[second][first] + D[first][third];
                            PI[second][third] = PI[second][first];
                        }
                    }


                }
            }
            foreach (var first in MainGraph.Keys)
            {
                if (D[first][first] < 0)
                {
                    foreach (var second in MainGraph.Keys)
                    {
                        foreach (var third in MainGraph.Keys)
                        {
                            if (D[second][first] < int.MaxValue && D[first][third] < int.MaxValue)
                            {
                                D[second][third] = int.MinValue;
                            }
                        }
                    }
                }
            }

            return D;


        }

        public void Floyd_Warshall_Way(string u, string v)
        {
            Dictionary<string, Dictionary<string, string>> PI = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, double>> D = this.Floyd_Warshall(PI);
            if (D[u][v] == int.MaxValue)
            {
                Console.WriteLine("No path found");
                return;
            }
            string c = u;
            while (c != v)
            {
                Console.WriteLine(c);
                c = PI[c][v];
            }
            Console.WriteLine(v);

        }


        public double FordFulkerson(string source, string sink, Graph MainGraph)
        {
            // Копия графа для остаточной сети
            Graph residualGraph = new Graph(MainGraph);

            // Словарь для хранения родителей в пути
            Dictionary<string, string> parent = new Dictionary<string, string>();

            double maxFlow = 0;

            // Пока существует путь из источника в сток
            while (Bfs(residualGraph, source, sink, parent))
            {
                double pathFlow = double.MaxValue;

                // Находим минимальную пропускную способность в пути
                string current = sink;
                while (current != source)
                {
                    string prev = parent[current];
                    pathFlow = Math.Min(pathFlow, residualGraph.MainGraph[prev][current]);
                    current = prev;
                }

                // Обновляем остаточную сеть и увеличиваем поток
                current = sink;
                while (current != source)
                {
                    string prev = parent[current];
                    residualGraph.MainGraph[prev][current] -= pathFlow;
                    if (!residualGraph.MainGraph[current].ContainsKey(prev))
                        residualGraph.AddWayFromVertexes(current,prev,0);
                    residualGraph.MainGraph[current][prev] += pathFlow;
                    current = prev;
                }

                maxFlow += pathFlow;
            }

            return maxFlow;
        }

        private bool Bfs(Graph residualGraph, string source, string sink, Dictionary<string, string> parent)
        {
            List <string> visited = new List<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(source);
            visited.Add(source);

            while (queue.Count > 0)
            {
                string u = queue.Dequeue();

                foreach (var v in residualGraph.MainGraph[u])
                {
                    if (!visited.Contains(v.Key) && v.Value > 0)
                    {
                        queue.Enqueue(v.Key);
                        visited.Add(v.Key);
                        parent[v.Key] = u;

                        if (v.Key == sink)
                            return true;
                    }
                }
            }

            return false;
        }
        public string NonAdjacentVertexes(string vertex)     // список вершин, не смежных с данной
        {
            string res = "";
            foreach (var v in MainGraph)
            {
                if (!v.Value.ContainsKey(vertex) && !v.Key.Equals(vertex))
                    res += v.Key + " ";

            }
            return res;
        }

        public Graph SymmetricDifference(Graph g)
        {
            Graph res = new Graph(this);
            foreach (string vertex in g.MainGraph.Keys)
            {
                if (!res.MainGraph.ContainsKey(vertex))
                {
                    res.AddVertex(vertex);
                }
            }
            foreach (string vertex in g.MainGraph.Keys)
            {
                foreach (var edge in g.MainGraph[vertex])
                {
                    if (res.MainGraph[vertex].Contains(edge))
                        res.MainGraph[vertex].Remove(edge.Key);
                    else
                        res.MainGraph[vertex][edge.Key] = edge.Value;
                }
            }
            return res;

        }

        




        public class Program
        {
            static void Main()
            {
                string type = "";
                //string inway = "C:\\Users\\HP\\OneDrive\\Рабочий стол\\ConsoleApp4\\ConsoleApp4\\Tests_Graphs\\test3.txt";
                string inway = "C:\\Users\\HP\\OneDrive\\Рабочий стол\\ConsoleApp4\\ConsoleApp4\\Tests_Graphs\\FF.txt";
               // string inway = "C:\\Users\\HP\\OneDrive\\Рабочий стол\\ConsoleApp4\\ConsoleApp4\\Tests_Graphs\\test4(ov).txt";
                string inway2 = "C:\\Users\\HP\\OneDrive\\Рабочий стол\\ConsoleApp4\\ConsoleApp4\\Tests_Graphs\\testsymdiff(nn).txt";
                string outway = "C:/Users/HP/OneDrive/Рабочий стол/ConsoleApp4/ConsoleApp4/Tests_Graphs/output.txt";
                Console.WriteLine("Выберите тип графа");
                Console.WriteLine("Неориентированный невзвешенный граф: t1");
                Console.WriteLine("Неориентированный взвешенный граф: t2");
                Console.WriteLine("Ориентированный невзвешенный граф: t3");
                Console.WriteLine("Ориентированный взвешенный граф: t4");
                string key = Console.ReadLine();
                Graph MyGraph = new Graph(key);
                Graph MyGraphCop = new Graph(key);
                switch (key)
                {
                    case "t1":
                        Console.WriteLine("Выход из программы: написать Leave");
                        Console.WriteLine("Показать исходный граф: написать Show");
                        Console.WriteLine("Показать копию графа: написать Show copy");
                        Console.WriteLine("Очистить граф: написать Clean");
                        Console.WriteLine("Заполнить граф по файлу: написать Fill from file");
                        Console.WriteLine("Записать граф в файл: написать Write to file");
                        Console.WriteLine("Добавить вершину: написать Add vertex");
                        Console.WriteLine("Добавить ребро: написать Add way");
                        Console.WriteLine("Удалить вершину: написать Delete vertex");
                        Console.WriteLine("Удалить ребро: написать Delete way");
                        Console.WriteLine("Задание 15. Вывести все вершины графа, не смежные с данной: написать Non Adjacent Vertexes");
                        Console.WriteLine("Задание 9. Построить граф, являющийся симметрической разностью двух заданных: написать Sym diff");
                        Console.WriteLine("Задание 39. Для каждой вершины найти кратчайшее (по числу рёбер) расстояние от неё до ближайшей из заданного множества вершин: написать Short_Distance");
                        type = "t1";
                        while (true)
                        {
                            string key1 = Console.ReadLine();
                            if (key1 == "Leave")
                            {
                                break;
                            }
                            else
                            {
                                switch (key1)
                                {
                                    case "Show":
                                        MyGraph.ShowMainGraph();
                                        break;
                                    case "Show copy":
                                        MyGraphCop.ShowMainGraph();
                                        break;
                                    case "Clean":
                                        MyGraphCop = new Graph(type);
                                        break;
                                    case "Fill from file":
                                        MyGraph = new Graph(inway, type);
                                        MyGraphCop = new Graph(MyGraph);
                                        MyGraphCop.Set_Nov();   
                                        break; 
                                    case "Write to file":
                                        MyGraphCop.WrtiteToFile(outway);
                                        break;
                                    case "Add vertex":
                                        Console.WriteLine("Введите добавляемую вершину");
                                        MyGraphCop.AddVertex(Console.ReadLine());
                                        break;
                                    case "Add way":
                                        Console.WriteLine("Введите первую вершину");
                                        string FirstVertexA = Console.ReadLine();
                                        Console.WriteLine("Введите вторую вершину");
                                        string SecondVertexA = Console.ReadLine();

                                        MyGraphCop.AddWayFromVertexes(FirstVertexA, SecondVertexA);
                                        break;
                                    case "Delete vertex":
                                        Console.WriteLine("Введите удаляемую вершину");
                                        MyGraphCop.DeleteVertex(Console.ReadLine());
                                        break;
                                    case "Delete way":
                                        Console.WriteLine("Введите первую вершину");
                                        string FirstVertexD = Console.ReadLine();
                                        Console.WriteLine("Введите вторую вершину");
                                        string SecondVertexD = Console.ReadLine();
                                        MyGraphCop.DeleteWayFromVertexes(FirstVertexD, SecondVertexD);
                                        break;
                                    case "Non Adjacent Vertexes":
                                        Console.WriteLine("Введите вершину");
                                        string str = Console.ReadLine();
                                        Console.WriteLine(MyGraph.NonAdjacentVertexes(str));
                                        break;
                                    case "Sym diff":
                                        Graph First = new Graph(inway2, type);
                                        Graph Second = MyGraphCop.SymmetricDifference(First);
                                        Second.ShowMainGraph();
                                        break;
                                    case "Short_Distance":
                                        List<string> set_of_vertexes = new List<string>();
                                        set_of_vertexes.Add("x1");
                                        set_of_vertexes.Add("x2");
                                        set_of_vertexes.Add("x3");
                                        MyGraphCop.Shortest_Distance_by_number_of_edges(set_of_vertexes);
                                        break;
                                    default:
                                        Console.WriteLine("Такая команда отсутствует");
                                        break;
                                }
                            }
                        }
                        break;
                    case "t2":
                        Console.WriteLine("Выход из программы: написать Leave");
                        Console.WriteLine("Показать первоначальный граф: написать Show");
                        Console.WriteLine("Показать копию графа: написать Show copy");
                        Console.WriteLine("Очистить граф: написать Clean");
                        Console.WriteLine("Заполнить граф по файлу: написать Fill from file");
                        Console.WriteLine("Записать граф в файл: написать Write to file");
                        Console.WriteLine("Добавить вершину: написать Add vertex");
                        Console.WriteLine("Добавить ребро: написать Add way");
                        Console.WriteLine("Удалить вершину: написать Delete vertex");
                        Console.WriteLine("Удалить ребро: написать Delete way");
                        Console.WriteLine("Задание 15. Вывести все вершины графа, не смежные с данной: написать Non Adjacent Vertexes");
                        Console.WriteLine("Задание 9. Построить граф, являющийся симметрической разностью двух заданных: написать Sym diff");
                        Console.WriteLine("Задание 39. Для каждой вершины найти кратчайшее (по числу рёбер) расстояние от неё до ближайшей из заданного множества вершин: написать Short_Distance");
                        Console.WriteLine("Алгоритм Прима: написать Prim");
                        Console.WriteLine("Задание 6. Найти вершину, сумма длин кратчайших путей от которой до остальных вершин минимальна.: написать D");
                        Console.WriteLine("Задание 3. Определить, есть ли в графе вершина, каждая из минимальных стоимостей пути от которой до остальных не превосходит N.: написать FB");
                        Console.WriteLine("Задание 15. Вывести кратчайшие пути из вершин u1 и u2 до v.: написать FW");
                        type = "t2";
                        while (true)
                        {
                            string key2 = Console.ReadLine();
                            if (key2 == "Leave")
                            {
                                break;
                            }
                            else
                            {
                                switch (key2)
                                {
                                    case "Show":
                                        MyGraph.ShowMainGraph();
                                        break;
                                    case "Show copy":
                                        MyGraphCop.ShowMainGraph();
                                        break;
                                    case "Clean":
                                        MyGraphCop = new Graph(type);
                                        break;
                                    case "Fill from file":
                                        MyGraph = new Graph(inway, type);
                                        MyGraphCop = new Graph(MyGraph);
                                        MyGraphCop.Set_Nov();
                                        break;
                                    case "Write to file":
                                        MyGraphCop.WrtiteToFile(outway);
                                        break;
                                    case "Add vertex":
                                        Console.WriteLine("Введите добавляемую вершину");
                                        MyGraphCop.AddVertex(Console.ReadLine());
                                        break;
                                    case "Add way":
                                        Console.WriteLine("Введите первую вершину");
                                        string FirstVertexA = Console.ReadLine();
                                        Console.WriteLine("Введите вторую вершину");
                                        string SecondVertexA = Console.ReadLine();
                                        Console.WriteLine("Введите длину пути");
                                        int Way = int.Parse(Console.ReadLine());
                                        MyGraphCop.AddWayFromVertexes(FirstVertexA, SecondVertexA, Way);
                                        break;
                                    case "Delete vertex":
                                        Console.WriteLine("Введите удаляемую вершину");
                                        MyGraphCop.DeleteVertex(Console.ReadLine());
                                        break;
                                    case "Delete way":
                                        Console.WriteLine("Введите первую вершину");
                                        string FirstVertexD = Console.ReadLine();
                                        Console.WriteLine("Введите вторую вершину");
                                        string SecondVertexD = Console.ReadLine();
                                        MyGraphCop.DeleteWayFromVertexes(FirstVertexD, SecondVertexD);
                                        break;
                                    case "Non Adjacent Vertexes":
                                        Console.WriteLine("Введите вершину");
                                        Console.WriteLine(MyGraph.NonAdjacentVertexes(Console.ReadLine()));
                                        break;
                                    case "Sym diff":
                                        Graph First = new Graph(inway2, type);
                                        Graph Second = MyGraphCop.SymmetricDifference(First);
                                        Second.ShowMainGraph();
                                        break;
                                    case "Short_Distance":
                                        List<string> set_of_vertexes = new List<string>();
                                        set_of_vertexes.Add("x1");
                                        set_of_vertexes.Add("x2");
                                        set_of_vertexes.Add("x3");
                                        MyGraphCop.Shortest_Distance_by_number_of_edges(set_of_vertexes);
                                        break;
                                    case "Prim":
                                        MyGraphCop.Prim("x1");
                                        break;
                                    case "D":
                                        Console.WriteLine(MyGraphCop.Min_sum_of_shortest_path_lengths());
                                        break;
                                    case "FB":
                                        MyGraphCop.Is_vertex_in_graph_min_costs(20);
                                        break;
                                    case "FW":
                                        Console.WriteLine("Введите вершину u1");
                                        string u1 = Console.ReadLine();
                                        Console.WriteLine("Введите вершину v");



                                        string v = Console.ReadLine();
                                        Console.WriteLine();
                                        MyGraphCop.Floyd_Warshall_Way(u1,v);
                                        Console.WriteLine();


                                        Console.WriteLine("Введите вершину u2");
                                        string u2 = Console.ReadLine();
                                        Console.WriteLine();
                                        MyGraphCop.Floyd_Warshall_Way(u2, v);
                                        break;
                                    default:
                                        Console.WriteLine("Такая команда отсутствует");
                                        break;  
                                }
                            }
                        }
                        break;
                    case "t3":
                        Console.WriteLine("Выход из программы: написать Leave");
                        Console.WriteLine("Показать первоначальный граф: написать Show");
                        Console.WriteLine("Показать копию графа: написать Show copy");
                        Console.WriteLine("Очистить граф: написать Clean");
                        Console.WriteLine("Заполнить граф по файлу: написать Fill from file");
                        Console.WriteLine("Записать граф в файл: написать Write to file");
                        Console.WriteLine("Добавить вершину: написать Add vertex");
                        Console.WriteLine("Добавить ребро: написать Add way");
                        Console.WriteLine("Удалить вершину: написать Delete vertex");
                        Console.WriteLine("Удалить ребро: написать Delete way");
                        Console.WriteLine("Задание 5. Для каждой вершины орграфа вывести её степень: Show deg");
                        Console.WriteLine("Задание 17. Является ли заданный орграф ацикличным: IsAcyclic");
                        type = "t3";
                        while (true)
                        {
                            string key3 = Console.ReadLine();
                            if (key3 == "Leave")
                            {
                                break;
                            }
                            else
                            {
                                switch (key3)
                                {
                                    case "Show":
                                        MyGraph.ShowMainGraph();
                                        break;
                                    case "Show copy":
                                        MyGraphCop.ShowMainGraph();
                                        break;
                                    case "Clean":
                                        MyGraphCop = new Graph(type);
                                        break;
                                    case "Fill from file":
                                        MyGraph = new Graph(inway, type);
                                        MyGraphCop = new Graph(MyGraph);
                                        MyGraphCop.Set_Nov();
                                        break;
                                    case "Write to file":
                                        MyGraphCop.WrtiteToFile(outway);
                                        break;
                                    case "Add vertex":
                                        Console.WriteLine("Введите добавляемую вершину");
                                        MyGraphCop.AddVertex(Console.ReadLine());
                                        break;
                                    case "Add way":
                                        Console.WriteLine("Введите первую вершину");
                                        string FirstVertexA = Console.ReadLine();
                                        Console.WriteLine("Введите вторую вершину");
                                        string SecondVertexA = Console.ReadLine();

                                        MyGraphCop.AddWayFromVertexes(FirstVertexA, SecondVertexA);
                                        break;
                                    case "Delete vertex":
                                        Console.WriteLine("Введите удаляемую вершину");
                                        MyGraphCop.DeleteVertex(Console.ReadLine());
                                        break;
                                    case "Delete way":
                                        Console.WriteLine("Введите первую вершину");
                                        string FirstVertexD = Console.ReadLine();
                                        Console.WriteLine("Введите вторую вершину");
                                        string SecondVertexD = Console.ReadLine();
                                        MyGraphCop.DeleteWayFromVertexes(FirstVertexD, SecondVertexD);
                                        break;
                                    case "Show deg":
                                        Console.WriteLine(MyGraph.DegOfVertex());
                                        break;
                                    case "IsAcyclic":
                                        MyGraphCop.IsAcyclic();
                                        break;
                                    default:
                                        Console.WriteLine("Такая команда отсутсвует");
                                        break;
                                }
                            }
                        }
                        break;
                    case "t4":
                        Console.WriteLine("Выход из программы: написать Leave");
                        Console.WriteLine("Показать первоначальный граф: написать Show");
                        Console.WriteLine("Показать копию графа: написать Show copy");
                        Console.WriteLine("Очистить граф: написать Clean");
                        Console.WriteLine("Заполнить граф по файлу: написать Fill from file");
                        Console.WriteLine("Записать граф в файл: написать Write to file");
                        Console.WriteLine("Добавить вершину: написать Add vertex");
                        Console.WriteLine("Добавить ребро: написать Add way");
                        Console.WriteLine("Удалить вершину: написать Delete vertex");
                        Console.WriteLine("Удалить ребро: написать Delete way");
                        Console.WriteLine("Задание 5. Для каждой вершины орграфа вывести её степень: Show deg");
                        Console.WriteLine("Задание 17. Является ли заданный орграф ацикличным: IsAcyclic");
                        Console.WriteLine("Задание 6. Найти вершину, сумма длин кратчайших путей от которой до остальных вершин минимальна.: написать D");
                        Console.WriteLine("Задание 3. Определить, есть ли в графе вершина, каждая из минимальных стоимостей пути от которой до остальных не превосходит N.: написать FB");
                        Console.WriteLine("Задание 15. Вывести кратчайшие пути из вершин u1 и u2 до v.: написать FW");
                        Console.WriteLine("Максимальный поток V: написать FF");
                        type = "t4";
                        while (true)
                        {
                            string key4 = Console.ReadLine();
                            if (key4 == "Leave")
                            {
                                break;
                            }
                            else
                            {
                                switch (key4)
                                {
                                    case "Show":
                                        MyGraph.ShowMainGraph();
                                        break;
                                    case "Show copy":
                                        MyGraphCop.ShowMainGraph();
                                        break;
                                    case "Clean":
                                        MyGraphCop = new Graph(type);
                                        break;
                                    case "Fill from file":
                                        MyGraph = new Graph(inway, type);
                                        MyGraphCop = new Graph(MyGraph);
                                        MyGraphCop.Set_Nov();
                                        break;
                                    case "Write to file":
                                        MyGraphCop.WrtiteToFile(outway);
                                        break;
                                    case "Add vertex":
                                        Console.WriteLine("Введите добавляемую вершину");
                                        MyGraphCop.AddVertex(Console.ReadLine());
                                        break;
                                    case "Add way":
                                        Console.WriteLine("Введите первую вершину");
                                        string FirstVertexA = Console.ReadLine();
                                        Console.WriteLine("Введите вторую вершину");
                                        string SecondVertexA = Console.ReadLine();
                                        Console.WriteLine("Введите длину пути");
                                        int Way = int.Parse(Console.ReadLine());
                                        MyGraphCop.AddWayFromVertexes(FirstVertexA, SecondVertexA, Way);
                                        break;
                                    case "Delete vertex":
                                        Console.WriteLine("Введите удаляемую вершину");
                                        MyGraphCop.DeleteVertex(Console.ReadLine());
                                        break;
                                    case "Delete way":
                                        Console.WriteLine("Введите первую вершину");
                                        string FirstVertexD = Console.ReadLine();
                                        Console.WriteLine("Введите вторую вершину");
                                        string SecondVertexD = Console.ReadLine();
                                        MyGraphCop.DeleteWayFromVertexes(FirstVertexD, SecondVertexD);
                                        break;
                                    case "Show deg":
                                        Console.WriteLine(MyGraph.DegOfVertex());
                                        break;
                                    case "IsAcyclic":
                                        MyGraphCop.IsAcyclic();
                                        break;
                                    case "D":
                                        Console.WriteLine(MyGraphCop.Min_sum_of_shortest_path_lengths());
                                        break;
                                    case "FB":
                                        MyGraphCop.Is_vertex_in_graph_min_costs(10);
                                        break;
                                    case "FW":
                                        Console.WriteLine("Введите вершину u1");
                                        string u1 = Console.ReadLine();
                                        Console.WriteLine("Введите вершину v");



                                        string v = Console.ReadLine();
                                        Console.WriteLine();
                                        MyGraphCop.Floyd_Warshall_Way(u1, v);
                                        Console.WriteLine();


                                        Console.WriteLine("Введите вершину u2");
                                        string u2 = Console.ReadLine();
                                        Console.WriteLine();
                                        MyGraphCop.Floyd_Warshall_Way(u2, v);
                                        break;
                                        break;
                                    case "FF":
                                        Console.WriteLine(MyGraphCop.FordFulkerson("x1","x6", MyGraph));
                                        break;
                                    default:
                                        Console.WriteLine("Такая команда отсутствует");
                                        break;
                                }
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Такая команда отсутствует");
                        break;
                }

            }
        }
    }
}

