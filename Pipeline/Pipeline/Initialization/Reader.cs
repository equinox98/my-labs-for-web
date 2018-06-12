namespace Pipeline.Initialization
{
    public static class Reader
    {
        //path to the csv file
        private const string _path = "Resorses/factories.csv";

        private static int _length = 0;

        /// <summary>
        /// Returns length
        /// </summary>
        /// <returns></returns>
        public static int GetLength()
        {
            return Reader._length;
        }

        /// <summary>
        /// Get File in matrix form
        /// </summary>
        /// <returns></returns>
        public static int[,] GetFile()
        {
            int length = 0;

            //get all content
            string file = System.IO.File.ReadAllText(_path);

            //get length
            length = System.Convert.ToInt32(file.Substring(0, file.IndexOf("\r\n")));

            //initialieze
            Reader._length = length;

            //truncate
            file = file.Substring(file.IndexOf("\r\n"), file.Length - file.IndexOf("\r\n"));


            //split the content
            string[] splitted = file.Split('\n');


            //declare the result
            int[,] matrix = new int[length, length];


            //fill infinitives
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    matrix[i, j] = Algorithms.Network.Infinity;
                }
            }


            //components of each line
            string[] components = null;

            foreach(var line in splitted)
            {
                try
                {
                    //get all components
                    components = line.Split(',');

                    //get info
                    int x = System.Convert.ToInt32(components[0]);
                    int y = System.Convert.ToInt32(components[1]);
                    int distance = System.Convert.ToInt32(components[2]);

                    //initialize
                    matrix[x - 1, y - 1] = distance;
                    matrix[y - 1, x - 1] = distance;
                }
                catch
                {
                    continue;
                }
            }

            return matrix;

        }

    }
}
