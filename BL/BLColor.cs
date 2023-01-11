using DL;
using DL.Models;

namespace BL
{
    public class BLColor:IBLColor
    {
        IDLColor DLColor;
        public BLColor(IDLColor DLColor)
        {
            this.DLColor = DLColor;
        }

        public async Task<Color> createColor(Color color)
        {
            return await DLColor.createColor(color);
        }

        public async Task<Color> deleteColor(int id)
        {
            return await DLColor.deleteColor(id);
        }

        public async Task<List<Color>> getColors()
        {
            return await DLColor.getColors();
        }

        public async Task<Color> updateColor(int id, Color color)
        {
            return await DLColor.updateColor(id, color);
        }
        public async Task<Color> getColorById(int id)
        {
            return await DLColor.getColorById(id);
        }
    }
}