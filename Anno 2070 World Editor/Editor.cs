using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Anno_2070_World_Editor
{
    public partial class Editor : Form
    {
        Bild picture;
        XmlDocument doc;
        new XmlNode Width;
        new XmlNode Height;
        string datei;
        long[,] resources;
        bool[,] fertility;
        short[] names;
        Hashtable namef;
        int row;
        public static Boolean opened;

        #region events
        void datagrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int index = names.Length;
                short[] temp = new short[index + 1];
                names.CopyTo(temp, 0);
                names = new short[index + 1];
                temp.CopyTo(names, 0);
                
                XmlNodeList Islands = doc.DocumentElement.ChildNodes[5].ChildNodes;
                XmlNodeList Island = Islands[e.RowIndex * 2 + 1].ChildNodes[1].ChildNodes;
                
                name.Items.Add(Island[0].FirstChild.Value);
                names[index] = short.Parse(Island[5].FirstChild.Value);
                namef.Add(name.Items[index], names[index]);
            }
            else
            {
                e.ThrowException = true;
            }
        }

        void datagrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            datagrid.Rows[datagrid.Rows.Count - 2].Cells[0].Value = datagrid.Rows.Count - 1;
        }

        void datagrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int i;
            for (i = e.Row.Index + 1; i < datagrid.Rows.Count - 1; i++)
            {
                datagrid.Rows[i].Cells[0].Value = i;
                for (int j = 0; j < 11; j++) resources[i - 1, j] = resources[i, j];
                for (int j = 0; j < 11; j++) fertility[i - 1, j] = fertility[i, j];
            }
            for (int j = 0; j < 11; j++) resources[i - 1, j] = 0;
            for (int j = 0; j < 11; j++) fertility[i - 1, j] = false;
        }

        void datagrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            for (int i = 0; i < 11; i++) resourcegrid.Rows[i].Cells[1].Value = resources[row, i];
            for (int i = 0; i < 16; i++) resourcegrid.Rows[i].Cells[3].Value = fertility[row, i];
            nummer.Text = (row + 1).ToString();
        }

        void datagrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string name = datagrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                datagrid.Rows[e.RowIndex].Cells[6].Value = namef[name];

                if (name[0] == char.Parse("N"))
                {
                    if (name[2] == char.Parse("X")) datagrid.Rows[e.RowIndex].Cells[3].Value = "Pirate Island";
                    else if (name[2] == char.Parse("D")) datagrid.Rows[e.RowIndex].Cells[3].Value = "Decoration";
                    else datagrid.Rows[e.RowIndex].Cells[3].Value = "Island";
                }
                else
                {
                    if (name[2] == char.Parse("X")) datagrid.Rows[e.RowIndex].Cells[3].Value = "E.T.O.";
                    else datagrid.Rows[e.RowIndex].Cells[3].Value = "Underwaterplateau";
                }
            }
        }

        void resourcegrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1) resources[row, e.RowIndex] = long.Parse(resourcegrid.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
            catch
            {
                resources[row, e.RowIndex] = 0;
            }
            if (e.ColumnIndex == 3) fertility[row, e.RowIndex] = bool.Parse(resourcegrid.Rows[e.RowIndex].Cells[3].Value.ToString());
        }
        #endregion

        private void generate_Click(object sender, EventArgs e)
        {
            int sizeto = int.Parse(leftto.Text);
            int tosize = int.Parse(toright.Text);
            int tosizeto = 32 * sizeto / tosize;
            int[,] islands = new int[datagrid.Rows.Count - 1, 5];
            int[,] arkslots = new int[arkgrid.Rows.Count - 1, 2];

            for (int i = 0; i < arkgrid.Rows.Count - 1; i++)
            {
                arkslots[i, 0] = ((int.Parse(arkgrid.Rows[i].Cells[0].Value.ToString()) * sizeto) / tosize) - (tosizeto / 2);
                arkslots[i, 1] = ((int.Parse(arkgrid.Rows[i].Cells[1].Value.ToString()) * sizeto) / tosize) - (tosizeto / 2);
            }

            for (int i = 0; i < datagrid.Rows.Count - 1; i++)
            {
                islands[i, 0] = (int)datagrid.Rows[i].Cells[0].Value;

                switch (datagrid.Rows[i].Cells[3].Value.ToString())
                {
                    case "Island":
                        islands[i, 1] = 0;
                        break;

                    case "Underwaterplateau":
                        islands[i, 1] = 1;
                        break;

                    case "Main Island":
                        islands[i, 1] = 2;
                        break;

                    case "E.T.O.":
                        islands[i, 1] = 3;
                        break;

                    case "Pirate Island":
                        islands[i, 1] = 4;
                        break;

                    case "Decoration":
                        islands[i, 1] = 5;
                        break;
                }

                islands[i, 2] = (int.Parse(datagrid.Rows[i].Cells[4].Value.ToString()) * sizeto) / tosize;
                islands[i, 3] = (int.Parse(datagrid.Rows[i].Cells[5].Value.ToString()) * sizeto) / tosize;
                islands[i, 4] = (int.Parse(datagrid.Rows[i].Cells[6].Value.ToString()) * sizeto) / tosize;
            }

            if (size.SelectedItem.ToString() == "Big")
            {
                Width.Value = "1792";
                Height.Value = "1792";
            }
            else if (size.SelectedItem.ToString() == "Medium")
            {
                Width.Value = "1664";
                Height.Value = "1664";
            }
            else if (size.SelectedItem.ToString() == "Small")
            {
                Width.Value = "1280";
                Height.Value = "1280";
            }
            else
            {
                Width.Value = size.SelectedItem.ToString();
                Height.Value = size.SelectedItem.ToString();
            }

            if (!opened)
            {
                opened = true;
                picture = new Bild();
                picture.Show();
            }
                picture.repaint(islands, arkslots, (int.Parse(Width.Value) * sizeto) / tosize, tosizeto);
        }

        public Editor(string[] args)
        {
            InitializeComponent();
            datagrid.DataError += new DataGridViewDataErrorEventHandler(datagrid_DataError);
            datagrid.UserAddedRow += datagrid_UserAddedRow;
            datagrid.UserDeletingRow += datagrid_UserDeletingRow;

            #region names
            names = new short[230];
            
            names[0] = 64;
            names[1] = 64;
            names[2] = 128;
            names[3] = 128;
            names[4] = 176;
            names[5] = 128;
            names[6] = 160;
            names[7] = 96;
            names[8] = 112;
            names[9] = 128;
            names[10] = 64;
            names[11] = 144;
            names[12] = 128;
            names[13] = 96;
            names[14] = 160;
            names[15] = 128;
            names[16] = 128;
            names[17] = 128;
            names[18] = 128;
            names[19] = 128;
            names[20] = 256;
            names[21] = 256;
            names[22] = 256;
            names[23] = 256;
            names[24] = 256;
            names[25] = 256;
            names[26] = 256;
            names[27] = 256;
            names[28] = 256;
            names[29] = 256;
            names[30] = 256;
            names[31] = 256;
            names[32] = 256;
            names[33] = 256;
            names[34] = 240;
            names[35] = 240;
            names[36] = 240;
            names[37] = 240;
            names[38] = 240;
            names[39] = 240;
            names[40] = 240;
            names[41] = 240;
            names[42] = 240;
            names[43] = 240;
            names[44] = 224;
            names[45] = 224;
            names[46] = 224;
            names[47] = 224;
            names[48] = 224;
            names[49] = 224;
            names[50] = 256;
            names[51] = 256;
            names[52] = 256;
            names[53] = 256;
            names[54] = 256;
            names[55] = 256;
            names[56] = 256;
            names[57] = 240;
            names[58] = 240;
            names[59] = 240;
            names[60] = 240;
            names[61] = 240;
            names[62] = 240;
            names[63] = 240;
            names[64] = 240;
            names[65] = 240;
            names[66] = 224;
            names[67] = 224;
            names[68] = 256;
            names[69] = 256;
            names[70] = 256;
            names[71] = 256;
            names[72] = 256;
            names[73] = 256;
            names[74] = 256;
            names[75] = 256;
            names[76] = 240;
            names[77] = 240;
            names[78] = 240;
            names[79] = 240;
            names[80] = 240;
            names[81] = 240;
            names[82] = 240;
            names[83] = 240;
            names[84] = 240;
            names[85] = 224;
            names[86] = 224;
            names[87] = 224;
            names[88] = 208;
            names[89] = 208;
            names[90] = 208;
            names[91] = 208;
            names[92] = 208;
            names[93] = 208;
            names[94] = 208;
            names[95] = 208;
            names[96] = 192;
            names[97] = 192;
            names[98] = 192;
            names[99] = 192;
            names[100] = 192;
            names[101] = 192;
            names[102] = 192;
            names[103] = 176;
            names[104] = 176;
            names[105] = 176;
            names[106] = 176;
            names[107] = 176;
            names[108] = 208;
            names[109] = 208;
            names[110] = 208;
            names[111] = 208;
            names[112] = 208;
            names[113] = 208;
            names[114] = 208;
            names[115] = 192;
            names[116] = 176;
            names[117] = 176;
            names[118] = 208;
            names[119] = 208;
            names[120] = 208;
            names[121] = 208;
            names[122] = 208;
            names[123] = 192;
            names[124] = 176;
            names[125] = 176;
            names[126] = 160;
            names[127] = 160;
            names[128] = 160;
            names[129] = 160;
            names[130] = 160;
            names[131] = 144;
            names[132] = 144;
            names[133] = 144;
            names[134] = 128;
            names[135] = 128;
            names[136] = 96;
            names[137] = 128;
            names[138] = 144;
            names[139] = 80;
            names[140] = 64;
            names[141] = 64;
            names[142] = 128;
            names[143] = 112;
            names[144] = 64;
            names[145] = 64;
            names[146] = 80;
            names[147] = 64;
            names[148] = 112;
            names[149] = 112;
            names[150] = 144;
            names[151] = 144;
            names[152] = 144;
            names[153] = 144;
            names[154] = 128;
            names[155] = 128;
            names[156] = 128;
            names[157] = 128;
            names[158] = 128;
            names[159] = 128;
            names[160] = 128;
            names[161] = 128;
            names[162] = 112;
            names[163] = 112;
            names[164] = 112;
            names[165] = 112;
            names[166] = 96;
            names[167] = 96;
            names[168] = 96;
            names[169] = 80;
            names[170] = 80;
            names[171] = 80;
            names[172] = 80;
            names[173] = 144;
            names[174] = 144;
            names[175] = 144;
            names[176] = 144;
            names[177] = 144;
            names[178] = 144;
            names[179] = 144;
            names[180] = 144;
            names[181] = 128;
            names[182] = 128;
            names[183] = 128;
            names[184] = 128;
            names[185] = 128;
            names[186] = 128;
            names[187] = 128;
            names[188] = 128;
            names[189] = 128;
            names[190] = 128;
            names[191] = 128;
            names[192] = 128;
            names[193] = 128;
            names[194] = 128;
            names[195] = 128;
            names[196] = 128;
            names[197] = 128;
            names[198] = 128;
            names[199] = 112;
            names[200] = 112;
            names[201] = 112;
            names[202] = 112;
            names[203] = 112;
            names[204] = 112;
            names[205] = 112;
            names[206] = 112;
            names[207] = 96;
            names[208] = 96;
            names[209] = 96;
            names[210] = 96;
            names[211] = 96;
            names[212] = 96;
            names[213] = 80;
            names[214] = 80;
            names[215] = 80;
            names[216] = 80;
            names[217] = 80;
            names[218] = 80;
            names[219] = 80;
            names[220] = 80;
            names[221] = 80;
            names[222] = 160;
            names[223] = 160;
            names[224] = 96;
            names[225] = 80;
            names[226] = 96;
            names[227] = 96;
            names[228] = 80;
            names[229] = 96;
            #endregion

            namef = new Hashtable();
            for (int i = 0; i < 230; i++) namef.Add(name.Items[i], names[i]);
            
            #region resourcegrid
            resourcegrid.Rows.Add(16);
            resourcegrid.Rows[0].Cells[0].Value = "Coal";
            resourcegrid.Rows[1].Cells[0].Value = "Iron";
            resourcegrid.Rows[2].Cells[0].Value = "Limestone";
            resourcegrid.Rows[3].Cells[0].Value = "Copper";
            resourcegrid.Rows[4].Cells[0].Value = "Basalt";
            resourcegrid.Rows[5].Cells[0].Value = "Oil";
            resourcegrid.Rows[6].Cells[0].Value = "Lobster";
            resourcegrid.Rows[7].Cells[0].Value = "Uranium";
            resourcegrid.Rows[8].Cells[0].Value = "Sand";
            resourcegrid.Rows[9].Cells[0].Value = "Gold";
            resourcegrid.Rows[10].Cells[0].Value = "RecyclableMaterials";

            resourcegrid.Rows[0].Cells[2].Value = "Vegetables";
            resourcegrid.Rows[1].Cells[2].Value = "Tea";
            resourcegrid.Rows[2].Cells[2].Value = "Algae";
            resourcegrid.Rows[3].Cells[2].Value = "Coffee";
            resourcegrid.Rows[4].Cells[2].Value = "Corn";
            resourcegrid.Rows[5].Cells[2].Value = "Diamonds";
            resourcegrid.Rows[6].Cells[2].Value = "Fruits";
            resourcegrid.Rows[7].Cells[2].Value = "Grain";
            resourcegrid.Rows[8].Cells[2].Value = "ManganeseNodules";
            resourcegrid.Rows[9].Cells[2].Value = "Rice";
            resourcegrid.Rows[10].Cells[2].Value = "Truffles";
            resourcegrid.Rows[11].Cells[2].Value = "Grapes";
            resourcegrid.Rows[12].Cells[2].Value = "SugarBeet";
            resourcegrid.Rows[13].Cells[2].Value = "Sponges";
            resourcegrid.Rows[14].Cells[2].Value = "Black Smoker";
            resourcegrid.Rows[15].Cells[2].Value = "Wíldcard";
            #endregion

            if (args.Length == 0)
            {
                openFileDialog1.ShowDialog();
                datei = openFileDialog1.FileName;
            }
            else datei = args[0];

            doc = new XmlDocument();
            doc.Load(datei);
            XmlNodeList WorldConfig = doc.DocumentElement.ChildNodes;
            Width = WorldConfig[0].FirstChild;
            Height = WorldConfig[1].FirstChild;
            XmlNodeList Arkslots = WorldConfig[3].ChildNodes;
            XmlNodeList Islands = WorldConfig[5].ChildNodes;

            resources = new long[256, 11];
            fertility = new bool[256, 16];

            if (Width.Value == "1792") size.SelectedIndex = 0;
            else if (Width.Value == "1664") size.SelectedIndex = 1;
            else if (Width.Value == "1280") size.SelectedIndex = 2;
            else
            {
                size.Items.Add(Width.Value);
                size.SelectedIndex = 3;
            }

            for (int i = 0; i < Arkslots.Count; i++)
            {
                arkgrid.Rows.Add();
                arkgrid.Rows[i].Cells[0].Value = Arkslots[i].FirstChild.FirstChild.Value;
                arkgrid.Rows[i].Cells[1].Value = Arkslots[i].LastChild.FirstChild.Value;
            }

            for (int i = 0; i < Islands.Count / 2; i++)
            {
                XmlNodeList Island = Islands[i * 2 + 1].ChildNodes[1].ChildNodes;
                datagrid.Rows.Add();

                datagrid.Rows[i].Cells[0].Value = i + 1;
                datagrid.Rows[i].Cells[1].Value = Island[0].FirstChild.Value;

                #region island[2]
                switch (Island[2].FirstChild.Value)
                {
                    case "0":
                        datagrid.Rows[i].Cells[2].Value = "North";
                        break;

                    case "1":
                        datagrid.Rows[i].Cells[2].Value = "West";
                        break;

                    case "2":
                        datagrid.Rows[i].Cells[2].Value = "South";
                        break;

                    case "3":
                        datagrid.Rows[i].Cells[2].Value = "East";
                        break;
                }
                #endregion

                #region island[7]
                switch (Island[7].FirstChild.Value)
                {
                    case "0":
                        datagrid.Rows[i].Cells[3].Value = "Island";
                        break;

                    case "1":
                        datagrid.Rows[i].Cells[3].Value = "Underwaterplateau";
                        break;

                    case "2":
                        datagrid.Rows[i].Cells[3].Value = "Main Island";
                        break;

                    case "3":
                        datagrid.Rows[i].Cells[3].Value = "E.T.O.";
                        break;

                    case "4":
                        datagrid.Rows[i].Cells[3].Value = "Pirate Island";
                        break;

                    case "5":
                        datagrid.Rows[i].Cells[3].Value = "Decoration";
                        break;
                }
                #endregion

                datagrid.Rows[i].Cells[4].Value = Island[3].FirstChild.Value;
                datagrid.Rows[i].Cells[5].Value = Island[4].FirstChild.Value;
                datagrid.Rows[i].Cells[6].Value = Island[5].FirstChild.Value;

                XmlNodeList res = Island[9].ChildNodes;
                XmlNodeList fer = Island[10].ChildNodes;

                #region resources
                for (int j = 0; j < res.Count; j++)
                {
                    switch (res[j].FirstChild.FirstChild.FirstChild.Value)
                    {
                        case "Coal":
                            resources[i, 0] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Iron":
                            resources[i, 1] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Limestone":
                            resources[i, 2] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Copper":
                            resources[i, 3] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Basalt":
                            resources[i, 4] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Oil":
                            resources[i, 5] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Lobster":
                            resources[i, 6] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Uranium":
                            resources[i, 7] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Sand":
                            resources[i, 8] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "Gold":
                            resources[i, 9] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;

                        case "RecyclableMaterials":
                            resources[i, 10] = long.Parse(res[j].LastChild.FirstChild.Value);
                            break;
                    }
                }

                for (int j = 0; j < fer.Count; j++)
                {
                    switch (fer[j].LastChild.FirstChild.Value)
                    {
                        case "Vegetables":
                            fertility[i, 0] = true;
                            break;

                        case "Tea":
                            fertility[i, 1] = true;
                            break;

                        case "Algae":
                            fertility[i, 2] = true;
                            break;

                        case "Coffee":
                            fertility[i, 3] = true;
                            break;

                        case "Corn":
                            fertility[i, 4] = true;
                            break;

                        case "Diamonds":
                            fertility[i, 5] = true;
                            break;

                        case "Fruits":
                            fertility[i, 6] = true;
                            break;

                        case "Grain":
                            fertility[i, 7] = true;
                            break;

                        case "ManganeseNodules":
                            fertility[i, 8] = true;
                            break;

                        case "Rice":
                            fertility[i, 9] = true;
                            break;

                        case "Truffles":
                            fertility[i, 10] = true;
                            break;

                        case "Grapes":
                            fertility[i, 11] = true;
                            break;

                        case "SugarBeet":
                            fertility[i, 12] = true;
                            break;

                        case "Sponges":
                            fertility[i, 13] = true;
                            break;

                        case "BlackSmoker":
                            fertility[i, 14] = true;
                            break;

                        case "Wildcard":
                            fertility[i, 15] = true;
                            break;
                    }
                }
                #endregion
            }

            datagrid.CellEnter += datagrid_CellEnter;
            datagrid.CellEndEdit += datagrid_CellEndEdit;
            resourcegrid.CellEndEdit += resourcegrid_CellEndEdit;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (datei != null)
            {
                #region größe
                if (size.SelectedItem.ToString() == "Big")
                {
                    Width.Value = "1792";
                    Height.Value = "1792";
                }
                else if (size.SelectedItem.ToString() == "Medium")
                {
                    Width.Value = "1664";
                    Height.Value = "1664";
                }
                else if (size.SelectedItem.ToString() == "Small")
                {
                    Width.Value = "1280";
                    Height.Value = "1280";
                }
                else
                {
                    Width.Value = size.SelectedItem.ToString();
                    Height.Value = size.SelectedItem.ToString();
                }
                #endregion

                string arkslots = "";
                string islands = "";

                for (int i = 0; i < arkgrid.Rows.Count - 1; i++) arkslots += "\r\n<i><x>" + arkgrid.Rows[i].Cells[0].Value + "</x><y>" + arkgrid.Rows[i].Cells[1].Value + "</y></i>";

                for (int i = 0; i < datagrid.Rows.Count - 1; i++)
                {
                    string name;
                    name = datagrid.Rows[i].Cells[1].Value.ToString();
                    islands += "\r\n\r\n<k>" + (i + 1) + "</k><v><hasValue>1</hasValue><IslandConfig><Name>" + name + "</Name><Filename>";

                    #region filename
                    if (name.Contains("addon") | name.Contains("rift"))
                    {
                        islands += "addondata/levels/Islands/";
                        if (name[2] == char.Parse("X")) islands += "third parties/";
                        else islands += "underwater/";
                    }
                    else
                    {
                        if (name[2] == char.Parse("Q"))
                        {
                            islands += "addondata/mod/";
                        }
                        else
                        {
                            islands += "data/levels/Islands/";
                        }
                        if (name[2] == char.Parse("X")) islands += "third parties/";
                        if (name[0] == char.Parse("N"))
                        {
                            if (name.Contains("p") | name.Contains("n")) islands += "normal/EcoMod/";
                            
                            else islands += "normal/";
                        }
                        else islands += "underwater/";
                    }
                    islands += name + ".isd</Filename>\r\n<Direction>";
                    #endregion

                    #region direction
                    switch (datagrid.Rows[i].Cells[2].Value.ToString())
                    {
                        case "North":
                            islands += 0;
                            break;

                        case "West":
                            islands += 1;
                            break;

                        case "South":
                            islands += 2;
                            break;

                        case "East":
                            islands += 3;
                            break;
                    }
                    #endregion

                    islands += "</Direction><PositionX>" + datagrid.Rows[i].Cells[4].Value + "</PositionX><PositionZ>" + datagrid.Rows[i].Cells[5].Value + "</PositionZ>";
                    islands += "<Width>" + datagrid.Rows[i].Cells[6].Value + "</Width><Height>" + datagrid.Rows[i].Cells[6].Value + "</Height><Type>";

                    #region type
                    switch (datagrid.Rows[i].Cells[3].Value.ToString())
                    {
                        case "Island":
                            islands += 0;
                            break;

                        case "Underwaterplateau":
                            islands += 1;
                            break;

                        case "Main Island":
                            islands += 2;
                            break;

                        case "E.T.O.":
                            islands += 3;
                            break;

                        case "Pirate Island":
                            islands += 4;
                            break;

                        case "Decoration":
                            islands += 5;
                            break;
                    }
                    #endregion

                    islands += "</Type><MissionID>0</MissionID><m_Resources>\r\n";

                    #region resources
                    if (resources[i, 0] > 0) islands += "<i><ResourceType><ResourceType>Coal</ResourceType></ResourceType><Amount>" + resources[i, 0] + "</Amount></i>\r\n";
                    if (resources[i, 1] > 0) islands += "<i><ResourceType><ResourceType>Iron</ResourceType></ResourceType><Amount>" + resources[i, 1] + "</Amount></i>\r\n";
                    if (resources[i, 2] > 0) islands += "<i><ResourceType><ResourceType>Limestone</ResourceType></ResourceType><Amount>" + resources[i, 2] + "</Amount></i>\r\n";
                    if (resources[i, 3] > 0) islands += "<i><ResourceType><ResourceType>Copper</ResourceType></ResourceType><Amount>" + resources[i, 3] + "</Amount></i>\r\n";
                    if (resources[i, 4] > 0) islands += "<i><ResourceType><ResourceType>Basalt</ResourceType></ResourceType><Amount>" + resources[i, 4] + "</Amount></i>\r\n";
                    if (resources[i, 5] > 0) islands += "<i><ResourceType><ResourceType>Oil</ResourceType></ResourceType><Amount>" + resources[i, 5] + "</Amount></i>\r\n";
                    if (resources[i, 6] > 0) islands += "<i><ResourceType><ResourceType>Lobster</ResourceType></ResourceType><Amount>" + resources[i, 6] + "</Amount></i>\r\n";
                    if (resources[i, 7] > 0) islands += "<i><ResourceType><ResourceType>Uranium</ResourceType></ResourceType><Amount>" + resources[i, 7] + "</Amount></i>\r\n";
                    if (resources[i, 8] > 0) islands += "<i><ResourceType><ResourceType>Sand</ResourceType></ResourceType><Amount>" + resources[i, 8] + "</Amount></i>\r\n";
                    if (resources[i, 9] > 0) islands += "<i><ResourceType><ResourceType>Gold</ResourceType></ResourceType><Amount>" + resources[i, 9] + "</Amount></i>\r\n";
                    if (resources[i, 10] > 0) islands += "<i><ResourceType><ResourceType>RecyclableMaterials</ResourceType></ResourceType><Amount>" + resources[i, 10] + "</Amount></i>\r\n";

                    islands += "</m_Resources><m_Fertility>\r\n";

                    if (fertility[i, 0]) islands += "<i><Fertility>Vegetables</Fertility></i>\r\n";
                    if (fertility[i, 1]) islands += "<i><Fertility>Tea</Fertility></i>\r\n";
                    if (fertility[i, 2]) islands += "<i><Fertility>Algae</Fertility></i>\r\n";
                    if (fertility[i, 3]) islands += "<i><Fertility>Coffee</Fertility></i>\r\n";
                    if (fertility[i, 4]) islands += "<i><Fertility>Corn</Fertility></i>\r\n";
                    if (fertility[i, 5]) islands += "<i><Fertility>Diamonds</Fertility></i>\r\n";
                    if (fertility[i, 6]) islands += "<i><Fertility>Fruits</Fertility></i>\r\n";
                    if (fertility[i, 7]) islands += "<i><Fertility>Grain</Fertility></i>\r\n";
                    if (fertility[i, 8]) islands += "<i><Fertility>ManganeseNodules</Fertility></i>\r\n";
                    if (fertility[i, 9]) islands += "<i><Fertility>Rice</Fertility></i>\r\n";
                    if (fertility[i, 10]) islands += "<i><Fertility>Truffles</Fertility></i>\r\n";
                    if (fertility[i, 11]) islands += "<i><Fertility>Grapes</Fertility></i>\r\n";
                    if (fertility[i, 12]) islands += "<i><Fertility>SugarBeet</Fertility></i>\r\n";
                    if (fertility[i, 13]) islands += "<i><Fertility>Sponges</Fertility></i>\r\n";
                    if (fertility[i, 14]) islands += "<i><Fertility>BlackSmoker</Fertility></i>\r\n";
                    if (fertility[i, 15]) islands += "<i><Fertility>Wildcard</Fertility></i>\r\n";
                    #endregion

                    islands += "</m_Fertility><LightProfile></LightProfile><AutoBuildConfig></AutoBuildConfig></IslandConfig></v>";
                }

                doc.DocumentElement.ChildNodes[0].InnerXml = Width.OuterXml;
                doc.DocumentElement.ChildNodes[1].InnerXml = Height.OuterXml;
                doc.DocumentElement.ChildNodes[3].InnerXml = arkslots + "\r\n";
                doc.DocumentElement.ChildNodes[5].InnerXml = islands + "\r\n";
                StreamWriter file = new StreamWriter(datei);
                file.Write(doc.DocumentElement.OuterXml);
                file.Close();
            }
        }
    }
}
