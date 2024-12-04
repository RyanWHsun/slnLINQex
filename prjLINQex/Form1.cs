using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLINQex
{
    public partial class Form1 : Form
    {
        public delegate string D(string p);
        public delegate bool Dtest(int num);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            callM1();
            callM2();
            callM3();
            callM4(str => "hello,"+str);

            int result = MyFirstOrDefault(x =>  x % 3 == 0);
            MessageBox.Show(result.ToString());
        }
        

        public string m1(string str)
        {
            return "hello,"+str;
        }
        public void callM1()
        {
            D d = new D(this.m1);
            MessageBox.Show(d("第一代"));
        }

        public void callM2()
        {
            D d = delegate (string str)
            {
                return "hello," + str;
            };
            MessageBox.Show(d("第二代"));
        }
        public void callM3()
        {
            D d = str => "hello," + str;
            MessageBox.Show(d("第三代"));
        }
        public void callM4(D d)
        {
            MessageBox.Show(d("第三代2"));
        }

        List<int> numbers = new List<int> { 1, 9, 4, 5, 3 };

        //自訂義Dtest 可改為系統內建 Func<int, bool> 
        public int MyFirstOrDefault(Dtest delegateName)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (delegateName(numbers[i]))
                {
                    return numbers[i];
                }
            }
            return -1;
        }
    }
}
