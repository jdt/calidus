using System.Xml;
namespace JDT.Calidus.Common.Projects
{
    public interface ICalidusProjectManager
    {
        /// <summary>
        /// Writes the calidus project to the specified xml writer
        /// </summary>
        /// <param name="project">The project to write</param>
        /// <param name="writer">The writer to write to</param>
        void WriteTo(ICalidusProject project, XmlWriter writer);

        /// <summary>
        /// Reads an ICalidusProject from an XmlReader
        /// </summary>
        /// <param name="reader">The reader to read from</param>
        /// <returns>The calidus project</returns>
        ICalidusProject ReadFrom(XmlReader reader);
    }
}