using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkAi.Model
{
    public class Prediction
    {
        public string TagId { get; set; }
        public string Tag { get; set; }
        public double Probability { get; set; }
        public Prediction(){}
        public Prediction(string TagId, string Tag, double Probability){
            this.TagId = TagId;
            this.Tag = Tag;
            this.Probability = Probability;
        }
    }

    public class CustomVision
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string Iteration { get; set; }
        public DateTime Created { get; set; }
        public List<Prediction> Predictions { get; set; }
        public CustomVision(){}
        public CustomVision(string Id, string Project, string Iteration, DateTime Created, List<Prediction> Predictions)
        {
            this.Id = Id;
            this.Project = Project;
            this.Iteration = Iteration;
            this.Created = Created;
            this.Predictions = Predictions;
        }
    }
}
