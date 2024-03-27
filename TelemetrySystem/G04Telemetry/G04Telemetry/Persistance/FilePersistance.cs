using G04Telemetry.CommonEvents;
using G04Telemetry.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.Persistance
{
    /// <summary>
    /// Esta clase guardara los eventos en un archivo local
    /// </summary>
    internal class FilePersistance : PersistanceBase
    {
        private string _fileName;
        private StreamWriter _fileWriter;
        public FilePersistance(string fileName, SerializationInterface serialize) : base(serialize)
        {
            _fileName = fileName + Tracker.Instance().getSerialization().getExtension();
            _fileWriter = new StreamWriter(_fileName, File.Exists(_fileName));
            _fileWriter.WriteLine(_serializationInterface.startSerialize());
            _fileWriter.Flush();
        }

        public override void flush()
        {

            string serializationString = Tracker.Instance().getSerialization().serializeAll(ref _events);
            _fileWriter.Write(serializationString);

            _fileWriter.Flush();
        }
        public override void close()
        {
            _fileWriter.WriteLine(_serializationInterface.endSerialize());
            _fileWriter.Flush();
        }
    }
}
