using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelaDeMorte : MonoBehaviour
{
    public Button botaoReiniciar;

    public string cenaInicial;

    void Start()
    {
        botaoReiniciar.onClick.AddListener(ReiniciarJogo);
    }

    void ReiniciarJogo()
    {
        SceneManager.LoadScene(cenaInicial);
    }
}