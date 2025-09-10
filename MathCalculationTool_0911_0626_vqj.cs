// 代码生成时间: 2025-09-11 06:26:08
using UnityEngine;
using System;

/// <summary>
/// A mathematical calculation toolkit that provides various operations.
/// </summary>
public static class MathCalculationTool
{
    // Add two numbers together
    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>The sum of the two numbers.</returns>
    public static double Add(double a, double b)
    {
        return a + b;
    }

    // Subtract one number from another
    /// <summary>
    /// Subtracts one number from another.
    /// </summary>
    /// <param name="a">Minuend.</param>
    /// <param name="b">Subtrahend.</param>
    /// <returns>The difference between the two numbers.</returns>
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Multiply two numbers
    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>The product of the two numbers.</returns>
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Divide one number by another
    /// <summary>
    /// Divides one number by another.
    /// </summary>
    /// <param name="a">Dividend.</param>
    /// <param name="b">Divisor.</param>
    /// <returns>The quotient of the division.</returns>
    /// <exception cref="DivideByZeroException">Thrown when attempting to divide by zero.</exception>
    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return a / b;
    }

    // Calculate the power of a number
    /// <summary>
    /// Calculates the power of a number.
    /// </summary>
    /// <param name="base">The base number.</param>
    /// <param name="exponent">The exponent.</param>
    /// <returns>The result of raising the base to the power of the exponent.</returns>
    public static double Power(double @base, double exponent)
    {
        return Mathf.Pow(@base, exponent);
    }

    // Calculate the square root of a number
    /// <summary>
    /// Calculates the square root of a number.
    /// </summary>
    /// <param name="value">The number to find the square root of.</param>
    /// <returns>The square root of the number.</returns>
    public static double SquareRoot(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Cannot calculate the square root of a negative number.");
        }
        return Mathf.Sqrt(value);
    }
}
