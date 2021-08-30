using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start()
    {
        // Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>(); // с
        //Установить начальное число очков равным 0
        scoreGT.text = "0";

        int diffLevel = DropDownHandler.diffValue;                  //Из класса DropDownHandler из переменной diffValue берётся сложность и присваевается новой локальной переменной которая и будет использоваться в if/else
        if (diffLevel == 0)                                         //easy difficulty
        {
            transform.localScale = new Vector3(10f, 1f, 4f);
        }
        else if (diffLevel == 1)                                    //normal difficulty
        {
            transform.localScale = new Vector3(3f, 1f, 4f);
        }
        else if (diffLevel == 2)                                    //hard difficulty
        {
            transform.localScale = new Vector3(1f, 1f, 4f);
        }
        else
        {
            Debug.Log("Difficulty Error:value is other or null");
        }
        
    }

    // Update is called once per frame
    void Update()
    { // Получить текущие координаты указателя мыши на экране из Input 
        Vector3 mousePos2D = Input.mousePosition;
        // Координата Z камеры определяет, как далеко в трехмерном пространстве 
        // находится указатель мыши 
        mousePos2D.z = -Camera.main.transform.position.z;
        // Преобразовать точку на двумерной плоскости экрана в трехмерные 
        // координаты игры 
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
        // Переместить корзину вдоль оси X в координату X указателя мыши 
        Vector3 pos = this.transform.position; pos.x = mousePos3D.x; this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision coll)
    {
        //Отыскать яблоко,попавшее в корзину
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);


            // Преобразовать текст в scoreGT в целое число
            int score = int.Parse(scoreGT.text); 
            // Добавить очки за пойманное яблоко
            score += 10;
            // Преобразовать число очков обратно в строку и вывести ее на экран
            scoreGT.text = score.ToString();

            //Запомнить высшее достижение
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }

        }
    }
}
