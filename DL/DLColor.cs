
using DL.Models;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DLColor:IDLColor
    {
        ColorCollection_2ALLContext furnaturecontext;
        public DLColor(ColorCollection_2ALLContext furnaturecontext)
        {
            this.furnaturecontext = furnaturecontext;
        }

        public async Task<Color> createColor(Color color)
        {
            await furnaturecontext.Colors.AddAsync(color);
            await furnaturecontext.SaveChangesAsync();
            return color;
        }
        public async Task<Color> getColorById(int id)
        {
            return await furnaturecontext.Colors.Where(color => color.Id == id).FirstAsync();
        }
        public async Task<Color> deleteColor(int id)
        {
            Color colorToDelete = await furnaturecontext.Colors.FindAsync(id);
            if (colorToDelete != null)
            {
                furnaturecontext.Colors.Remove(colorToDelete);
                await furnaturecontext.SaveChangesAsync();
                return colorToDelete;
            }
            return null;
        }

        public async Task<List<Color>> getColors()
        {
            List<Color> colors = await furnaturecontext.Colors.Select(p => p).OrderBy(c=>c.Order).ToListAsync();                                                                                     //&& u.Password.Equals(password)).FirstOrDefaultAsync();
            if (colors != null)
                return colors;
            return null;
        }

        public async Task<Color> updateColor(int id, Color color)
        {
            Color colorToUpdate = await furnaturecontext.Colors.FindAsync(id);
            if (colorToUpdate != null)
            {
                colorToUpdate.Id = color.Id;
                furnaturecontext.Entry(colorToUpdate).CurrentValues.SetValues(color);
                await furnaturecontext.SaveChangesAsync();
                return color;
            }
            else
            {
                createColor(color);
                return color;
            }
        }
    }
}