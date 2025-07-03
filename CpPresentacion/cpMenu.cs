using MaterialSkin;
using MaterialSkin.Controls;

namespace CpPresentacion
{
    public partial class cpMenu : MaterialForm
    {
        public cpMenu()
        {
            InitializeComponent();

            // Inicializa el MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // O DARK o LIGHT
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void LbMenu_Click(object sender, EventArgs e)
        {

        }
    }
}
