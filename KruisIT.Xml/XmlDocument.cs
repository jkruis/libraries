using System;
namespace KruisIT.Xml
{
	/*		created by http://kruisit.nl - 20080824
	 *		XmlDocument that automatically loads all namespaces.
	 *		The default namespace, if present, gets the prefix 'default' or is removed, as per the constructor parameter.
	 *		license:	http://creativecommons.org/licenses/by/3.0/
	 */
	public class XmlDocument : System.Xml.XmlDocument
	{
		public enum DefaultNsBehaviourEnum
		{
			Name,
			Remove
		}

		private const string DEFAULT_DEFAULT_NS_PREFIX = "default";

		public string DefaultNsPrefix { get; set; }
		public DefaultNsBehaviourEnum DefaultNsBehaviour { get; private set; }

		public System.Xml.XmlNamespaceManager NamespaceManager { get; private set; }

		public XmlDocument(DefaultNsBehaviourEnum defaultNsBehaviour)
		{
			DefaultNsBehaviour = defaultNsBehaviour;
			if (DefaultNsBehaviourEnum.Name == defaultNsBehaviour)
			{
				DefaultNsPrefix = DEFAULT_DEFAULT_NS_PREFIX;
			}
		}

		#region Load
		public new void Load(string filename)
		{
			// character encoding error? open file in notepad and save as UTF-8.
			base.Load(filename);
			NamespaceManager = CreateNamespaceMgr(DefaultNsBehaviour, DefaultNsPrefix);
		}
		public new void Load(System.IO.Stream inStream)
		{
			base.Load(inStream);
			NamespaceManager = CreateNamespaceMgr(DefaultNsBehaviour, DefaultNsPrefix);
		}
		public new void Load(System.IO.TextReader txtReader)
		{
			base.Load(txtReader);
			NamespaceManager = CreateNamespaceMgr(DefaultNsBehaviour, DefaultNsPrefix);
		}
		public new void Load(System.Xml.XmlReader reader)
		{
			base.Load(reader);
			NamespaceManager = CreateNamespaceMgr(DefaultNsBehaviour, DefaultNsPrefix);
		}
		#endregion

		#region LoadXml
		public new void LoadXml(string xml)
		{
			base.LoadXml(xml);
			NamespaceManager = CreateNamespaceMgr(DefaultNsBehaviour, DefaultNsPrefix);
		}
		#endregion

		#region SelectSingleNode
		public new System.Xml.XmlNode SelectSingleNode(string xpath)
		{
			return (null != NamespaceManager) ? base.SelectSingleNode(xpath, NamespaceManager) : base.SelectSingleNode(xpath);
		}
		private new System.Xml.XmlNode SelectSingleNode(string xpath,
				System.Xml.XmlNamespaceManager nsmgr)
		{
			throw new NotSupportedException();
		}
		#endregion

		#region SelectNodes
		public new System.Xml.XmlNodeList SelectNodes(string xpath)
		{
			try
			{
				return (null != NamespaceManager) ? base.SelectNodes(xpath, NamespaceManager) : base.SelectNodes(xpath);
			}
			catch (Exception ex)
			{
				if (!(ex.Message.Contains("Namespace prefix") && ex.Message.Contains("not defined")))
				{
					throw;
				}
				else
				{
					return base.SelectNodes("/forcing/an/empty/nodelist");
				}
			}
		}
		private new System.Xml.XmlNodeList SelectNodes(string xpath, System.Xml.XmlNamespaceManager nsmgr)
		{
			throw new NotSupportedException();
		}
		#endregion

		private System.Xml.XmlNamespaceManager CreateNamespaceMgr(DefaultNsBehaviourEnum defaultNsBehaviour, string prefixForDefaultNS)
		{
			if (DefaultNsBehaviourEnum.Remove == defaultNsBehaviour)
			{
				base.InnerXml = System.Text.RegularExpressions.Regex.Replace(base.InnerXml, "xmlns=\"[^ ]*\" ", "");
			}

			System.Collections.Specialized.NameValueCollection namespaces = GetNamespaces(base.DocumentElement, prefixForDefaultNS ?? "");
			System.Xml.XmlNamespaceManager namespaceMgr = null;
			if (0 != namespaces.Count)
			{
				namespaceMgr = new System.Xml.XmlNamespaceManager(base.NameTable);
				for (int i = 0; i < namespaces.Count; i++)
				{
					namespaceMgr.AddNamespace(namespaces.Keys[i], namespaces[i]);
				}
			}
			return namespaceMgr;
		}
		private System.Collections.Specialized.NameValueCollection GetNamespaces(System.Xml.XmlElement doc, string prefixForDefaultNS)
		{
			System.Collections.Specialized.NameValueCollection ret = new System.Collections.Specialized.NameValueCollection();
			foreach (System.Xml.XmlAttribute attr in doc.Attributes)
			{
				if (-1 < attr.Name.IndexOf("xmlns"))
				{
					// xmlns=&lt;uri&gt; is the default namespace, xmlns:&lt;name&gt;=&lt;uri&gt; is a named namespace
					string key = (-1 < attr.Name.IndexOf("xmlns:")) ? attr.Name.Replace("xmlns:", "") : prefixForDefaultNS;
					ret.Add(key, attr.Value);
				}
			}
			return ret;
		}
	}
}