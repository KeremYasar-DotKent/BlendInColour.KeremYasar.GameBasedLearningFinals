using UnityEngine;
using UnityEngine.SceneManagement; // Sahneleri deðiþtirebilmek için bu kütüphane þart!

public class LevelChanger : MonoBehaviour
{
    // Unity Inspector'dan sonraki sahnenin tam adýný yazabilmek için deðiþken
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Kapýya deðen nesnenin oyuncu olup olmadýðýný kontrol ediyoruz
        if (other.CompareTag("Player"))
        {
            // Eðer bir sonraki sahnenin adý boþ býrakýlmadýysa o sahneye geç
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("Dostum, Inspector'dan 'Next Scene Name' alanýna sahne adý yazmayý unuttun!");
            }
        }
    }
}