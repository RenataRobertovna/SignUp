﻿using System;

namespace PasswordCheck
{
    public delegate void Message(string messagr);

    public class Password
    {
        public event Message Error;
        public event Message Success;

        private readonly int length;

        private readonly string symbols1;
        private readonly string symbols2;
        private readonly string symbols3;
        private readonly string symbols4;
        
        private readonly string symbols;

        public Password()
        {
            length = 8;
            symbols1 = "QWERTYUIOPASDFGHJKLZXCVBNM";
            symbols2 = "qwertyuiopasdfghjklzxcvbnm";
            symbols3 = "!@#$%^&*+-:;,._";
            symbols4 = "0123456789";

            symbols = symbols1 + symbols2 + symbols3 + symbols4;
        }

        public bool MinLength(string password)
        {
            if (password.Length < length)
            {
                Error?.Invoke($"Пароль содержит меньше {length} символов");
                return false;
            }
            else
            {
                Success?.Invoke("Пароль имеет достаточное количество символов");
                return true;
            }
        }

        public bool CheckSymbols(string password)
        {
            int pass_check1 = password.IndexOfAny(symbols1.ToCharArray());
            int pass_check2 = password.IndexOfAny(symbols2.ToCharArray());
            int pass_check3 = password.IndexOfAny(symbols3.ToCharArray());
            int pass_check4 = password.IndexOfAny(symbols4.ToCharArray());

            if (pass_check1 == -1 || pass_check2 == -1 || pass_check3 == -1 || pass_check4 == -1)
            {
                Error?.Invoke("Пароль не соответствует минимальным требованиям");
                return false;
            }
            else
            {
                Success?.Invoke("Пароль соответстует минимальным требованиям");
                return true;
            }
        }

        public bool CheckAlphabet(string password)
        {
            foreach(var symbol in password)
            {
                if (!symbols.Contains(symbol))
                {
                    Error?.Invoke("Пароль содержит зпрещённые символы");
                    return false;
                }
            }
            Success?.Invoke("Пароль не содержит запрещённые символы");
            return true;
        }
    }
}
