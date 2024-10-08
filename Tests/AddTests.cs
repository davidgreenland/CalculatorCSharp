﻿using NUnit.Framework;
using CalculatorProject;

namespace Tests
{
    public class AddTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup() => _calculator = new Calculator();

        [TestCase(0, 0, 0)]
        [TestCase(1, 2, 3)]
        [TestCase(3, 8, 11)]
        [TestCase(0, 8, 8)]
        [TestCase(-3, 10, 7)]
        [TestCase(-7, -9, -16)]
        [TestCase(6789, 345, 7134)]
        public void Add_returns_expected_result_for_given_inputs(int a, int b, int expected)
        {
            var result = _calculator.Add(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Basic addition did not return {expected}");
        }
    }
}
