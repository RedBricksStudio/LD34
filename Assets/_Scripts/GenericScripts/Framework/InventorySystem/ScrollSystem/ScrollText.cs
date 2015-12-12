// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */


/**
 * class responsible for parsing the raw file, and holding it's information
 */
using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.Xml;
using System.IO;
using System.Collections.Generic;

public class ScrollText
{
	private List<S_ScrollTextComponent> meta;
	private List<S_ScrollTextComponent> content;

	private string name;

	public ScrollText (TextAsset rawText)
	{
		this.name = rawText.name;
		this.content = new List<S_ScrollTextComponent>();
		this.meta = new List<S_ScrollTextComponent>();

		//Parse the file
		XmlReader reader = XmlReader.Create(new StringReader(rawText.text));

		//Read meta
		string segmentStart = "empty";
		string currentType = "none";
		S_ScrollTextComponent newComponent;

		while (reader.Read()) {
			switch (reader.NodeType) {
			case XmlNodeType.Element:
				if (!reader.Name.Equals("scrolltext")) {
					if (segmentStart.Equals("empty")) {
						segmentStart = reader.Name;
					} else {
						currentType = reader.Name;
					}
				}
				break;
			case XmlNodeType.Text:

				//Insert into the appropriate list				
				newComponent = new S_ScrollTextComponent(currentType, reader.Value);
				switch (segmentStart) {
				case "meta":
					this.meta.Add(newComponent);
					break;
				case "content":
					this.content.Add(newComponent);
					break;
				}

				break;
			case XmlNodeType.EndElement:
				if (reader.Name.Equals(segmentStart)) {
					segmentStart = "empty";
				}
				break;
			}
		}

	}

	public IList getMeta() {
		return meta;
	}

	public IList getContent() {
		return content;
	}

	public string getName() {
		return name;
	}

	public struct S_ScrollTextComponent {
		private string typeName;
		private string content;

		public S_ScrollTextComponent (string type, string content) {
			this.typeName = type;
			this.content = content;
		}

		public string getContent ()  {
			return content;
		}

		public string getType() {
			return typeName;
		}
	}
}


