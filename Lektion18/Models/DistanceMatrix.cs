using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;

namespace WebMatrixTest.Models
{
    /* Target:
{
  "status": "OK",
  "origin_addresses": [ "Vancouver, BC, Canada", "Seattle, État de Washington, États-Unis" ],
  "destination_addresses": [ "San Francisco, Californie, États-Unis", "Victoria, BC, Canada" ],
  "rows": [ {
    "elements": [ {
      "status": "OK",
      "duration": {
        "value": 340110,
        "text": "3 jours 22 heures"
      },
      "distance": {
        "value": 1734542,
        "text": "1 735 km"
      }
    }, {
      "status": "OK",
      "duration": {
        "value": 24487,
        "text": "6 heures 48 minutes"
      },
      "distance": {
        "value": 129324,
        "text": "129 km"
      }
    } ]
  }, {
    "elements": [ {
      "status": "OK",
      "duration": {
        "value": 288834,
        "text": "3 jours 8 heures"
      },
      "distance": {
        "value": 1489604,
        "text": "1 490 km"
      }
    }, {
      "status": "OK",
      "duration": {
        "value": 14388,
        "text": "4 heures 0 minutes"
      },
      "distance": {
        "value": 135822,
        "text": "136 km"
      }
    } ]
  } ]
}
     * */
    public class DistanceMatrixData
    {
        public string status { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<string> destination_addresses { get; set; }
        public List<DistanceMatrixRow> rows { get; set; }
    }

    public class DistanceMatrixRow
    {
        public List<DistanceMatrixElement> elements { get; set; }
    }

    public class DistanceMatrixElement
    {
        public string status { get; set; }
        public DistanceMatrixDuration duration { get; set; }
        public DistanceMatrixDistance distance { get; set; }
    }

    public class DistanceMatrixDuration
    {
        public int value { get; set; }
        public string text { get; set; }
    }

    public class DistanceMatrixDistance
    {
        public int value { get; set; }
        public string text { get; set; }
    }

    public class DistanceMatrix
    {
        public static List<string> DeserializeRoutesTest()
        {
            string json = @"{""status"": ""OK"",
  ""origin_addresses"": [ ""Vancouver, BC, Canada"", ""Seattle, État de Washington, États-Unis"" ],
  ""destination_addresses"": [ ""San Francisco, Californie, États-Unis"", ""Victoria, BC, Canada"" ],
  ""rows"": [ {
    ""elements"": [ {
      ""status"": ""OK"",
      ""duration"": {
        ""value"": 340110,
        ""text"": ""3 jours 22 heures""
      },
      ""distance"": {
        ""value"": 1734542,
        ""text"": ""1 735 km""
      }
    }, {
      ""status"": ""OK"",
      ""duration"": {
        ""value"": 24487,
        ""text"": ""6 heures 48 minutes""
      },
      ""distance"": {
        ""value"": 129324,
        ""text"": ""129 km""
      }
    } ]
  }, {
    ""elements"": [ {
      ""status"": ""OK"",
      ""duration"": {
        ""value"": 288834,
        ""text"": ""3 jours 8 heures""
      },
      ""distance"": {
        ""value"": 1489604,
        ""text"": ""1 490 km""
      }
    }, {
      ""status"": ""OK"",
      ""duration"": {
        ""value"": 14388,
        ""text"": ""4 heures 0 minutes""
      },
      ""distance"": {
        ""value"": 135822,
        ""text"": ""136 km""
      }
    } ]
  } ]
}";
            DistanceMatrixData distanceMatrixData = new JavaScriptSerializer()
                                                    .Deserialize<DistanceMatrixData>(json);

            List<string> routes = new List<string>();
            string origin;
            for (int originIndex = 0; 
                originIndex < distanceMatrixData.origin_addresses.Count; 
                originIndex++)
            {
                origin = distanceMatrixData.origin_addresses[originIndex];
                for (int destinationIndex = 0; 
                    destinationIndex < distanceMatrixData.destination_addresses.Count; 
                    destinationIndex++)
                {
                    routes.Add(string.Format("From: {0} To: {1} Distance: {2}"
                       ,origin
                       ,distanceMatrixData.destination_addresses[destinationIndex]
                       ,distanceMatrixData
                            .rows[originIndex]
                            .elements[destinationIndex]
                            .distance
                            .text
                    ));
                }
            }

            return routes;
        }
    }
}