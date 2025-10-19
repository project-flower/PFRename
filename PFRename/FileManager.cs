using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PFRename
{
    public class FileManager
    {
        #region Private Fields

        private readonly XmlSerializer serializer;

        #endregion

        #region Public Methods

        public FileManager()
        {
            serializer = new XmlSerializer(typeof(Project));
        }

        public Project LoadProject(string fileName)
        {
            var settings = new XmlReaderSettings()
            {
                CheckCharacters = false,
            };

            try
            {
                using (var streamReader = new StreamReader(fileName))
                using (var xmlReader = XmlReader.Create(streamReader, settings))
                {
                    return (Project)(serializer.Deserialize(xmlReader));
                }
            }
            catch
            {
                throw;
            }
        }

        public void SaveProject(string fileName, Project project)
        {
            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    serializer.Serialize(writer, project);
                    writer.Flush();
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
