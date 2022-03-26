namespace KLIN
{
    internal class KLINInstance
    {
        private static string _klinFilePath;

        private static List<Parameter> _configOptions;

        internal bool KLINInstanse(string desiredName)
        {
            if (desiredName.Length < 2)
                return false;
            _klinFilePath = @"*\" + desiredName;
            if (!Directory.Exists(_klinFilePath))
            {
                var file = File.Create(_klinFilePath);
                file.Close();
            }
            string[] contents = File.ReadAllLines(_klinFilePath);

            if (contents.Length == 0)
                return true;

            
            return true;
        }
    }

    internal class Parameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Parameter objAsParameter = obj as Parameter;
            if (objAsParameter == null) return false;
            else return Equals(objAsParameter);
        }
        public string GetValue()
        {
            return Value;
        }
        public bool Equals(Parameter other)
        {
            if (other == null) return false;
            return (Value.Equals(other.Value));
        }
        public void Parse(string line)
        {
        line.Split(' ')
        }
    }
}
