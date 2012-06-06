using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;

namespace alchemy
{
	public class DataStorage
	{

		public const int MAXSIZE = 48;

		[Serializable()]
		public class DataPresenter
		{
            Hashtable openedElements;
			//bool[] openedElements;
            Dictionary2D links;
			//int[,] links;
			Hashtable colors;

			/*private void pushNans()
			{
				for (int i = 0; i < links.GetLength(0); i++)
					for (int j = 0; j < links.GetLength(1); j++)
						links[i, j] = -1;
			}*/

			public DataPresenter(int maxSize)
            {
                openedElements = new Hashtable();
                links = new Dictionary2D();
                colors = new Hashtable();       
			}
			
			public DataPresenter()
            {
                openedElements = new Hashtable();
                links = new Dictionary2D();
                colors = new Hashtable();
			}

			public bool this[string index]
			{
				set
				{
					openedElements[index] = value;
				}
				get
				{
                    object o = openedElements[index];
                    if (o == null)
                        return false;
                    bool? b = o as bool?;
                    if (b == null)
                        return false;
                    return (bool)b;
				}
			}

			public Dictionary2D Links
			{
				get
				{
					return links;
				}
			}

			public Hashtable Colors
			{
				get
				{
					return colors;
				}
			}
		}

		private DataPresenter data;
		public static DataStorage instance;
		string fileName;

		public DataStorage(string fileName)
		{
			this.fileName = fileName;

			if (File.Exists(fileName))
				LoadData(fileName);
			else
			{
				LoadDefaults();
				SaveData(fileName);
			}
		}

		public void SaveData(string fileName)
		{
			using (Stream stream = File.OpenWrite(fileName))
			{
				BinaryFormatter serializer = new BinaryFormatter();
				serializer.Serialize(stream, data);
			}
		}

		public int Size
		{
            get
            {
                return data.Links.Size;
            }
		}

		public void LoadDefaults()
		{
            data = new DataPresenter();
			data["water"] = true;
			data["earth"] = true;
			data["fire"] = true;
			data["air"] = true;

            data.Links["-1", "-2"] = "water";
            data.Links["-2", "-3"] = "earth";
            data.Links["-3", "-4"] = "fire";
            data.Links["-4", "-6"] = "air";

            data.Links["earth", "fire"] = "lava";
            data.Links["earth", "water"] = "swamp";
            data.Links["earth", "earth"] = "stone";
            data.Links["earth", "air"] = "dust";
            data.Links["fire", "water"] = "steam";
            data.Links["fire", "steam"] = "alcohol";
            data.Links["fire", "energy"] = "1UP";
            data.Links["fire", "air"] = "energy";
            data.Links["stone", "1UP"] = "mount";
            data.Links["swamp", "energy"] = "life";
            data.Links["life", "stone"] = "egg";
            data.Links["water", "alcohol"] = "vodka";
            data.Links["egg", "life"] = "chicken";
            data.Links["chicken", "fire"] = "McDonalds";
            data.Links["chicken", "1UP"] = "dragon";
            
            data.Links["mount", "mount"] = "country";
            data.Links["country", "vodka"] = "Russia";
            data.Links["country", "McDonalds"] = "US";
            data.Links["US", "Russia"] = "bomb";




            /*data.Links[2, 3] = data.Links[3, 2] = 47;
			//обсидиан
			data.Links[4, 2] = data.Links[2, 4] = 10;
			//energy
			data.Links[1, 3] = data.Links[3, 1] = 5;
			//lava
			data.Links[0, 1] = data.Links[1, 0] = 4;
			//boloto
			data.Links[0, 2] = data.Links[2, 0] = 14;
			//steam
			data.Links[2, 1] = data.Links[1, 2] = 7;
			//grass
			data.Links[6, 0] = data.Links[0, 6] = 8;
			//1UP
			data.Links[5, 1] = data.Links[1, 5] = 9;
			//MineCraft
			data.Links[9, 10] = data.Links[10, 9] = 11;
			//alco
			data.Links[7, 1] = data.Links[1, 7] = 12;
			//vodka
			data.Links[12, 2] = data.Links[2, 12] = 13;
			//life
			data.Links[14, 5] = data.Links[5, 14] = 6;
			//bacteria
			data.Links[14, 6] = data.Links[6, 14] = 15;
			//stone
			data.Links[0, 0] = 16;
			//egg
			data.Links[16, 6] = data.Links[6, 16] = 17;
			//chichen
			data.Links[17, 6] = data.Links[6, 17] = 18;
			//MakDak
			data.Links[9, 18] = data.Links[18, 9] = 19;
			//Earth
			data.Links[9, 0] = data.Links[0, 9] = 20;
			//ash
			data.Links[3, 0] = data.Links[0, 3] = 21;
			//dino
			data.Links[0, 17] = data.Links[17, 0] = 22;
			//dragon
			data.Links[22, 1] = data.Links[1, 22] = 23;
			//job
			data.Links[16, 16] = 29;
			//animal
			data.Links[9, 15] = data.Links[15, 9] = 24;
			//human
			data.Links[29, 24] = data.Links[24, 29] = 25;
			data.Links[28, 6] = data.Links[6, 28] = 25;
			//sand
			data.Links[16, 2] = data.Links[2, 16] = 27;
			//clay
			data.Links[27, 2] = data.Links[2, 27] = 30;
			//golem
			data.Links[30, 6] = data.Links[6, 30] = 28;
			//dovakhiin
			data.Links[25, 23] = data.Links[23, 25] = 26;
			//obsession
			data.Links[19, 25] = data.Links[25, 19] = 31;
			//alconaut
			data.Links[13, 25] = data.Links[25, 13] = 32;
			//sex
			data.Links[25, 25] = 33;
			//tools
			data.Links[29, 25] = data.Links[25, 29] = 34;
			//diamonds
			data.Links[34, 16] = data.Links[16, 34] = 35;
			//ukrashenia
			data.Links[35, 34] = data.Links[34, 35] = 36;
			//mountains
			data.Links[16, 9] = data.Links[9, 16] = 37;
			//country
			data.Links[37, 37] = 38;
			//Russia
			data.Links[38, 13] = data.Links[13, 38] = 39;
			//USA
			data.Links[19, 38] = data.Links[38, 19] = 40;
			//nuke
			data.Links[40, 39] = data.Links[39, 40] = 41;
			//tree
			data.Links[8, 9] = data.Links[9, 8] = 42;
 			//paper
			data.Links[42, 34] = data.Links[34, 42] = 43;
			//books
			data.Links[43, 43] = 44;
			//shelf
			data.Links[44, 44] = 45;
			//metal
            data.Links[0, 34] = data.Links[34, 0] = 46;*/
		}

		public void LoadData(string fileName)
		{
			using (Stream stream = File.OpenRead(fileName))
			{
				BinaryFormatter deserializer = new BinaryFormatter();
				data = (DataPresenter)deserializer.Deserialize(stream);
			}
		}


		public DataPresenter Data
		{
			get
			{
				return data;
			}
		}
	}
}
