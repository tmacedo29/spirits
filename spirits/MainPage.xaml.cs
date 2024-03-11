namespace spirits;

public partial class MainPage : ContentPage
{
  //------------------------------------------------------------------------------------------------------------------------
  
  string pergunta;
  string resposta = "Não sei quem você é! Não me pergunte mais!";
  string elogio = "querido, amando, maravilhoso, lindo, cheio de vida, sábio";
  int indiceDoCaracterDoElogio = 0;

  bool estaNoModoResposta = false;

  //------------------------------------------------------------------------------------------------------------------------

	public MainPage()
	{
		InitializeComponent();
    entryPergunta.Focus();
	}

  //------------------------------------------------------------------------------------------------------------------------

  void Inicializar()
  {
    frameResposta.IsVisible = false;
    labelResposta.Text = "";
    labelPergunta.Text = "";
		resposta = "Não sei quem você é! Não me pergunte mais!";
    pergunta = "";
  }

  //------------------------------------------------------------------------------------------------------------------------

	private void QuandoClicarNoBotaoMostrarResposta(object sender, EventArgs e)
	{
    labelResposta.Text = resposta;
		frameResposta.IsVisible = true;
	}

  //------------------------------------------------------------------------------------------------------------------------

	private void QuandoClicarNoBotaoLimpar(object sender, EventArgs e)
	{
    Inicializar();
	}

  //------------------------------------------------------------------------------------------------------------------------

  private void QuandoClicarNoBotaoVoltar(object sender, EventArgs e)
	{
    Inicializar();
	}

  //------------------------------------------------------------------------------------------------------------------------

  void QuandoTextoMudar(object sender, TextChangedEventArgs e)
  {
    var perguntaSendoDigitada = e.NewTextValue;
    if (perguntaSendoDigitada != null && perguntaSendoDigitada.Length > 0)
    {
      if (perguntaSendoDigitada == ".")
      {
        resposta = "";
        estaNoModoResposta = true;
        indiceDoCaracterDoElogio = 0;
      }
      else if (estaNoModoResposta && perguntaSendoDigitada == ",")
        estaNoModoResposta = false;


      if (estaNoModoResposta)
      {
        pergunta += elogio[indiceDoCaracterDoElogio];
        indiceDoCaracterDoElogio++;
      }
      else if (perguntaSendoDigitada != ",")
        pergunta += perguntaSendoDigitada;

      if (estaNoModoResposta && perguntaSendoDigitada != ".")
        resposta += perguntaSendoDigitada;

      labelPergunta.Text = pergunta;
      (sender as Entry).Text = "";
    }
  }

  //------------------------------------------------------------------------------------------------------------------------

}

