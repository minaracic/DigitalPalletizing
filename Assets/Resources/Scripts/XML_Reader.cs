﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

/// <summary>
/// Class for reading dimensions of the boxes from XML
/// </summary>
public class XML_Reader : MonoBehaviour
{

    [SerializeField]
    private TextAsset xml;
    private XmlDocument _document = new XmlDocument();

    private Dictionary<string, Vector3> dict = new Dictionary<string, Vector3>();

    /// <summary>
    /// Functon for extraction dimension from XML file 
    /// </summary>
    /// <param name="boxName"> Name of the box for finding dimension</param>
    /// <returns>Vector3 with dimenzion of boxName</returns>
    private Vector3 getSizeBoxName(string boxName)
    {
        Vector3 vec = new Vector3();
        foreach (XmlNode node in _document.DocumentElement.SelectNodes("/QCARConfig/Tracking/ImageTarget"))
        {
            string name = node.Attributes["name"]?.InnerText;
            
            if (name == boxName + ".Front")
            {
                string atrSize = node.Attributes["size"]?.InnerText;
                string[] size = atrSize.Split(' ');
                vec.x = float.Parse(size[0]);
                vec.z = float.Parse(size[1]);
            }
            if (name == boxName + ".Right")
            {
                string atrSize = node.Attributes["size"]?.InnerText;
                string[] size = atrSize.Split(' ');
                vec.y = float.Parse(size[0]);
            }
        }
        dict.Add(boxName, vec);
        return vec;
    }

    /// <summary>
    /// Function for returning size of the box from boxes colection
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Vector3 dimension of forwarded box name</returns>
    public Vector3 getSizeByName(string name)
    {
        return dict[name];
    }
    // Start is called before the first frame update
    void Start()
    {
        _document.LoadXml(xml.ToString());
        List<string> tempName = new List<string>();
        foreach (XmlNode node in _document.DocumentElement.SelectNodes("/QCARConfig/Tracking/ImageTarget"))
        {
            string name = node.Attributes["name"]?.InnerText.Split('.')[0];
            if (!tempName.Contains(name))
            {
                tempName.Add(name);
                getSizeBoxName(name);
            }
        }

        foreach (KeyValuePair<string,Vector3> entry in dict)
        {
            Debug.Log(entry.Key);
            Debug.Log(entry.Value);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
