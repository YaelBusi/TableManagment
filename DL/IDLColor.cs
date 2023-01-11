using DL.Models;
using System;
using System.Linq;
using System.Text;

namespace DL
{
    public interface IDLColor
    {
        Task<List<Color>> getColors();
        Task<Color> createColor(Color color);
        Task<Color> updateColor(int id, Color color);
        Task<Color> deleteColor(int id);
        Task<Color> getColorById(int id);
    }
 }
