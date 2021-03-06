﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GVBASIC_Compiler.Compiler;
using GVBASIC_Compiler;

namespace CompilerUnitTest
{
    [TestClass]
    public class RunningTest
    {
        [TestMethod]
        public void AssignVar()
        {
            string sourceCode =
                "10 A = 1                               \n" +
                "20 B% = 2                              \n" +
                "30 C$ = \"HJB\"                        \n" +
                "40 D% = 17.1                           \n" +
                "50 EF% = 20.1                          \n" +
                "60 PRINT EF%                           \n" +
                "70 PRINT A                             \n" +
                "80 PRINT C$                            \n" +
                "90 PRINT A + B% + C$ + D%              \n" +
                "100 LET V = 176                        \n" +
                "110 PRINT V                            \n";

            // 20
            // 1
            // HJB
            // 3HJB17
            // 176

            string result =
                "20\n" +
                "1\n" +
                "HJB\n" +
                "3HJB17\n" +
                "176\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void ReadData()
        {
            string sourceCode =
                "10 DATA 1,23,2.6,19.5                     \n" +
                "20 READ A,T,F% , R%                       \n" +
                "30 PRINT T,A,F%, R%                       \n";

            // 23
            // 1
            // 2
            // 19

            string result =
                "23" + "\n" +
                "1" + "\n" +
                "2" + "\n" +
                "19" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void IfElse()
        {
            string sourceCode =
                "10 A = 1: B = 7                            \n" +
                "20 IF A > 0 THEN PRINT \"A>0\"             \n" +
                "30 IF B < 5 THEN PRINT \"B<5\"             \n" +
                "40 C = 110                                 \n" +
                "50 IF C < 20 GOTO 70 ELSE PRINT \"CCC\"    \n" +
                "60 PRINT \"THIS IS 60\"                    \n" +
                "70 PRINT \"THIS IS 70\"                    \n" +
                "80 END                                     \n" +
                "90 PRINT 117                               \n" +
                "100 A=5                                    \n" +
                "110 IF A>9 THEN PRINT 77:PRINT 99          \n";

            // A>0
            // CCC
            // THIS IS 60
            // THIS IS 70

            string result =
                "A>0" + "\n" +
                "CCC" + "\n" +
                "THIS IS 60" + "\n" +
                "THIS IS 70" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void ForNext()
        {
            string sourceCode =
                "10 FOR I=1 TO 5                            \n" +
                "20 FOR J=I TO 3                            \n" +
                "30 PRINT J;                                \n" +
                "40 NEXT                                    \n" +
                "45 PRINT \";\"                             \n" +
                "50 NEXT                                    \n" +
                "60 PRINT \"->\":FOR I=1 TO 3               \n" +
                "70 PRINT I                                 \n" +
                "80 NEXT I                                  \n";

            // 123;
            // 23;
            // 3;
            // 4;
            // 5;
            // ->
            // 1
            // 2
            // 3

            string result =
                "123;" + "\n" +
                "23;" + "\n" +
                "3;" + "\n" +
                "4;" + "\n" +
                "5;" + "\n" +
                "->" + "\n" +
                "1" + "\n" +
                "2" + "\n" +
                "3" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void GOTO()
        {
            string sourceCode =
                "10 A = 1                            \n" +
                "20 PRINT A                          \n" +
                "30 A = A + 1                        \n" +
                "40 IF A<5 GOTO 20                   \n";

            // 1
            // 2
            // 3
            // 4

            string result =
                "1" + "\n" +
                "2" + "\n" +
                "3" + "\n" +
                "4" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void WhileWend()
        {
            string sourceCode =
                "10 A = 3                            \n" +
                "20 WHILE A > 0                      \n" +
                "30 PRINT A                          \n" +
                "40 A=A-1                            \n" +
                "50 B=3                              \n" +
                "60 WHILE B<6                        \n" +
                "70 PRINT B;                         \n" +
                "80 B=B+1                            \n" +
                "90 WEND                             \n" +
                "100 WEND                            \n" +
                "110 WHILE 0                         \n" +
                "120 WHILE 1                         \n" +
                "130 PRINT 111                       \n" +
                "140 WEND                            \n" +
                "150 PRINT 222                       \n" +
                "160 WEND                            ";

            // 3
            // 3452
            // 3451
            // 345

            string result =
                "3" + "\n" +
                "3452" + "\n" +
                "3451" + "\n" +
                "345";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void OnGoto()
        {
            string sourceCode =
                "10 ON ABS(3) GOTO 20,30,40,50      \n" +
                "20 PRINT 222                       \n" +
                "30 PRINT 333                       \n" +
                "40 PRINT 444                       \n" +
                "50 PRINT 555                       \n";

            // 444
            // 555

            string result =
                "444" + "\n" +
                "555" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void GoSub()
        {
            string sourceCode =
                "10 PRINT \"TEST GOSUB\"            \n" +
                "20 FOR I=1 TO 3                    \n" +
                "30 PRINT I                         \n" +
                "40 GOSUB 70                        \n" +
                "50 NEXT                            \n" +
                "60 END                             \n" +
                "70 PRINT \"sub\"                   \n" +
                "80 RETURN                          \n";

            // TEST GOSUB
            // 1
            // sub
            // 2
            // sub
            // 3
            // sub

            string result =
                "TEST GOSUB"        + "\n" +
                "1"                 + "\n" +
                "sub"               + "\n" +
                "2"                 + "\n" +
                "sub"               + "\n" +
                "3"                 + "\n" +
                "sub"               + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void DefFn()
        {
            string code =
                "10 X=17                        \n" +
                "20 DEF FN AA(X)=X+ABS(X)       \n" +
                "30 DEF FN BB(X)=X+FN AA(X)     \n" +
                "40 PRINT FN AA(2)              \n" +
                "50 PRINT FN BB(7)              \n" +
                "60 AA=7                        \n" +
                "70 PRINT AA                    \n" +
                "80 PRINT FN AA(AA)             \n" +
                "90 PRINT AA                    \n" +
                "100 X=66                       \n" +
                "100 PRINT X                    \n" +
                "110 PRINT FN AA(19)            \n" +
                "120 PRINT X                    \n" +
                "130 PRINT FN AA( FN BB(17))    \n";

            // 4
            // 21
            // 7
            // 14
            // 7
            // 66
            // 38
            // 66
            // 102

            string result =
                "4"         + "\n" +
                "21"        + "\n" +
                "7"         + "\n" +
                "14"        + "\n" +
                "7"         + "\n" +
                "66"        + "\n" +
                "38"        + "\n" +
                "66"        + "\n" +
                "102"       + "\n";

            TestHelper.TestProgram(code, result);
        }

        [TestMethod]
        public void DimArray()
        {
            string code =
                "10 DIM A(10)                       \n" +
                "20 A(1) = 17                       \n" +
                "30 PRINT A(1)                      \n" +
                "40 B(2,7) = 888                    \n" +
                "50 PRINT B(2,7) + A(1)             \n" +
                "60 FOR I=1 TO 7                    \n" +
                "70 FOR J=1 TO 5                    \n" +
                "80 F$(I,J) = I + \",\" + J         \n" +
                "90 NEXT                            \n" +
                "100 NEXT                           \n" +
                "110 PRINT F$(3,4)                  \n";

            // 17
            // 905
            // 3,4

            string result =
                "17"            + "\n" +
                "905"           + "\n" +
                "3,4"           + "\n";

            TestHelper.TestProgram(code, result);
        }

        [TestMethod]
        public void SwapVar()
        {
            string code =
                "10 A=7:B=9                         \n" +
                "20 SWAP A,B                        \n" +
                "30 PRINT A,B                       \n" +
                "40 C(2,3) = 77                     \n" +
                "50 I=2                             \n" +
                "60 SWAP A, C(I,I+1)                \n" +
                "70 PRINT C(2,3),A                  \n";

            // 9
            // 7
            // 9
            // 77

            string result =
                "9"             + "\n" +
                "7"             + "\n" +
                "9"             + "\n" +
                "77"            + "\n";

            TestHelper.TestProgram(code, result);
        }

        [TestMethod]
        public void Inkey()
        {
            string code = 
                "10 A$ = INKEY$                     \n" +
                "20 PRINT A$                        \n";

            string result = 
                "";

            TestHelper.TestProgram(code, result );
        }

        [TestMethod]
        public void Power()
        {
            string code =
                "10 A=2^3                           \n" +
                "20 PRINT A                         \n" +
                "30 PRINT 2^0.5                     \n" +
                "40 PRINT 7+6^3-2                   \n";

            string result =
                "8"                                     + "\n" +
                ((float)Math.Pow(2,0.5)).ToString()     + "\n" +
                "221"                                   + "\n";

            TestHelper.TestProgram(code, result);
        }

        [TestMethod]
        public void MathOperator()
        {
            string code =
                "10 PRINT 12+7*3-6/4                        \n" +
                "20 PRINT 7/2-6*1                           \n" +
                "30 C=1-(7.2*3+8-6/5)+7-(7*(2-4)+44/3-2)    \n" +
                "40 PRINT C^2                               \n";

            string result =
                "31.5" + "\n" +
                "-2.5" + "\n" +
                "363.5378" + "\n";

            TestHelper.TestProgram(code, result);
        }

        [TestMethod]
        public void BoolLogic()
        {
            string code =
                "10 A= 1                                    \n" +
                "20 B= 2                                    \n" +
                "30 R= 3                                    \n" +
                "40 C = A>B AND R<A                         \n" +
                "50 PRINT C                                 \n" +
                "60 PRINT A<B OR R<A                        \n";

            string result =
                "0" + "\n" +
                "1" + "\n";

            TestHelper.TestProgram(code, result);
        }
    }
}
