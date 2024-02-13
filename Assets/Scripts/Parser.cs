using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Palmmedia.ReportGenerator.Core.Common;

public class Parser : MonoBehaviour
{
    void Awake()
    {
        ParseJsonAndImport();
    }

    void ParseJsonAndImport(){
        using (StreamReader r = new StreamReader( Path.Combine("Assets/Resources/Data", "a1.json")))
        {
            string json = r.ReadToEnd();
            List<Level> levels = JsonUtility.FromJson<List<Level>>(json);
        }
    }
}
    