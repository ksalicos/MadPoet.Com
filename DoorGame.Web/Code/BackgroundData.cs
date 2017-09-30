using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Madpoet.Web.Code
{
    public class BackgroundData
    {
        public static BackgroundData GetInstance { get; } = new BackgroundData();

        private BackgroundData()
        {
            var rnd = new Random();
            _cols = 12;
            _rows = 10;
            for (var i = 0; i < _cols * _rows; i++)
            {
                var c = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                _colors.Add(("#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2")).ToUpper());
            }
        }

        private readonly object _lock = new object();
        private readonly List<string> _colors = new List<string>();
        public string[] Colors => _colors.ToArray();
        private int _rows, _cols;

        public async Task<bool> SetColor(int boxNum, string color)
        {
            lock (_lock)
            {
                if (boxNum >= Colors.Length || boxNum < 0) return false;

                Colors[boxNum] = color;
                return true;
            }
        }

        public (int Rows, int Cols) Dims()
        {
            return (_rows, _cols);
        }
    }
}