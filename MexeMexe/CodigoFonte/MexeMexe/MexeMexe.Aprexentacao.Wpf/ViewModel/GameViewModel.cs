namespace MexeMexe.Aprexentacao.Wpf.ViewModel
{
    public class GameViewModel : ViewModelBase
    {

        public string textoTeste { get { return "Funcionando"; } set { textoTeste = value;NotifyPropertyChange(nameof(textoTeste));  } }
    }
}
