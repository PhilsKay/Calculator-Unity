using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Calculate : MonoBehaviour
{
    // Text UI Input/Output
    public TextMeshProUGUI CalculateText;
    public TextMeshProUGUI ResultText;
    private string calculateTextInput = string.Empty;
    private string ResultTextInput = string.Empty;

    private string operand1;
    private string operand2;
    private string operation = "";
    private bool calculatorUsed;

    // Start is called before the first frame update
    void Start()
    {
        CalculateText.text = calculateTextInput;    
        ResultText.text = ResultTextInput;
        operand1 = string.Empty;
        operand2 = string.Empty;
        calculatorUsed = false;
        
    }

    /// <summary>
    /// Method that takes all the number input
    /// </summary>
    /// <param name="num"></param>
    public void Button_Click(string num)
    {
        // Cancel the text on screen if the calculator has been used
        //To start new calculation
        if(calculatorUsed == true)
        {
            CalculateText.text = string.Empty;
            ResultText.text = string.Empty;
            calculateTextInput = string.Empty;  
            calculatorUsed = false;
        }
       calculateTextInput += num;
       CalculateText.text += num;
    }

    /// <summary>
    /// Gets the Period action
    /// </summary>
    /// <param name="point"></param>
    public void Period_Click(string point)
    {
        calculateTextInput += point;
        CalculateText.text += point;
    }

    /// <summary>
    /// Gets the operators value
    /// </summary>
    /// <param name="value"></param>
    public void Operation_Click(string value)
    {
        operand1 = calculateTextInput;
        calculateTextInput = string.Empty;
        operation = value;
        CalculateText.text += operation.ToString();
    }

    public void ClearText_Click()
    {
        CalculateText.text = string.Empty; ;
        calculateTextInput = string.Empty;
        ResultText.text = string.Empty;
        calculatorUsed = false;
    }

    public void DeleteLastNumber()
    {
        if(calculateTextInput.Length > 0 && CalculateText.text.Length > 0)
        {
            calculateTextInput = calculateTextInput.Remove(calculateTextInput.Length - 1);
            CalculateText.text = CalculateText.text.Remove(CalculateText.text.Length - 1);
        }
 
    }

    public void EqualTo_Click(string value)
    {
        CalculateText.text += value;
        operand2 = calculateTextInput;
        double num1;
        double num2;
        bool firstSucceed = double.TryParse(operand1, out num1);
        bool secondSucceed = double.TryParse(operand2, out num2);
        if (operation == "+")
        {
            ResultTextInput = ((double)Math.Round((num1 + num2), 3)).ToString();
        }
        else if (operation == "-")
        {
            ResultTextInput = ((double)Math.Round((num1 - num2), 3)).ToString();
        }
        else if (operation == "x")
        {
            ResultTextInput = ((double)Math.Round((num1 * num2), 3)).ToString();
        }
        else if (operation == "%")
        {
            ResultTextInput = ((double)Math.Round((num1 % num2), 3)).ToString();
        }
        else
        {
            ResultTextInput = ((double)Math.Round((num1 / num2), 3)).ToString();
            if (num2 == 0)
            {
                ResultTextInput = "Undefined";
            }
        }
        ResultText.text = ResultTextInput;
        calculatorUsed = true;  
    }
}
