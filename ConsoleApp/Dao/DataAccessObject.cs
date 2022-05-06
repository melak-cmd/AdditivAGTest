namespace ConsoleApp.Dao
{
    public abstract class DataAccessObject<T>
    {
        public void Run()
        {
            Connect();
            Select();
            Process();
            Disconnect();
        }

        public virtual void Disconnect()
        {
        }

        public abstract void Process();
        public abstract T Get(int id);

        public abstract void Select();

        public virtual void Connect()
        {
        }
    }
}