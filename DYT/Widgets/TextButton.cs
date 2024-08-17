using UnityEngine;

namespace DYT.Widgets
{
    [RequireComponent(typeof(Image))]
    public class TextButton : Button
    {
        public bool isChecked { get; set; }
        
        private Image image;
        private Color colour;
        private Color overcolour;
        
        
        
        public TextButton Init(string name = null)
        {
            base.Init();

            image = GetComponent<Image>().Init("Images/ui", "blank");
            text = transform.GetChild(0).GetComponent<Text>().Init(30);

            colour = new Color(0.9f, 0.8f, 0.6f, 1);
            colour = new Color(1, 1, 1, 1);
            
            return this;
        }
    }
}