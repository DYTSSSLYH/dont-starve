using System;
using System.IO;
using System.Xml;
using DYT.Consts;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DYT.Bridges
{
    public class ImageWidgetBridge
    {
        private readonly Image _image;
        
        public ImageWidgetBridge(Image image)
        {
            _image = image;
        }

        public void SetTexture(string atlas, string texture)
        {
            string xmlFilePath = GameLaunch.GetFilePath(atlas);
            
            // 解析 XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            
            XmlNode textureXmlNode = xmlDoc.SelectSingleNode("//Texture");
            
            string texFileName = textureXmlNode.Attributes["filename"].Value;

            string texFilePath = Path.Combine(Path.GetDirectoryName(xmlFilePath), texFileName);
            
            byte[] texBytes = File.ReadAllBytes(texFilePath);


            // 验证KTEX头部
            if (texBytes.Length < 4 ||
                texBytes[0] != 'K' || texBytes[1] != 'T' ||
                texBytes[2] != 'E' || texBytes[3] != 'X'
            )
            {
                Debug.LogError("不是有效的KTEX文件格式");
            }

            // KTEX文件结构解析
            // 平台标识、像素格式、纹理类型、mipmap数量、标志、剩余部分
            
            int offset = 8; // 头部大小
            
            // 每个mipmap有16字节的信息
            MipmapInfo mainMipmapInfo = null;
            TextureFormat textureFormat = TextureFormat.DXT5;
            while (true)
            {
                MipmapInfo mipmapInfo = new MipmapInfo
                {
                    width = BitConverter.ToUInt16(texBytes, offset),
                    height = BitConverter.ToUInt16(texBytes, offset + 2),
                    pitch = BitConverter.ToUInt16(texBytes, offset + 4),
                    dataSize = BitConverter.ToInt32(texBytes, offset + 6)
                };

                offset += 10;

                if (mainMipmapInfo == null)
                {
                    mainMipmapInfo = mipmapInfo;
                    
                    if (mipmapInfo.width * mipmapInfo.height == mipmapInfo.dataSize)
                    {
                        textureFormat = TextureFormat.DXT5;
                    }
                    else if (mipmapInfo.width * mipmapInfo.height * 4 == mipmapInfo.dataSize)
                    {
                        textureFormat = TextureFormat.RGBA32;
                        break;
                    }
                }

                if (mipmapInfo.width == 1 && mipmapInfo.height == 1)
                {
                    break;
                }
            }
            
            // 提取像素数据
            byte[] pixelData = new byte[mainMipmapInfo.dataSize];
            Array.Copy(texBytes, offset, pixelData, 0, mainMipmapInfo.dataSize);

            // 解压DXT压缩（如果需要）
            // 饥荒通常使用DXT5格式
            Texture2D texture2D = new Texture2D(
                mainMipmapInfo.width, mainMipmapInfo.height, textureFormat, false
            );
            texture2D.LoadRawTextureData(pixelData);
            texture2D.Apply();

            SpriteMetaData sprite =  new SpriteMetaData();

            XmlNodeList elements = xmlDoc.SelectNodes("//Element");

            foreach (XmlNode element in elements)
            {
                string texName = element.Attributes["name"].Value;

                if (string.Equals(texName, texture))
                {
                    // 读取UV坐标 (0-1范围)
                    float u1 = float.Parse(element.Attributes["u1"].Value);
                    float u2 = float.Parse(element.Attributes["u2"].Value);
                    float v1 = float.Parse(element.Attributes["v1"].Value);
                    float v2 = float.Parse(element.Attributes["v2"].Value);

                    // 转换为像素坐标
                    // 注意：饥荒的V坐标是从上到下，Unity是从下到上，需要翻转
                    float x = u1 * mainMipmapInfo.width;
                    float y = (1 - v2) * mainMipmapInfo.height; // 翻转V坐标
                    float width = (u2 - u1) * mainMipmapInfo.width;
                    float height = (v2 - v1) * mainMipmapInfo.height;

                    sprite = new SpriteMetaData
                    {
                        name = texture,
                        rect = new Rect(x, y, width, height),
                        alignment = (int)SpriteAlignment.Center,
                        pivot = new Vector2(0.5f, 0.5f)
                    };

                    break;
                }
            }

            _image.sprite = Sprite.Create(texture2D, sprite.rect, sprite.pivot);
        }

        public void SetHAnchor(int anchor)
        {
            float x = _image.rectTransform.pivot.x;
            
            if (anchor == Const.ANCHOR_LEFT)
            {
                x = 0;
            }
            else if (anchor == Const.ANCHOR_MIDDLE)
            {
                x = 0.5f;
            }
            else if (anchor == Const.ANCHOR_RIGHT)
            {
                x = 1;
            }
            
            _image.rectTransform.pivot = new Vector2(x, _image.rectTransform.pivot.y);
        }
        
        public void SetVAnchor(int anchor)
        {
            float y = _image.rectTransform.pivot.y;
            
            if (anchor == Const.ANCHOR_TOP)
            {
                y = 0;
            }
            else if (anchor == Const.ANCHOR_MIDDLE)
            {
                y = 0.5f;
            }
            else if (anchor == Const.ANCHOR_BOTTOM)
            {
                y = 1;
            }
            
            _image.rectTransform.pivot = new Vector2(_image.rectTransform.pivot.x, y);
        }

        public void SetTint(float r, float g, float b, float a)
        {
            _image.color = new Color(r, g, b, a);
        }
    }
}