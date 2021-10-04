namespace DefaultNamespace
{
    public class Converter
    {

        private string jsonfile = "text.json"; 
        
        public Converter()
        {
            if (File.Exists(jsonfile))
            {
                string content = File.ReadAllText(jsonfile);
                System.Console.WriteLine(content);
            }
            else
            {
                System.Console.WriteLine("Cant find file");
            }
        }
    }
}