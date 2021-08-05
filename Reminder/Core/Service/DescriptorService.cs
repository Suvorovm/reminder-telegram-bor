﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Reminder.Core.Service
{
    public class DescriptorService
    {
        private IList<object> _createdDescriptor = new List<object>();

        public void LoadDescriptor<T>(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StringReader(doc.OuterXml)) {
                object descriptor = xmlSerializer.Deserialize(textReader);
                _createdDescriptor.Add(descriptor);
            }
        }

        public T GetDescriptor<T>()
        {
            object descriptor = _createdDescriptor.FirstOrDefault((s) => s is T);
            if (descriptor == null) {
                return default;
            }
            return (T) descriptor;
        }

        public List<object> GetAllDescriptors<T>()
        {
            List<object> descriptor = _createdDescriptor.Where((s) => s is T).ToList();
            return descriptor.Count == 0 ? default : descriptor;
        }
    }
}