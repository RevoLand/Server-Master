using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using Alphaleonis.Win32.Filesystem;
using System.Xml;

// Source: https://github.com/crdx/PortableSettingsProvider
namespace ServerMaster.Framework
{
    public sealed class PortableSettingsProvider : SettingsProvider, IApplicationSettingsProvider
    {
        private const string _rootNodeName = "settings";
        private const string _localSettingsNodeName = "localSettings";
        private const string _globalSettingsNodeName = "globalSettings";
        private const string _className = "PortableSettingsProvider";
        private XmlDocument _xmlDocument;

        private string _filePath => Path.Combine(Definitions.Directories.ServerMaster.MevcutDizin.FullName,
            $"{ApplicationName}.xml");

        private XmlNode _localSettingsNode
        {
            get
            {
                var settingsNode = GetSettingsNode(_localSettingsNodeName);
                var machineNode = settingsNode.SelectSingleNode(Environment.MachineName.ToLowerInvariant());

                if (machineNode == null)
                {
                    machineNode = _rootDocument.CreateElement(Environment.MachineName.ToLowerInvariant());
                    settingsNode.AppendChild(machineNode);
                }

                return machineNode;
            }
        }

        private XmlNode _globalSettingsNode => GetSettingsNode(_globalSettingsNodeName);

        private XmlNode _rootNode => _rootDocument.SelectSingleNode(_rootNodeName);

        private XmlDocument _rootDocument
        {
            get
            {
                if (_xmlDocument == null)
                {
                    try
                    {
                        _xmlDocument = new XmlDocument();
                        _xmlDocument.Load(_filePath);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }

                    if (_xmlDocument.SelectSingleNode(_rootNodeName) != null)
                        return _xmlDocument;

                    _xmlDocument = GetBlankXmlDocument();
                }

                return _xmlDocument;
            }
        }

        public override string ApplicationName
        {
            get => "Server Master";
            set { }
        }

        public override string Name => _className;

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(Name, config);
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            foreach (SettingsPropertyValue propertyValue in collection)
                SetValue(propertyValue);

            try
            {
                _rootDocument.Save(_filePath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                /*
                 * If this is a portable application and the device has been
                 * removed then this will fail, so don't do anything. It's
                 * probably better for the application to stop saving settings
                 * rather than just crashing outright. Probably.
                 */
            }
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            var values = new SettingsPropertyValueCollection();

            foreach (SettingsProperty property in collection)
            {
                values.Add(new SettingsPropertyValue(property)
                {
                    SerializedValue = GetValue(property)
                });
            }

            return values;
        }

        private void SetValue(SettingsPropertyValue propertyValue)
        {
            var targetNode = IsGlobal(propertyValue.Property)
               ? _globalSettingsNode
               : _localSettingsNode;

            var settingNode = targetNode.SelectSingleNode($"setting[@name='{propertyValue.Name}']");

            if (settingNode != null)
            {
                settingNode.InnerText = propertyValue.SerializedValue.ToString();
            }
            else
            {
                settingNode = _rootDocument.CreateElement("setting");

                var nameAttribute = _rootDocument.CreateAttribute("name");
                nameAttribute.Value = propertyValue.Name;

                settingNode.Attributes.Append(nameAttribute);
                settingNode.InnerText = propertyValue.SerializedValue.ToString();

                targetNode.AppendChild(settingNode);
            }
        }

        private string GetValue(SettingsProperty property)
        {
            var targetNode = IsGlobal(property) ? _globalSettingsNode : _localSettingsNode;
            var settingNode = targetNode.SelectSingleNode($"setting[@name='{property.Name}']");

            if (settingNode == null)
                return property.DefaultValue?.ToString();

            return settingNode.InnerText;
        }

        private bool IsGlobal(SettingsProperty property)
        {
            foreach (DictionaryEntry attribute in property.Attributes)
            {
                if ((Attribute)attribute.Value is SettingsManageabilityAttribute)
                    return true;
            }

            return false;
        }

        private XmlNode GetSettingsNode(string name)
        {
            var settingsNode = _rootNode.SelectSingleNode(name);

            if (settingsNode == null)
            {
                settingsNode = _rootDocument.CreateElement(name);
                _rootNode.AppendChild(settingsNode);
            }

            return settingsNode;
        }

        public XmlDocument GetBlankXmlDocument()
        {
            var blankXmlDocument = new XmlDocument();
            blankXmlDocument.AppendChild(blankXmlDocument.CreateXmlDeclaration("1.0", "utf-8", string.Empty));
            blankXmlDocument.AppendChild(blankXmlDocument.CreateElement(_rootNodeName));

            return blankXmlDocument;
        }

        public void Reset(SettingsContext context)
        {
            _localSettingsNode.RemoveAll();
            _globalSettingsNode.RemoveAll();

            _xmlDocument.Save(_filePath);
        }

        // do nothing
        public SettingsPropertyValue GetPreviousVersion(SettingsContext context, SettingsProperty property) => new SettingsPropertyValue(property);

        public void Upgrade(SettingsContext context, SettingsPropertyCollection properties)
        {
        }
    }
}