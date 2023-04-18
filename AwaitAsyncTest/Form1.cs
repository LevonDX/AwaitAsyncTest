using System.Runtime.CompilerServices;

namespace AwaitAsyncTest
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        //void OnCalcCompleted()
        //{
        //    MessageBox.Show("Task completed");
        //}

        long F()
        {
            long result = 0;
            for (int i = 0; i <= 1E09; i++)
            {
                result += i;
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task<long> t = Task.Run(F);

            TaskAwaiter<long> awaiter = t.GetAwaiter();

            //awaiter.OnCompleted(OnCalcCompleted);

            awaiter.OnCompleted(() =>
            {
                try
                {
                    long result = t.Result;

                    MessageBox.Show(result.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }
    }
}