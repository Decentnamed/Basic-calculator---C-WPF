using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    class MainLogic : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string bufferIO = "0";
        public string operatorBuffer = "";
        public string previousOperatorBuffer = "";
        public string firstDigitBuffer = "";
        public string secondDigitBuffer = "";
        public string operationBuffer = "";
        public string resultBuffer = "";
        public string egualSign = "";
        public bool operatorFlag = false;
        public bool BufferIOflag = false;
        public bool resultFlag = false;
        public bool digitFlag = false;
        public bool commaFlag = false;
        public bool signFlag = false;
        public bool operationFlag = false;

        public string ReminderWindow
        {
            get
            {
                return $"{FirstDigitBuffer} {OperatorBuffer} {SecondDigitBuffer} {EgualSign}";
            }
        }

        public string BufferIO
        {
            get { return bufferIO; }
            set
            {
                bufferIO = value;
                OnPropetyChanged();
            }
        }

        public string OperatorBuffer
        {
            get { return operatorBuffer; }
            set
            {
                operatorBuffer = value;
                OnPropetyChanged();
            }
        }
        public string PreviousOperatorBuffer
        {
            get { return previousOperatorBuffer; }
            set
            {
                previousOperatorBuffer = value;
                OnPropetyChanged();
            }
        }

        public string FirstDigitBuffer
        {
            get { return firstDigitBuffer; }
            set
            {
                firstDigitBuffer = value;
                OnPropetyChanged();
                OnPropetyChanged("ReminderWindow");
            }
        }

        public string SecondDigitBuffer
        {
            get { return secondDigitBuffer; }
            set
            {
                secondDigitBuffer = value;
                OnPropetyChanged();
                OnPropetyChanged("ReminderWindow");
            }
        }

        public string OperationBuffer
        {
            get { return operationBuffer; }
            set
            {
                operationBuffer = value;
                OnPropetyChanged();
                OnPropetyChanged("ReminderWindow");
            }
        }

        public string ResultBuffer
        {
            get { return resultBuffer; }
            set
            {
                resultBuffer = value;
                OnPropetyChanged();
                OnPropetyChanged("ReminderWindow");
            }
        }

        public string EgualSign
        {
            get { return egualSign; }
            set
            {
                egualSign = value;
                OnPropetyChanged();
                OnPropetyChanged("ReminderWindow");
            }
        }

        internal void GetDigit(string digit)
        {
            if (resultFlag == false)
            {
                if (digitFlag == false)
                {
                    if (BufferIO == "0")
                        BufferIO = "";
                    BufferIO += digit;

                }
                else
                {
                    BufferIO = "";
                    BufferIO += digit;
                    digitFlag = false;
                }
            }
            else
            {
                Clear();
                if (BufferIO == "0")
                    BufferIO = "";
                BufferIO += digit;
            }


        }

        internal void GetOperator(string getOperator)
        {
            OperatorBuffer = getOperator;
            digitFlag = true;
            commaFlag = false;
            if (operatorFlag == false)
            {
                FirstDigitBuffer = BufferIO;
                operatorFlag = true;
            }
            else
            {
                if (resultFlag == false)
                {
                    double wynik;
                    if (PreviousOperatorBuffer == "+")
                    {
                        SecondDigitBuffer = BufferIO;
                        wynik = Convert.ToDouble(FirstDigitBuffer) + Convert.ToDouble(SecondDigitBuffer);
                        BufferIO = Convert.ToString(wynik);
                        FirstDigitBuffer = BufferIO;
                        SecondDigitBuffer = "";
                    }
                    if (PreviousOperatorBuffer == "-")
                    {
                        SecondDigitBuffer = BufferIO;
                        wynik = Convert.ToDouble(FirstDigitBuffer) - Convert.ToDouble(SecondDigitBuffer);
                        BufferIO = Convert.ToString(wynik);
                        FirstDigitBuffer = BufferIO;
                        SecondDigitBuffer = "";
                    }
                    if (PreviousOperatorBuffer == "×")
                    {
                        SecondDigitBuffer = BufferIO;
                        wynik = Convert.ToDouble(FirstDigitBuffer) * Convert.ToDouble(SecondDigitBuffer);
                        BufferIO = Convert.ToString(wynik);
                        FirstDigitBuffer = BufferIO;
                        SecondDigitBuffer = "";
                    }
                    if (PreviousOperatorBuffer == "÷")
                    {
                        SecondDigitBuffer = BufferIO;
                        wynik = Convert.ToDouble(FirstDigitBuffer) / Convert.ToDouble(SecondDigitBuffer);
                        BufferIO = Convert.ToString(wynik);
                        FirstDigitBuffer = BufferIO;
                        SecondDigitBuffer = "";
                    }
                }
                else
                {
                    resultFlag = false;
                    FirstDigitBuffer = BufferIO;
                    SecondDigitBuffer = "";
                    EgualSign = "";
                }

            }
            PreviousOperatorBuffer = OperatorBuffer;
        }

        internal void GetComma(string comma)
        {
            if (resultFlag == false)
            {
                if (commaFlag == false)
                {
                    BufferIO += comma;
                    commaFlag = true;
                }

            }
            else
            {
                Clear();
                BufferIO += comma;
                commaFlag = true;
            }
        }

        internal void DoubleArgumentsOperation()
        {
            double result;
            if (OperatorBuffer == "+")
            {
                SecondDigitBuffer = BufferIO;
                result = Convert.ToDouble(FirstDigitBuffer) + Convert.ToDouble(SecondDigitBuffer);
                BufferIO = Convert.ToString(result);
                resultFlag = true;
                //flagaOperatora = false;
                EgualSign = "=";
            }
            if (OperatorBuffer == "-")
            {
                SecondDigitBuffer = BufferIO;
                result = Convert.ToDouble(FirstDigitBuffer) - Convert.ToDouble(SecondDigitBuffer);
                BufferIO = Convert.ToString(result);
                resultFlag = true;
                EgualSign = "=";
            }
            if (OperatorBuffer == "×")
            {
                SecondDigitBuffer = BufferIO;
                result = Convert.ToDouble(FirstDigitBuffer) * Convert.ToDouble(SecondDigitBuffer);
                BufferIO = Convert.ToString(result);
                resultFlag = true;
                EgualSign = "=";
            }
            if (OperatorBuffer == "÷")
            {
                SecondDigitBuffer = BufferIO;
                result = Convert.ToDouble(FirstDigitBuffer) / Convert.ToDouble(SecondDigitBuffer);
                BufferIO = Convert.ToString(result);
                resultFlag = true;
                EgualSign = "=";
            }
        }

        internal void ChangeSign()
        {
            if (BufferIO != "0")
                if (signFlag == false)
                {
                    BufferIO = "-" + BufferIO;
                    signFlag = true;
                }
                else
                {
                    BufferIO = BufferIO.Substring(1);
                    signFlag = false;
                }
        }

        internal void PercentageOperation()
        {
            if (FirstDigitBuffer == "" || FirstDigitBuffer == "0")
            {
                FirstDigitBuffer = "0";
            }
            else
            {
                SecondDigitBuffer = BufferIO;
                double result;
                double secondNumber;
                secondNumber = (Convert.ToDouble(SecondDigitBuffer) * Convert.ToDouble(FirstDigitBuffer)) / 100;
                if (PreviousOperatorBuffer == "+")
                {
                    result = Convert.ToDouble(FirstDigitBuffer) + secondNumber;
                    SecondDigitBuffer = Convert.ToString(secondNumber);
                    BufferIO = Convert.ToString(result);
                    resultFlag = true;
                }
                if (PreviousOperatorBuffer == "-")
                {
                    result = Convert.ToDouble(FirstDigitBuffer) + secondNumber;
                    SecondDigitBuffer = Convert.ToString(secondNumber);
                    BufferIO = Convert.ToString(result);
                    resultFlag = true;
                }
                if (PreviousOperatorBuffer == "×")
                {
                    result = Convert.ToDouble(FirstDigitBuffer) + secondNumber;
                    SecondDigitBuffer = Convert.ToString(secondNumber);
                    BufferIO = Convert.ToString(result);
                    resultFlag = true;
                }
                if (PreviousOperatorBuffer == "÷")
                {
                    result = Convert.ToDouble(FirstDigitBuffer) + secondNumber;
                    SecondDigitBuffer = Convert.ToString(secondNumber);
                    BufferIO = Convert.ToString(result);
                    resultFlag = true;
                }

            }
        }

        internal void OperatorChange(string operatorChange)
        {
            if (digitFlag == true)
            {
                OperatorBuffer = operatorChange;
                operatorFlag = false;
            }

        }

        internal void UndoSign()
        {
            BufferIO = BufferIO.Substring(0, BufferIO.Length - 1);
            if (BufferIO == "")
            {
                BufferIO = "0";
            }
        }

        internal void GetSinglaArgumentOperation(string getOperation)
        {
            SecondDigitBuffer = "";
            PreviousOperatorBuffer = "";
            EgualSign = "";
            OperatorBuffer = "";
            OperationBuffer = getOperation;
            operationFlag = true;
            FirstDigitBuffer = BufferIO;
            SingleArgumentOperation();
        }

        internal void SingleArgumentOperation()
        {
            double result;
            if (OperationBuffer == "1/x")
            {
                result = 1 / Convert.ToDouble(FirstDigitBuffer);
                BufferIO = Convert.ToString(result);
                FirstDigitBuffer = "1/(" + FirstDigitBuffer + ")";

            }
            if (OperationBuffer == "x²")
            {
                result = Convert.ToDouble(FirstDigitBuffer) * Convert.ToDouble(FirstDigitBuffer);
                BufferIO = Convert.ToString(result);
                FirstDigitBuffer = "sqrt(" + FirstDigitBuffer + ")";
            }
            if (OperationBuffer == "√x")
            {
                result = Math.Sqrt(Convert.ToDouble(FirstDigitBuffer));
                BufferIO = Convert.ToString(result);
                FirstDigitBuffer = "√(" + FirstDigitBuffer + ")";
            }
        }

        internal void Clear()
        {
            BufferIO = "0";
            OperatorBuffer = "";
            PreviousOperatorBuffer = "";
            FirstDigitBuffer = "";
            SecondDigitBuffer = "";
            OperationBuffer = "";
            ResultBuffer = "";
            EgualSign = "";
            operatorFlag = false;
            BufferIOflag = false;
            resultFlag = false;
            digitFlag = false;
            commaFlag = false;
            signFlag = false;
            operationFlag = false;
        }
    }
}
