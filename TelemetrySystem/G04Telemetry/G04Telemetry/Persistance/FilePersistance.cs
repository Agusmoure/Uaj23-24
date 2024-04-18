using G04Telemetry.CommonEvents;
using G04Telemetry.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
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
        private SerializationInterface _serialization;
        public FilePersistance(string fileName, SerializationInterface serialize) : base(serialize)
        {
            _serialization = serialize;
            _fileName = fileName + _serialization.getExtension();
            _fileWriter = new StreamWriter(_fileName, File.Exists(_fileName));
            _fileWriter.WriteLine(_serializationInterface.startSerialize());
            _fileWriter.Flush();
        }

        public override void flush()
        {

            string serializationString = _serialization.serializeAll(ref _events);
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
