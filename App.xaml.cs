namespace ojherreras2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new Views.vLogin()));
            //return new Window(new Views.vLogin());
        }
    }
}