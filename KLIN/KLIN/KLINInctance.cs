namespace KLIN
{
    internal class KLINInstanse
    {
        private string _klinFilePath;

        public List<Parameter> _configOptions;

        internal KLINInstanse(string desiredName)
        {
            if (desiredName.Length < 2)
                return;
            _klinFilePath = @".\" + desiredName;
            if (!File.Exists(_klinFilePath))
            {
                var file = File.Create(_klinFilePath);
                file.Close();
            }

            string[] contents = File.ReadAllLines(_klinFilePath);

            if (contents.Length == 0)
                return;

            _configOptions = new();

            for (int i = 0; i < contents.Length; i++)
            {
                _configOptions.Add(Parameter.Parse(contents[i]));
            }
            return;
        }

        internal void AddElement(string name, string value)
        {
            _configOptions.Add(new Parameter { Name = name, Value = value });
        }

        internal void ChangeValue(string name, string value)
        {
            if (!_configOptions.Contains(new Parameter { Name = name }))
                return;
            _configOptions.Find(x => x.Name == name).Value = value;
        }

        internal void SaveChanges()
        {
            if (!File.Exists(_klinFilePath))
                return;

            var file = File.Create(_klinFilePath);
            file.Close();

            File.WriteAllLines(_klinFilePath, Parameter.ToStringArray(_configOptions));
        }
    }
}
